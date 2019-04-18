using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type LightProbes serialization implementation.
    /// </summary>
    public class SaveGameType_LightProbes : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.LightProbes);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.LightProbes lightProbes = (UnityEngine.LightProbes)value;
            writer.WriteProperty("bakedProbes", lightProbes.bakedProbes);
            writer.WriteProperty("name", lightProbes.name);
            writer.WriteProperty("hideFlags", lightProbes.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            return base.Read(reader);
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.LightProbes lightProbes = (UnityEngine.LightProbes)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "bakedProbes":
                        lightProbes.bakedProbes = reader.ReadProperty<UnityEngine.Rendering.SphericalHarmonicsL2[]>();
                        break;
                    case "name":
                        lightProbes.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        lightProbes.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}