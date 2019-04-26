using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

using BayatGames.SaveGamePro.Reflection;
using BayatGames.SaveGamePro.Utilities;
//using System.Threading.Tasks;

namespace BayatGames.SaveGamePro.Networking
{

    /// <summary>
    /// Save Game Pro Cloud API.
    /// Extend this class to provide your own Save Game Pro Cloud integration.
    /// </summary>
    public abstract class SaveGameCloud
    {

        /// <summary>
        /// The settings.
        /// </summary>
        protected SaveGameSettings m_Settings;

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public virtual SaveGameSettings Settings
        {
            get
            {
                return m_Settings;
            }
            set
            {
                m_Settings = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.Networking.SaveGameCloud"/> class.
        /// </summary>
        public SaveGameCloud() : this(SaveGame.DefaultSettings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.Networking.SaveGameCloud"/> class.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public SaveGameCloud(SaveGameSettings settings)
        {
            m_Settings = settings;
        }

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual async Task SaveAsync<T>(string identifier, T value)
        {
            await SaveAsync(identifier, (object)value, Settings);
        }
#endif

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual IEnumerator Save<T>(string identifier, T value)
        {
            return Save(identifier, (object)value, Settings);
        }

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public virtual async Task SaveAsync(string identifier, object value)
        {
            await SaveAsync(identifier, value, Settings);
        }
#endif

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public virtual IEnumerator Save(string identifier, object value)
        {
            return Save(identifier, value, Settings);
        }

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual async Task SaveAsync<T>(string identifier, T value, SaveGameSettings settings)
        {
            await SaveAsync(identifier, (object)value, settings);
        }
#endif

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual IEnumerator Save<T>(string identifier, T value, SaveGameSettings settings)
        {
            return Save(identifier, (object)value, settings);
        }

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public virtual Task SaveAsync(string identifier, object value, SaveGameSettings settings)
        {
            throw new NotImplementedException();
        }
#endif

        /// <summary>
        /// Save the specified value using the identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public abstract IEnumerator Save(string identifier, object value, SaveGameSettings settings);

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Download the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public virtual async Task DownloadAsync(string identifier)
        {
            await DownloadAsync(identifier, Settings);
        }
#endif

        /// <summary>
        /// Download the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public virtual IEnumerator Download(string identifier)
        {
            return Download(identifier, Settings);
        }

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Download the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public virtual Task DownloadAsync(string identifier, SaveGameSettings settings)
        {
            throw new NotImplementedException();
        }
#endif

        /// <summary>
        /// Download the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public abstract IEnumerator Download(string identifier, SaveGameSettings settings);

        /// <summary>
        /// Load the value.
        /// </summary>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T Load<T>()
        {
            return (T)Load(typeof(T), default(T), Settings);
        }

        /// <summary>
        /// Load the value.
        /// </summary>
        /// <param name="type">Type.</param>
        public virtual object Load(Type type)
        {
            return Load(type, type.GetDefault(), Settings);
        }

        /// <summary>
        /// Load the value, if not exists, return the default value.
        /// </summary>
        /// <param name="defaultValue">Default value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T Load<T>(T defaultValue)
        {
            return (T)Load(typeof(T), defaultValue, Settings);
        }

        /// <summary>
        /// Load the value, if not exists, return the default value.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="defaultValue">Default value.</param>
        public virtual object Load(Type type, object defaultValue)
        {
            return Load(type, defaultValue, Settings);
        }

        /// <summary>
        /// Load the value.
        /// </summary>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T Load<T>(SaveGameSettings settings)
        {
            return (T)Load(typeof(T), default(T), settings);
        }

        /// <summary>
        /// Load the value.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="settings">Settings.</param>
        public virtual object Load(Type type, SaveGameSettings settings)
        {
            return Load(type, type.GetDefault(), settings);
        }

        /// <summary>
        /// Load the value, if not exists, return the default value.
        /// </summary>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T Load<T>(T defaultValue, SaveGameSettings settings)
        {
            if (defaultValue == null)
            {
                defaultValue = default(T);
            }
            return (T)Load(typeof(T), defaultValue, settings);
        }

        /// <summary>
        /// Load the value, if not exists, return the default value.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="settings">Settings.</param>
        public abstract object Load(Type type, object defaultValue, SaveGameSettings settings);

        /// <summary>
        /// Load the data into the value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual void LoadInto<T>(T value)
        {
            LoadInto((object)value, Settings);
        }

        /// <summary>
        /// Load the data into the value.
        /// </summary>
        /// <param name="value">Value.</param>
        public virtual void LoadInto(object value)
        {
            LoadInto(value, Settings);
        }

        /// <summary>
        /// Load the data into the value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual void LoadInto<T>(T value, SaveGameSettings settings)
        {
            LoadInto((object)value, settings);
        }

        /// <summary>
        /// Load the data into the value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public abstract void LoadInto(object value, SaveGameSettings settings);

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Clear the user data.
        /// </summary>
        public virtual async Task ClearAsync()
        {
            await ClearAsync(Settings);
        }
#endif

        /// <summary>
        /// Clear the user data.
        /// </summary>
        public virtual IEnumerator Clear()
        {
            return Clear(Settings);
        }

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Clear the user data.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public virtual Task ClearAsync(SaveGameSettings settings)
        {
            throw new NotImplementedException();
        }
#endif

        /// <summary>
        /// Clear the user data.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public abstract IEnumerator Clear(SaveGameSettings settings);

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Delete the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public virtual async Task DeleteAsync(string identifier)
        {
            await DeleteAsync(identifier, Settings);
        }
#endif

        /// <summary>
        /// Delete the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public virtual IEnumerator Delete(string identifier)
        {
            return Delete(identifier, Settings);
        }

#if CSHARP_7_3_OR_NEWER
        /// <summary>
        /// Delete the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public virtual Task DeleteAsync(string identifier, SaveGameSettings settings)
        {
            throw new NotImplementedException();
        }
#endif

        /// <summary>
        /// Delete the specified identifier.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="settings">Settings.</param>
        public abstract IEnumerator Delete(string identifier, SaveGameSettings settings);

    }

}