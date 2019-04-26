using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using BayatGames.SaveGamePro.Examples;

public class ItemsGenerator : MonoBehaviour
{
    public Text statusText;
    int randomPositionForRelevantItems;
    int relevantItemsCount;
    public bool isStartingPhase = true;
    //public Text locationText;
    //public GameObject canvas;
    //public GameObject empltySlot;
    public List<GameObject> items = new List<GameObject>();
    List<string> itemsString = new List<string>()
    {
        "BoxingGloves", "FootBall", "driller", "electricsaw", "hammer", "RugbyBall"
    };
    public GameObject[] sceneItems;

    //public Text scoreText;

    public string[] itemsForCurrentlocation;
    // Use this for initialization

    List<GameObject> myInputList = new List<GameObject>();
    List<int> myCount = new List<int>();
    bool isFirstEntry = true;
    int relevantItemsIterator = 0;
    PlayerController playerController;

    public int UIInventoryLimit = 0;

    SaveGameObject sgo;

    bool firstEntry = false;

    void Start()
    {
        //statusText.text = "Relevant items collected : 0 / 0";
        ////Debug.Log("Scene Number: "+SceneManager.GetActiveScene().buildIndex);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sgo = GameObject.FindGameObjectWithTag("SGO").GetComponent<SaveGameObject>();

        //itemsForCurrentlocation = RelevanceManager.DetermineLocation("Grocery Store");
        //sceneItems = GameObject.FindGameObjectsWithTag("Item");
        //myCount.Clear();
        //isStartingPhase = false;

        //relevantItemsCount = GamePersistentManager.Instance.sceneItemsManager[SceneManager.GetActiveScene().buildIndex].itemsInScene;

   

    }

    private void Update()
    {
        if (firstEntry)
        {
            statusText.text = "Relevant items collected : " + playerController.relevantItemsCollectedInLevel.ToString() + " / " + UIInventoryLimit.ToString();//0 / 0";
        }

        if (sgo.testForObjects)
        {
            sgo.testForObjects = false;

            itemsForCurrentlocation = RelevanceManager.DetermineLocation(playerController.scenarioText);
            //itemsForCurrentlocation = RelevanceManager.DetermineLocation("Grocery Store");
            sceneItems = GameObject.FindGameObjectsWithTag("Item");
            myCount.Clear();
            isStartingPhase = false;

            //relevantItemsCount = GamePersistentManager.Instance.sceneItemsManager[SceneManager.GetActiveScene().buildIndex].itemsInScene;
            relevantItemsCount = sceneItems.Length / 2;
            UIInventoryLimit = sceneItems.Length / 2;

            //for(int i=0;i< sceneItems.Length / 2; i++)
            //{
            //    var createImage = Instantiate(empltySlot) as GameObject;
            //    createImage.transform.SetParent(canvas.transform, false);
            //}


            firstEntry = true;
            CountRelevantItems();

            for (int j = 0; j < sceneItems.Length; j++)
            {


                if (myCount.Contains(j))
                {

                    if (SceneManager.GetActiveScene().buildIndex == 0)
                    {

                        //sceneItems[j] = Instantiate(myInputList[relevantItemsIterator]) as GameObject;
                        //sceneItems[j].transform.position = sceneItems[j].transform.position;
                        //sceneItems[j].transform.rotation = Quaternion.identity;
                        GameObject g = Instantiate(myInputList[relevantItemsIterator]) as GameObject;
                        g.transform.position = sceneItems[j].transform.position;
                        g.transform.rotation = Quaternion.identity;
                        relevantItemsIterator++;
                    }

                    if (SceneManager.GetActiveScene().buildIndex == 1)
                    {


                        //sceneItems[j] = Instantiate(myInputList[relevantItemsIterator]) as GameObject;
                        //sceneItems[j].transform.position = sceneItems[j].transform.position;
                        //sceneItems[j].transform.rotation = Quaternion.identity;

                        GameObject g = Instantiate(myInputList[relevantItemsIterator]) as GameObject;
                        g.transform.position = sceneItems[j].transform.position;
                        g.transform.rotation = Quaternion.identity;
                        relevantItemsIterator++;

                    }

                    if (SceneManager.GetActiveScene().buildIndex == 2)
                    {


                        //sceneItems[j] = Instantiate(myInputList[relevantItemsIterator]) as GameObject;
                        //sceneItems[j].transform.position = sceneItems[j].transform.position;
                        //sceneItems[j].transform.rotation = Quaternion.identity;
                        GameObject g = Instantiate(myInputList[relevantItemsIterator]) as GameObject;
                        g.transform.position = sceneItems[j].transform.position;
                        g.transform.rotation = Quaternion.identity;
                        relevantItemsIterator++;

                    }

                }

                else
                {

                    //sceneItems[j] = Instantiate(Resources.Load("L1/" + itemsString[Random.Range(0, itemsString.Count - 1)]) as GameObject);// items[Random.Range(0, items.Count - 1)]) as GameObject;
                    //sceneItems[j].transform.position = sceneItems[j].transform.position;
                    //sceneItems[j].transform.rotation = Quaternion.identity;

                    GameObject g = Instantiate(items[Random.Range(0, items.Count - 1)] as GameObject);
                    //GameObject g = Instantiate(Resources.Load("L1/" + itemsString[Random.Range(0, itemsString.Count - 1)]) as GameObject);
                    g.transform.position = sceneItems[j].transform.position;
                    g.transform.rotation = Quaternion.identity;

                }

            }
        }

    }

    void CountRelevantItems()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            myInputList = GamePersistentManager.Instance.itemsList.ToList().GetRange(5, 5);
            myInputList = ShuffleList(myInputList);

            while (myCount.Count < sceneItems.Length / 2)
            {
                randomPositionForRelevantItems = Random.Range(0, 2 * relevantItemsCount);
                if (!myCount.Contains(randomPositionForRelevantItems))
                    myCount.Add(randomPositionForRelevantItems);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            myInputList = GamePersistentManager.Instance.itemsList.ToList().GetRange(0, 5);
            myInputList = ShuffleList(myInputList);

            while (myCount.Count < sceneItems.Length / 2)
            {
                randomPositionForRelevantItems = Random.Range(0, 2 * relevantItemsCount);
                if (!myCount.Contains(randomPositionForRelevantItems))
                    myCount.Add(randomPositionForRelevantItems);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            myInputList = GamePersistentManager.Instance.itemsList.ToList().GetRange(21, 7);
            myInputList = ShuffleList(myInputList);
   

            while (myCount.Count < sceneItems.Length / 2)
            {
                randomPositionForRelevantItems = Random.Range(0, 2 * relevantItemsCount);
                if (!myCount.Contains(randomPositionForRelevantItems))
                    myCount.Add(randomPositionForRelevantItems);
            }
        }

    }

    List<GameObject> ShuffleList(List<GameObject> inputList)
    {

        System.Random random = new System.Random();

        GameObject myGameobject;

        int n = inputList.Count;
        for (int i = 0; i < n; i++)
        {

            int r = i + (int)(random.NextDouble() * (n - i));
            myGameobject = inputList[r];
            inputList[r] = inputList[i];
            inputList[i] = myGameobject;
        }

        return inputList;

    }


}
