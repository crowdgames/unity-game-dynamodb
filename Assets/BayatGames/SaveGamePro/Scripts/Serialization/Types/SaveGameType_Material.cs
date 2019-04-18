using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Material serialization implementation.
    /// </summary>
    public class SaveGameType_Material : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Material);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Material material = (UnityEngine.Material)value;
            writer.WriteProperty("shader", material.shader);
            writer.WriteProperty("color", material.color);
            writer.WriteProperty("mainTexture", material.mainTexture);
            writer.WriteProperty("mainTextureOffset", material.mainTextureOffset);
            writer.WriteProperty("mainTextureScale", material.mainTextureScale);
            writer.WriteProperty("renderQueue", material.renderQueue);
            writer.WriteProperty("shaderKeywords", material.shaderKeywords);
            writer.WriteProperty("globalIlluminationFlags", material.globalIlluminationFlags);
            writer.WriteProperty("enableInstancing", material.enableInstancing);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("doubleSidedGI", material.doubleSidedGI);
#endif
            writer.WriteProperty("name", material.name);
            writer.WriteProperty("hideFlags", material.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Material material = new UnityEngine.Material(reader.ReadProperty<UnityEngine.Shader>());
            ReadInto(material, reader);
            return material;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Material material = (UnityEngine.Material)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "shader":
                        if (material.shader == null)
                        {
                            material.shader = reader.ReadProperty<UnityEngine.Shader>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Shader>(material.shader);
                        }
                        break;
                    case "color":
                        material.color = reader.ReadProperty<UnityEngine.Color>();
                        break;
                    case "mainTexture":
                        if (material.mainTexture == null)
                        {
                            material.mainTexture = reader.ReadProperty<UnityEngine.Texture2D>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Texture2D>(material.mainTexture as Texture2D);
                        }
                        break;
                    case "mainTextureOffset":
                        material.mainTextureOffset = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "mainTextureScale":
                        material.mainTextureScale = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "renderQueue":
                        material.renderQueue = reader.ReadProperty<System.Int32>();
                        break;
                    case "shaderKeywords":
                        material.shaderKeywords = reader.ReadProperty<System.String[]>();
                        break;
                    case "globalIlluminationFlags":
                        material.globalIlluminationFlags = reader.ReadProperty<UnityEngine.MaterialGlobalIlluminationFlags>();
                        break;
                    case "enableInstancing":
                        material.enableInstancing = reader.ReadProperty<System.Boolean>();
                        break;
                    case "doubleSidedGI":
#if UNITY_2017_1_OR_NEWER
                        material.doubleSidedGI = reader.ReadProperty<System.Boolean>();
#else
                        reader.ReadProperty<System.Boolean>();
#endif
                        break;
                    case "name":
                        material.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        material.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}