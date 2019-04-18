using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

#if !UNITY_SAMSUNGTV && !UNITY_SWITCH && !UNITY_PSP2

    /// <summary>
    /// Save Game Type VideoClip serialization implementation.
    /// </summary>
    public class SaveGameType_VideoClip : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Video.VideoClip);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Video.VideoClip videoClip = (UnityEngine.Video.VideoClip)value;
            writer.WriteProperty("name", videoClip.name);
            writer.WriteProperty("hideFlags", videoClip.hideFlags);
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
            UnityEngine.Video.VideoClip videoClip = (UnityEngine.Video.VideoClip)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "name":
                        videoClip.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        videoClip.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

#endif

}