using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ItemsGenerator : MonoBehaviour
{

    int randomPositionForRelevantItems;
    int relevantItemsCount;
    public bool isStartingPhase = true;
    public Text locationText;
    public List<GameObject> items = new List<GameObject>();
    GameObject[] sceneItems;

    //public Text scoreText;

    public string[] itemsForCurrentlocation;
    // Use this for initialization

    List<GameObject> myInputList = new List<GameObject>();
    List<int> myCount = new List<int>();
    bool isFirstEntry = true;
    int relevantItemsIterator = 0;

    void Start()
    {
        //Debug.Log("Scene Number: "+SceneManager.GetActiveScene().buildIndex);
        itemsForCurrentlocation = RelevanceManager.DetermineLocation(locationText.text);
        sceneItems = GameObject.FindGameObjectsWithTag("Item");
        myCount.Clear();
        isStartingPhase = false;

        relevantItemsCount = GamePersistentManager.Instance.sceneItemsManager[SceneManager.GetActiveScene().buildIndex].itemsInScene;

        for (int j = 0; j < sceneItems.Length; j++)
        {

            CountRelevantItems();


            if (myCount.Contains(j))
            {

                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    sceneItems[j] = Instantiate(myInputList[relevantItemsIterator], sceneItems[j].transform.position, Quaternion.identity);
                    //sceneItems[j] = Instantiate(GamePersistentManager.Instance.itemsList[Random.Range(5, 10)],
                    //    sceneItems[j].transform.position, Quaternion.identity);
                    relevantItemsIterator++;
                }

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    //if (isFirstEntry)
                    //{
                    //    isFirstEntry = false;
                    //    List<GameObject> myInputList = GamePersistentManager.Instance.itemsList.ToList().GetRange(0, 5);

                    //    myInputList = ShuffleList(myInputList);
                    //}
                    sceneItems[j] = Instantiate(myInputList[relevantItemsIterator], sceneItems[j].transform.position, Quaternion.identity);
                    //sceneItems[j] = Instantiate(GamePersistentManager.Instance.itemsList[Random.Range(5, 10)],
                    //    sceneItems[j].transform.position, Quaternion.identity);
                    relevantItemsIterator++;
                    //sceneItems[j] = Instantiate(GamePersistentManager.Instance.itemsList[Random.Range(0, 5)],
                    //    sceneItems[j].transform.position, Quaternion.identity);
                }

                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    //if (isFirstEntry)
                    //{
                    //    isFirstEntry = false;
                    //    List<GameObject> myInputList = GamePersistentManager.Instance.itemsList.ToList().GetRange(21, 27);
                    //    myInputList = ShuffleList(myInputList);
                    //}
                    sceneItems[j] = Instantiate(myInputList[relevantItemsIterator], sceneItems[j].transform.position, Quaternion.identity);
                    //sceneItems[j] = Instantiate(GamePersistentManager.Instance.itemsList[Random.Range(5, 10)],
                    //    sceneItems[j].transform.position, Quaternion.identity);
                    relevantItemsIterator++;
                    //sceneItems[j] = Instantiate(GamePersistentManager.Instance.itemsList[Random.Range(21, 27)],
                    //    sceneItems[j].transform.position, Quaternion.identity);
                }

            }

            else
            {
                sceneItems[j] = Instantiate(items[Random.Range(0, items.Count - 1)], sceneItems[j].transform.position, Quaternion.identity);

            }

        }

    }

    void CountRelevantItems()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            myInputList = GamePersistentManager.Instance.itemsList.ToList().GetRange(5, 5);
            myInputList = ShuffleList(myInputList);

            while (myCount.Count < 3)
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
            while (myCount.Count < 5)
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
            while (myCount.Count < 7)
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
