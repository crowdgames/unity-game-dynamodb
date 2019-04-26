using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using System.Text;

using BayatGames.SaveGamePro.Reflection;
using BayatGames.SaveGamePro.Serialization.Types;
using BayatGames.SaveGamePro.Utilities;

namespace BayatGames.SaveGamePro.Serialization.Formatters.Json
{

    /// <summary>
    /// Json text reader.
    /// </summary>
    public class JsonTextReader : JsonReader
    {

        #region Fields

        /// <summary>
        /// The reader.
        /// </summary>
        protected TextReader m_Reader;

        /// <summary>
        /// The json.
        /// </summary>
        protected string m_Json;

        /// <summary>
        /// The position.
        /// </summary>
        protected int m_Position;

        /// <summary>
        /// Is it first property in the save game type?
        /// </summary>
        protected bool m_IsFirstProperty = true;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the reader.
        /// </summary>
        /// <value>The reader.</value>
        public virtual TextReader Reader
        {
            get
            {
                return m_Reader;
            }
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public override IEnumerable<string> Properties
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
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextReader"/> class.
        /// </summary>
        /// <param name="reader">Reader.</param>
        /// <param name="settings">Settings.</param>
        public JsonTextReader(TextReader reader, SaveGameSettings settings) : base(settings)
        {
            m_Reader = reader;
            m_Position = 0;
            m_Json = m_Reader.ReadToEnd().RemoveWhitespaceJson();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Read the specified type.
        /// </summary>
        /// <param name="type">Type.</param>
        public override object Read(Type type)
        {
            Type nullableType = null;
            object result = null;
            if (type == null || string.IsNullOrEmpty(m_Json))
            {
                result = null;
            }
            else if (m_Json[m_Position] == 'n' && PeekString() == "null")
            {
                ReadString();
                result = null;
            }
            else
            {
                if (Nullable.GetUnderlyingType(type) != null)
                {
                    nullableType = type;
                    type = Nullable.GetUnderlyingType(type);
                }
                bool isEnum = false;
                bool isSerializable = false;
                bool isGeneric = false;
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
                if (type == typeof(UnityEngine.GameObject))
                {

                    // Skip object start
                    m_Position++;

                    m_IsFirstProperty = true;
                    int layer = 0;
                    bool isStatic = false;
                    string tag = "";
                    string name = "";
                    UnityEngine.HideFlags hideFlags = UnityEngine.HideFlags.None;
                    foreach (string property in Properties)
                    {
                        switch (property)
                        {
                            case "layer":
                                layer = ReadProperty<int>();
                                break;
                            case "isStatic":
                                isStatic = ReadProperty<bool>();
                                break;
                            case "tag":
                                tag = ReadProperty<string>();
                                break;
                            case "name":
                                name = ReadProperty<string>();
                                break;
                            case "hideFlags":
                                hideFlags = ReadProperty<UnityEngine.HideFlags>();
                                break;
                        }
                    }
                    UnityEngine.GameObject gameObject = new UnityEngine.GameObject(name);
                    gameObject.layer = layer;
                    gameObject.isStatic = isStatic;
                    gameObject.tag = tag;
                    gameObject.name = name;
                    gameObject.hideFlags = hideFlags;

                    // Skip comma
                    m_Position++;

                    ReadQoutedString();

                    // Skip colon and array start
                    m_Position += 2;

                    int length = GetArrayLength();
                    bool isFirst = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }

                        // Skip object start
                        m_Position++;

                        ReadQoutedString();

                        // Skip colon
                        m_Position++;

                        string typeFullName = ReadQoutedString();
                        Type componentType = Type.GetType(typeFullName);
                        UnityEngine.Component component = gameObject.GetComponent(componentType);
                        if (componentType != typeof(UnityEngine.Transform) && componentType.BaseType != typeof(UnityEngine.Transform))
                        {
                            UnityEngine.Component newComponent = gameObject.AddComponent(componentType);
                            if (newComponent != null)
                            {
                                component = newComponent;
                            }
                        }

                        // Skip comma
                        m_Position++;

                        ReadQoutedString();

                        // Skip colon
                        m_Position++;

                        ReadInto(component);

                        // Skip object end
                        m_Position++;
                    }

                    // Skip comma and array end
                    m_Position += 2;

                    ReadQoutedString();

                    // Skip colon and array start
                    m_Position += 2;

                    length = GetArrayLength();
                    isFirst = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        ReadChild(gameObject);
                    }

                    result = gameObject;

                    // Skip object end
                    m_Position++;

                }
                else if (type == typeof(string))
                {
                    result = ReadQoutedString().UnEscapeStringJson();
                }
                else if (isEnum)
                {
                    result = Enum.Parse(type, ReadQoutedString().UnEscapeStringJson());
                }
                else if (type == typeof(bool))
                {
                    result = bool.Parse(ReadString());
                }
                else if (type == typeof(short) || type == typeof(int) || type == typeof(long) ||
                          type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong) ||
                          type == typeof(byte) || type == typeof(sbyte) || type == typeof(decimal) ||
                          type == typeof(double) || type == typeof(float))
                {
                    result = Convert.ChangeType(ReadString(), type);
                }
                else if (type.IsArray)
                {
                    // Skip array start
                    m_Position++;

                    Type elementType = type.GetElementType();
                    int length = GetArrayLength();
                    Array array = Array.CreateInstance(elementType, length);
                    bool isFirst = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        array.SetValue(Read(elementType), i);
                    }
                    result = array;

