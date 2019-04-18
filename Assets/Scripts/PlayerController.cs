using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;


public class PlayerController : MonoBehaviour
{


    //UI text aspects
    public GameObject GameOverUI;
    public Text relevantitems;
    public Text irrelevantItems;
    public Sprite openChest;
    public GameObject[] sceneHCHItems;
    public GameObject itemMismatchUI;
    public Image irrelevantImage;
    public GameObject gameCompleteUI;

    //Inventory script
    InventoryManager inventoryManager;
    int inventoryCount = 0;
    public GameObject tChest;
    public int inventoryLimit;
    public GameObject collectable = null;
    string collectableName;
    public CanvasGroup cg;

    // Analytics
    Vector3 previousPos;
    Vector3 startPos;

    LevelManager lm;
    Logger logger;

    //DB entries
    public string level1Completion, level2Completion, level3Completion;
    public string gameCompletionStatus;

    public int curHealth = 1;
    //public int maxHealth = 5;

    // General physics variables
    public float maxSpeed = 6.9f;
    public float jumpForce = 1000.0f;
    bool facingRight = true;
    bool sliding;
    public Rigidbody2D rb;
    public BoxCollider2D slidingCollider;
    BoxCollider2D myCol;
    bool canMove;
    bool canDie;
    bool jumpPressed;
    string[] killers;
    int deathCount;

    // Variables for checking for ground
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.4f;
    public LayerMask whatIsGround;

    //public gameMaster gm;
    AudioSource audioFootstep;
    AudioSource audioCoin;
    AudioSource audioJump;

    // Knockback variables
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public float delay = 3;


    private int level = 1;
    private Text levelText;
    private GameObject levelImage;
    private SpriteRenderer sr;
    public Animator anim;

    GameObject coinTextObj;
    Text coinText;
    int coins;
    int win = 0;

    float move;

    int enterOnce = 0;

    DynamoDB.Dynode dynode;
    ItemsGenerator itemsgenerator;

    bool startOver = true;
    // Use this for initialization
    void Start()
    {
        GamePersistentManager.Instance.startPosition = transform.position;
        inventoryManager = GetComponent<InventoryManager>();
        itemsgenerator = GameObject.FindGameObjectWithTag("ItemsMaster").GetComponent<ItemsGenerator>();
        inventoryLimit = GamePersistentManager.Instance.sceneItemsManager[SceneManager.GetActiveScene().buildIndex].itemsInScene;
        Debug.Log("Inventyory LIMIT" + inventoryLimit);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //myCol = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        logger = GetComponent<Logger>();


        killers = new string[] { "Killer", "RisingSpikes", "Spikes", "Bullet", "Ninja", "Lava", "Pit" };
        //levelImage.SetActive(false);

        curHealth = 1;
        //gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();

        startPos = transform.position;

        lm = GameObject.FindObjectOfType<LevelManager>();

        //Debug.Log("Start: " + startPos);

        canMove = true;
        canDie = true;
        jumpPressed = false;
        //Debug.Log("Can move in start: " + canMove);

        deathCount = 0;

        coins = 0;
        coinTextObj = GameObject.FindGameObjectWithTag("CoinText");
        if (DataManager.mode != 3)
        {
            // coinText = coinTextObj.GetComponent<Text>();
            // coinText.text = "Coins: " + coins + "/" + DataManager.NCOINS; //+ "\tLevel: " + (SceneManager.GetActiveScene().buildIndex + 1) + "/" + (SceneManager.sceneCountInBuildSettings - 1); //+ " ID: " + logger.dynode.player_id;
        }

        //reload all collected items if the player is alive
        if (GamePersistentManager.Instance.currentLives > -1)
        {

            Time.timeScale = 1;
            inventoryManager.DisplayHeart(GamePersistentManager.Instance.currentLives);
            FillInventoryDuringStart();
        }
    }

