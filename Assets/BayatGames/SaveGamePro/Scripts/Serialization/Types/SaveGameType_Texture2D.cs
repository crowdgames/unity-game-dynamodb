using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Texture2D serialization implementation.
    /// </summary>
    public class SaveGameType_Texture2D : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Texture2D);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Texture2D texture2D = (UnityEngine.Texture2D)value;
            writer.WriteProperty("width", texture2D.width);
            writer.WriteProperty("height", texture2D.height);
            writer.WriteProperty("rawTextureData", texture2D.EncodeToPNG());
            writer.WriteProperty("dimension", texture2D.dimension);
            writer.WriteProperty("filterMode", texture2D.filterMode);
            writer.WriteProperty("anisoLevel", texture2D.anisoLevel);
            writer.WriteProperty("wrapMode", texture2D.wrapMode);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "wrapModeU", texture2D.wrapModeU );
			writer.WriteProperty ( "wrapModeV", texture2D.wrapModeV );
			writer.WriteProperty ( "wrapModeW", texture2D.wrapModeW );
#endif
            writer.WriteProperty("mipMapBias", texture2D.mipMapBias);
            writer.WriteProperty("name", texture2D.name);
            writer.WriteProperty("hideFlags", texture2D.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Texture2D texture2D = new UnityEngine.Texture2D(0, 0);
            ReadInto(texture2D, reader);
            return texture2D;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Texture2D texture2D = (UnityEngine.Texture2D)value;
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
                    case "rawTextureData":
                        texture2D.LoadImage(reader.ReadProperty<byte[]>());
                        texture2D.Apply();
                        break;
                    case "dimension":
                        reader.ReadProperty<UnityEngine.Rendering.TextureDimension>();
                        break;
                    case "filterMode":
                        texture2D.filterMode = reader.ReadProperty<UnityEngine.FilterMode>();
                        break;
                    case "anisoLevel":
                        texture2D.anisoLevel = reader.ReadProperty<System.Int32>();
                        break;
                    case "wrapMode":
                        texture2D.wrapMode = reader.ReadProperty<UnityEngine.TextureWrapMode>();
                        break;
                    case "wrapModeU":
#if UNITY_2017_1_OR_NEWER
                        texture2D.wrapModeU = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeV":
#if UNITY_2017_1_OR_NEWER
                        texture2D.wrapModeV = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeW":
#if UNITY_2017_1_OR_NEWER
                        texture2D.wrapModeW = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "mipMapBias":
                        texture2D.mipMapBias = reader.ReadProperty<System.Single>();
                        break;
                    case "name":
                        texture2D.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        texture2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}