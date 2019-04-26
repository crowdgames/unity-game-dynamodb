using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
#if NET_4_6 || NET_STANDARD_2_0
using System.Threading.Tasks;
#endif
using UnityEngine;

using BayatGames.SaveGamePro.IO;
using BayatGames.SaveGamePro.Reflection;
using BayatGames.SaveGamePro.Utilities;

namespace BayatGames.SaveGamePro
{

    /// <summary>
    /// The Main Save Game Pro API.
    /// </summary>
    public static class SaveGame
    {

        #region Delegates

        /// <summary>
        /// Save event handler.
        /// </summary>
        public delegate void SaveEventHandler(string identifier, object value, SaveGameSettings settings);

        /// <summary>
        /// Load event handler.
        /// </summary>
        public delegate void LoadEventHandler(string identifier, object result, Type type, object defaultValue, SaveGameSettings settings);

        /// <summary>
        /// Load into event handler.
        /// </summary>
        public delegate void LoadIntoEventHandler(string identifier, object value, SaveGameSettings settings);

        /// <summary>
        /// Delete event handler.
        /// </summary>
        public delegate void DeleteEventHandler(string identifier, SaveGameSettings settings);

        /// <summary>
        /// Move event handler.
        /// </summary>
        public delegate void MoveEventHandler(string fromIdentifier, string toIdentifier, SaveGameSettings settings);

        /// <summary>
        /// Clear event handler.
        /// </summary>
        public delegate void ClearEventHandler(SaveGameSettings settings);

        #endregion

        #region Events

        /// <summary>
        /// Occurs when on saved.
        /// </summary>
        public static event SaveEventHandler OnSaved;

        /// <summary>
        /// Occurs when on loaded.
        /// </summary>
        public static event LoadEventHandler OnLoaded;

        /// <summary>
        /// Occurs when on loaded into.
        /// </summary>
        public static event LoadIntoEventHandler OnLoadedInto;

        /// <summary>
        /// Occurs when on deleted.
        /// </summary>
        public static event DeleteEventHandler OnDeleted;

        /// <summary>
        /// Occurs when on moved.
        /// </summary>
        public static event MoveEventHandler OnMoved;

        /// <summary>
        /// Occurs when on copied.
        /// </summary>
        public static event MoveEventHandler OnCopied;

        /// <summary>
        /// Occurs when on cleared.
        /// </summary>
        public static event ClearEventHandler OnCleared;

        #endregion

        #region Fields

        /// <summary>
        /// Cache persistent data path.
        /// </summary>
        public static readonly string PersistentDataPath = Application.persistentDataPath;

        /// <summary>
        /// Cache the main thread.
        /// </summary>
        public static readonly Thread MainThread = Thread.CurrentThread;

        /// <summary>
        /// The Save Game Pro Version.
        /// </summary>
        public static readonly Version Version = new Version(2, 6, 9);

        /// <summary>
        /// The default settings.
        /// </summary>
        private static SaveGameSettings m_DefaultSettings;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the default settings.
        /// </summary>
        /// <value>The default settings.</value>
        public static SaveGameSettings DefaultSettings
        {
            get
            {
                return m_DefaultSettings;
            }
            set
            {
                m_DefaultSettings = value;
            }
        }

        /// <summary>
        /// Gets a value indicating is file IO supported.
        /// </summary>
        /// <value><c>true</c> if is file IO supported; otherwise, <c>false</c>.</value>
        public static bool IsFileIOSupported
        {
            get
            {
#if UNITY_WEBGL || UNITY_SAMSUNGTV || UNITY_TVOS
				return false;
#else
                return true;
#endif
            }
        }

