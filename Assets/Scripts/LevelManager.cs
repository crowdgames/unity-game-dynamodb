using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    /*
    private static Random random = new Random();
    public static bool randomized = true;
    private static bool created = false;
    public static List<int> levelOrder;
    */

    public CanvasGroup cg;
    PlayerController player;
    Logger log;
    Vector3 startPos;
    Fade fadePanel;
    public GameObject deathEffect;
    public GameObject coin;
    GameObject coinTextObj;

    void Start()
    {

        Debug.Log("inside level manager start");
        player = GameObject.FindObjectOfType<PlayerController>();
        //log = player.GetComponent<Logger>();
        fadePanel = GameObject.FindObjectOfType<Fade>();
        //startPos = player.transform.position;
        coinTextObj = GameObject.FindGameObjectWithTag("CoinText");
        
        if(DataManager.mode == 3)
        {
            //No coins
            //coinTextObj.SetActive(false);
            //Debug.Log("No coins " + DataManager.mode);
            //DisableCoins();
        }
        else
        {
            Debug.Log("Mode " + DataManager.mode);
            //Designer coins (==0) or Path coins (==1) or random coins (==2)
            //coinTextObj.SetActive(true);
            //GenerateCoins(DataManager.mode);
        }
        
    }

    public void DisableCoins()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject c in coins)
        {
            c.SetActive(false);
            Debug.Log("making coin inactive");
        }
    }

    public void GenerateCoins(int mode)
    {
        Debug.Log("Inside generate coins with mode " + mode);
        if (mode != 0 || mode != 3)
        {
            List<Vector2> pos = new List<Vector2>();
            string name = SceneManager.GetActiveScene().name;
            string path = "Coins/";
            path += mode == 1 ? "out_" + name + "_path" : "out_" + name + "_randall";
            Debug.Log(path);
            TextAsset coinData = Resources.Load<TextAsset>(path);
            //Debug.Log(coinData.text);
            string[] lines = coinData.text.Split('\n');
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string line = lines[i];
                //Debug.Log("Line: " + line);
                float x = float.Parse(line.Split(',')[0]);
                float y = float.Parse(line.Split(',')[1]);
                pos.Add(new Vector2(x, y));
                //Debug.Log("x: " + x + "y: " + y);
            }
            if (mode == 1)   // Path
            {
                Debug.Log("Inside mode 1");
                /*
                GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
                foreach (GameObject c in coins)
                {
                    c.SetActive(false);
                    Debug.Log("making coin inactive");
                }
                */
                DisableCoins();
                foreach (Vector2 p in pos)
                {
                    Instantiate(coin, p, Quaternion.identity);
                    Debug.Log("instantiating path coin");
                }
            }
            else if (mode == 2)            //Randall
            {
                Debug.Log("Inside mode 2");
                /*
                GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
                foreach (GameObject c in coins)
                {
                    c.SetActive(false);
                    Debug.Log("making coin inactive");
                }
                */
                DisableCoins();

                for (int i = 0; i < DataManager.NCOINS; i++)
                {
                    int index = Random.Range(0, pos.Count);
                    Instantiate(coin, pos[index], Quaternion.identity);
                    Debug.Log("instantiating random coin");
                    pos.RemoveAt(index);
                }
            }
        }
        /*
        else if(mode == 3)  // No coins
        {
            Debug.Log("Inside mode 3");
            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
            foreach (GameObject c in coins)
                c.SetActive(false);
            Debug.Log("Deactivated all coins");
        } */
    }
    
    public void Die()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Inside die...");
        StartCoroutine("Respawn");
        Debug.Log("After respawn");
    }

    IEnumerator Respawn()
    {
        Debug.Log("Inside respawn...");
        Debug.Log(player.transform.position);
        Instantiate(deathEffect, player.transform.position, player.transform.rotation);
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        player.transform.position = startPos;
        player.gameObject.SetActive(true);
        Debug.Log("Active: " + player.gameObject.activeSelf);
        Debug.Log("Set to true" + player.transform.position);
        log.logging = true;
    }

    public IEnumerator FadeOut()
    {
        Debug.Log("Inside fade out");
        player.rb.velocity = Vector3.zero;
        player.anim.SetFloat("Speed", 0f);
        player.anim.SetFloat("vSpeed", 0f);
        yield return StartCoroutine(FadeCo(cg, cg.alpha, 1));
  
        //Invoke("LoadNextLevel",3f);
        //Randomizer.LoadNextLevel();
        //Debug.Log("Exiting fade out");
    }

    public IEnumerator FadeCo(CanvasGroup cg, float start, float end, float lerpTime = 2f)
    {
        Debug.Log("Inside fadeco");
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageCompleted = timeSinceStarted / lerpTime;

        
        while (true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageCompleted = timeSinceStarted / lerpTime;

            float curVal = Mathf.Lerp(start, end, percentageCompleted);

            cg.alpha = curVal;


            //yield return new WaitForEndOfFrame();
            yield return null;

            if (percentageCompleted >= 1)
                break;

        }
        /*
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        */
        //DestroyImmediate(deathEffect,true);
        //Randomizer.LoadNextLevel();
        Debug.Log("Exiting fadeco");
     //   yield return null;
    }

    void LoadNextLevel()
    {
        Debug.Log("Called LoadNextLevel");
        Randomizer.LoadNextLevel();
    }

}