                    // Skip array end
                    m_Position++;

                }
                else if (type == typeof(DictionaryEntry))
                {

                    // Skip object start
                    m_Position++;

                    DictionaryEntry entry = new DictionaryEntry();
                    bool isFirst = true;
                    Type keyType = null;
                    Type valueType = null;
                    for (int i = 0; i < 4; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        string property = ReadQoutedString();

                        // Skip colon
                        m_Position++;

                        if (property == "KeyType")
                        {
                            keyType = Type.GetType(ReadQoutedString());
                        }
                        else if (property == "Key")
                        {
                            entry.Key = Read(keyType);
                        }
                        else if (property == "ValueType")
                        {
                            valueType = Type.GetType(ReadQoutedString());
                        }
                        else if (property == "Value")
                        {
                            entry.Value = Read(valueType);
                        }
                    }
                    result = entry;

                    // Skip object end
                    m_Position++;

                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                {

                    // Skip object start
                    m_Position++;

                    Type[] genericArgs = type.GetGenericArguments();
                    object key = null;
                    object value = null;

                    string property = ReadQoutedString();

                    // Skip colon
                    m_Position++;

                    if (property == "Key")
                    {
                        key = Read(genericArgs[0]);
                    }
                    else
                    {
                        value = Read(genericArgs[1]);
                    }


                    // Skip comma
                    m_Position++;

                    property = ReadQoutedString();

                    // Skip colon
                    m_Position++;

                    if (property == "Key")
                    {
                        key = Read(genericArgs[0]);
                    }
                    else
                    {
                        value = Read(genericArgs[1]);
                    }
                    result = Activator.CreateInstance(type, key, value);

                    // Skip object end
                    m_Position++;

                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(List<>))
                {

                    // Skip array start
                    m_Position++;

                    Type[] genericArgs = type.GetGenericArguments();
                    int length = GetArrayLength();
                    IList list = (IList)Activator.CreateInstance(type);
                    bool isFirst = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        list.Add(Read(genericArgs[0]));
                    }
                    result = list;

                    // Skip array end
                    m_Position++;

                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(LinkedList<>))
                {

                    // Skip array start
                    m_Position++;

                    Type[] genericArgs = type.GetGenericArguments();
                    int length = GetArrayLength();
                    object list = Activator.CreateInstance(type);
                    MethodInfo addLast = type.GetMethod("AddLast", genericArgs);
                    bool isFirst = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        addLast.Invoke(list, new object[] { Read(genericArgs[0]) });
                    }
                    result = list;

