using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Keyframe serialization implementation.
    /// </summary>
    public class SaveGameType_Keyframe : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Keyframe);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Keyframe keyframe = (UnityEngine.Keyframe)value;
            writer.WriteProperty("time", keyframe.time);
            writer.WriteProperty("value", keyframe.value);
            writer.WriteProperty("inTangent", keyframe.inTangent);
            writer.WriteProperty("outTangent", keyframe.outTangent);
            //writer.WriteProperty ( "tangentMode", keyframe.tangentMode );
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Keyframe keyframe = new UnityEngine.Keyframe();
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "time":
                        keyframe.time = reader.ReadProperty<System.Single>();
                        break;
                    case "value":
                        keyframe.value = reader.ReadProperty<System.Single>();
                        break;
                    case "inTangent":
                        keyframe.inTangent = reader.ReadProperty<System.Single>();
                        break;
                    case "outTangent":
                        keyframe.outTangent = reader.ReadProperty<System.Single>();
                        break;
                    case "tangentMode": // Obsolote
                        reader.ReadProperty<System.Int32>();
                        break;
                }
            }
            return keyframe;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            base.ReadInto(value, reader);
        }

    }

}