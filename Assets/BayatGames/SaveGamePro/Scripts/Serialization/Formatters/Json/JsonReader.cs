using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Serialization.Formatters.Json
{

    /// <summary>
    /// Json reader.
    /// </summary>
    public abstract class JsonReader : IDisposable, ISaveGameReader
    {

        #region Fields

        /// <summary>
        /// The settings.
        /// </summary>
        protected SaveGameSettings m_Settings;

        #endregion

        #region Properties

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
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public abstract IEnumerable<string> Properties { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonReader"/> class.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public JsonReader(SaveGameSettings settings)
        {
            m_Settings = settings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Read the specified type.
        /// </summary>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T Read<T>()
        {
            return (T)Read(typeof(T));
        }

        /// <summary>
        /// Read the specified type.
        /// </summary>
        /// <param name="type">Type.</param>
        public abstract object Read(Type type);

        /// <summary>
        /// Reads the into.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual void ReadInto<T>(T value)
        {
            ReadInto((object)value);
        }

        /// <summary>
        /// Reads the data into the value.
        /// </summary>
        /// <param name="value">Value.</param>
        public abstract void ReadInto(object value);

        /// <summary>
        /// Reads the property.
        /// </summary>
        /// <returns>The property.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T ReadProperty<T>()
        {
            return (T)ReadProperty(typeof(T));
        }

        /// <summary>
        /// Reads the property.
        /// </summary>
        /// <returns>The property.</returns>
        /// <param name="type">Type.</param>
        public abstract object ReadProperty(Type type);

        /// <summary>
        /// Reads the into property.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual void ReadIntoProperty<T>(T value)
        {
            ReadIntoProperty((object)value);
        }

        /// <summary>
        /// Reads the into property.
        /// </summary>
        /// <param name="value">Value.</param>
        public abstract void ReadIntoProperty(object value);

        /// <summary>
        /// Reads the savable members.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="type">Type.</param>
        public abstract void ReadSavableMembers(object obj, Type type);

        /// <summary>
        /// Reads into the savable members.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="type">Type.</param>
        public abstract void ReadIntoSavableMembers(object obj, Type type);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonReader"/>. The <see cref="Dispose"/> method
        /// leaves the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonReader"/> in an unusable state.
        /// After calling <see cref="Dispose"/>, you must release all references to the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonReader"/> so the garbage collector can reclaim
        /// the memory that the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonReader"/> was occupying.</remarks>
        public abstract void Dispose();

        #endregion

    }

}