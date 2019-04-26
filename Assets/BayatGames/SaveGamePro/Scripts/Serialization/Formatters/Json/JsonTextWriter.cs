using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Reflection;

using BayatGames.SaveGamePro.Reflection;
using BayatGames.SaveGamePro.Serialization.Types;
using BayatGames.SaveGamePro.Utilities;

namespace BayatGames.SaveGamePro.Serialization.Formatters.Json
{

    /// <summary>
    /// Json text writer.
    /// </summary>
    public class JsonTextWriter : JsonWriter
    {

        #region Fields

        /// <summary>
        /// The writer.
        /// </summary>
        protected TextWriter m_Writer;

        /// <summary>
        /// The is first property.
        /// </summary>
        protected bool m_IsFirstProperty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the writer.
        /// </summary>
        /// <value>The writer.</value>
        public virtual TextWriter Writer
        {
            get
            {
                return m_Writer;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextWriter"/> class.
        /// </summary>
        /// <param name="writer">Writer.</param>
        /// <param name="settings">Settings.</param>
        public JsonTextWriter(TextWriter writer, SaveGameSettings settings) : base(settings)
        {
            m_Writer = writer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Write the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public override void Write(object value)
        {
            if (value == null)
            {
                m_Writer.Write("null");
            }
            else
            {
                Type type = value.GetType();
                bool isEnum = false;
                bool isSerializable = false;
                bool isGeneric = false;
                bool isGenericCollection = false;
#if (UNITY_WSA || UNITY_WINRT) && !UNITY_EDITOR
				TypeInfo info = type.GetTypeInfo ();
				isEnum = info.IsEnum;
				isSerializable = info.IsSerializable;
				isGeneric = info.IsGenericType;
#else
                isEnum = type.IsEnum;
                isSerializable = type.IsSerializable;
                isGeneric = type.IsGenericType;
#endif
                isGenericCollection = type.GetInterfaces().Contains(typeof(ICollection<>));
                if (type == typeof(UnityEngine.GameObject))
                {
                    m_Writer.Write("{");
                    UnityEngine.GameObject gameObject = value as UnityEngine.GameObject;
                    m_IsFirstProperty = true;
                    WriteProperty("layer", gameObject.layer);
                    WriteProperty("isStatic", gameObject.isStatic);
                    WriteProperty("tag", gameObject.tag);
                    WriteProperty("name", gameObject.name);
                    WriteProperty("hideFlags", gameObject.hideFlags);
                    m_Writer.Write(",");
                    Write("components");
                    m_Writer.Write(":");
                    m_Writer.Write("[");
                    UnityEngine.Component[] components = gameObject.GetComponents<UnityEngine.Component>();
                    bool isFirst = true;
                    for (int i = 0; i < components.Length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            m_Writer.Write(",");
                        }
                        m_Writer.Write("{");
                        Write("type");
                        m_Writer.Write(":");
                        Write(components[i].GetType().AssemblyQualifiedName);
                        m_Writer.Write(",");
                        Write("component");
                        m_Writer.Write(":");
                        Write(components[i]);
                        m_Writer.Write("}");
                    }
                    m_Writer.Write("]");
                    m_Writer.Write(",");
                    Write("childs");
                    m_Writer.Write(":");
                    List<UnityEngine.GameObject> childs = new List<UnityEngine.GameObject>();
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        childs.Add(gameObject.transform.GetChild(i).gameObject);
                    }
                    Write(childs);
                    m_Writer.Write("}");
                }
                else if (type == typeof(string) || isEnum)
                {
                    m_Writer.Write("\"{0}\"", value.ToString().EscapeStringJson());
                }
                else if (type == typeof(bool))
                {
                    m_Writer.Write(value.ToString().ToLower());
                }
                else if (type == typeof(short) || type == typeof(int) || type == typeof(long) ||
                          type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong) ||
                          type == typeof(byte) || type == typeof(sbyte) || type == typeof(decimal) ||
                          type == typeof(double) || type == typeof(float))
                {
                    m_Writer.Write(Convert.ChangeType(Convert.ToDecimal(value), typeof(string)));
                }
                else if (type == typeof(DictionaryEntry))
                {
                    DictionaryEntry entry = (DictionaryEntry)value;
                    m_Writer.Write("{");
                    Write("KeyType");
                    m_Writer.Write(":");
                    Write(entry.Key.GetType().AssemblyQualifiedName);
                    m_Writer.Write(",");
                    Write("Key");
                    m_Writer.Write(":");
                    Write(entry.Key);
                    m_Writer.Write(",");
                    Write("ValueType");
                    m_Writer.Write(":");
                    Write(entry.Value.GetType().AssemblyQualifiedName);
                    m_Writer.Write(",");
                    Write("Value");
                    m_Writer.Write(":");
                    Write(entry.Value);
                    m_Writer.Write("}");
                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                {
                    m_Writer.Write("{");
                    Write("Key");
                    m_Writer.Write(":");
                    Write(type.GetProperty("Key").GetValue(value, null));
                    m_Writer.Write(",");
                    Write("Value");
                    m_Writer.Write(":");
                    Write(type.GetProperty("Value").GetValue(value, null));
                    m_Writer.Write("}");
                }
                else if (value is Hashtable)
                {
                    Hashtable hashtable = value as Hashtable;
                    bool isFirst = true;
                    m_Writer.Write("[");
                    foreach (DictionaryEntry entry in hashtable)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            m_Writer.Write(",");
                        }
                        Write(entry);
                    }
                    m_Writer.Write("]");
                }
                else if (value is IDictionary)
                {
                    IDictionary dictionary = value as IDictionary;
                    bool isFirst = true;
                    m_Writer.Write("{");
                    foreach (var key in dictionary.Keys)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            m_Writer.Write(",");
                        }
                        Write(key);
                        m_Writer.Write(":");
                        Write(dictionary[key]);
                    }
                    m_Writer.Write("}");
                }
                else if (value is IEnumerable && (value is ICollection || isGenericCollection))
                {
                    IEnumerable enumerable = value as IEnumerable;
                    IEnumerator e = enumerable.GetEnumerator();
                    bool isFirst = true;
                    m_Writer.Write("[");
                    while (e.MoveNext())
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            m_Writer.Write(",");
                        }
                        Write(e.Current);
                    }
                    m_Writer.Write("]");
                }
                else
                {
                    WriteObject(value, type);
                }
            }
        }

        /// <summary>
        /// Writes the property.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public override void WriteProperty(string identifier, object value)
        {
            if (m_IsFirstProperty)
            {
                m_IsFirstProperty = false;
            }
            else
            {
                m_Writer.Write(",");
            }
            Write(identifier);
            m_Writer.Write(":");
            Write(value);
        }

        /// <summary>
        /// Writes the object.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="type">Type.</param>
        protected virtual void WriteObject(object value, Type type)
        {
            if (value is ISavable)
            {
                m_Writer.Write("{");
                m_IsFirstProperty = true;
                ISavable savable = value as ISavable;
                savable.OnWrite(this);
                m_Writer.Write("}");
            }
            else if (SaveGameTypeManager.HasType(type))
            {
                m_Writer.Write("{");
                m_IsFirstProperty = true;
                SaveGameType saveGameType = SaveGameTypeManager.GetType(type);
                saveGameType.Write(value, this);
                m_Writer.Write("}");
            }
#if !UNITY_WSA || !UNITY_WINRT
            else if (value is ISerializable)
            {
                SerializationInfo info = new SerializationInfo(type, new FormatterConverter());
                ISerializable serializable = value as ISerializable;
                serializable.GetObjectData(info, new StreamingContext(StreamingContextStates.All));
                WriteSerializationInfo(info);
            }
#endif
            else
            {
                WriteSavableMembers(value, type);
            }
        }

        /// <summary>
        /// Writes the savable members.
        /// </summary>
        public override void WriteSavableMembers(object obj, Type type)
        {
            bool isFirst = true;
            m_Writer.Write("{");
            WriteSavableFields(obj, type, ref isFirst);
            WriteSavableProperties(obj, type, ref isFirst);
            m_Writer.Write("}");
        }

        /// <summary>
        /// Writes the savable fields.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="type">Type.</param>
        public virtual void WriteSavableFields(object obj, Type type, ref bool isFirst)
        {
            List<FieldInfo> fields = type.GetSavableFields();
            for (int i = 0; i < fields.Count; i++)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    m_Writer.Write(",");
                }
                Write(fields[i].Name);
                m_Writer.Write(":");
                Write(fields[i].GetValue(obj));
            }
        }

        /// <summary>
        /// Writes the savable properties.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="type">Type.</param>
        public virtual void WriteSavableProperties(object obj, Type type, ref bool isFirst)
        {
            List<PropertyInfo> properties = type.GetSavableProperties();
            for (int i = 0; i < properties.Count; i++)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    m_Writer.Write(",");
                }
                Write(properties[i].Name);
                m_Writer.Write(":");
                Write(properties[i].GetValue(obj, null));
            }
        }

#if !UNITY_WSA || !UNITY_WINRT
        /// <summary>
        /// Writes the serialization info.
        /// </summary>
        /// <param name="info">Info.</param>
        protected virtual void WriteSerializationInfo(SerializationInfo info)
        {
            var e = info.GetEnumerator();
            bool isFirst = true;
            m_Writer.Write("{");
            while (e.MoveNext())
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    m_Writer.Write(",");
                }
                Write(e.Name);
                m_Writer.Write(":");
                Write(e.Value);
            }
            m_Writer.Write("}");
        }
#endif

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextWriter"/>. The <see cref="Dispose"/>
        /// method leaves the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextWriter"/> in an unusable
        /// state. After calling <see cref="Dispose"/>, you must release all references to the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextWriter"/> so the garbage collector can
        /// reclaim the memory that the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextWriter"/> was occupying.</remarks>
        public override void Dispose()
        {
            if (m_Writer != null)
            {
                m_Writer.Dispose();
            }
        }

        #endregion

    }

}