using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Serialization.Formatters.Binary
{

    /// <summary>
    /// Binary formatter.
    /// Serialize and Deserialize data binary representations.
    /// </summary>
    public class BinaryFormatter : ISaveGameFormatter
    {

        #region Constants

        public const byte PropertyStart = 100;
        public const byte PropertyEnd = 101;
        public const byte SaveGameTypeStart = 102;
        public const byte SaveGameTypeEnd = 103;
        public const byte Terminator = 104;

        #endregion

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

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryFormatter"/> class.
        /// </summary>
        public BinaryFormatter() : this(SaveGame.DefaultSettings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryFormatter"/> class.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public BinaryFormatter(SaveGameSettings settings)
        {
            m_Settings = settings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Serialize the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public virtual byte[] Serialize(object value)
        {
            using (MemoryStream output = new MemoryStream())
            {
                Serialize(output, value, Settings);
                return output.ToArray();
            }
        }

        /// <summary>
        /// Serialize the specified output and value.
        /// </summary>
        /// <param name="output">Output.</param>
        /// <param name="value">Value.</param>
        public virtual void Serialize(Stream output, object value)
        {
            Serialize(output, value, Settings);
        }

        /// <summary>
        /// Serialize the specified output, value and settings.
        /// </summary>
        /// <param name="output">Output.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public virtual void Serialize(Stream output, object value, SaveGameSettings settings)
        {
            using (BinaryObjectWriter writer = new BinaryObjectWriter(output, settings))
            {
                writer.Write(value);
            }
        }

        /// <summary>
        /// Deserialize the specified input.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T Deserialize<T>(Stream input)
        {
            return (T)Deserialize(input, typeof(T), Settings);
        }

        /// <summary>
        /// Deserialize the specified input and settings.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="settings">Settings.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T Deserialize<T>(Stream input, SaveGameSettings settings)
        {
            return (T)Deserialize(input, typeof(T), settings);
        }

        /// <summary>
        /// Deserialize the specified buffer.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual T Deserialize<T>(byte[] buffer)
        {
            return (T)Deserialize(buffer, typeof(T));
        }

        /// <summary>
        /// Deserialize the specified buffer and type.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="type">Type.</param>
        public virtual object Deserialize(byte[] buffer, Type type)
        {
            using (MemoryStream input = new MemoryStream(buffer))
            {
                return Deserialize(input, type, Settings);
            }
        }

        /// <summary>
        /// Deserialize the specified input.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual object Deserialize(Stream input, Type type)
        {
            return Deserialize(input, type, Settings);
        }

        /// <summary>
        /// Deserialize the specified input, type and settings.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="type">Type.</param>
        /// <param name="settings">Settings.</param>
        public virtual object Deserialize(Stream input, Type type, SaveGameSettings settings)
        {
            input.Position = 0L;
            using (BinaryObjectReader reader = new BinaryObjectReader(input, settings))
            {
                return reader.Read(type);
            }
        }

        /// <summary>
        /// Deserializes the into.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="value">Value.</param>
        public virtual void DeserializeInto(Stream input, object value)
        {
            DeserializeInto(input, value, Settings);
        }

        /// <summary>
        /// Deserializes the into.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public virtual void DeserializeInto(Stream input, object value, SaveGameSettings settings)
        {
            input.Position = 0L;
            using (BinaryObjectReader reader = new BinaryObjectReader(input, settings))
            {
                (reader as ISaveGameReader).ReadInto(value);
            }
        }

        /// <summary>
        /// Determines whether this instance is type supported the specified type.
        /// </summary>
        /// <returns><c>true</c> if this instance is type supported the specified type; otherwise, <c>false</c>.</returns>
        /// <param name="type">Type.</param>
        public virtual bool IsTypeSupported(Type type)
        {
            return true;
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="value">Value.</param>
        public static byte[] SerializeObject(object value)
        {
            BinaryFormatter formatter = new BinaryFormatter(SaveGame.DefaultSettings);
            return formatter.Serialize(value);
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="output">Output.</param>
        /// <param name="value">Value.</param>
        public static void SerializeObject(Stream output, object value)
        {
            BinaryFormatter formatter = new BinaryFormatter(SaveGame.DefaultSettings);
            formatter.Serialize(output, value);
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="buffer">Buffer.</param>
        /// <param name="type">Type.</param>
        public static object DeserializeObject(byte[] buffer, Type type)
        {
            BinaryFormatter formatter = new BinaryFormatter(SaveGame.DefaultSettings);
            return formatter.Deserialize(buffer, type);
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="input">Input.</param>
        /// <param name="type">Type.</param>
        public static object DeserializeObject(Stream input, Type type)
        {
            BinaryFormatter formatter = new BinaryFormatter(SaveGame.DefaultSettings);
            return formatter.Deserialize(input, type);
        }

        #endregion

    }

}