using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using BayatGames.SaveGamePro;
using BayatGames.SaveGamePro.Networking;

namespace BayatGames.SaveGamePro.Examples
{

    /// <summary>
    /// Web cloud save example.
    /// </summary>
    public class WebCloudSave : MonoBehaviour
    {

        /// <summary>
        /// The identifier.
        /// </summary>
        public string identifier = "helloWorld";

        /// <summary>
        /// The secret key.
        /// </summary>
        public string secretKey;

        /// <summary>
        /// The URL.
        /// </summary>
        public string url;

        /// <summary>
        /// The default value.
        /// </summary>
        public string defaultValue = "Hello, World!";

        /// <summary>
        /// The save button.
        /// </summary>
        public Button saveButton;

        /// <summary>
        /// The load button.
        /// </summary>
        public Button loadButton;

        /// <summary>
        /// The clear button.
        /// </summary>
        public Button clearButton;

        /// <summary>
        /// The username input field.
        /// </summary>
        public InputField usernameInputField;

        /// <summary>
        /// The password input field.
        /// </summary>
        public InputField passwordInputField;

        /// <summary>
        /// The data input field.
        /// </summary>
        public InputField dataInputField;

        /// <summary>
        /// Save the data.
        /// </summary>
        public void Save()
        {
            StartCoroutine("DoSave");
        }

        IEnumerator DoSave()
        {
            Debug.Log("Saving...");

            // Disable save button.
            saveButton.interactable = false;
            SaveGameWeb web = new SaveGameWeb(url, secretKey, usernameInputField.text, passwordInputField.text);
            yield return StartCoroutine(web.Save(identifier, dataInputField.text));

            // Enable save button.
            saveButton.interactable = true;
#if UNITY_2017_1_OR_NEWER
            if ( web.Request.isHttpError || web.Request.isNetworkError )
			{
				Debug.LogError ( "Save Failed" );
				Debug.LogError ( web.Request.error );
				Debug.LogError ( web.Request.downloadHandler.text );
			}
			else
			{
				Debug.Log ( "Save Successful" );
				Debug.Log ( "Response: " + web.Request.downloadHandler.text );
			}
#else
            if (web.Request.isError)
            {
                Debug.LogError("Save Failed");
                Debug.LogError(web.Request.error);
                Debug.LogError(web.Request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Save Successful");
                Debug.Log("Response: " + web.Request.downloadHandler.text);
            }
#endif
        }

        /// <summary>
        /// Load the data.
        /// </summary>
        public void Load()
        {
            StartCoroutine("DoLoad");
        }

        IEnumerator DoLoad()
        {
            Debug.Log("Loading...");

            // Disable load button.
            loadButton.interactable = false;
            SaveGameWeb web = new SaveGameWeb(url, secretKey, usernameInputField.text, passwordInputField.text);
            yield return StartCoroutine(web.Download(identifier));

            // Enable load button.
            loadButton.interactable = true;
#if UNITY_2017_1_OR_NEWER
            if ( web.Request.isHttpError || web.Request.isNetworkError )
			{
                Debug.LogError("Load Failed");
                Debug.LogError(web.Request.error);
                Debug.LogError(web.Request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Load Successful");
                Debug.Log("Response: " + web.Request.downloadHandler.text);
                dataInputField.text = web.Load<string>(defaultValue);
            }
#else
            if (web.Request.isError)
            {
                Debug.LogError("Load Failed");
                Debug.LogError(web.Request.error);
                Debug.LogError(web.Request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Load Successful");
                Debug.Log("Response: " + web.Request.downloadHandler.text);
                dataInputField.text = web.Load<string>(defaultValue);
            }
#endif
        }

        /// <summary>
        /// Clear the user data.
        /// </summary>
        public void Clear()
        {
            StartCoroutine("DoClear");
        }

        IEnumerator DoClear()
        {
            Debug.Log("Clearing...");

            // Disable clear button.
            clearButton.interactable = false;
            SaveGameWeb web = new SaveGameWeb(url, secretKey, usernameInputField.text, passwordInputField.text);
            yield return StartCoroutine(web.Clear());

            // Enable clear button.
            clearButton.interactable = true;
#if UNITY_2017_1_OR_NEWER
            if (web.Request.isHttpError || web.Request.isNetworkError)
            {
                Debug.LogError("Clear Failed");
                Debug.LogError(web.Request.error);
            }
            else
            {
                Debug.Log("Clear Successful");
                Debug.Log("Response: " + web.Request.downloadHandler.text);
            }
#else
            if (web.Request.isError)
            {
                Debug.LogError("Clear Failed");
                Debug.LogError(web.Request.error);
            }
            else
            {
                Debug.Log("Clear Successful");
                Debug.Log("Response: " + web.Request.downloadHandler.text);
            }
#endif
        }

    }

}