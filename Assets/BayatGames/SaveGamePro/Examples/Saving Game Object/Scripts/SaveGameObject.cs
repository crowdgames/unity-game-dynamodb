using BayatGames.SaveGamePro.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BayatGames.SaveGamePro.Examples
{


    /// <summary>
    /// Save game object example.
    /// </summary>
    public class SaveGameObject : MonoBehaviour
    {
       
        
        public static string fileName = "SerializedDataV.txt";//+ SceneManager.GetActiveScene().buildIndex + ".txt";
        string url = "https://s3.us-east-2.amazonaws.com/gameedits/" + fileName;
        //string url = "https://s3.us-east-2.amazonaws.com/gameedits/test.txt";
        /// <summary>
        /// The target to save.
        /// </summary>
        public bool testMode = false;

        public bool testForObjects = false;

        public List<GameObject> obj = new List<GameObject>();

        /// <summary>
        /// Save the target.
        /// </summary>
        public void Save()
        {
            Debug.Log(Application.persistentDataPath);
            SaveGame.Save(fileName, obj);
            Debug.Log("File saved!");
        }



        void Awake()
        { 
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                fileName = "SerializedDataV1.txt";
                //url = "https://s3.us-east-2.amazonaws.com/gameedits/" + fileName;
            }

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                fileName = "SerializedDataV2.txt";
                //url = "https://s3.us-east-2.amazonaws.com/gameedits/" + fileName;
            }

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                fileName = "SerializedDataV3.txt";
              
            }

            url = "https://s3.us-east-2.amazonaws.com/gameedits/" + fileName;


            if (testMode)
                ReadURL();
        }


        //// Function to load "gameObject.txt" file from Amazon s3 bucket.
        void ReadURL()
        {
            // Debug.Log("Reading file");
            WWW www = new WWW(url);

            StartCoroutine(WaitForRequest(www));

        }

        IEnumerator WaitForRequest(WWW www)
        {
            yield return www;

            // check for errors
            if (www.error == null)
            {
                Debug.Log("WWW Ok!");
                var formatter = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream(www.bytes))
                {

                    obj = formatter.Deserialize<List<GameObject>>(stream);
                }
                testForObjects = true;
            }
            else
            {
                Debug.Log("WWW Error: " + www.error);
            }


        }


    }
}