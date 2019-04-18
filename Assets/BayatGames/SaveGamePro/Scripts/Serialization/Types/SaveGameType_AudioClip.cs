using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type AudioClip serialization implementation.
    /// </summary>
    public class SaveGameType_AudioClip : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.AudioClip);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.AudioClip audioClip = (UnityEngine.AudioClip)value;
            float[] data = new float[audioClip.samples];
            audioClip.GetData(data, 0);
            writer.WriteProperty("data", data);
            writer.WriteProperty("channels", audioClip.channels);
            writer.WriteProperty("frequency", audioClip.frequency);
            writer.WriteProperty("name", audioClip.name);
            writer.WriteProperty("hideFlags", audioClip.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            string name = "";
            float[] data = new float[0];
            int channels = 0;
            int frequency = 0;
            HideFlags flags = HideFlags.None;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "data":
                        data = reader.ReadProperty<float[]>();
                        break;
                    case "channels":
                        channels = reader.ReadProperty<System.Int32>();
                        break;
                    case "frequency":
                        frequency = reader.ReadProperty<System.Int32>();
                        break;
                    case "name":
                        name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        flags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
            AudioClip audioClip = AudioClip.Create(name, data.Length, channels, frequency, false);
            audioClip.SetData(data, 0);
            audioClip.hideFlags = flags;
            return audioClip;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.AudioClip audioClip = (UnityEngine.AudioClip)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "data":
                        audioClip.SetData(reader.ReadProperty<float[]>(), 0);
                        break;
                    case "channels":
                        reader.ReadProperty<System.Int32>();
                        break;
                    case "frequency":
                        reader.ReadProperty<System.Int32>();
                        break;
                    case "name":
                        audioClip.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        audioClip.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}