using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

using BayatGames.SaveGamePro.IO;
using BayatGames.SaveGamePro.Utilities;

namespace BayatGames.SaveGamePro.Networking
{

    /// <summary>
    /// Save Game Cloud Web API Integration.
    /// </summary>
    public class SaveGameWeb : SaveGameCloud
    {

        /// <summary>
        /// The secret key.
        /// </summary>
        protected string m_SecretKey;

        /// <summary>
        /// The username.
        /// </summary>
        protected string m_Username;

        /// <summary>
        /// The password.
        /// </summary>
        protected string m_Password;

        /// <summary>
        /// The URL.
        /// </summary>
        protected string m_Url;

        /// <summary>
        /// Create a new account if not exists?
        /// </summary>
        protected bool m_CreateAccount = true;

        /// <summary>
        /// The request.
        /// </summary>
        protected UnityWebRequest m_Request;

        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        /// <value>The secret key.</value>
        public virtual string SecretKey
        {
            get
            {
                return m_SecretKey;
            }
            set
            {
                m_SecretKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username
        {
            get
            {
                return m_Username;
            }
            set
            {
                m_Username = value;
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public virtual string Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BayatGames.SaveGamePro.Networking.SaveGameWeb"/> create account.
        /// </summary>
        /// <value><c>true</c> if create account; otherwise, <c>false</c>.</value>
        public virtual bool CreateAccount
        {
            get
            {
                return m_CreateAccount;
            }
            set
            {
                m_CreateAccount = value;
            }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public virtual string Url
        {
            get
            {
                return m_Url;
            }
            set
            {
                m_Url = value;
            }
        }

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <value>The request.</value>
        public virtual UnityWebRequest Request
        {
            get
            {
                return m_Request;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.Networking.SaveGameWeb"/> class.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="secretKey">Secret key.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public SaveGameWeb(string url, string secretKey, string username, string password) : this(url, secretKey, username, password, SaveGame.DefaultSettings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.Networking.SaveGameWeb"/> class.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="secretKey">Secret key.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="settings">Settings.</param>
        public SaveGameWeb(string url, string secretKey, string username, string password, SaveGameSettings settings) : base(settings)
        {
            m_Url = url;
            m_SecretKey = secretKey;
            m_Username = username;
            m_Password = password;
        }

        /// <summary>
        /// Gets the file URL.
        /// </summary>
        /// <returns>The file URL.</returns>
        /// <param name="identifier">Identifier.</param>
        public virtual IEnumerator GetFileUrl(string identifier)
        {
            return GetFileUrl(identifier, Settings);
        }

        /// <summary>
        /// Gets the file URL.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public virtual IEnumerator GetFileUrl(string identifier, SaveGameSettings settings)
        {
            var form = CreateRequestForm("getfileurl", identifier, settings);
            form.Add("file-name", identifier);
            m_Request = UnityWebRequest.Post(m_Url, form);
#if UNITY_2017_2_OR_NEWER
            yield return m_Request.SendWebRequest();
#else
            yield return m_Request.Send();
#endif
        }

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <returns>The file.</returns>
        /// <param name="identifier">Identifier.</param>
        /// <param name="uploadIdentifier">Upload identifier.</param>
        public virtual IEnumerator UploadFile(string identifier, string uploadIdentifier)
        {
            return UploadFile(identifier, uploadIdentifier, Settings);
        }

        /// <summary>
        /// Upload the specified identifier, uploadIdentifier and settings.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="uploadIdentifier">Upload identifier.</param>
        /// <param name="settings">Settings.</param>
        public virtual IEnumerator UploadFile(string identifier, string uploadIdentifier, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            byte[] data = File.ReadAllBytes(SaveGameFileStorage.GetAbsolutePath(settings.Identifier, settings.BasePath));

            // Using WWWForm instead of Multipart form data, because there are some internal issues within Unity
            WWWForm form = new WWWForm();
            form.AddField("action", "uploadfile");
            form.AddField("secret-key", m_SecretKey);
            form.AddField("username", m_Username);
            form.AddField("password", m_Password);
            form.AddField("file-name", uploadIdentifier);
            if (m_CreateAccount)
            {
                form.AddField("create-account", "");
            }
            form.AddBinaryData("file", data, uploadIdentifier);
            //var form = CreateRequestForm("downloadfile", settings);
            //form.Add("file-name", identifier);
            m_Request = UnityWebRequest.Post(m_Url, form);
#if UNITY_2017_2_OR_NEWER
            yield return m_Request.SendWebRequest();
#else
            yield return m_Request.Send();
#endif
        }

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <returns>The file.</returns>
        /// <param name="identifier">Identifier.</param>
        /// <param name="downloadIdentifier">Download identifier.</param>
        public virtual IEnumerator DownloadFile(string identifier, string downloadIdentifier)
        {
            return DownloadFile(identifier, downloadIdentifier, Settings);
        }

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <returns>The file.</returns>
        /// <param name="identifier">Identifier.</param>
        /// <param name="downloadIdentifier">Download identifier.</param>
        /// <param name="settings">Settings.</param>
        public virtual IEnumerator DownloadFile(string identifier, string downloadIdentifier, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            var form = CreateRequestForm("downloadfile", settings);
            form.Add("file-name", identifier);
            m_Request = UnityWebRequest.Post(m_Url, form);
#if UNITY_2017_2_OR_NEWER
            yield return m_Request.SendWebRequest();
#else
            yield return m_Request.Send();
#endif
#if UNITY_2017_1_OR_NEWER
            if (m_Request.isHttpError || m_Request.isNetworkError)
            {
                Debug.LogError("Download Failed");
                Debug.LogError(m_Request.error);
                Debug.LogError(m_Request.downloadHandler.text);
            }
            else
            {
                File.WriteAllBytes(
                    SaveGameFileStorage.GetAbsolutePath(downloadIdentifier, settings.BasePath),
                    m_Request.downloadHandler.data);
            }
#else
            if (m_Request.isError)
            {
                Debug.LogError("Download Failed");
                Debug.LogError(m_Request.error);
                Debug.LogError(m_Request.downloadHandler.text);
            }
            else
            {
                File.WriteAllBytes(
                    SaveGameFileStorage.GetAbsolutePath(downloadIdentifier, settings.BasePath),
                    m_Request.downloadHandler.data);
            }
#endif
        }

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public override IEnumerator Save(string identifier, object value, SaveGameSettings settings)
        {
            byte[] data;
            using (MemoryStream stream = new MemoryStream())
            {
                settings.Formatter.Serialize(stream, value, settings);
                data = stream.ToArray();
            }
            var form = CreateRequestForm("save", identifier, data, settings);
            m_Request = UnityWebRequest.Post(m_Url, form);
#if UNITY_2017_2_OR_NEWER
            yield return m_Request.SendWebRequest();
#else
            yield return m_Request.Send();
#endif
        }

        /// <summary>
        /// Download the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public override IEnumerator Download(string identifier, SaveGameSettings settings)
        {
            var form = CreateRequestForm("load", identifier, settings);
            m_Request = UnityWebRequest.Post(m_Url, form);
#if UNITY_2017_2_OR_NEWER
            yield return m_Request.SendWebRequest();
#else
            yield return m_Request.Send();
#endif
        }

        /// <summary>
        /// Load the value, if not exists, return the default value.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="settings">Settings.</param>
        public override object Load(Type type, object defaultValue, SaveGameSettings settings)
        {
            object result = null;
            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(m_Request.downloadHandler.text)))
            {
                result = settings.Formatter.Deserialize(stream, type, settings);
            }
            if (result == null)
            {
                result = defaultValue;
            }
            return result;
        }

        /// <summary>
        /// Load the data into the value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public override void LoadInto(object value, SaveGameSettings settings)
        {
            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(m_Request.downloadHandler.text)))
            {
                settings.Formatter.DeserializeInto(stream, value, settings);
            }
        }

        /// <summary>
        /// Clear the user data.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public override IEnumerator Clear(SaveGameSettings settings)
        {
            var form = CreateRequestForm("clear", settings);
            m_Request = UnityWebRequest.Post(m_Url, form);
#if UNITY_2017_2_OR_NEWER
            yield return m_Request.SendWebRequest();
#else
            yield return m_Request.Send();
#endif
        }

        /// <summary>
        /// Delete the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public override IEnumerator Delete(string identifier, SaveGameSettings settings)
        {
            var form = CreateRequestForm("delete", settings);
            m_Request = UnityWebRequest.Post(m_Url, form);
#if UNITY_2017_2_OR_NEWER
            yield return m_Request.SendWebRequest();
#else
            yield return m_Request.Send();
#endif
        }

        /// <summary>
        /// Create the request form for the given action and settings.
        /// </summary>
        /// <returns>The request form.</returns>
        /// <param name="action">Action.</param>
        /// <param name="settings">Settings.</param>
        public virtual Dictionary<string, string> CreateRequestForm(string action, SaveGameSettings settings)
        {
            return CreateRequestForm(action, null, null, settings);
        }

        /// <summary>
        /// Create the request form for the given action and settings.
        /// </summary>
        /// <returns>The request form.</returns>
        /// <param name="action">Action.</param>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public virtual Dictionary<string, string> CreateRequestForm(string action, string identifier, SaveGameSettings settings)
        {
            return CreateRequestForm(action, identifier, null, settings);
        }

        /// <summary>
        /// Create the request form for the given action and settings.
        /// </summary>
        /// <returns>The request form.</returns>
        /// <param name="action">Action.</param>
        /// <param name="data">Data.</param>
        /// <param name="settings">Settings.</param>
        public virtual Dictionary<string, string> CreateRequestForm(string action, byte[] data, SaveGameSettings settings)
        {
            return CreateRequestForm(action, null, data, settings);
        }

        /// <summary>
        /// Create the request form for the given action, identifier, data, and settings.
        /// </summary>
        /// <returns>The request form.</returns>
        /// <param name="action">Action.</param>
        /// <param name="identifier">Identifier.</param>
        /// <param name="data">Data.</param>
        /// <param name="settings">Settings.</param>
        public virtual Dictionary<string, string> CreateRequestForm(string action, string identifier, byte[] data, SaveGameSettings settings)
        {
            if (string.IsNullOrEmpty(action))
            {
                throw new ArgumentNullException("action");
            }
            Dictionary<string, string> form = new Dictionary<string, string>();
            form.Add("secret-key", m_SecretKey);
            form.Add("username", m_Username);
            form.Add("password", m_Password);
            if (m_CreateAccount)
            {
                form.Add("create-account", "");
            }
            form.Add("action", action);
            if (!string.IsNullOrEmpty(identifier))
            {
                form.Add("data-key", identifier);
            }
            if (data != null)
            {
                form.Add("data-value", Convert.ToBase64String(data));
            }
            return form;
        }

    }

}