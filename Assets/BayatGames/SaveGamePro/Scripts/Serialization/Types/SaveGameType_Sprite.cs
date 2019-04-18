using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Sprite serialization implementation.
    /// </summary>
    public class SaveGameType_Sprite : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Sprite);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Sprite sprite = (UnityEngine.Sprite)value;
            writer.WriteProperty("texture", sprite.texture);
            writer.WriteProperty("rect", sprite.rect);
            writer.WriteProperty("pivot", new Vector2(sprite.pivot.x / sprite.rect.width + sprite.rect.x, sprite.pivot.y / sprite.rect.height));
            writer.WriteProperty("pixelsPerUnit", sprite.pixelsPerUnit);
            writer.WriteProperty("name", sprite.name);
            writer.WriteProperty("hideFlags", sprite.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Sprite sprite = UnityEngine.Sprite.Create(
                                            reader.ReadProperty<UnityEngine.Texture2D>(),
                                            reader.ReadProperty<UnityEngine.Rect>(),
                                            reader.ReadProperty<UnityEngine.Vector2>(),
                                            reader.ReadProperty<float>());
            ReadInto(sprite, reader);
            return sprite;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Sprite sprite = (UnityEngine.Sprite)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "texture":
                        Texture2D texture = reader.ReadProperty<UnityEngine.Texture2D>();
                        sprite.texture.LoadRawTextureData(texture.GetRawTextureData());
                        break;
                    case "rect":
                        reader.ReadProperty<UnityEngine.Rect>();
                        break;
                    case "pivot":
                        reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "pixelsPerUnit":
                        reader.ReadProperty<float>();
                        break;
                    case "name":
                        sprite.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        sprite.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}