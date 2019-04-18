using System;
using System.IO;
using UnityEngine;

using BayatGames.SaveGamePro.IO;
using BayatGames.SaveGamePro.Reflection;
using BayatGames.SaveGamePro.Serialization;
using BayatGames.SaveGamePro.Serialization.Formatters.Binary;
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
        /// The Save Game Pro Version.
        /// </summary>
        public static readonly Version Version = new Version(2, 5, 1);

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

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public static void Save(string identifier, object value)
        {
            Save(identifier, value, DefaultSettings);
        }

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
            settings.Formatter.Serialize(settings.Storage.GetWriteStream(settings), value, settings);
            settings.Storage.OnSaved(settings);
            if (OnSaved != null)
            {
                OnSaved(identifier, value, settings);
            }
        }

        /// <summary>
        /// Load the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Load<T>(string identifier)
        {
            return (T)Load(identifier, typeof(T), default(T), DefaultSettings);
        }

        /// <summary>
        /// Load the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="type">Type.</param>
        public static object Load(string identifier, Type type)
        {
            return Load(identifier, type, type.GetDefault(), DefaultSettings);
        }

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
            object result = settings.Formatter.Deserialize(settings.Storage.GetReadStream(settings), type, settings);
            settings.Storage.OnLoaded(settings);
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

        /// <summary>
        /// Loads the data into the value.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public static void LoadInto(string identifier, object value)
        {
            LoadInto(identifier, value, DefaultSettings);
        }

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

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="texture">Texture.</param>
        public static void SaveImage(string identifier, Texture2D texture)
        {
            SaveImage(identifier, texture, DefaultSettings);
        }

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

        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="identifier">Identifier.</param>
        public static Texture2D LoadImage(string identifier)
        {
            return LoadImage(identifier, DefaultSettings);
        }

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