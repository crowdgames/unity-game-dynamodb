using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Texture3D serialization implementation.
    /// </summary>
    public class SaveGameType_Texture3D : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Texture3D);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Texture3D texture3D = (UnityEngine.Texture3D)value;
            writer.WriteProperty("width", texture3D.width);
            writer.WriteProperty("height", texture3D.height);
            writer.WriteProperty("depth", texture3D.depth);
            writer.WriteProperty("dimension", texture3D.dimension);
            writer.WriteProperty("filterMode", texture3D.filterMode);
            writer.WriteProperty("anisoLevel", texture3D.anisoLevel);
            writer.WriteProperty("wrapMode", texture3D.wrapMode);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("wrapModeU", texture3D.wrapModeU);
            writer.WriteProperty("wrapModeV", texture3D.wrapModeV);
            writer.WriteProperty("wrapModeW", texture3D.wrapModeW);
#endif
            writer.WriteProperty("mipMapBias", texture3D.mipMapBias);
            writer.WriteProperty("name", texture3D.name);
            writer.WriteProperty("hideFlags", texture3D.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Texture3D texture3D = new UnityEngine.Texture3D(
                                                  reader.ReadProperty<System.Int32>(),
                                                  reader.ReadProperty<System.Int32>(),
                                                  reader.ReadProperty<System.Int32>(),
                                                  TextureFormat.ARGB32,
                                                  true);
            ReadInto(texture3D, reader);
            return texture3D;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Texture3D texture3D = (UnityEngine.Texture3D)value;
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
                    case "depth":
                        reader.ReadProperty<System.Int32>();
                        break;
                    case "dimension":
                        reader.ReadProperty<UnityEngine.Rendering.TextureDimension>();
                        break;
                    case "filterMode":
                        texture3D.filterMode = reader.ReadProperty<UnityEngine.FilterMode>();
                        break;
                    case "anisoLevel":
                        texture3D.anisoLevel = reader.ReadProperty<System.Int32>();
                        break;
                    case "wrapMode":
                        texture3D.wrapMode = reader.ReadProperty<UnityEngine.TextureWrapMode>();
                        break;
                    case "wrapModeU":
#if UNITY_2017_1_OR_NEWER
                        texture3D.wrapModeU = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeV":
#if UNITY_2017_1_OR_NEWER
                        texture3D.wrapModeV = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeW":
#if UNITY_2017_1_OR_NEWER
                        texture3D.wrapModeW = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "mipMapBias":
                        texture3D.mipMapBias = reader.ReadProperty<System.Single>();
                        break;
                    case "name":
                        texture3D.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        texture3D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}