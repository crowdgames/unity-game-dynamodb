using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;

using BayatGames.SaveGamePro.Reflection;
using BayatGames.SaveGamePro.Serialization.Types;
using BayatGames.SaveGamePro.Utilities;

namespace BayatGames.SaveGamePro.Serialization.Formatters.Binary
{

    /// <summary>
    /// Binary object reader.
    /// </summary>
    public class BinaryObjectReader : IDisposable, ISaveGameReader
    {

        #region Fields

        /// <summary>
        /// The reader.
        /// </summary>
        protected BinaryReader m_Reader;

        /// <summary>
        /// The settings.
        /// </summary>
        protected SaveGameSettings m_Settings;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the reader.
        /// </summary>
        /// <value>The reader.</value>
        public virtual BinaryReader Reader
        {
            get
            {
                return m_Reader;
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

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public virtual IEnumerable<string> Properties
        {
            get
            {
                return GetProperties();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectReader"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="settings">Settings.</param>
        public BinaryObjectReader(Stream stream, SaveGameSettings settings) : this(new BinaryReader(
                stream,
                settings.Encoding), settings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectReader"/> class.
        /// </summary>
        /// <param name="reader">Reader.</param>
        /// <param name="settings">Settings.</param>
        public BinaryObjectReader(BinaryReader reader, SaveGameSettings settings)
        {
            m_Reader = reader;
            m_Settings = settings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Read this instance.
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
        public virtual object Read(Type type)
        {
            Type nullableType = null;
            object result = null;
            if (type == null || !m_Reader.ReadBoolean())
            {
                result = null;
            }
            else
            {
                if (Nullable.GetUnderlyingType(type) != null)
                {
                    nullableType = type;
                    type = Nullable.GetUnderlyingType(type);
                }
                bool isPrimitive = false;
                bool isEnum = false;
                bool isSerializable = false;
                bool isGeneric = false;
#if (UNITY_WSA || UNITY_WINRT) && !UNITY_EDITOR
				TypeInfo info = type.GetTypeInfo ();
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
                if (type == typeof(UnityEngine.GameObject))
                {

                    // Skip save game type start
                    m_Reader.ReadByte();
                    m_Reader.ReadInt64();

                    int layer = ReadProperty<int>();
                    bool isStatic = ReadProperty<bool>();
                    string tag = ReadProperty<string>();
                    string name = ReadProperty<string>();
                    UnityEngine.HideFlags hideFlags = ReadProperty<UnityEngine.HideFlags>();

                    // Skip save game type end
                    m_Reader.ReadByte();

                    UnityEngine.GameObject gameObject = new UnityEngine.GameObject(name)
                    {
                        layer = layer,
                        isStatic = isStatic,
                        tag = tag,
                        hideFlags = hideFlags
                    };

                    m_Reader.ReadString();
                    int count = m_Reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        string typeName = m_Reader.ReadString();
                        Type componentType = Type.GetType(typeName);
                        UnityEngine.Component component = gameObject.GetComponent(componentType);
                        if (componentType != typeof(UnityEngine.Transform) && componentType.BaseType != typeof(UnityEngine.Transform))
                        {
                            UnityEngine.Component newComponent = gameObject.AddComponent(componentType);
                            if (newComponent != null)
                            {
                                component = newComponent;
                            }
                        }
                        ReadInto(component);
                    }

                    m_Reader.ReadString();
                    count = m_Reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        ReadChild(gameObject);
                    }
                    result = gameObject;
                }
                else if (isPrimitive || type == typeof(string) || type == typeof(decimal))
                {
                    if (type == typeof(string))
                    {
                        result = m_Reader.ReadString();
                    }
                    else if (type == typeof(decimal))
                    {
                        result = m_Reader.ReadDecimal();
                    }
                    else if (type == typeof(short))
                    {
                        result = m_Reader.ReadInt16();
                    }
                    else if (type == typeof(int))
                    {
                        result = m_Reader.ReadInt32();
                    }
                    else if (type == typeof(long))
                    {
                        result = m_Reader.ReadInt64();
                    }
                    else if (type == typeof(ushort))
                    {
                        result = m_Reader.ReadUInt16();
                    }
                    else if (type == typeof(uint))
                    {
                        result = m_Reader.ReadUInt32();
                    }
                    else if (type == typeof(ulong))
                    {
                        result = m_Reader.ReadUInt64();
                    }
                    else if (type == typeof(double))
                    {
                        result = m_Reader.ReadDouble();
                    }
                    else if (type == typeof(float))
                    {
                        result = m_Reader.ReadSingle();
                    }
                    else if (type == typeof(byte))
                    {
                        result = m_Reader.ReadByte();
                    }
                    else if (type == typeof(sbyte))
                    {
                        result = m_Reader.ReadSByte();
                    }
                    else if (type == typeof(char))
                    {
                        result = m_Reader.ReadChar();
                    }
                    else if (type == typeof(bool))
                    {
                        result = m_Reader.ReadBoolean();
                    }
                }
                else if (isEnum)
                {
                    result = Enum.Parse(type, m_Reader.ReadString());
                }
                else if (type == typeof(DateTime))
                {
                    result = DateTime.FromBinary(m_Reader.ReadInt64());
                }
                else if (type == typeof(TimeSpan))
                {
                    result = TimeSpan.Parse(m_Reader.ReadString());
                }
                else if (type.IsArray)
                {
                    Type elementType = type.GetElementType();
                    int rank = m_Reader.ReadInt32();
                    int[] lengths = new int[rank];
                    for (int i = 0; i < rank; i++)
                    {
                        lengths[i] = m_Reader.ReadInt32();
                    }
                    Array array = Array.CreateInstance(elementType, lengths);
                    int[] indices = new int[array.Rank];
                    for (int i = 0; i < array.Rank; i++)
                    {
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
                            array.SetValue(Read(elementType), indices);
                        }
                    }
                    result = array;
                }
                else if (type == typeof(DictionaryEntry))
                {
                    DictionaryEntry entry = new DictionaryEntry();
                    Type keyType = Type.GetType(m_Reader.ReadString());
                    entry.Key = Read(keyType);
                    Type valueType = Type.GetType(m_Reader.ReadString());
                    entry.Value = Read(valueType);
                    result = entry;
                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                {
                    Type[] genericArgs = type.GetGenericArguments();
                    result = Activator.CreateInstance(type, Read(genericArgs[0]), Read(genericArgs[1]));
                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type[] genericArgs = type.GetGenericArguments();
                    IList list = (IList)Activator.CreateInstance(type);
                    int length = m_Reader.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        list.Add(Read(genericArgs[0]));
                    }
                    result = list;
                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(LinkedList<>))
                {
                    Type[] genericArgs = type.GetGenericArguments();
                    object linkedList = Activator.CreateInstance(type);
                    MethodInfo addLast = type.GetMethod("AddLast", genericArgs);
                    int length = m_Reader.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        addLast.Invoke(linkedList, new object[] { Read(genericArgs[0]) });
                    }
                    result = linkedList;
                }
                else if (isGeneric && (type.GetGenericTypeDefinition() == typeof(Dictionary<,>) ||
                          type.GetGenericTypeDefinition() == typeof(SortedDictionary<,>) ||
                          type.GetGenericTypeDefinition() == typeof(SortedList<,>)))
                {
                    Type[] genericArgs = type.GetGenericArguments();
                    IDictionary dictionary = (IDictionary)Activator.CreateInstance(type);
                    int length = m_Reader.ReadInt32();
                    Type keyValuePairType = typeof(KeyValuePair<,>).MakeGenericType(genericArgs);
                    PropertyInfo keyProperty = keyValuePairType.GetProperty("Key", TypeUtils.SavableBindingFlags);
                    PropertyInfo valueProperty = keyValuePairType.GetProperty("Value", TypeUtils.SavableBindingFlags);
                    for (int i = 0; i < length; i++)
                    {
                        object keyValuePair = Read(keyValuePairType);
                        dictionary.Add(keyProperty.GetValue(keyValuePair, null), valueProperty.GetValue(keyValuePair, null));
                    }
                    result = dictionary;
                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(Stack<>))
                {
                    Type[] genericArgs = type.GetGenericArguments();
                    object stack = Activator.CreateInstance(type);
                    MethodInfo push = type.GetMethod("Push");
                    int length = m_Reader.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        push.Invoke(stack, new object[] { Read(genericArgs[0]) });
                    }
                    result = stack;
                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(Queue<>))
                {
                    Type[] genericArgs = type.GetGenericArguments();
                    object queue = Activator.CreateInstance(type);
                    MethodInfo enqueue = type.GetMethod("Enqueue");
                    int length = m_Reader.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        enqueue.Invoke(queue, new object[] { Read(genericArgs[0]) });
                    }
                    result = queue;
                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(HashSet<>))
                {
                    Type[] genericArgs = type.GetGenericArguments();
                    object hashSet = Activator.CreateInstance(type);
                    MethodInfo addMethod = type.GetMethod("Add");
                    int length = m_Reader.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        addMethod.Invoke(hashSet, new object[] { Read(genericArgs[0]) });
                    }
                    result = hashSet;
                }
                else if (type == typeof(Hashtable))
                {
                    Hashtable hashtable = new Hashtable();
                    int length = m_Reader.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        DictionaryEntry entry = Read<DictionaryEntry>();
                        hashtable.Add(entry.Key, entry.Value);
                    }
                    result = hashtable;
                }
                else if (SaveGameTypeManager.HasType(type))
                {

                    // Skip save game type start
                    m_Reader.ReadByte();
                    m_Reader.ReadInt64();

                    SaveGameType saveGameType = SaveGameTypeManager.GetType(type);
                    result = saveGameType.Read(this);

                    // Skip save game type end
                    m_Reader.ReadByte();

                }
                else
                {
                    result = ReadObject(type);
                }
            }
#if !(UNITY_WSA || UNITY_WINRT) || UNITY_EDITOR
            if (result is IDeserializationCallback)
            {
                (result as IDeserializationCallback).OnDeserialization(this);
            }
#endif
            if (nullableType != null)
            {
                Type genericType = type.GetNullableType();
                result = Activator.CreateInstance(genericType, result);
            }
            return result;
        }

        /// <summary>
        /// Reads the data into the value.
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
        public virtual void ReadInto(object value)
        {
            if (value == null || !m_Reader.ReadBoolean())
            {
                return;
            }
            Type type = value.GetType();
            bool isGeneric = false;
#if (UNITY_WSA || UNITY_WINRT) && !UNITY_EDITOR
			TypeInfo info = type.GetTypeInfo ();
			isGeneric = info.IsGenericType;
#else
            isGeneric = type.IsGenericType;
#endif
            if (type == typeof(UnityEngine.GameObject))
            {

                // Skip save game type start
                m_Reader.ReadByte();
                m_Reader.ReadInt64();

                int layer = ReadProperty<int>();
                bool isStatic = ReadProperty<bool>();
                string tag = ReadProperty<string>();
                string name = ReadProperty<string>();
                UnityEngine.HideFlags hideFlags = ReadProperty<UnityEngine.HideFlags>();

                // Skip save game type end
                m_Reader.ReadByte();

                UnityEngine.GameObject gameObject = value as UnityEngine.GameObject;
                gameObject.layer = layer;
                gameObject.isStatic = isStatic;
                gameObject.tag = tag;
                gameObject.name = name;
                gameObject.hideFlags = hideFlags;

                m_Reader.ReadString();
                int count = m_Reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string typeName = m_Reader.ReadString();
                    Type componentType = Type.GetType(typeName);
                    UnityEngine.Component component = gameObject.GetComponent(componentType);
                    if (component == null)
                    {
                        component = gameObject.AddComponent(componentType);
                    }
                    ReadInto(component);
                }

                m_Reader.ReadString();
                count = m_Reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    if (gameObject.transform.childCount > i)
                    {
                        UnityEngine.Transform childTransform = gameObject.transform.GetChild(i);
                        ReadInto<UnityEngine.GameObject>(childTransform.gameObject);
                    }
                    else
                    {
                        ReadChild(gameObject);
                    }
                }
            }
            else if (type.IsArray)
            {
                Type elementType = type.GetElementType();
                int rank = m_Reader.ReadInt32();
                int[] lengths = new int[rank];
                for (int i = 0; i < rank; i++)
                {
                    lengths[i] = m_Reader.ReadInt32();
                }
                Array array = Array.CreateInstance(elementType, lengths);
                int[] indices = new int[array.Rank];
                for (int i = 0; i < array.Rank; i++)
                {
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
                        object arrayValue = array.GetValue(indices);
                        if (arrayValue == null)
                        {
                            array.SetValue(Read(elementType), indices);
                        }
                        else
                        {
                            ReadInto(array.GetValue(indices));
                        }
                    }
                }
            }
            else if (isGeneric && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type[] genericArgs = type.GetGenericArguments();
                IList list = value as IList;
                int length = m_Reader.ReadInt32();
                for (int i = 0; i < length; i++)
                {
                    if (list.Count > i && list[i] != null)
                    {
                        ReadInto(list[i]);
                    }
                    else
                    {
                        list.Add(Read(genericArgs[0]));
                    }
                }
            }
            else if (value is ICollection && value is IEnumerable)
            {
                m_Reader.ReadInt32();
                IEnumerable e = value as IEnumerable;
                foreach (object subValue in e)
                {
                    ReadInto(subValue);
                }
            }
            else if (SaveGameTypeManager.HasType(type))
            {

                // Skip save game type start
                m_Reader.ReadByte();
                m_Reader.ReadInt64();

                SaveGameType saveGameType = SaveGameTypeManager.GetType(type);
                saveGameType.ReadInto(value, this);

                // Skip save game type End
                m_Reader.ReadByte();
            }
            else
            {
                ReadIntoObject(type, value);
            }
        }

        /// <summary>
        /// Reads the child.
        /// </summary>
        /// <returns>The child.</returns>
        /// <param name="parent">Parent.</param>
        public virtual UnityEngine.GameObject ReadChild(UnityEngine.GameObject parent)
        {
            if (parent == null || !m_Reader.ReadBoolean())
            {
                return null;
            }
            else
            {

                // Skip save game type start
                m_Reader.ReadByte();
                m_Reader.ReadInt64();

                int layer = ReadProperty<int>();
                bool isStatic = ReadProperty<bool>();
                string tag = ReadProperty<string>();
                string name = ReadProperty<string>();
                UnityEngine.HideFlags hideFlags = ReadProperty<UnityEngine.HideFlags>();

                // Skip save game type end
                m_Reader.ReadByte();

                UnityEngine.GameObject gameObject = new UnityEngine.GameObject(name)
                {
                    layer = layer,
                    isStatic = isStatic,
                    tag = tag,
                    hideFlags = hideFlags
                };
                gameObject.transform.SetParent(parent.transform);

                m_Reader.ReadString();
                int count = m_Reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string typeName = m_Reader.ReadString();
                    Type componentType = Type.GetType(typeName);
                    UnityEngine.Component component = gameObject.GetComponent(componentType);
                    if (componentType != typeof(UnityEngine.Transform) && componentType.BaseType != typeof(UnityEngine.Transform))
                    {
                        UnityEngine.Component newComponent = gameObject.AddComponent(componentType);
                        if (newComponent != null)
                        {
                            component = newComponent;
                        }
                    }
                    ReadInto(component);
                }

                m_Reader.ReadString();
                count = m_Reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    ReadChild(gameObject);
                }
                return gameObject;
            }
        }

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
        public virtual object ReadProperty(Type type)
        {
            m_Reader.ReadByte();
            m_Reader.ReadString();
            m_Reader.ReadInt64();
            object result = Read(type);
            m_Reader.ReadByte();
            return result;
        }

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
        public virtual void ReadIntoProperty(object value)
        {
            m_Reader.ReadByte();
            m_Reader.ReadString();
            m_Reader.ReadInt64();
            ReadInto(value);
            m_Reader.ReadByte();
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <returns>The properties.</returns>
        protected virtual string[] GetProperties()
        {
            long startPos = m_Reader.BaseStream.Position;
            int depth = 0;
            List<string> properties = new List<string>();
            while (true)
            {
                if (m_Reader.BaseStream.Position >= m_Reader.BaseStream.Length)
                {
                    break;
                }
                byte b = m_Reader.ReadByte();
                if (b == BinaryFormatter.PropertyStart)
                {
                    properties.Add(SkipProperty());
                }
                else if (b == BinaryFormatter.PropertyEnd)
                {
                    continue;
                }
                else if (b == BinaryFormatter.SaveGameTypeStart)
                {
                    if (depth > 0)
                    {
                        m_Reader.BaseStream.Position = m_Reader.ReadInt64();
                    }
                    depth++;
                }
                else if (b == BinaryFormatter.SaveGameTypeEnd)
                {
                    if (depth == 0)
                    {
                        break;
                    }
                    depth--;
                }
            }
            m_Reader.BaseStream.Position = startPos;
            return properties.ToArray();
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <returns>The property.</returns>
        protected virtual string SkipProperty()
        {
            string property = m_Reader.ReadString();
            m_Reader.BaseStream.Position = m_Reader.ReadInt64();

            // Skip property end
            m_Reader.ReadByte();

            return property;
        }

        /// <summary>
        /// Instantiates Objects and Reads the data into it.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual object ReadObject(Type type)
        {
            object result = null;
            if (type.IsSubclassOf<UnityEngine.ScriptableObject>())
            {
                result = UnityEngine.ScriptableObject.CreateInstance(type);
            }
            else if (type.IsValueType())
            {
                result = Activator.CreateInstance(type);
            }
            else
            {
                result = type.CreateInstance();
            }
            ReadObject(type, result);
            return result;
        }

        /// <summary>
        /// Reads the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="type">Type.</param>
        protected virtual void ReadObject(Type type, object result)
        {
            if (result != null)
            {
                if (result is ISavable)
                {
                    ISavable savable = result as ISavable;
                    savable.OnRead(this);
                }
#if !UNITY_WSA || !UNITY_WINRT
                else if (result is ISerializable)
                {
                    int count = m_Reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        string name = m_Reader.ReadString();
                        FieldInfo field = type.GetSavableField(name);
                        if (field != null)
                        {
                            field.SetValue(result, Read(field.FieldType));
                            continue;
                        }
                        PropertyInfo property = type.GetSavableProperty(name);
                        if (property != null)
                        {
                            property.SetValue(result, Read(property.PropertyType), null);
                            continue;
                        }
                    }
                }
#endif
                else
                {
                    ReadSavableMembers(result, type);
                }
            }
        }

        /// <summary>
        /// Reads into the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="type">Type.</param>
        protected virtual void ReadIntoObject(Type type, object result)
        {
            if (result != null)
            {
                if (result is ISavable)
                {
                    ISavable savable = result as ISavable;
                    savable.OnRead(this);
                }
#if !UNITY_WSA || !UNITY_WINRT
                else if (result is ISerializable)
                {
                    int count = m_Reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        string name = m_Reader.ReadString();
                        FieldInfo field = type.GetSavableField(name);
                        if (field != null)
                        {
                            object fieldValue = field.GetValue(result);
                            ReadInto(fieldValue);
                            continue;
                        }
                        PropertyInfo property = type.GetSavableProperty(name);
                        if (property != null)
                        {
                            object propertyValue = property.GetValue(result, null);
                            ReadInto(propertyValue);
                            continue;
                        }
                    }
                }
#endif
                else
                {
                    ReadIntoSavableMembers(result, type);
                }
            }
        }

        /// <summary>
        /// Reads the savable members.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="type">Type.</param>
        public virtual void ReadSavableMembers(object obj, Type type)
        {


            // Reading fields
            int count = m_Reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                string name = m_Reader.ReadString();
                FieldInfo field = type.GetSavableField(name);
                if (field != null)
                {
                    field.SetValue(obj, Read(field.FieldType));
                    continue;
                }
                PropertyInfo property = type.GetSavableProperty(name);
                if (property != null)
                {
                    property.SetValue(obj, Read(property.PropertyType), null);
                    continue;
                }
            }

            // Reading properties
            count = m_Reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                string name = m_Reader.ReadString();
                FieldInfo field = type.GetSavableField(name);
                if (field != null)
                {
                    field.SetValue(obj, Read(field.FieldType));
                    continue;
                }
                PropertyInfo property = type.GetSavableProperty(name);
                if (property != null)
                {
                    property.SetValue(obj, Read(property.PropertyType), null);
                    continue;
                }
            }
        }

        /// <summary>
        /// Reads into the savable members.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="type">Type.</param>
        public virtual void ReadIntoSavableMembers(object obj, Type type)
        {

            // Reading fields
            int count = m_Reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                string name = m_Reader.ReadString();
                FieldInfo field = type.GetSavableField(name);
                if (field != null)
                {
                    object fieldValue = field.GetValue(obj);
                    if (fieldValue == null)
                    {
                        field.SetValue(obj, Read(field.FieldType));
                    }
                    else
                    {
                        ReadInto(fieldValue);
                    }
                    continue;
                }
                PropertyInfo property = type.GetSavableProperty(name);
                if (property != null)
                {
                    object propertyValue = property.GetValue(obj, null);
                    if (propertyValue == null)
                    {
                        property.SetValue(obj, Read(property.PropertyType), null);
                    }
                    else
                    {
                        ReadInto(propertyValue);
                    }
                    continue;
                }
            }

            // Reading properties
            count = m_Reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                string name = m_Reader.ReadString();
                FieldInfo field = type.GetSavableField(name);
                if (field != null)
                {
                    object fieldValue = field.GetValue(obj);
                    if (fieldValue == null)
                    {
                        field.SetValue(obj, Read(field.FieldType));
                    }
                    else
                    {
                        ReadInto(fieldValue);
                    }
                    continue;
                }
                PropertyInfo property = type.GetSavableProperty(name);
                if (property != null)
                {
                    object propertyValue = property.GetValue(obj, null);
                    if (propertyValue == null)
                    {
                        property.SetValue(obj, Read(property.PropertyType), null);
                    }
                    else
                    {
                        ReadInto(propertyValue);
                    }
                    continue;
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectReader"/>. The <see cref="Dispose"/>
        /// method leaves the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectReader"/> in an
        /// unusable state. After calling <see cref="Dispose"/>, you must release all references to the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectReader"/> so the garbage collector
        /// can reclaim the memory that the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryObjectReader"/> was occupying.</remarks>
        public virtual void Dispose()
        {
            if (m_Reader != null)
            {
                (m_Reader as IDisposable).Dispose();
            }
        }

        #endregion

    }

}