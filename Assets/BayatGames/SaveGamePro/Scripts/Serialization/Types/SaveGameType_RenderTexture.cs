using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type RenderTexture serialization implementation.
    /// </summary>
    public class SaveGameType_RenderTexture : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.RenderTexture);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.RenderTexture renderTexture = (UnityEngine.RenderTexture)value;
            writer.WriteProperty("width", renderTexture.width);
            writer.WriteProperty("height", renderTexture.height);
            writer.WriteProperty("depth", renderTexture.depth);
            writer.WriteProperty("isPowerOfTwo", renderTexture.isPowerOfTwo);
            writer.WriteProperty("format", renderTexture.format);
            writer.WriteProperty("useMipMap", renderTexture.useMipMap);
            writer.WriteProperty("autoGenerateMips", renderTexture.autoGenerateMips);
            writer.WriteProperty("dimension", renderTexture.dimension);
            writer.WriteProperty("volumeDepth", renderTexture.volumeDepth);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "memorylessMode", renderTexture.memorylessMode );
#endif
            writer.WriteProperty("antiAliasing", renderTexture.antiAliasing);
            writer.WriteProperty("enableRandomWrite", renderTexture.enableRandomWrite);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("descriptor", renderTexture.descriptor);
#endif
            writer.WriteProperty("filterMode", renderTexture.filterMode);
            writer.WriteProperty("anisoLevel", renderTexture.anisoLevel);
            writer.WriteProperty("wrapMode", renderTexture.wrapMode);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("wrapModeU", renderTexture.wrapModeU);
            writer.WriteProperty("wrapModeV", renderTexture.wrapModeV);
            writer.WriteProperty("wrapModeW", renderTexture.wrapModeW);
#endif
            writer.WriteProperty("mipMapBias", renderTexture.mipMapBias);
            writer.WriteProperty("name", renderTexture.name);
            writer.WriteProperty("hideFlags", renderTexture.hideFlags);
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
            UnityEngine.RenderTexture renderTexture = (UnityEngine.RenderTexture)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "width":
                        renderTexture.width = reader.ReadProperty<System.Int32>();
                        break;
                    case "height":
                        renderTexture.height = reader.ReadProperty<System.Int32>();
                        break;
                    case "depth":
                        renderTexture.depth = reader.ReadProperty<System.Int32>();
                        break;
                    case "isPowerOfTwo":
                        renderTexture.isPowerOfTwo = reader.ReadProperty<System.Boolean>();
                        break;
                    case "format":
                        renderTexture.format = reader.ReadProperty<UnityEngine.RenderTextureFormat>();
                        break;
                    case "useMipMap":
                        renderTexture.useMipMap = reader.ReadProperty<System.Boolean>();
                        break;
                    case "autoGenerateMips":
                        renderTexture.autoGenerateMips = reader.ReadProperty<System.Boolean>();
                        break;
                    case "dimension":
                        renderTexture.dimension = reader.ReadProperty<UnityEngine.Rendering.TextureDimension>();
                        break;
                    case "volumeDepth":
                        renderTexture.volumeDepth = reader.ReadProperty<System.Int32>();
                        break;
                    case "memorylessMode":
#if UNITY_2017_1_OR_NEWER
                        renderTexture.memorylessMode = reader.ReadProperty<UnityEngine.RenderTextureMemoryless>();
#endif
                        break;
                    case "antiAliasing":
                        renderTexture.antiAliasing = reader.ReadProperty<System.Int32>();
                        break;
                    case "enableRandomWrite":
                        renderTexture.enableRandomWrite = reader.ReadProperty<System.Boolean>();
                        break;
                    case "descriptor":
#if UNITY_2017_1_OR_NEWER
                        renderTexture.descriptor = reader.ReadProperty<UnityEngine.RenderTextureDescriptor>();
#endif
                        break;
                    case "filterMode":
                        renderTexture.filterMode = reader.ReadProperty<UnityEngine.FilterMode>();
                        break;
                    case "anisoLevel":
                        renderTexture.anisoLevel = reader.ReadProperty<System.Int32>();
                        break;
                    case "wrapMode":
                        renderTexture.wrapMode = reader.ReadProperty<UnityEngine.TextureWrapMode>();
                        break;
                    case "wrapModeU":
#if UNITY_2017_1_OR_NEWER
                        renderTexture.wrapModeU = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeV":
#if UNITY_2017_1_OR_NEWER
                        renderTexture.wrapModeV = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "wrapModeW":
#if UNITY_2017_1_OR_NEWER
                        renderTexture.wrapModeW = reader.ReadProperty<UnityEngine.TextureWrapMode>();
#else
                        reader.ReadProperty<UnityEngine.TextureWrapMode>();
#endif
                        break;
                    case "mipMapBias":
                        renderTexture.mipMapBias = reader.ReadProperty<System.Single>();
                        break;
                    case "name":
                        renderTexture.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        renderTexture.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}