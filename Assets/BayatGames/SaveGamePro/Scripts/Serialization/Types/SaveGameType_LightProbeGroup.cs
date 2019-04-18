using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type LightProbeGroup serialization implementation.
    /// </summary>
    public class SaveGameType_LightProbeGroup : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.LightProbeGroup);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.LightProbeGroup lightProbeGroup = (UnityEngine.LightProbeGroup)value;
            writer.WriteProperty("enabled", lightProbeGroup.enabled);
            writer.WriteProperty("tag", lightProbeGroup.tag);
            writer.WriteProperty("name", lightProbeGroup.name);
            writer.WriteProperty("hideFlags", lightProbeGroup.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.LightProbeGroup lightProbeGroup = SaveGameType.CreateComponent<UnityEngine.LightProbeGroup>();
            ReadInto(lightProbeGroup, reader);
            return lightProbeGroup;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.LightProbeGroup lightProbeGroup = (UnityEngine.LightProbeGroup)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "probePositions":
                        reader.ReadProperty<UnityEngine.Vector3[]>();
                        break;
                    case "enabled":
                        lightProbeGroup.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "tag":
                        lightProbeGroup.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        lightProbeGroup.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        lightProbeGroup.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}