using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Reflection
{

    /// <summary>
    /// Type utilities.
    /// </summary>
    public static class TypeUtils
    {

        /// <summary>
        /// The savable binding flags.
        /// </summary>
        public const BindingFlags SavableBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

#if UNITY_WSA && !UNITY_EDITOR
        /// <summary>
        /// Determines if the type is savable.
        /// </summary>
        /// <returns><c>true</c> if is savable the specified type; otherwise, <c>false</c>.</returns>
        /// <param name="type">Type.</param>
        public static bool IsSavable(this Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            List<FieldInfo> fields = type.GetSavableFields();
            List<PropertyInfo> properties = type.GetSavableProperties();
            return !typeInfo.IsInterface &&
            (fields.Count > 0 || properties.Count > 0) &&
            typeInfo.GetCustomAttribute<ObsoleteAttribute>() == null;
        }
#else
        /// <summary>
        /// Determines if the type is savable.
        /// </summary>
        /// <returns><c>true</c> if is savable the specified type; otherwise, <c>false</c>.</returns>
        /// <param name="type">Type.</param>
        public static bool IsSavable(this Type type)
        {
            List<FieldInfo> fields = type.GetSavableFields();
            List<PropertyInfo> properties = type.GetSavableProperties();
            return !type.IsInterface &&
            (fields.Count > 0 || properties.Count > 0) &&
            !Attribute.IsDefined(type, typeof(ObsoleteAttribute));
        }
#endif

        /// <summary>
        /// Gets the savable field.
        /// </summary>
        /// <returns>The savable field.</returns>
        /// <param name="type">Type.</param>
        /// <param name="name">Name.</param>
        public static FieldInfo GetSavableField(this Type type, string name)
        {
            FieldInfo field = type.GetField(name, TypeUtils.SavableBindingFlags);
            return field != null && field.IsSavable() ? field : null;
        }

        /// <summary>
        /// Gets the savable property.
        /// </summary>
        /// <returns>The savable property.</returns>
        /// <param name="type">Type.</param>
        /// <param name="name">Name.</param>
        public static PropertyInfo GetSavableProperty(this Type type, string name)
        {
            PropertyInfo property = type.GetProperty(name, TypeUtils.SavableBindingFlags);
            return property != null && property.IsSavable() ? property : null;
        }

        /// <summary>
        /// Gets the savable fields.
        /// </summary>
        /// <returns>The savable fields.</returns>
        /// <param name="type">Type.</param>
        public static List<FieldInfo> GetSavableFields(this Type type)
        {
            FieldInfo[] fields = type.GetFields(TypeUtils.SavableBindingFlags);
            List<FieldInfo> savableFields = new List<FieldInfo>();
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                if (field.IsSavable())
                {
                    savableFields.Add(field);
                }
            }
            return savableFields;
        }

        /// <summary>
        /// Gets the savable properties.
        /// </summary>
        /// <returns>The savable properties.</returns>
        /// <param name="type">Type.</param>
        public static List<PropertyInfo> GetSavableProperties(this Type type)
        {
            PropertyInfo[] properties = type.GetProperties(TypeUtils.SavableBindingFlags);
            List<PropertyInfo> savableProperties = new List<PropertyInfo>();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                if (property.IsSavable())
                {
                    savableProperties.Add(property);
                }
            }
            return savableProperties;
        }
#if UNITY_WSA && !UNITY_EDITOR
        /// <summary>
        /// Gets the friendly name of the type.
        /// </summary>
        /// <returns>The friendly name.</returns>
        /// <param name="type">Type.</param>
        public static string GetFriendlyName(this Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            string name = type.FullName;
            if (typeInfo.IsGenericType)
            {
                name = type.FullName.Split('`')[0] + "<" + string.Join(
                    ", ",
                    type.GetGenericArguments().Select(x => x.GetFriendlyName()).ToArray()) + ">";
            }
            else
            {
                name = type.FullName;
            }
            name = name.Replace("+", ".");
            return name;
        }
#else
        /// <summary>
        /// Gets the friendly name of the type.
        /// </summary>
        /// <returns>The friendly name.</returns>
        /// <param name="type">Type.</param>
        public static string GetFriendlyName(this Type type)
        {
            string name = type.FullName;
            if (type.IsGenericType)
            {
                name = type.FullName.Split('`')[0] + "<" + string.Join(
                    ", ",
                    type.GetGenericArguments().Select(x => x.GetFriendlyName()).ToArray()) + ">";
            }
            else
            {
                name = type.FullName;
            }
            name = name.Replace("+", ".");
            return name;
        }
#endif
#if UNITY_WSA && !UNITY_EDITOR
        /// <summary>
        /// Gets the default value of the type.
        /// </summary>
        /// <returns>The default.</returns>
        /// <param name="type">Type.</param>
        public static object GetDefault(this Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            if (typeInfo.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
#else
        /// <summary>
        /// Gets the default value of the type.
        /// </summary>
        /// <returns>The default.</returns>
        /// <param name="type">Type.</param>
        public static object GetDefault(this Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
#endif
#if UNITY_WSA && !UNITY_EDITOR
        /// <summary>
        /// Checks whether this type is subclass of another type or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns>True if the type is subclass, false if it isn't</returns>
        public static bool IsSubclassOf<T>(this Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            return typeInfo.IsSubclassOf(typeof(T));
        }
#else
        /// <summary>
        /// Checks whether this type is subclass of another type or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns>True if the type is subclass, false if it isn't</returns>
        public static bool IsSubclassOf<T>(this Type type)
        {
            return type.IsSubclassOf(typeof(T));
        }
#endif
#if UNITY_WSA && !UNITY_EDITOR
        /// <summary>
        /// Checks whether this type is a value type or not
        /// </summary>
        /// <param name="type"></param>
        /// <returns>True if the type is value type, false if it isn't</returns>
        public static bool IsValueType(this Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            return typeInfo.IsValueType;
        }
#else
        /// <summary>
        /// Checks whether this type is a value type or not
        /// </summary>
        /// <param name="type"></param>
        /// <returns>True if the type is value type, false if it isn't</returns>
        public static bool IsValueType(this Type type)
        {
            return type.IsValueType;
        }
#endif
#if UNITY_WSA && !UNITY_EDITOR
        /// <summary>
        /// Creates an instance of the type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>The instance of the type</returns>
        public static object CreateInstance(this Type type)
        {
            return Activator.CreateInstance(type);
        }
#else
        /// <summary>
        /// Creates an instance of the type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>The instance of the type</returns>
        public static object CreateInstance(this Type type)
        {
            return FormatterServices.GetUninitializedObject(type);
        }
#endif
        /// <summary>
        /// Retrieves the nullable version of the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetNullableType(this Type type)
        {
            return typeof(Nullable<>).MakeGenericType(type);
        }

    }

}