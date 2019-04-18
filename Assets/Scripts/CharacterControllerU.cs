using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class CharacterControllerU : MonoBehaviour
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

    //DB entries
    public string level1Completion, level2Completion, level3Completion;
    public string gameCompletionStatus;

    //Inventory script
    InventoryManager inventoryManager;
    int inventoryCount = 0;
    public GameObject tChest;
    public int inventoryLimit;
    public GameObject collectable = null;
    string collectableName;
    public CanvasGroup cg;
    LevelManager lm;


    Rigidbody2D rigidBody;
    public float movementSpeed;
    bool facingRight;
    Animator anim;

    public Transform[] groundPoints;
    public float groundRadius;
    public LayerMask whatIsGround;
    bool isGrounded;
    bool jumping;
    public float jumpForce;

    BoxCollider2D myCol;
    bool canMove;
    bool canDie;
    Vector3 startPos;
    ItemsGenerator itemsgenerator;

    Logger logger;
    // Use this for initialization
    void Start()
    {
        logger = this.gameObject.GetComponent<Logger>();
        facingRight = true;
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GamePersistentManager.Instance.startPosition = transform.position;
        inventoryManager = GetComponent<InventoryManager>();
        itemsgenerator = GameObject.FindGameObjectWithTag("ItemsMaster").GetComponent<ItemsGenerator>();
        inventoryLimit = GamePersistentManager.Instance.sceneItemsManager[SceneManager.GetActiveScene().buildIndex].itemsInScene;
        startPos = transform.position;

        lm = GameObject.FindObjectOfType<LevelManager>();
        canMove = true;
        canDie = true;

        if (GamePersistentManager.Instance.currentLives > -1)
        {

            Time.timeScale = 1;
            inventoryManager.DisplayHeart(GamePersistentManager.Instance.currentLives);
            FillInventoryDuringStart();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = IsPlayerOnGround();
        HandlePlayerMovement(horizontal);
        Flip(horizontal);
        ManageAnimationLayerWeights();
        ResetValues();
    }

    private void Update()
    {

        GatherPlayerInput();
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



    }

    void HandlePlayerMovement(float horizontalAxisValue)
    {
        if (isGrounded && jumping)
        {
            isGrounded = false;
            rigidBody.AddForce(new Vector2(0, jumpForce));
            anim.SetTrigger("jump");
        }

        if(rigidBody.velocity.y < 0)
        {
            anim.SetBool("landing", true);
        }

        rigidBody.velocity = new Vector2(horizontalAxisValue * movementSpeed, rigidBody.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontalAxisValue));
    }

    void GatherPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumping = true;

        }
    }

    void Flip(float horizontal)
    {

        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    bool IsPlayerOnGround()
    {
        if (rigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] groundColliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < groundColliders.Length; i++)
                {
                    if (groundColliders[i].gameObject != gameObject)
                    {
                        anim.ResetTrigger("jump");
                        anim.SetBool("landing", false);
                        return true;
                    }
                }
            }
        }
        return false;

    }

    void ResetValues()
    {
        jumping = false;
    }

    void ManageAnimationLayerWeights()
    {
        if (!isGrounded)
        {
            anim.SetLayerWeight(1,1);
        }else
        {
            anim.SetLayerWeight(1, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //Save HCG Item

        if (col.CompareTag("HCGItem"))//.gameObject.tag == "HCGItem" && gameObject.tag =="Player")
        {

            oneHit = false;
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

                //IncrementRunID and action count to 0
                logger.sendLevelStatustoDB = true;
                logger.dynode.run_id = logger.dynode.generateID();
                logger.dynode.run_count++;

                logger.dynode.action_count = 0;

            }

        }


        if (col.CompareTag("Spikes"))
        {
            Debug.Log(col.gameObject.tag + gameObject.tag);
            Debug.Log("Spikes trap");

            GamePersistentManager.Instance.currentLives -= 1;

            //Debug.Log(GamePersistentManager.Instance.currentLives);
            inventoryManager.DisplayHeart(GamePersistentManager.Instance.currentLives);
            StartOverAgain();
            //Die();
            //IncrementRunID and action count to 0
            logger.sendLevelStatustoDB = true;
            logger.dynode.run_id = logger.dynode.generateID();
            logger.dynode.run_count++;

            logger.dynode.action_count = 0;
        }

        if (col.CompareTag("RisingSpikes"))//col.gameObject.tag == "RisingSpikes" && gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.tag + gameObject.tag);
            Debug.Log("Spikes trap");

            GamePersistentManager.Instance.currentLives -= 1;

            //Debug.Log(GamePersistentManager.Instance.currentLives);
            inventoryManager.DisplayHeart(GamePersistentManager.Instance.currentLives);
            StartOverAgain();
            //Die();

            //IncrementRunID and action count to 0
            logger.sendLevelStatustoDB = true;
            logger.dynode.run_id = logger.dynode.generateID();
            logger.dynode.run_count++;

            logger.dynode.action_count = 0;
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
                if(SceneManager.GetActiveScene().buildIndex == 0)
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


    }

    public bool oneHit = true;
    private void OnTriggerExit2D(Collider2D collision)
    {
        oneHit = true;
    }

    public void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public IEnumerator FadeOut()
    {
        Debug.Log("Inside fade out");
        rigidBody.velocity = Vector3.zero;
        anim.SetFloat("Speed", 0f);
        anim.SetFloat("vSpeed", 0f);
        yield return StartCoroutine(lm.FadeCo(cg, cg.alpha, 1));
        //inventoryLimit = GetSceneIndex(SceneManager.GetActiveScene().buildIndex + 1);
        GamePersistentManager.Instance.currentLives = 3;
        GamePersistentManager.Instance.inventoryItems.Clear();
        GamePersistentManager.Instance.inventoryCount = 0;
        if (SceneManager.GetActiveScene().buildIndex + 1 <= 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
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
    }
}
