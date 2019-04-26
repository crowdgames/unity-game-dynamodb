using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Serialization.Formatters.Json
{

    /// <summary>
    /// Json formatter.
    /// Serialize and Deserialize json representations.
    /// </summary>
    public class JsonFormatter : ISaveGameFormatter
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

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonFormatter"/> class.
        /// </summary>
        public JsonFormatter() : this(SaveGame.DefaultSettings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonFormatter"/> class.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public JsonFormatter(SaveGameSettings settings)
        {
            m_Settings = settings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Serialize the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public string Serialize(object value)
        {
            StringWriter output = new StringWriter();
            Serialize(output, value, Settings);
            return output.ToString();
        }

        /// <summary>
        /// Serialize the specified output and value.
        /// </summary>
        /// <param name="output">Output.</param>
        /// <param name="value">Value.</param>
        public void Serialize(Stream output, object value)
        {
            Serialize(output, value, Settings);
        }

        /// <summary>
        /// Serialize the specified output, value and settings.
        /// </summary>
        /// <param name="output">Output.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public void Serialize(Stream output, object value, SaveGameSettings settings)
        {
            Serialize(new StreamWriter(output, settings.Encoding), value, settings);
        }

        /// <summary>
        /// Serialize the specified output and value.
        /// </summary>
        /// <param name="output">Output.</param>
        /// <param name="value">Value.</param>
        public void Serialize(TextWriter output, object value)
        {
            Serialize(output, value, Settings);
        }

        /// <summary>
        /// Serialize the specified output, value and settings.
        /// </summary>
        /// <param name="output">Output.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public void Serialize(TextWriter output, object value, SaveGameSettings settings)
        {
            using (JsonWriter writer = new JsonTextWriter(output, settings))
            {
                writer.Write(value);
            }
        }

        /// <summary>
        /// Deserialize the specified input.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T Deserialize<T>(string input)
        {
            return (T)Deserialize(input, typeof(T));
        }

        /// <summary>
        /// Deserialize the specified input.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T Deserialize<T>(Stream input)
        {
            return (T)Deserialize(input, typeof(T), Settings);
        }

        /// <summary>
        /// Deserialize the specified input.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T Deserialize<T>(TextReader input)
        {
            return (T)Deserialize(input, typeof(T), Settings);
        }

        /// <summary>
        /// Deserialize the specified input and type.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="type">Type.</param>
        public object Deserialize(string input, Type type)
        {
            return Deserialize(new StringReader(input), type, Settings);
        }

        /// <summary>
        /// Deserialize the specified input and type.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="type">Type.</param>
        public object Deserialize(Stream input, Type type)
        {
            return Deserialize(input, type, Settings);
        }

        /// <summary>
        /// Deserialize the specified input, type and settings.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="type">Type.</param>
        /// <param name="settings">Settings.</param>
        public object Deserialize(Stream input, Type type, SaveGameSettings settings)
        {
            input.Position = 0L;
            return Deserialize(new StreamReader(input, settings.Encoding), type, settings);
        }

        /// <summary>
        /// Deserialize the specified input and type.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="type">Type.</param>
        public object Deserialize(TextReader input, Type type)
        {
            return Deserialize(input, type, Settings);
        }

        /// <summary>
        /// Deserialize the specified input, type and settings.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="type">Type.</param>
        /// <param name="settings">Settings.</param>
        public object Deserialize(TextReader input, Type type, SaveGameSettings settings)
        {
            using (JsonReader reader = new JsonTextReader(input, settings))
            {
                return reader.Read(type);
            }
        }

        /// <summary>
        /// Deserializes the into.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="value">Value.</param>
        public void DeserializeInto(Stream input, object value)
        {
            DeserializeInto(input, value, Settings);
        }

        /// <summary>
        /// Deserializes the into.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public void DeserializeInto(Stream input, object value, SaveGameSettings settings)
        {
            input.Position = 0L;
            DeserializeInto(new StreamReader(input, settings.Encoding), value, settings);
        }

        /// <summary>
        /// Deserializes the into.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="value">Value.</param>
        public void DeserializeInto(TextReader input, object value)
        {
            DeserializeInto(input, value, Settings);
        }

        /// <summary>
        /// Deserializes the into.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="value">Value.</param>
        /// <param name="settings">Settings.</param>
        public void DeserializeInto(TextReader input, object value, SaveGameSettings settings)
        {
            using (JsonReader reader = new JsonTextReader(input, settings))
            {
                reader.ReadInto(value);
            }
        }

        /// <summary>
        /// Determines whether this instance is type supported the specified type.
        /// </summary>
        /// <returns><c>true</c> if this instance is type supported the specified type; otherwise, <c>false</c>.</returns>
        /// <param name="type">Type.</param>
        public bool IsTypeSupported(Type type)
        {
            if (type.IsArray && type.GetArrayRank() > 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="value">Value.</param>
        public static string SerializeObject(object value)
        {
            JsonFormatter formatter = new JsonFormatter(SaveGame.DefaultSettings);
            return formatter.Serialize(value);
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="json">Json.</param>
        /// <param name="type">Type.</param>
        public static object DeserializeObject(string json, Type type)
        {
            JsonFormatter formatter = new JsonFormatter(SaveGame.DefaultSettings);
            return formatter.Deserialize(json, type);
        }

        #endregion

    }

}