        /// <summary>
        /// Gets a value indicating is windows store.
        /// </summary>
        /// <value><c>true</c> if is windows store; otherwise, <c>false</c>.</value>
        public static bool IsWindowsStore
        {
            get
            {
#if UNITY_WSA || UNITY_WINRT
                return true;
#else
                return false;
#endif
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Save all behaviours.
        /// Finds all SaveGameBehaviours and calls the Save method on them.
        /// </summary>
        public static void SaveAllBehaviours()
        {
            SaveGameBehaviour[] behaviours = GameObject.FindObjectsOfType<SaveGameBehaviour>();
            foreach (SaveGameBehaviour behaviour in behaviours)
            {
                behaviour.Save();
            }
        }

        /// <summary>
        /// Load all behaviours.
        /// Finds all SaveGameBehaviours and calls the Load method on them.
        /// </summary>
        public static void LoadAllBehaviours()
        {
            SaveGameBehaviour[] behaviours = GameObject.FindObjectsOfType<SaveGameBehaviour>();
            foreach (SaveGameBehaviour behaviour in behaviours)
            {
                behaviour.Load();
            }
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Save the specified value using the identifier Asynchronously.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Task SaveAsync<T>(string identifier, T value)
        {
            return SaveAsync(identifier, (object)value, DefaultSettings);
        }
#endif

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Save<T>(string identifier, T value)
        {
            Save(identifier, (object)value, DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Save the specified value using the identifier Asynchronously.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Task SaveAsync(string identifier, object value)
        {
            return SaveAsync(identifier, value, DefaultSettings);
        }
#endif

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public static void Save(string identifier, object value)
        {
            Save(identifier, value, DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Save the specified value using the identifier Asynchronously.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static Task SaveAsync<T>(string identifier, T value, SaveGameSettings settings)
        {
            return SaveAsync(identifier, (object)value, settings);
        }
#endif

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Save<T>(string identifier, T value, SaveGameSettings settings)
        {
            Save(identifier, (object)value, settings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Save the specified value using the identifier Asynchronously.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static Task SaveAsync(string identifier, object value, SaveGameSettings settings)
        {
            Task task = new Task(() =>
            {
                SaveGame.Save(identifier, value, settings);
            });
            task.Start();
            return task;
        }
#endif

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public static void Save(string identifier, object value, SaveGameSettings settings)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentNullException("identifier");
            }
            if (value == null)
            {
                Debug.LogWarning("SaveGamePro: Can't Save a null value");
                return;
            }
            if (!settings.Formatter.IsTypeSupported(value.GetType()))
            {
                Debug.LogWarningFormat("SaveGamePro: The serialization of type {0} isn't supported.", value.GetType());
                return;
            }
            settings.Identifier = identifier;
            settings.Storage.OnSave(settings);
            Stream stream = settings.Storage.GetWriteStream(settings);
            if (settings.Encrypt)
            {
                byte[] serializedData;
                using (MemoryStream mStream = new MemoryStream())
                {
                    settings.Formatter.Serialize(mStream, value, settings);
                    serializedData = mStream.ToArray();
                }
                CryptoStream encStream = new CryptoStream(stream, settings.Encryptor, CryptoStreamMode.Write);
                encStream.Write(serializedData, 0, serializedData.Length);
                encStream.FlushFinalBlock();
                stream = encStream;
            }
            else
            {
                settings.Formatter.Serialize(stream, value, settings);
            }
            settings.Storage.OnSaved(settings);
            stream.Dispose();
            if (OnSaved != null)
            {
                OnSaved(identifier, value, settings);
            }
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public static Task<T> LoadAsync<T>(string identifier)
        {
            return LoadAsync<T>(identifier, default(T), DefaultSettings);
        }
#endif

        /// <summary>
        /// Load the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Load<T>(string identifier)
        {
            return (T)Load(identifier, typeof(T), default(T), DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="type">Type.</param>
        public static Task<object> LoadAsync(string identifier, Type type)
        {
            return LoadAsync(identifier, type, type.GetDefault(), DefaultSettings);
        }
#endif

        /// <summary>
        /// Load the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="type">Type.</param>
        public static object Load(string identifier, Type type)
        {
            return Load(identifier, type, type.GetDefault(), DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="defaultValue">Default value.</param>
        public static Task<T> LoadAsync<T>(string identifier, T defaultValue)
        {
            return LoadAsync<T>(identifier, defaultValue, DefaultSettings);
        }
#endif

        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Load<T>(string identifier, T defaultValue)
        {
            if (defaultValue == null)
            {
                defaultValue = default(T);
            }
            return (T)Load(identifier, typeof(T), defaultValue, DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="type">Type.</param>
        /// <param name="defaultValue">Default value.</param>
        public static Task<object> LoadAsync(string identifier, Type type, object defaultValue)
        {
            return LoadAsync(identifier, type, defaultValue, DefaultSettings);
        }
#endif

        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="type">Type.</param>
        /// <param name="defaultValue">Default value.</param>
        public static object Load(string identifier, Type type, object defaultValue)
        {
            return Load(identifier, type, defaultValue, DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="settings">Settings.</param>
        public static Task<T> LoadAsync<T>(string identifier, T defaultValue, SaveGameSettings settings)
        {
            if (defaultValue == null)
            {
                defaultValue = default(T);
            }
            Task<T> task = new Task<T>(() =>
            {
                return (T)SaveGame.Load(identifier, typeof(T), defaultValue, settings);
            });
            task.Start();
            return task;
        }
#endif

        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Load<T>(string identifier, T defaultValue, SaveGameSettings settings)
        {
            if (defaultValue == null)
            {
                defaultValue = default(T);
            }
            return (T)Load(identifier, typeof(T), defaultValue, settings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="type">Type.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="settings">Settings.</param>
        public static Task<object> LoadAsync(string identifier, Type type, object defaultValue, SaveGameSettings settings)
        {
            Task<object> task = new Task<object>(() =>
            {
                return SaveGame.Load(identifier, type, defaultValue, settings);
            });
            task.Start();
            return task;
        }
#endif

        /// <summary>
        /// Load the specified identifier, if not exists, returns the default value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="type">Type.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="settings">Settings.</param>
        public static object Load(string identifier, Type type, object defaultValue, SaveGameSettings settings)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentNullException("identifier");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (defaultValue == null)
            {
                defaultValue = type.GetDefault();
            }
            settings.Identifier = identifier;
            if (!Exists(settings.Identifier, settings))
            {
                if (defaultValue == null)
                {
                    Debug.LogWarning("SaveGamePro: The specified identifier does not exists, please make sure the identifeir is exist before loading. The Default value is not specified, it might make exceptions and errors.");
                }
                else
                {
                    Debug.LogWarning("SaveGamePro: The specified identifier does not exists, please make sure the identifeir is exist before loading. Returning default value.");
                }
                return defaultValue;
            }
            settings.Storage.OnLoad(settings);
            object result = null;
            Stream stream = settings.Storage.GetReadStream(settings);
            if (settings.Encrypt)
            {
                using (MemoryStream dataOut = new MemoryStream())
                {
                    using (MemoryStream memoryStream = new MemoryStream(stream.ReadFully()))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, settings.Decryptor, CryptoStreamMode.Read))
                        {
                            byte[] decryptedData = cryptoStream.ReadFully();
                            dataOut.Write(decryptedData, 0, decryptedData.Length);
                        }
                    }
                    dataOut.Flush();
                    result = settings.Formatter.Deserialize(dataOut, type, settings);
                }
            }
            else
            {
                result = settings.Formatter.Deserialize(stream, type, settings);
            }
            settings.Storage.OnLoaded(settings);
            stream.Dispose();
            if (result == null)
            {
                result = defaultValue;
            }
            if (OnLoaded != null)
            {
                OnLoaded(identifier, result, type, defaultValue, settings);
            }
            return result;
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Loads the data into the value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Task LoadIntoAsync<T>(string identifier, T value)
        {
            return LoadIntoAsync(identifier, (object)value, DefaultSettings);
        }
#endif

        /// <summary>
        /// Loads the data into the value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void LoadInto<T>(string identifier, T value)
        {
            LoadInto(identifier, (object)value, DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Loads the data into the value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public static Task LoadIntoAsync(string identifier, object value)
        {
            return LoadIntoAsync(identifier, value, DefaultSettings);
        }
#endif

        /// <summary>
        /// Loads the data into the value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public static void LoadInto(string identifier, object value)
        {
            LoadInto(identifier, value, DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Loads the data into the value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static Task LoadIntoAsync<T>(string identifier, T value, SaveGameSettings settings)
        {
            return LoadIntoAsync(identifier, (object)value, settings);
        }
#endif

        /// <summary>
        /// Loads the data into the value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void LoadInto<T>(string identifier, T value, SaveGameSettings settings)
        {
            LoadInto(identifier, (object)value, settings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Loads the data into the value Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public static Task LoadIntoAsync(string identifier, object value, SaveGameSettings settings)
        {
            Task task = new Task(() =>
            {
                SaveGame.LoadInto(identifier, value, settings);
            });
            task.Start();
            return task;
        }
#endif

        /// <summary>
        /// Loads the data into the value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public static void LoadInto(string identifier, object value, SaveGameSettings settings)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentNullException("identifier");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            settings.Identifier = identifier;
            if (!Exists(settings.Identifier, settings))
            {
                Debug.LogWarning("SaveGamePro: The specified identifier does not exists.");
                return;
            }
            settings.Storage.OnLoad(settings);
            settings.Formatter.DeserializeInto(settings.Storage.GetReadStream(settings), value, settings);
            settings.Storage.OnLoaded(settings);
            if (OnLoadedInto != null)
            {
                OnLoadedInto(identifier, value, settings);
            }
        }

        /// <summary>
        /// Clear all user data.
        /// </summary>
        public static void Clear()
        {
            Clear(DefaultSettings);
        }

        /// <summary>
        /// Clear all user data.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public static void Clear(SaveGameSettings settings)
        {
            settings.Storage.Clear(settings);
            if (OnCleared != null)
            {
                OnCleared(settings);
            }
        }

        /// <summary>
        /// Delete the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public static void Delete(string identifier)
        {
            Delete(identifier, DefaultSettings);
        }

        /// <summary>
        /// Delete the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public static void Delete(string identifier, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            settings.Storage.Delete(settings);
            if (OnDeleted != null)
            {
                OnDeleted(identifier, settings);
            }
        }

        /// <summary>
        /// Copy the specified identifier to identifier.
        /// </summary>
        /// <param name="fromIdentifier">From identifier.</param>
        /// <param name="toIdentifier">To identifier.</param>
        public static void Copy(string fromIdentifier, string toIdentifier)
        {
            Copy(fromIdentifier, toIdentifier, DefaultSettings);
        }

        /// <summary>
        /// Copy the specified identifier to identifier.
        /// </summary>
        /// <param name="fromIdentifier">From identifier.</param>
        /// <param name="toIdentifier">To identifier.</param>
        /// <param name="settings">Settings.</param>
        public static void Copy(string fromIdentifier, string toIdentifier, SaveGameSettings settings)
        {
            settings.Storage.Copy(fromIdentifier, toIdentifier, settings);
            if (OnCopied != null)
            {
                OnCopied(fromIdentifier, toIdentifier, settings);
            }
        }

        /// <summary>
        /// Move the specified identifier to identifier.
        /// </summary>
        /// <param name="fromIdenifier">From idenifier.</param>
        /// <param name="toIdentifier">To identifier.</param>
        public static void Move(string fromIdenifier, string toIdentifier)
        {
            Move(fromIdenifier, toIdentifier, DefaultSettings);
        }

        /// <summary>
        /// Move the specified identifier to identifier.
        /// </summary>
        /// <param name="fromIdentifier">From identifier.</param>
        /// <param name="toIdentifier">To identifier.</param>
        /// <param name="settings">Settings.</param>
        public static void Move(string fromIdentifier, string toIdentifier, SaveGameSettings settings)
        {
            settings.Storage.Move(fromIdentifier, toIdentifier, settings);
            if (OnMoved != null)
            {
                OnMoved(fromIdentifier, toIdentifier, settings);
            }
        }

        /// <summary>
        /// Checks if the specified identifier exists or not.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public static bool Exists(string identifier)
        {
            return Exists(identifier, DefaultSettings);
        }

        /// <summary>
        /// Checks if the specified identifier exists or not.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public static bool Exists(string identifier, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            return settings.Storage.Exists(settings);
        }

        /// <summary>
        /// Gets the files.
        /// This method only works on platforms that support file storage.
        /// </summary>
        /// <returns>The files.</returns>
        public static FileInfo[] GetFiles()
        {
            return GetFiles(string.Empty, DefaultSettings);
        }

        /// <summary>
        /// Gets the files.
        /// This method only works on platforms that support file storage.
        /// </summary>
        /// <returns>The files.</returns>
        /// <param name="identifier">Identifier.</param>
        public static FileInfo[] GetFiles(string identifier)
        {
            return GetFiles(identifier, DefaultSettings);
        }

        /// <summary>
        /// Gets the files.
        /// This method only works on platforms that support file storage.
        /// </summary>
        /// <returns>The files.</returns>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public static FileInfo[] GetFiles(string identifier, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            return settings.Storage.GetFiles(settings);
        }

        /// <summary>
        /// Gets the directories.
        /// This method only works on platforms that support file storage.
        /// </summary>
        /// <returns>The directories.</returns>
        public static DirectoryInfo[] GetDirectories()
        {
            return GetDirectories(string.Empty, DefaultSettings);
        }

        /// <summary>
        /// Gets the directories.
        /// This method only works on platforms that support file storage.
        /// </summary>
        /// <returns>The directories.</returns>
        /// <param name="identifier">Identifier.</param>
        public static DirectoryInfo[] GetDirectories(string identifier)
        {
            return GetDirectories(identifier, DefaultSettings);
        }

        /// <summary>
        /// Gets the directories.
        /// This method only works on platforms that support file storage.
        /// </summary>
        /// <returns>The directories.</returns>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public static DirectoryInfo[] GetDirectories(string identifier, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            return settings.Storage.GetDirectories(settings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Saves the image Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="texture">Texture.</param>
        public static Task SaveImageAsync(string identifier, Texture2D texture)
        {
            return SaveImageAsync(identifier, texture, DefaultSettings);
        }
#endif

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="texture">Texture.</param>
        public static void SaveImage(string identifier, Texture2D texture)
        {
            SaveImage(identifier, texture, DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Saves the image Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="texture">Texture.</param>
        /// <param name="settings">Settings.</param>
        public static Task SaveImageAsync(string identifier, Texture2D texture, SaveGameSettings settings)
        {
            Task task = new Task(() =>
            {
                SaveGame.SaveImage(identifier, texture, settings);
            });
            task.Start();
            return task;
        }
#endif

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="texture">Texture.</param>
        /// <param name="settings">Settings.</param>
        public static void SaveImage(string identifier, Texture2D texture, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            string path = SaveGameFileStorage.GetAbsolutePath(settings.Identifier, settings.BasePath);
            File.WriteAllBytes(path, texture.EncodeToPNG());
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Loads the image Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public static Task<Texture2D> LoadImageAsync(string identifier)
        {
            return LoadImageAsync(identifier, DefaultSettings);
        }
#endif

        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="identifier">Identifier.</param>
        public static Texture2D LoadImage(string identifier)
        {
            return LoadImage(identifier, DefaultSettings);
        }

#if NET_4_6 || NET_STANDARD_2_0
        /// <summary>
        /// Loads the image Asynchronously.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public static Task<Texture2D> LoadImageAsync(string identifier, SaveGameSettings settings)
        {
            Task<Texture2D> task = new Task<Texture2D>(() =>
            {
                return SaveGame.LoadImage(identifier, settings);
            });
            task.Start();
            return task;
        }
#endif

        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public static Texture2D LoadImage(string identifier, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            string path = SaveGameFileStorage.GetAbsolutePath(settings.Identifier, settings.BasePath);
            byte[] data = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(0, 0);
            texture.LoadImage(data);
            return texture;
        }

        /// <summary>
        /// Gets the absolute path to the identifier.
        /// This method only works on platforms that support file storage.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static string GetAbsolutePath(string identifier)
        {
            return GetAbsolutePath(identifier, DefaultSettings);
        }

        /// <summary>
        /// Gets the absolute path to the identifier.
        /// This method only works on platforms that support file storage.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static string GetAbsolutePath(string identifier, SaveGameSettings settings)
        {
            settings.Identifier = identifier;
            return SaveGameFileStorage.GetAbsolutePath(settings.Identifier, settings.BasePath);
        }

        #endregion

    }

}