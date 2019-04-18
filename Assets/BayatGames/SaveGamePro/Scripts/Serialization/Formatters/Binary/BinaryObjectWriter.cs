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

namespace BayatGames.SaveGamePro.Serialization.Formatters.Binary
{

    /// <summary>
    /// Binary object writer.
    /// </summary>
    public class BinaryObjectWriter : IDisposable, ISaveGameWriter
    {

        #region Fields

        /// <summary>
        /// The writer.
        /// </summary>
        protected BinaryWriter m_Writer;

        /// <summary>
        /// The settings.
        /// </summary>
        protected SaveGameSettings m_Settings;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the writer.
        /// </summary>
        /// <value>The writer.</value>
        public virtual BinaryWriter Writer
        {
            get
            {
                return m_Writer;
            }
        }

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
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectWriter"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        public BinaryObjectWriter(Stream stream, SaveGameSettings settings) : this(new BinaryWriter(
                stream,
                settings.Encoding), settings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectWriter"/> class.
        /// </summary>
        /// <param name="writer">Writer.</param>
        public BinaryObjectWriter(BinaryWriter writer, SaveGameSettings settings)
        {
            m_Writer = writer;
            m_Settings = settings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Write the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual void Write<T>(T value)
        {
            Write((object)value);
        }

        /// <summary>
        /// Write the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public virtual void Write(object value)
        {
            m_Writer.Write(value != null);
            if (value == null)
            {
                return;
            }
            else
            {
                Type type = value.GetType();
                bool isPrimitive = false;
                bool isEnum = false;
                bool isSerializable = false;
                bool isGeneric = false;
                bool isGenericCollection = false;
#if (UNITY_WSA || UNITY_WINRT) && !UNITY_EDITOR
                TypeInfo info = type.GetTypeInfo();
                isPrimitive = info.IsPrimitive;
                isEnum = info.IsEnum;
                isSerializable = info.IsSerializable;
                isGeneric = info.IsGenericType;
#else
                isPrimitive = type.IsPrimitive;
                isEnum = type.IsEnum;
                isSerializable = type.IsSerializable;
                isGeneric = type.IsGenericType;
#endif
                isGenericCollection = type.GetInterfaces().Contains(typeof(ICollection<>));
                if (type == typeof(UnityEngine.GameObject))
                {
                    UnityEngine.GameObject gameObject = value as UnityEngine.GameObject;

                    m_Writer.BaseStream.WriteByte(BinaryFormatter.SaveGameTypeStart);
                    long position = m_Writer.BaseStream.Position;
                    m_Writer.Write(0L);

                    WriteProperty("layer", gameObject.layer);
                    WriteProperty("isStatic", gameObject.isStatic);
                    WriteProperty("tag", gameObject.tag);
                    WriteProperty("name", gameObject.name);
                    WriteProperty("hideFlags", gameObject.hideFlags);

                    long lastPosition = m_Writer.BaseStream.Position;
                    m_Writer.BaseStream.Position = position;
                    m_Writer.Write(lastPosition);
                    m_Writer.BaseStream.Position = lastPosition;
                    m_Writer.BaseStream.WriteByte(BinaryFormatter.SaveGameTypeEnd);

                    UnityEngine.Component[] components = gameObject.GetComponents<UnityEngine.Component>();
                    m_Writer.Write("components");
                    m_Writer.Write(components.Length);
                    for (int i = 0; i < components.Length; i++)
                    {
                        m_Writer.Write(components[i].GetType().AssemblyQualifiedName);
                        Write(components[i]);
                    }
                    components = null;
                    List<UnityEngine.GameObject> childs = new List<UnityEngine.GameObject>();
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        childs.Add(gameObject.transform.GetChild(i).gameObject);
                    }
                    m_Writer.Write("childs");
                    m_Writer.Write(childs.Count);
                    for (int i = 0; i < childs.Count; i++)
                    {
                        Write(childs[i]);
                    }
                    childs = null;
                }
                else if (isPrimitive || type == typeof(string) || type == typeof(decimal))
                {
                    if (type == typeof(string))
                    {
                        m_Writer.Write((string)value);
                    }
                    else if (type == typeof(decimal))
                    {
                        m_Writer.Write((decimal)value);
                    }
                    else if (type == typeof(short))
                    {
                        m_Writer.Write((short)value);
                    }
                    else if (type == typeof(int))
                    {
                        m_Writer.Write((int)value);
                    }
                    else if (type == typeof(long))
                    {
                        m_Writer.Write((long)value);
                    }
                    else if (type == typeof(ushort))
                    {
                        m_Writer.Write((ushort)value);
                    }
                    else if (type == typeof(uint))
                    {
                        m_Writer.Write((uint)value);
                    }
                    else if (type == typeof(ulong))
                    {
                        m_Writer.Write((ulong)value);
                    }
                    else if (type == typeof(double))
                    {
                        m_Writer.Write((double)value);
                    }
                    else if (type == typeof(float))
                    {
                        m_Writer.Write((float)value);
                    }
                    else if (type == typeof(byte))
                    {
                        m_Writer.Write((byte)value);
                    }
                    else if (type == typeof(sbyte))
                    {
                        m_Writer.Write((sbyte)value);
                    }
                    else if (type == typeof(char))
                    {
                        m_Writer.Write((char)value);
                    }
                    else if (type == typeof(bool))
                    {
                        m_Writer.Write((bool)value);
                    }
                }
                else if (isEnum)
                {
                    m_Writer.Write(value.ToString());
                }
                else if (type == typeof(DateTime))
                {
                    m_Writer.Write(((DateTime)value).ToBinary());
                }
                else if (type == typeof(TimeSpan))
                {
                    m_Writer.Write(((TimeSpan)value).ToString());
                }
                else if (type.IsArray)
                {
                    Array array = value as Array;
                    int[] indices = new int[array.Rank];
                    m_Writer.Write(array.Rank);
                    for (int i = 0; i < array.Rank; i++)
                    {
                        m_Writer.Write(array.GetLength(i));
                        indices[i] = array.GetLowerBound(i);
                    }
                    indices[array.Rank - 1]--;
                    bool complete = false;
                    while (!complete)
                    {
                        indices[array.Rank - 1]++;
                        for (int i = array.Rank - 1; i >= 0; i--)
                        {
                            if (indices[i] > array.GetUpperBound(i))
                            {
                                if (i == 0)
                                {
                                    complete = true;
                                    break;
                                }
                                for (int j = i; j < array.Rank; j++)
                                {
                                    indices[j] = array.GetLowerBound(j);
                                }
                                indices[i - 1]++;
                            }
                        }
                        if (!complete)
                        {
                            Write(array.GetValue(indices));
                        }
                    }
                }
                else if (value is IEnumerable && (value is ICollection || isGenericCollection))
                {
                    IEnumerable enumerable = value as IEnumerable;
                    int count = (int)type.GetProperty("Count").GetValue(value, null);
                    IEnumerator e = enumerable.GetEnumerator();
                    m_Writer.Write(count);
                    while (e.MoveNext())
                    {
                        Write(e.Current);
                    }
                }
                else if (type == typeof(DictionaryEntry))
                {
                    DictionaryEntry entry = (DictionaryEntry)value;
                    m_Writer.Write(entry.Key.GetType().AssemblyQualifiedName);
                    Write(entry.Key);
                    m_Writer.Write(entry.Value.GetType().AssemblyQualifiedName);
                    Write(entry.Value);
                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                {
                    Write(type.GetProperty("Key").GetValue(value, null));
                    Write(type.GetProperty("Value").GetValue(value, null));
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
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public virtual void WriteProperty<T>(string identifier, T value)
        {
            WriteProperty(identifier, (object)value);
        }

        /// <summary>
        /// Writes the property.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="value">Value.</param>
        public virtual void WriteProperty(string identifier, object value)
        {
            m_Writer.BaseStream.WriteByte(BinaryFormatter.PropertyStart);
            m_Writer.Write(identifier);
            long position = m_Writer.BaseStream.Position;
            m_Writer.Write(0L);
            Write(value);
            long lastPosition = m_Writer.BaseStream.Position;
            m_Writer.BaseStream.Position = position;
            m_Writer.Write(lastPosition);
            m_Writer.BaseStream.Position = lastPosition;
            m_Writer.BaseStream.WriteByte(BinaryFormatter.PropertyEnd);
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
                ISavable savable = value as ISavable;
                savable.OnWrite(this);
            }
            else if (SaveGameTypeManager.HasType(type))
            {
                m_Writer.BaseStream.WriteByte(BinaryFormatter.SaveGameTypeStart);
                long position = m_Writer.BaseStream.Position;
                m_Writer.Write(0L);
                SaveGameType saveGameType = SaveGameTypeManager.GetType(type);
                saveGameType.Write(value, this);
                long lastPosition = m_Writer.BaseStream.Position;
                m_Writer.BaseStream.Position = position;
                m_Writer.Write(lastPosition);
                m_Writer.BaseStream.Position = lastPosition;
                m_Writer.BaseStream.WriteByte(BinaryFormatter.SaveGameTypeEnd);
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
        /// <param name="value">Value.</param>
        /// <param name="type">Type.</param>
        public virtual void WriteSavableMembers(object value, Type type)
        {
            WriteSavableFields(value, type);
            WriteSavableProperties(value, type);
        }

        /// <summary>
        /// Writes the savable fields.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="type">Type.</param>
        public virtual void WriteSavableFields(object value, Type type)
        {
            List<FieldInfo> fields = type.GetSavableFields();
            m_Writer.Write(fields.Count);
            for (int i = 0; i < fields.Count; i++)
            {
                m_Writer.Write(fields[i].Name);
                Write(fields[i].GetValue(value));
            }
        }

        /// <summary>
        /// Writes the savable properties.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="type">Type.</param>
        public virtual void WriteSavableProperties(object value, Type type)
        {
            List<PropertyInfo> properties = type.GetSavableProperties();
            m_Writer.Write(properties.Count);
            for (int i = 0; i < properties.Count; i++)
            {
                m_Writer.Write(properties[i].Name);
                Write(properties[i].GetValue(value, null));
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
            m_Writer.Write(info.MemberCount);
            while (e.MoveNext())
            {
                m_Writer.Write(e.Name);
                Write(e.Value);
            }
        }
#endif

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectWriter"/>. The <see cref="Dispose"/>
        /// method leaves the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectWriter"/> in an
        /// unusable state. After calling <see cref="Dispose"/>, you must release all references to the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectWriter"/> so the garbage collector
        /// can reclaim the memory that the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectWriter"/> was occupying.</remarks>
        public virtual void Dispose()
        {
            if (m_Writer != null)
            {
                (m_Writer as IDisposable).Dispose();
            }
        }

        #endregion

    }

}