using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type SparseTexture serialization implementation.
    /// </summary>
    public class SaveGameType_SparseTexture : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.SparseTexture);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.SparseTexture sparseTexture = (UnityEngine.SparseTexture)value;
            writer.WriteProperty("width", sparseTexture.width);
            writer.WriteProperty("height", sparseTexture.height);
            writer.WriteProperty("dimension", sparseTexture.dimension);
            writer.WriteProperty("filterMode", sparseTexture.filterMode);
            writer.WriteProperty("anisoLevel", sparseTexture.anisoLevel);
            writer.WriteProperty("wrapMode", sparseTexture.wrapMode);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "wrapModeU", sparseTexture.wrapModeU );
			writer.WriteProperty ( "wrapModeV", sparseTexture.wrapModeV );
			writer.WriteProperty ( "wrapModeW", sparseTexture.wrapModeW );
#endif
            writer.WriteProperty("mipMapBias", sparseTexture.mipMapBias);
            writer.WriteProperty("name", sparseTexture.name);
            writer.WriteProperty("hideFlags", sparseTexture.hideFlags);
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
            UnityEngine.SparseTexture sparseTexture = (UnityEngine.SparseTexture)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "width":
                        sparseTexture.width = reader.ReadProperty<System.Int32>();
                        break;
                    case "height":
                        sparseTexture.height = reader.ReadProperty<System.Int32>();
                        break;
                    case "dimension":
                        sparseTexture.dimension = reader.ReadProperty<UnityEngine.Rendering.TextureDimension>();
                        break;
                    case "filterMode":
                        sparseTexture.filterMode = reader.ReadProperty<UnityEngine.FilterMode>();
                        break;
                    case "anisoLevel":
                        sparseTexture.anisoLevel = reader.ReadProperty<System.Int32>();
                        break;
                    case "wrapMode":
                        sparseTexture.wrapMode = reader.ReadProperty<UnityEngine.TextureWrapMode>();
                        break;
                    case "wrapModeU":
#if UNITY_2017_1_OR_NEWER
                        sparseTexture.wrapModeU = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeV":
#if UNITY_2017_1_OR_NEWER
                        sparseTexture.wrapModeV = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeW":
#if UNITY_2017_1_OR_NEWER
                        sparseTexture.wrapModeW = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "mipMapBias":
                        sparseTexture.mipMapBias = reader.ReadProperty<System.Single>();
                        break;
                    case "name":
                        sparseTexture.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        sparseTexture.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}