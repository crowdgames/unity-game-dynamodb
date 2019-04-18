using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type NavMeshData serialization implementation.
    /// </summary>
    public class SaveGameType_NavMeshData : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.AI.NavMeshData);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.AI.NavMeshData navMeshData = (UnityEngine.AI.NavMeshData)value;
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "position", navMeshData.position );
			writer.WriteProperty ( "rotation", navMeshData.rotation );
#endif
            writer.WriteProperty("name", navMeshData.name);
            writer.WriteProperty("hideFlags", navMeshData.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.AI.NavMeshData navMeshData = new UnityEngine.AI.NavMeshData();
            ReadInto(navMeshData, reader);
            return navMeshData;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.AI.NavMeshData navMeshData = (UnityEngine.AI.NavMeshData)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "position":
#if UNITY_2017_1_OR_NEWER
                        navMeshData.position = reader.ReadProperty<UnityEngine.Vector3>();
#else
                        reader.ReadProperty<UnityEngine.Vector3>();
#endif
                        break;
                    case "rotation":
#if UNITY_2017_1_OR_NEWER
                        navMeshData.rotation = reader.ReadProperty<UnityEngine.Quaternion>();
#else
                        reader.ReadProperty<UnityEngine.Quaternion>();
#endif
                        break;
                    case "name":
                        navMeshData.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        navMeshData.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}