    void FixedUpdate()
    {
        // Check if grounded
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        grounded = Physics2D.IsTouchingLayers(groundCheck.GetComponent<Collider2D>(), whatIsGround);
        anim.SetBool("Ground", grounded);


        if (canMove)
        {
            anim.SetFloat("vSpeed", rb.velocity.y);

            // Horizontal motion
            move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move));
        }

        // Knockback and motion stuff
        if (knockbackCount <= 0) // You can't move while getting knocked back.
        {
            /*
            // Sliding stuff
            float slideAccell;
            /*if (Input.GetKey(KeyCode.S) && grounded && Mathf.Abs(rb.velocity.x) > 3.0f)
            {
                sliding = true;
                slideAccell = 2.0f;
                slidingCollider.enabled = true;
                myCol.enabled = false;
            }
            //else
            {
                sliding = false;
                slideAccell = 1.0f;
                slidingCollider.enabled = false;
                myCol.enabled = true;
            }
            anim.SetBool("Sliding", sliding);
           */
            // MOTION
            if (canMove)
                rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        }
        else
        {
            if (knockFromRight)
                rb.velocity = new Vector2(-knockback, knockback);
            else
                rb.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }

        // Animation flips
        if (move > 0 && !facingRight && canMove)
            Flip();
        else if (move < 0 && facingRight && canMove)
            Flip();

        // Jumping
        if (grounded && jumpPressed && canMove)
        {

            //Debug.Log("Jumping called");
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            grounded = false;
            //audioJump.Play();
            jumpPressed = false;
        }
    }


    void Update()
    {

        if (GamePersistentManager.Instance.inventoryCount == inventoryLimit)
        {
            tChest.GetComponent<SpriteRenderer>().sprite = openChest;
        }


        if (GamePersistentManager.Instance.currentLives < 0)
        {
            gameCompletionStatus = "Incomplete";
            logger.sendGameCompletionLoggingtoDB = true;
            GameOverUI.SetActive(true);
            relevantitems.text = "Relevant Items Collected: " + GamePersistentManager.Instance.relevantItemsCollected;
            irrelevantItems.text = "Irrelevant Items Collected: " + GamePersistentManager.Instance.irrelevantItemsCollected;
            Time.timeScale = 0;
        }


        // Check if dead
        if (curHealth <= 0 && canDie)
        {
            lm.Die();
        }

        // Check for max health
        /**if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }*/

        if (Input.GetKeyDown(KeyCode.UpArrow) && !jumpPressed && grounded)
        {
            jumpPressed = true;
        }

        DataManager.play_time += Time.deltaTime;
        //coinText.text = "Coins: " + coins + "/" + DataManager.NCOINS + "Time: " + DataManager.play_time + " Level: " + (SceneManager.GetActiveScene().buildIndex + 1) + "/" + (SceneManager.sceneCountInBuildSettings - 1); //+ " ID: " + logger.dynode.player_id;
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public bool oneHit = true;
    private void OnTriggerExit2D(Collider2D collision)
    {
        enterOnce = 0;
    }


    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        inventoryManager.DisplayHeart(GamePersistentManager.Instance.currentLives);
        StartOverAgain();

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //if (col == this.gameObject.GetComponent<Collider2D>()) { 
        if (col.CompareTag("HCGItem"))//.gameObject.tag == "HCGItem" && gameObject.tag =="Player")
        {


            Debug.Log(col.gameObject.tag + gameObject.tag);
            string objectName = col.gameObject.name;
            objectName = objectName.Replace("(Clone)", "");


            if (itemsgenerator.itemsForCurrentlocation.Contains(objectName))
            {

                inventoryManager.AddItem(col.gameObject);
                GamePersistentManager.Instance.inventoryItems.Add(objectName);
                GamePersistentManager.Instance.inventoryCount += 1;
                GamePersistentManager.Instance.relevantItemsCollected += 1;

                if (GamePersistentManager.Instance.inventoryCount > inventoryLimit)
                {
                    col.gameObject.SetActive(false);
                }


            }

            if (!itemsgenerator.itemsForCurrentlocation.Contains(objectName))

            {
                logger.sendLevelStatustoDB = true;
                logger.dynode.run_id = logger.dynode.generateID();
                logger.dynode.run_count++;

                logger.dynode.action_count = 0;
                //Die and restart
                //Restart level
                // Reduce one heart
                col.gameObject.SetActive(false);
                GamePersistentManager.Instance.currentLives -= 1;
                GamePersistentManager.Instance.irrelevantItemsCollected += 1;
                inventoryManager.DisplayHeart(GamePersistentManager.Instance.currentLives);


                if (GamePersistentManager.Instance.currentLives > 0)
                {
                    itemMismatchUI.SetActive(true);
                    irrelevantImage.overrideSprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
                    Time.timeScale = 0;
                }


            }

        }

        if (col.CompareTag("Spikes"))
        {
            if (startOver)
            {
                startOver = false;
                logger.sendLevelStatustoDB = true;
                logger.dynode.run_id = logger.dynode.generateID();
                logger.dynode.run_count++;

                logger.dynode.action_count = 0;
                //Debug.Log(col.gameObject.tag + gameObject.tag);
                //Debug.Log("Spikes trap");

                GamePersistentManager.Instance.currentLives -= 1;

                //Debug.Log(GamePersistentManager.Instance.currentLives);
                StartCoroutine(ResetPlayer());
                //inventoryManager.DisplayHeart(GamePersistentManager.Instance.currentLives);
                //StartOverAgain();

            }

        }

        if (col.CompareTag("RisingSpikes"))//col.gameObject.tag == "RisingSpikes" && gameObject.tag == "Player")
        {
            logger.sendLevelStatustoDB = true;
            logger.dynode.run_id = logger.dynode.generateID();
            logger.dynode.run_count++;

            logger.dynode.action_count = 0;

            //Debug.Log(col.gameObject.tag + gameObject.tag);
            //Debug.Log("Spikes trap");

            GamePersistentManager.Instance.currentLives -= 1;

            //Debug.Log(GamePersistentManager.Instance.currentLives);
            //StartCoroutine(ResetPlayer());
            inventoryManager.DisplayHeart(GamePersistentManager.Instance.currentLives);
            StartOverAgain();


        }

        if (col.CompareTag("Chest"))
        {
            //Debug.Log("Coins: " + coins);
            // logger.LogWin(coins);
            canMove = false;
            canDie = false;

            if (GamePersistentManager.Instance.inventoryCount == inventoryLimit)
            {
                //IncrementRunID and action count to 0
                //logger.dynode.run_id = logger.dynode.generateID();
                //logger.dynode.run_count++;

                //logger.dynode.action_count = 0;
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    level1Completion = "Complete";
                    level2Completion = "Incomplete";
                    level3Completion = "Incomplete";
                }

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    level1Completion = "Complete";
                    level2Completion = "Complete";
                    level3Completion = "Incomplete";
                }

                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    level1Completion = "Complete";
                    level2Completion = "Complete";
                    level3Completion = "Complete";
                }
                logger.sendLevelCompletiontoDB = true;
                StartCoroutine(FadeOut());
            }


        }

        //if (col.gameObject.tag == "Chest")
        //{
        //    canMove = false;
        //    canDie = false;

        //    if (GamePersistentManager.Instance.inventoryCount == inventoryLimit)
        //        StartCoroutine(FadeOut());

        //}

        //if ((col.CompareTag("Enemy") || col.CompareTag("Killer")) && canDie)
        //if ((System.Array.IndexOf(killers, col.tag) > -1) && canDie)
        //{

        //    jumpPressed = false;
        //    Debug.Log("Killed by: " + col.tag);
        //    deathCount++;
        //    float pos_x = transform.position.x;
        //    float pos_y = transform.position.y;
        //    Debug.Log("Tag: " + col.tag);
        //    lm.Die();
        //    logger.LogDeath(col.tag, deathCount, pos_x, pos_y);
        //}
    }


    public void Damage(int dmg)
    {
        curHealth -= dmg;
        // anim.Play("FlashRed");
    }
    public void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator FadeOut()
    {
        Debug.Log("Inside fade out");
        rb.velocity = Vector3.zero;
        anim.SetFloat("Speed", 0f);
        anim.SetFloat("vSpeed", 0f);
        yield return StartCoroutine(lm.FadeCo(cg, cg.alpha, 1));
        //inventoryLimit = GetSceneIndex(SceneManager.GetActiveScene().buildIndex + 1);
        GamePersistentManager.Instance.currentLives = 3;
        GamePersistentManager.Instance.inventoryItems.Clear();
        GamePersistentManager.Instance.inventoryCount = 0;
        if (SceneManager.GetActiveScene().buildIndex + 1 <= 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                gameCompletionStatus = "Complete";
                logger.sendGameCompletionLoggingtoDB = true;
                gameCompleteUI.SetActive(true);
            }
        }
    }


    void Footstep()
    {
        //audioFootstep.Play();
    }

    /*IEnumerator Wait(float waitTime)
    {
        float fadeTime = GameObject.Find("GameMaster").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }*/

    void FillInventoryDuringStart()
    {
        //Clear the inventory
        inventoryManager.ClearInventory();

        //Debug.Log(GamePersistentManager.Instance.inventoryItems.Count);
        //Grab the items from persistent manager

        if (GamePersistentManager.Instance.inventoryItems.Count > 0)
        {
            //GameObject myObject;
            for (int i = 0; i < GamePersistentManager.Instance.inventoryItems.Count; i++)
            {
                for (int j = 0; j < GamePersistentManager.Instance.itemsList.Count; j++)
                {
                    if (GamePersistentManager.Instance.inventoryItems[i] == GamePersistentManager.Instance.itemsList[j].gameObject.name)
                    {
                        inventoryManager.AddItem(GamePersistentManager.Instance.itemsList[j].gameObject);
                    }
                }
            }
        }
    }

    public void StartOverAgain()
    {
        transform.position = GamePersistentManager.Instance.startPosition;
        Time.timeScale = 1;
        itemMismatchUI.SetActive(false);
        startOver = true;
    }

}
