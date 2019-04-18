using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Serialization
{

    /// <summary>
    /// Save Game Reader Interface.
    /// An Interface for Data Readers.
    /// </summary>
    public interface ISaveGameReader
    {

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        IEnumerable<string> Properties { get; }

        /// <summary>
        /// Read the data.
        /// </summary>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        T Read<T>();

        /// <summary>
        /// Read the data using the specified type.
        /// </summary>
        /// <param name="type">Type.</param>
        object Read(Type type);

        /// <summary>
        /// Read the data to the value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void ReadInto<T>(T value);

        /// <summary>
        /// Read the data to the value.
        /// </summary>
        /// <param name="value">Value.</param>
        void ReadInto(object value);

        /// <summary>
        /// Read the property.
        /// </summary>
        /// <returns>The property.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        T ReadProperty<T>();

        /// <summary>
        /// Read the property.
        /// </summary>
        /// <returns>The property.</returns>
        /// <param name="type">Type.</param>
        object ReadProperty(Type type);

        /// <summary>
        /// Read the data into the property.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void ReadIntoProperty<T>(T value);

        /// <summary>
        /// Read the data into the property.
        /// </summary>
        /// <param name="value">Value.</param>
        void ReadIntoProperty(object value);

        /// <summary>
        /// Reads the savable members.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="type">Type.</param>
        void ReadSavableMembers(object obj, Type type);

    }

}