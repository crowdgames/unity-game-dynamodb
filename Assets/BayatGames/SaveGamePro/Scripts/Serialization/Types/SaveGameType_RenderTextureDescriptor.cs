using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

#if UNITY_2017_1_OR_NEWER
    /// <summary>
    /// Save Game Type RenderTextureDescriptor serialization implementation.
    /// </summary>
    public class SaveGameType_RenderTextureDescriptor : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.RenderTextureDescriptor);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.RenderTextureDescriptor renderTextureDescriptor = (UnityEngine.RenderTextureDescriptor)value;
            writer.WriteProperty("width", renderTextureDescriptor.width);
            writer.WriteProperty("height", renderTextureDescriptor.height);
            writer.WriteProperty("msaaSamples", renderTextureDescriptor.msaaSamples);
            writer.WriteProperty("volumeDepth", renderTextureDescriptor.volumeDepth);
            writer.WriteProperty("colorFormat", renderTextureDescriptor.colorFormat);
            writer.WriteProperty("depthBufferBits", renderTextureDescriptor.depthBufferBits);
            writer.WriteProperty("dimension", renderTextureDescriptor.dimension);
            writer.WriteProperty("shadowSamplingMode", renderTextureDescriptor.shadowSamplingMode);
            writer.WriteProperty("vrUsage", renderTextureDescriptor.vrUsage);
            writer.WriteProperty("memoryless", renderTextureDescriptor.memoryless);
            writer.WriteProperty("sRGB", renderTextureDescriptor.sRGB);
            writer.WriteProperty("useMipMap", renderTextureDescriptor.useMipMap);
            writer.WriteProperty("autoGenerateMips", renderTextureDescriptor.autoGenerateMips);
            writer.WriteProperty("enableRandomWrite", renderTextureDescriptor.enableRandomWrite);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.RenderTextureDescriptor renderTextureDescriptor = new UnityEngine.RenderTextureDescriptor();
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "width":
                        renderTextureDescriptor.width = reader.ReadProperty<System.Int32>();
                        break;
                    case "height":
                        renderTextureDescriptor.height = reader.ReadProperty<System.Int32>();
                        break;
                    case "msaaSamples":
                        renderTextureDescriptor.msaaSamples = reader.ReadProperty<System.Int32>();
                        break;
                    case "volumeDepth":
                        renderTextureDescriptor.volumeDepth = reader.ReadProperty<System.Int32>();
                        break;
                    case "colorFormat":
                        renderTextureDescriptor.colorFormat = reader.ReadProperty<UnityEngine.RenderTextureFormat>();
                        break;
                    case "depthBufferBits":
                        renderTextureDescriptor.depthBufferBits = reader.ReadProperty<System.Int32>();
                        break;
                    case "dimension":
                        renderTextureDescriptor.dimension = reader.ReadProperty<UnityEngine.Rendering.TextureDimension>();
                        break;
                    case "shadowSamplingMode":
                        renderTextureDescriptor.shadowSamplingMode = reader.ReadProperty<UnityEngine.Rendering.ShadowSamplingMode>();
                        break;
                    case "vrUsage":
                        renderTextureDescriptor.vrUsage = reader.ReadProperty<UnityEngine.VRTextureUsage>();
                        break;
                    case "memoryless":
                        renderTextureDescriptor.memoryless = reader.ReadProperty<UnityEngine.RenderTextureMemoryless>();
                        break;
                    case "sRGB":
                        renderTextureDescriptor.sRGB = reader.ReadProperty<System.Boolean>();
                        break;
                    case "useMipMap":
                        renderTextureDescriptor.useMipMap = reader.ReadProperty<System.Boolean>();
                        break;
                    case "autoGenerateMips":
                        renderTextureDescriptor.autoGenerateMips = reader.ReadProperty<System.Boolean>();
                        break;
                    case "enableRandomWrite":
                        renderTextureDescriptor.enableRandomWrite = reader.ReadProperty<System.Boolean>();
                        break;
                }
            }
            return renderTextureDescriptor;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            base.ReadInto(value, reader);
        }

    }
#endif

}