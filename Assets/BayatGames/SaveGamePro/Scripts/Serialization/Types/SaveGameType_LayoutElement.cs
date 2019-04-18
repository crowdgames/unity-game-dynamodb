using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type LayoutElement serialization implementation.
    /// </summary>
    public class SaveGameType_LayoutElement : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.UI.LayoutElement);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.UI.LayoutElement layoutElement = (UnityEngine.UI.LayoutElement)value;
            writer.WriteProperty("ignoreLayout", layoutElement.ignoreLayout);
            writer.WriteProperty("minWidth", layoutElement.minWidth);
            writer.WriteProperty("minHeight", layoutElement.minHeight);
            writer.WriteProperty("preferredWidth", layoutElement.preferredWidth);
            writer.WriteProperty("preferredHeight", layoutElement.preferredHeight);
            writer.WriteProperty("flexibleWidth", layoutElement.flexibleWidth);
            writer.WriteProperty("flexibleHeight", layoutElement.flexibleHeight);
            writer.WriteProperty("layoutPriority", layoutElement.layoutPriority);
            writer.WriteProperty("useGUILayout", layoutElement.useGUILayout);
            writer.WriteProperty("enabled", layoutElement.enabled);
            writer.WriteProperty("tag", layoutElement.tag);
            writer.WriteProperty("name", layoutElement.name);
            writer.WriteProperty("hideFlags", layoutElement.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.UI.LayoutElement layoutElement = SaveGameType.CreateComponent<UnityEngine.UI.LayoutElement>();
            ReadInto(layoutElement, reader);
            return layoutElement;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.UI.LayoutElement layoutElement = (UnityEngine.UI.LayoutElement)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "ignoreLayout":
                        layoutElement.ignoreLayout = reader.ReadProperty<System.Boolean>();
                        break;
                    case "minWidth":
                        layoutElement.minWidth = reader.ReadProperty<System.Single>();
                        break;
                    case "minHeight":
                        layoutElement.minHeight = reader.ReadProperty<System.Single>();
                        break;
                    case "preferredWidth":
                        layoutElement.preferredWidth = reader.ReadProperty<System.Single>();
                        break;
                    case "preferredHeight":
                        layoutElement.preferredHeight = reader.ReadProperty<System.Single>();
                        break;
                    case "flexibleWidth":
                        layoutElement.flexibleWidth = reader.ReadProperty<System.Single>();
                        break;
                    case "flexibleHeight":
                        layoutElement.flexibleHeight = reader.ReadProperty<System.Single>();
                        break;
                    case "layoutPriority":
#if UNITY_2017_1_OR_NEWER
						layoutElement.layoutPriority = reader.ReadProperty<System.Int32> ();
#else
                        reader.ReadProperty<System.Int32>();
#endif
                        break;
                    case "useGUILayout":
                        layoutElement.useGUILayout = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enabled":
                        layoutElement.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "tag":
                        layoutElement.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        layoutElement.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        layoutElement.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}