using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Texture2DArray serialization implementation.
    /// </summary>
    public class SaveGameType_Texture2DArray : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Texture2DArray);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Texture2DArray texture2DArray = (UnityEngine.Texture2DArray)value;
            writer.WriteProperty("width", texture2DArray.width);
            writer.WriteProperty("height", texture2DArray.height);
            writer.WriteProperty("depth", texture2DArray.depth);
            writer.WriteProperty("dimension", texture2DArray.dimension);
            writer.WriteProperty("filterMode", texture2DArray.filterMode);
            writer.WriteProperty("anisoLevel", texture2DArray.anisoLevel);
            writer.WriteProperty("wrapMode", texture2DArray.wrapMode);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "wrapModeU", texture2DArray.wrapModeU );
			writer.WriteProperty ( "wrapModeV", texture2DArray.wrapModeV );
			writer.WriteProperty ( "wrapModeW", texture2DArray.wrapModeW );
#endif
            writer.WriteProperty("mipMapBias", texture2DArray.mipMapBias);
            writer.WriteProperty("name", texture2DArray.name);
            writer.WriteProperty("hideFlags", texture2DArray.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Texture2DArray texture2DArray = new UnityEngine.Texture2DArray(
                                                            reader.ReadProperty<System.Int32>(),
                                                            reader.ReadProperty<System.Int32>(),
                                                            reader.ReadProperty<System.Int32>(),
                                                            TextureFormat.ARGB32,
                                                            true);
            ReadInto(texture2DArray, reader);
            return texture2DArray;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Texture2DArray texture2DArray = (UnityEngine.Texture2DArray)value;
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
                        texture2DArray.filterMode = reader.ReadProperty<UnityEngine.FilterMode>();
                        break;
                    case "anisoLevel":
                        texture2DArray.anisoLevel = reader.ReadProperty<System.Int32>();
                        break;
                    case "wrapMode":
                        texture2DArray.wrapMode = reader.ReadProperty<UnityEngine.TextureWrapMode>();
                        break;
                    case "wrapModeU":
#if UNITY_2017_1_OR_NEWER
                        texture2DArray.wrapModeU = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeV":
#if UNITY_2017_1_OR_NEWER
                        texture2DArray.wrapModeV = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeW":
#if UNITY_2017_1_OR_NEWER
                        texture2DArray.wrapModeW = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "mipMapBias":
                        texture2DArray.mipMapBias = reader.ReadProperty<System.Single>();
                        break;
                    case "name":
                        texture2DArray.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        texture2DArray.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}