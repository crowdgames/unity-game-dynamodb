using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type RectTransform serialization implementation.
    /// </summary>
    public class SaveGameType_RectTransform : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.RectTransform);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.RectTransform rectTransform = (UnityEngine.RectTransform)value;
            writer.WriteProperty("anchorMin", rectTransform.anchorMin);
            writer.WriteProperty("anchorMax", rectTransform.anchorMax);
            writer.WriteProperty("anchoredPosition3D", rectTransform.anchoredPosition3D);
            writer.WriteProperty("anchoredPosition", rectTransform.anchoredPosition);
            writer.WriteProperty("sizeDelta", rectTransform.sizeDelta);
            writer.WriteProperty("pivot", rectTransform.pivot);
            writer.WriteProperty("offsetMin", rectTransform.offsetMin);
            writer.WriteProperty("offsetMax", rectTransform.offsetMax);
            writer.WriteProperty("position", rectTransform.position);
            writer.WriteProperty("localPosition", rectTransform.localPosition);
            writer.WriteProperty("eulerAngles", rectTransform.eulerAngles);
            writer.WriteProperty("localEulerAngles", rectTransform.localEulerAngles);
            writer.WriteProperty("right", rectTransform.right);
            writer.WriteProperty("up", rectTransform.up);
            writer.WriteProperty("forward", rectTransform.forward);
            writer.WriteProperty("rotation", rectTransform.rotation);
            writer.WriteProperty("localRotation", rectTransform.localRotation);
            writer.WriteProperty("localScale", rectTransform.localScale);
            writer.WriteProperty("parent", rectTransform.parent);
            writer.WriteProperty("hasChanged", rectTransform.hasChanged);
            writer.WriteProperty("hierarchyCapacity", rectTransform.hierarchyCapacity);
            writer.WriteProperty("tag", rectTransform.tag);
            writer.WriteProperty("name", rectTransform.name);
            writer.WriteProperty("hideFlags", rectTransform.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.RectTransform rectTransform = SaveGameType.CreateComponent<UnityEngine.RectTransform>();
            ReadInto(rectTransform, reader);
            return rectTransform;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.RectTransform rectTransform = (UnityEngine.RectTransform)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "anchorMin":
                        rectTransform.anchorMin = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "anchorMax":
                        rectTransform.anchorMax = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "anchoredPosition3D":
                        rectTransform.anchoredPosition3D = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "anchoredPosition":
                        rectTransform.anchoredPosition = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "sizeDelta":
                        rectTransform.sizeDelta = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "pivot":
                        rectTransform.pivot = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "offsetMin":
                        rectTransform.offsetMin = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "offsetMax":
                        rectTransform.offsetMax = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "position":
                        rectTransform.position = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "localPosition":
                        rectTransform.localPosition = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "eulerAngles":
                        rectTransform.eulerAngles = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "localEulerAngles":
                        rectTransform.localEulerAngles = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "right":
                        rectTransform.right = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "up":
                        rectTransform.up = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "forward":
                        rectTransform.forward = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "rotation":
                        rectTransform.rotation = reader.ReadProperty<UnityEngine.Quaternion>();
                        break;
                    case "localRotation":
                        rectTransform.localRotation = reader.ReadProperty<UnityEngine.Quaternion>();
                        break;
                    case "localScale":
                        rectTransform.localScale = reader.ReadProperty<UnityEngine.Vector3>();
                        break;
                    case "parent":
                        if (rectTransform.parent == null)
                        {
                            rectTransform.SetParent(reader.ReadProperty<UnityEngine.Transform>(), false);
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Transform>(rectTransform.parent);
                        }
                        break;
                    case "hasChanged":
                        rectTransform.hasChanged = reader.ReadProperty<System.Boolean>();
                        break;
                    case "hierarchyCapacity":
                        rectTransform.hierarchyCapacity = reader.ReadProperty<System.Int32>();
                        break;
                    case "tag":
                        rectTransform.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        rectTransform.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        rectTransform.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}