                    // Skip array end
                    m_Position++;

                }
                else if (isGeneric && (type.GetGenericTypeDefinition() == typeof(Dictionary<,>) ||
                          type.GetGenericTypeDefinition() == typeof(SortedDictionary<,>) ||
                          type.GetGenericTypeDefinition() == typeof(SortedList<,>)))
                {

                    // Skip object start
                    m_Position++;

                    Type[] genericArgs = type.GetGenericArguments();
                    int length = GetObjectLength();
                    bool isFirst = true;
                    IDictionary dictionary = (IDictionary)Activator.CreateInstance(type);
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        object key = Read(genericArgs[0]);

                        // Skip colon
                        m_Position++;

                        object value = Read(genericArgs[1]);
                        dictionary.Add(key, value);
                    }
                    result = dictionary;

                    // Skip object end
                    m_Position++;

                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(Stack<>))
                {

                    // Skip array start
                    m_Position++;

                    Type[] genericArgs = type.GetGenericArguments();
                    int length = GetArrayLength();
                    object stack = Activator.CreateInstance(type);
                    MethodInfo push = type.GetMethod("Push");
                    bool isFirst = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        push.Invoke(stack, new object[] { Read(genericArgs[0]) });
                    }
                    result = stack;

                    // Skip array end
                    m_Position++;

                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(Queue<>))
                {

                    // Skip array start
                    m_Position++;

                    Type[] genericArgs = type.GetGenericArguments();
                    int length = GetArrayLength();
                    object queue = Activator.CreateInstance(type);
                    MethodInfo enqueue = type.GetMethod("Enqueue");
                    bool isFirst = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        enqueue.Invoke(queue, new object[] { Read(genericArgs[0]) });
                    }
                    result = queue;

                    // Skip array end
                    m_Position++;

                }
                else if (isGeneric && type.GetGenericTypeDefinition() == typeof(HashSet<>))
                {

                    // Skip array start
                    m_Position++;

                    Type[] genericArgs = type.GetGenericArguments();
                    int length = GetArrayLength();
                    object hashSet = Activator.CreateInstance(type);
                    MethodInfo addMethod = type.GetMethod("Add");
                    bool isFirst = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        addMethod.Invoke(hashSet, new object[] { Read(genericArgs[0]) });
                    }
                    result = hashSet;

                    // Skip array end
                    m_Position++;

                }
                else if (type == typeof(Hashtable))
                {

                    // Skip array start
                    m_Position++;

                    bool isFirst = true;
                    Hashtable hashtable = new Hashtable();
                    int length = GetArrayLength();
                    for (int i = 0; i < length; i++)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                        }
                        else
                        {
                            // Skip comma
                            m_Position++;
                        }
                        DictionaryEntry entry = Read<DictionaryEntry>();
                        hashtable.Add(entry.Key, entry.Value);
                    }
                    result = hashtable;

                    // Skip array end
                    m_Position++;

                }
                else if (SaveGameTypeManager.HasType(type))
                {

                    // Skip object start
                    m_Position++;

                    m_IsFirstProperty = true;
                    SaveGameType saveGameType = SaveGameTypeManager.GetType(type);
                    result = saveGameType.Read(this);

                    // Skip object end
                    m_Position++;

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
        public override void ReadInto(object value)
        {
            if (value == null || string.IsNullOrEmpty(m_Json))
            {
                return;
            }
            else if (m_Json[m_Position] == 'n' && PeekString() == "null")
            {
                ReadString();
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

                // Skip object start
                m_Position++;

                m_IsFirstProperty = true;
                int layer = 0;
                bool isStatic = false;
                string tag = "";
                string name = "";
                UnityEngine.HideFlags hideFlags = UnityEngine.HideFlags.None;
                foreach (string property in Properties)
                {
                    switch (property)
                    {
                        case "layer":
                            layer = ReadProperty<int>();
                            break;
                        case "isStatic":
                            isStatic = ReadProperty<bool>();
                            break;
                        case "tag":
                            tag = ReadProperty<string>();
                            break;
                        case "name":
                            name = ReadProperty<string>();
                            break;
                        case "hideFlags":
                            hideFlags = ReadProperty<UnityEngine.HideFlags>();
                            break;
                    }
                }
                UnityEngine.GameObject gameObject = value as UnityEngine.GameObject;
                gameObject.layer = layer;
                gameObject.isStatic = isStatic;
                gameObject.tag = tag;
                gameObject.name = name;
                gameObject.hideFlags = hideFlags;

                // Skip comma
                m_Position++;

                ReadQoutedString();

                // Skip colon and array start
                m_Position += 2;

                int length = GetArrayLength();
                bool isFirst = true;
                for (int i = 0; i < length; i++)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        // Skip comma
                        m_Position++;
                    }

                    // Skip object start
                    m_Position++;

                    ReadQoutedString();

                    // Skip colon
                    m_Position++;

                    string typeFullName = ReadQoutedString();
                    Type componentType = Type.GetType(typeFullName);
                    UnityEngine.Component component = gameObject.GetComponent(componentType);
                    if (component == null)
                    {
                        component = gameObject.AddComponent(componentType);
                    }

                    // Skip comma
                    m_Position++;

                    ReadQoutedString();

                    // Skip colon
                    m_Position++;

                    ReadInto(component);

                    // Skip object end
                    m_Position++;
                }

                // Skip comma and array end
                m_Position += 2;

                ReadQoutedString();

                // Skip colon and array start
                m_Position += 2;

                length = GetArrayLength();
                isFirst = true;
                for (int i = 0; i < length; i++)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        // Skip comma
                        m_Position++;
                    }
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

                // Skip object end
                m_Position++;

            }
            else if (type.IsArray)
            {

                // Skip array start
                m_Position++;

                Type elementType = type.GetElementType();
                int length = GetArrayLength();
                Array array = value as Array;
                if (array.Length < length)
                {
                    array = Array.CreateInstance(elementType, length);
                }
                bool isFirst = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        // Skip comma
                        m_Position++;
                    }
                    object arrayValue = array.GetValue(i);
                    if (arrayValue == null)
                    {
                        array.SetValue(Read(elementType), i);
                    }
                    else
                    {
                        ReadInto(array.GetValue(i));
                    }
                }

                // Skip array end
                m_Position++;

            }
            else if (isGeneric && type.GetGenericTypeDefinition() == typeof(List<>))
            {

                // Skip array start
                m_Position++;

                Type[] genericArgs = type.GetGenericArguments();
                int length = GetArrayLength();
                IList list = value as IList;
                bool isFirst = true;
                for (int i = 0; i < length; i++)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        // Skip comma
                        m_Position++;
                    }
                    if (list.Count > i && list[i] != null)
                    {
                        ReadInto(list[i]);
                    }
                    else
                    {
                        list.Add(Read(genericArgs[0]));
                    }
                }

                // Skip array end
                m_Position++;

            }
            else if (value is ICollection && value is IEnumerable)
            {

                // Skip array start
                m_Position++;

                IEnumerable e = value as IEnumerable;
                bool isFirst = true;
                foreach (object subValue in e)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        // Skip comma
                        m_Position++;
                    }
                    ReadInto(subValue);
                }

                // Skip array end
                m_Position++;

            }
            else if (SaveGameTypeManager.HasType(type))
            {

                // Skip object start
                m_Position++;

                m_IsFirstProperty = true;
                SaveGameType saveGameType = SaveGameTypeManager.GetType(type);
                saveGameType.ReadInto(value, this);

                // Skip object end
                m_Position++;

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
            if (parent == null || string.IsNullOrEmpty(m_Json))
            {
                return null;
            }
            else if (m_Json[m_Position] == 'n' && PeekString() == "null")
            {
                ReadString();
                return null;
            }
            else
            {

                // Skip object start
                m_Position++;

                m_IsFirstProperty = true;
                int layer = 0;
                bool isStatic = false;
                string tag = "";
                string name = "";
                UnityEngine.HideFlags hideFlags = UnityEngine.HideFlags.None;
                foreach (string property in Properties)
                {
                    switch (property)
                    {
                        case "layer":
                            layer = ReadProperty<int>();
                            break;
                        case "isStatic":
                            isStatic = ReadProperty<bool>();
                            break;
                        case "tag":
                            tag = ReadProperty<string>();
                            break;
                        case "name":
                            name = ReadProperty<string>();
                            break;
                        case "hideFlags":
                            hideFlags = ReadProperty<UnityEngine.HideFlags>();
                            break;
                    }
                }
                UnityEngine.GameObject gameObject = new UnityEngine.GameObject(name);
                gameObject.layer = layer;
                gameObject.isStatic = isStatic;
                gameObject.tag = tag;
                gameObject.name = name;
                gameObject.hideFlags = hideFlags;
                gameObject.transform.SetParent(parent.transform);

                // Skip comma
                m_Position++;

                ReadQoutedString();

                // Skip colon and array start
                m_Position += 2;

                int length = GetArrayLength();
                bool isFirst = true;
                for (int i = 0; i < length; i++)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        // Skip comma
                        m_Position++;
                    }

                    // Skip object start
                    m_Position++;

                    ReadQoutedString();

                    // Skip colon
                    m_Position++;

                    string typeFullName = ReadQoutedString();
                    Type componentType = Type.GetType(typeFullName);
                    UnityEngine.Component component = gameObject.GetComponent(componentType);
                    if (componentType != typeof(UnityEngine.Transform) && componentType.BaseType != typeof(UnityEngine.Transform))
                    {
                        UnityEngine.Component newComponent = gameObject.AddComponent(componentType);
                        if (newComponent != null)
                        {
                            component = newComponent;
                        }
                    }

                    // Skip comma
                    m_Position++;

                    ReadQoutedString();

                    // Skip colon
                    m_Position++;

                    ReadInto(component);

                    // Skip object end
                    m_Position++;
                }

                // Skip comma and array end
                m_Position += 2;

                ReadQoutedString();

                // Skip colon and array start
                m_Position += 2;

                length = GetArrayLength();
                isFirst = true;
                for (int i = 0; i < length; i++)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        // Skip comma
                        m_Position++;
                    }
                    ReadChild(gameObject);
                }

                // Skip object end
                m_Position++;
                return gameObject;
            }
        }

        /// <summary>
        /// Reads the property.
        /// </summary>
        /// <returns>The property.</returns>
        /// <param name="type">Type.</param>
        public override object ReadProperty(Type type)
        {
            if (m_IsFirstProperty)
            {
                m_IsFirstProperty = false;
            }
            else
            {
                // Skip comma
                m_Position++;
            }

            ReadQoutedString();

            // Skip colon
            m_Position++;

            return Read(type);
        }

        /// <summary>
        /// Reads the into property.
        /// </summary>
        /// <param name="value">Value.</param>
        public override void ReadIntoProperty(object value)
        {
            if (m_IsFirstProperty)
            {
                m_IsFirstProperty = false;
            }
            else
            {
                // Skip comma
                m_Position++;
            }

            ReadQoutedString();

            // Skip colon
            m_Position++;

            ReadInto(value);
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <returns>The properties.</returns>
        protected virtual string[] GetProperties()
        {
            if (m_Json[m_Position] == '{' || m_Json[m_Position] == ',')
            {
                m_Position++;
            }
            List<string> properties = new List<string>();
            if (m_Json[m_Position] == '}')
            {
                return properties.ToArray();
            }
            int startPos = m_Position;
            int depth = 0;
            properties.Add(ReadQoutedString());
            if (m_Json[m_Position] != ']')
            {
                while (m_Json.Length > m_Position)
                {
                    switch (m_Json[m_Position])
                    {
                        case '{':
                        case '[':
                            depth++;
                            break;
                        case '}':
                        case ']':
                            if (depth == 0)
                            {
                                m_Position = startPos;
                                return properties.ToArray();
                            }
                            depth--;
                            break;
                        case ',':
                            if (depth == 0)
                            {
                                m_Position++;
                                properties.Add(ReadQoutedString());
                                continue;
                            }
                            break;
                    }
                    m_Position++;
                }
                m_Position = startPos;
            }
            return properties.ToArray();
        }

        /// <summary>
        /// Gets the length of the object.
        /// </summary>
        /// <returns>The object length.</returns>
        protected virtual int GetObjectLength()
        {
            if (m_Json[m_Position] == '{')
            {
                m_Position++;
            }
            int length = 0;
            if (m_Json[m_Position] == '}')
            {
                return length;
            }
            int depth = 0;
            int position = m_Position;
            if (m_Json[m_Position] != ']')
            {
                while (m_Json.Length > position)
                {
                    switch (m_Json[position])
                    {
                        case '[':
                        case '{':
                            depth++;
                            break;
                        case ']':
                        case '}':
                            if (depth == 0)
                            {
                                return length;
                            }
                            depth--;
                            break;
                        case ':':
                            if (depth == 0)
                            {
                                length++;
                            }
                            break;
                    }
                    position++;
                }
            }
            return length;
        }

        /// <summary>
        /// Gets the length of the array.
        /// </summary>
        /// <returns>The array length.</returns>
        protected virtual int GetArrayLength()
        {
            if (m_Json[m_Position] == '[')
            {
                m_Position++;
            }
            int length = 0;
            if (m_Json[m_Position] == ']')
            {
                return length;
            }
            int depth = 0;
            int position = m_Position;
            if (m_Json[m_Position] != ']')
            {
                while (m_Json.Length > position)
                {
                    switch (m_Json[position])
                    {
                        case '[':
                        case '{':
                            depth++;
                            break;
                        case ']':
                        case '}':
                            if (depth == 0)
                            {
                                // Add last entry
                                length++;

                                return length;
                            }
                            depth--;
                            break;
                        case ',':
                            if (depth == 0)
                            {
                                length++;
                            }
                            break;
                    }
                    position++;
                }
            }
            return length;
        }

        /// <summary>
        /// Reads the string without move.
        /// </summary>
        /// <returns>The string without move.</returns>
        protected virtual string PeekString()
        {
            int startPos = m_Position;
            string result = ReadString();
            m_Position = startPos;
            return result;
        }

        /// <summary>
        /// Reads the number.
        /// </summary>
        /// <returns>The number.</returns>
        protected virtual string ReadString()
        {
            StringBuilder builder = new StringBuilder();
            while (m_Json.Length > m_Position)
            {
                switch (m_Json[m_Position])
                {
                    default:
                        builder.Append(m_Json[m_Position]);
                        break;
                    case ',':
                    case ']':
                    case '}':
                        return builder.ToString();
                }
                m_Position++;
            }
            return builder.ToString();
        }

        /// <summary>
        /// Reads the string.
        /// </summary>
        /// <returns>The string.</returns>
        protected virtual string ReadQoutedString()
        {
            StringBuilder builder = new StringBuilder();

            // Skip first qoute
            m_Position++;

            while (m_Json.Length > m_Position)
            {
                switch (m_Json[m_Position])
                {
                    default:
                        builder.Append(m_Json[m_Position]);
                        break;
                    case '"':

                        // Skip last qoute
                        m_Position++;

                        return builder.ToString();
                }
                m_Position++;
            }
            return builder.ToString();
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

                    // Skip object start
                    m_Position++;

                    m_IsFirstProperty = true;
                    ISavable savable = result as ISavable;
                    savable.OnRead(this);

                    // Skip object end
                    m_Position++;

                }
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

                    // Skip object start
                    m_Position++;

                    m_IsFirstProperty = true;
                    ISavable savable = result as ISavable;
                    savable.OnRead(this);

                    // Skip object end
                    m_Position++;

                }
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
        public override void ReadSavableMembers(object obj, Type type)
        {

            // Skip object start
            m_Position++;

            bool isFirst = true;
            int length = GetObjectLength();
            for (int i = 0; i < length; i++)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    // Skip comma
                    m_Position++;
                }
                string name = ReadQoutedString();
                FieldInfo field = type.GetSavableField(name);
                if (field != null)
                {
                    // Skip colon
                    m_Position++;
                    object value = Read(field.FieldType);
                    field.SetValue(obj, value);
                    continue;
                }
                PropertyInfo property = type.GetSavableProperty(name);
                if (property != null)
                {
                    // Skip colon
                    m_Position++;
                    object value = Read(property.PropertyType);
                    property.SetValue(obj, value, null);
                    continue;
                }
            }

            // Skip object start
            m_Position++;
        }

        /// <summary>
        /// Reads into the savable members.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="type">Type.</param>
        public override void ReadIntoSavableMembers(object obj, Type type)
        {

            // Skip object start
            m_Position++;

            bool isFirst = true;
            int length = GetObjectLength();
            for (int i = 0; i < length; i++)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    // Skip comma
                    m_Position++;
                }
                string name = ReadQoutedString();
                FieldInfo field = type.GetSavableField(name);
                if (field != null)
                {
                    // Skip colon
                    m_Position++;
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
                    // Skip colon
                    m_Position++;
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

            // Skip object start
            m_Position++;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextReader"/>. The <see cref="Dispose"/>
        /// method leaves the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextReader"/> in an unusable
        /// state. After calling <see cref="Dispose"/>, you must release all references to the
        /// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextReader"/> so the garbage collector can
        /// reclaim the memory that the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonTextReader"/> was occupying.</remarks>
        public override void Dispose()
        {
            if (m_Reader != null)
            {
                m_Reader.Dispose();
            }
        }

        #endregion

    }

}