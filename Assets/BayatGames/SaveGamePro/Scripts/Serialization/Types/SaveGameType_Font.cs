using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Font serialization implementation.
    /// </summary>
    public class SaveGameType_Font : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Font);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Font font = (UnityEngine.Font)value;
            writer.WriteProperty("fontNames", font.fontNames);
            writer.WriteProperty("characterInfo", font.characterInfo);
            writer.WriteProperty("name", font.name);
            writer.WriteProperty("hideFlags", font.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Font font = new UnityEngine.Font();
            ReadInto(font, reader);
            return font;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Font font = (UnityEngine.Font)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "fontNames":
                        font.fontNames = reader.ReadProperty<System.String[]>();
                        break;
                    case "characterInfo":
                        font.characterInfo = reader.ReadProperty<UnityEngine.CharacterInfo[]>();
                        break;
                    case "name":
                        font.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        font.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}