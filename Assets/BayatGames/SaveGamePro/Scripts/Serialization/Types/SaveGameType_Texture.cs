using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Texture serialization implementation.
    /// </summary>
    public class SaveGameType_Texture : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Texture);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Texture texture = (UnityEngine.Texture)value;
            writer.WriteProperty("width", texture.width);
            writer.WriteProperty("height", texture.height);
            writer.WriteProperty("dimension", texture.dimension);
            writer.WriteProperty("filterMode", texture.filterMode);
            writer.WriteProperty("anisoLevel", texture.anisoLevel);
            writer.WriteProperty("wrapMode", texture.wrapMode);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("wrapModeU", texture.wrapModeU);
            writer.WriteProperty("wrapModeV", texture.wrapModeV);
            writer.WriteProperty("wrapModeW", texture.wrapModeW);
#endif
            writer.WriteProperty("mipMapBias", texture.mipMapBias);
            writer.WriteProperty("name", texture.name);
            writer.WriteProperty("hideFlags", texture.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Texture texture = new UnityEngine.Texture2D(0, 0);
            ReadInto(texture, reader);
            return texture;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Texture texture = (UnityEngine.Texture)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "width":
                        reader.ReadProperty<System.Int32>();
                        break;
                    case "height":
                        reader.ReadProperty<System.Int32>();
                        break;
                    case "dimension":
                        reader.ReadProperty<UnityEngine.Rendering.TextureDimension>();
                        break;
                    case "filterMode":
                        texture.filterMode = reader.ReadProperty<UnityEngine.FilterMode>();
                        break;
                    case "anisoLevel":
                        texture.anisoLevel = reader.ReadProperty<System.Int32>();
                        break;
                    case "wrapMode":
                        texture.wrapMode = reader.ReadProperty<UnityEngine.TextureWrapMode>();
                        break;
                    case "wrapModeU":
#if UNITY_2017_1_OR_NEWER
                        texture.wrapModeU = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeV":
#if UNITY_2017_1_OR_NEWER
                        texture.wrapModeV = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeW":
#if UNITY_2017_1_OR_NEWER
                        texture.wrapModeW = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "mipMapBias":
                        texture.mipMapBias = reader.ReadProperty<System.Single>();
                        break;
                    case "name":
                        texture.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        texture.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}