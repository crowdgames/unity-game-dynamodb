using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using BayatGames.SaveGamePro;
using BayatGames.SaveGamePro.Networking;

namespace BayatGames.SaveGamePro.Examples
{

    /// <summary>
    /// Upload Texture example.
    /// </summary>
    public class UploadTexture : MonoBehaviour
    {

        /// <summary>
        /// The identifier.
        /// </summary>
        public string identifier = "texture.png";

        /// <summary>
        /// The secret key.
        /// </summary>
        public string secretKey;

        /// <summary>
        /// The URL.
        /// </summary>
        public string url;

        /// <summary>
        /// The upload button.
        /// </summary>
        public Button uploadButton;

        /// <summary>
        /// The upload button.
        /// </summary>
        public Button downloadButton;

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
        /// The image.
        /// </summary>
        public Image image;

        /// <summary>
        /// Upload the file.
        /// </summary>
        public void Upload()
        {
            StartCoroutine("DoUpload");
        }

        IEnumerator DoUpload()
        {
            Debug.Log("Uploading...");

            // Disable upload button.
            uploadButton.interactable = false;
            SaveGameWeb web = new SaveGameWeb(url, secretKey, usernameInputField.text, passwordInputField.text);
            yield return StartCoroutine(web.UploadFile(identifier, identifier));

            // Enable upload button.
            uploadButton.interactable = true;
#if UNITY_2017_1_OR_NEWER
			if ( web.Request.isHttpError || web.Request.isNetworkError )
			{
				Debug.LogError ( "Upload Failed" );
				Debug.LogError ( web.Request.error );
				Debug.LogError ( web.Request.downloadHandler.text );
			}
			else
			{
				Debug.Log ( "Upload Successful" );
				Debug.Log ( "Response: " + web.Request.downloadHandler.text );
			}
#else
            if (web.Request.isError)
            {
                Debug.LogError("Upload Failed");
                Debug.LogError(web.Request.error);
                Debug.LogError(web.Request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Upload Successful");
                Debug.Log("Response: " + web.Request.downloadHandler.text);
            }
#endif
        }

        /// <summary>
        /// Download the file.
        /// </summary>
        public void Download()
        {
            StartCoroutine("DoDownload");
        }

        IEnumerator DoDownload()
        {
            Debug.Log("Downloading...");

            // Disable download button.
            downloadButton.interactable = false;
            SaveGameWeb web = new SaveGameWeb(url, secretKey, usernameInputField.text, passwordInputField.text);
            yield return StartCoroutine(web.DownloadFile(identifier, identifier));

            // Enable download button.
            downloadButton.interactable = true;
#if UNITY_2017_1_OR_NEWER
            if (web.Request.isHttpError || web.Request.isNetworkError)
            {
                Debug.LogError("Download Failed");
                Debug.LogError(web.Request.error);
                Debug.LogError(web.Request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Download Successful");
                Debug.Log("Response: " + web.Request.downloadHandler.text);
            }
#else
            if (web.Request.isError)
            {
                Debug.LogError("Download Failed");
                Debug.LogError(web.Request.error);
                Debug.LogError(web.Request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Download Successful");
                Debug.Log("Response: " + web.Request.downloadHandler.text);
            }
#endif
        }

        /// <summary>
        /// Gets the file URL.
        /// </summary>
        public void GetFileUrl()
        {
            StartCoroutine("DoGetFileUrl");
        }

        IEnumerator DoGetFileUrl()
        {
            Debug.Log("Getting File Url...");

            // Disable download button.
            downloadButton.interactable = false;
            SaveGameWeb web = new SaveGameWeb(url, secretKey, usernameInputField.text, passwordInputField.text);
            yield return StartCoroutine(web.GetFileUrl(identifier));

            // Enable download button.
            downloadButton.interactable = true;
#if UNITY_2017_1_OR_NEWER
            if (web.Request.isHttpError || web.Request.isNetworkError)
            {
                Debug.LogError("Getting File Url Failed");
                Debug.LogError(web.Request.error);
                Debug.LogError(web.Request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Getting File Url Successful");
                Debug.Log("File Url: " + web.Request.downloadHandler.text);
            }
#else
            if (web.Request.isError)
            {
                Debug.LogError("Getting File Url Failed");
                Debug.LogError(web.Request.error);
                Debug.LogError(web.Request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Getting File Url Successful");
                Debug.Log("File Url: " + web.Request.downloadHandler.text);
            }
#endif
        }

        /// <summary>
        /// Save the data.
        /// </summary>
        public void Save()
        {
            SaveGame.SaveImage(identifier, image.sprite.texture);
        }

        /// <summary>
        /// Load the data.
        /// </summary>
        public void Load()
        {
            Texture2D texture = SaveGame.LoadImage(identifier);
            image.sprite = Sprite.Create(
                texture,
                new Rect(0f, 0f, texture.width, texture.height),
                new Vector2(0.5f, 0.5f),
                100f);
        }

        /// <summary>
        /// Clear the image.
        /// </summary>
        public void Clear()
        {
            image.sprite = null;
        }

    }

}