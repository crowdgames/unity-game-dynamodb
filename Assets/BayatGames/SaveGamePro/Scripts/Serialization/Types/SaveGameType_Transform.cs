using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Transform serialization implementation.
    /// </summary>
    public class SaveGameType_Transform : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Transform);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Transform transform = (UnityEngine.Transform)value;
            writer.WriteProperty("position", transform.position);
            writer.WriteProperty("localPosition", transform.localPosition);
            writer.WriteProperty("rotation", transform.rotation);
            writer.WriteProperty("localRotation", transform.localRotation);
            writer.WriteProperty("localScale", transform.localScale);
            writer.WriteProperty("parent", transform.parent);
            writer.WriteProperty("tag", transform.tag);
            writer.WriteProperty("name", transform.name);
            writer.WriteProperty("hideFlags", transform.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Transform transform = SaveGameType.CreateComponent<UnityEngine.Transform>();
            ReadInto(transform, reader);
            return transform;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Transform transform = (UnityEngine.Transform)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "position":
                        transform.position = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "localPosition":
                        transform.localPosition = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "eulerAngles":
                        reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "localEulerAngles":
                        reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "right":
                        reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "up":
                        reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "forward":
                        reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "rotation":
                        transform.rotation = reader.ReadProperty<UnityEngine.Quaternion>();
                        break;
                    case "localRotation":
                        transform.localRotation = reader.ReadProperty<UnityEngine.Quaternion>();
                        break;
                    case "localScale":
                        transform.localScale = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "parent":
                        if (transform.parent == null)
                        {
                            transform.parent = reader.ReadProperty<UnityEngine.Transform>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Transform>(transform.parent);
                        }
                        break;
                    case "hasChanged":
                        reader.ReadProperty<System.Boolean>();
                        break;
                    case "hierarchyCapacity":
                        reader.ReadProperty<System.Int32>();
                        break;
                    case "tag":
                        transform.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        transform.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        transform.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}