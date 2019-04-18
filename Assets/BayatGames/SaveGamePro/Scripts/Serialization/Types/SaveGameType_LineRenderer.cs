using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type LineRenderer serialization implementation.
    /// </summary>
    public class SaveGameType_LineRenderer : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.LineRenderer);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.LineRenderer lineRenderer = (UnityEngine.LineRenderer)value;
            writer.WriteProperty("startWidth", lineRenderer.startWidth);
            writer.WriteProperty("endWidth", lineRenderer.endWidth);
            writer.WriteProperty("widthCurve", lineRenderer.widthCurve);
            writer.WriteProperty("widthMultiplier", lineRenderer.widthMultiplier);
            writer.WriteProperty("startColor", lineRenderer.startColor);
            writer.WriteProperty("endColor", lineRenderer.endColor);
            writer.WriteProperty("colorGradient", lineRenderer.colorGradient);
            writer.WriteProperty("positionCount", lineRenderer.positionCount);
            writer.WriteProperty("useWorldSpace", lineRenderer.useWorldSpace);
            writer.WriteProperty("loop", lineRenderer.loop);
            writer.WriteProperty("numCornerVertices", lineRenderer.numCornerVertices);
            writer.WriteProperty("numCapVertices", lineRenderer.numCapVertices);
            writer.WriteProperty("textureMode", lineRenderer.textureMode);
            writer.WriteProperty("alignment", lineRenderer.alignment);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "generateLightingData", lineRenderer.generateLightingData );
#endif
            writer.WriteProperty("enabled", lineRenderer.enabled);
            writer.WriteProperty("shadowCastingMode", lineRenderer.shadowCastingMode);
            writer.WriteProperty("receiveShadows", lineRenderer.receiveShadows);
            writer.WriteProperty("material", lineRenderer.material);
            writer.WriteProperty("sharedMaterial", lineRenderer.sharedMaterial);
            writer.WriteProperty("materials", lineRenderer.materials);
            writer.WriteProperty("sharedMaterials", lineRenderer.sharedMaterials);
            writer.WriteProperty("lightmapIndex", lineRenderer.lightmapIndex);
            writer.WriteProperty("realtimeLightmapIndex", lineRenderer.realtimeLightmapIndex);
            writer.WriteProperty("lightmapScaleOffset", lineRenderer.lightmapScaleOffset);
            writer.WriteProperty("motionVectorGenerationMode", lineRenderer.motionVectorGenerationMode);
            writer.WriteProperty("realtimeLightmapScaleOffset", lineRenderer.realtimeLightmapScaleOffset);
            writer.WriteProperty("lightProbeUsage", lineRenderer.lightProbeUsage);
            writer.WriteProperty("lightProbeProxyVolumeOverride", lineRenderer.lightProbeProxyVolumeOverride);
            writer.WriteProperty("probeAnchor", lineRenderer.probeAnchor);
            writer.WriteProperty("reflectionProbeUsage", lineRenderer.reflectionProbeUsage);
            writer.WriteProperty("sortingLayerName", lineRenderer.sortingLayerName);
            writer.WriteProperty("sortingLayerID", lineRenderer.sortingLayerID);
            writer.WriteProperty("sortingOrder", lineRenderer.sortingOrder);
            writer.WriteProperty("tag", lineRenderer.tag);
            writer.WriteProperty("name", lineRenderer.name);
            writer.WriteProperty("hideFlags", lineRenderer.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.LineRenderer lineRenderer = SaveGameType.CreateComponent<UnityEngine.LineRenderer>();
            ReadInto(lineRenderer, reader);
            return lineRenderer;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.LineRenderer lineRenderer = (UnityEngine.LineRenderer)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "startWidth":
                        lineRenderer.startWidth = reader.ReadProperty<System.Single>();
                        break;
                    case "endWidth":
                        lineRenderer.endWidth = reader.ReadProperty<System.Single>();
                        break;
                    case "widthCurve":
                        lineRenderer.widthCurve = reader.ReadProperty<UnityEngine.AnimationCurve>();
                        break;
                    case "widthMultiplier":
                        lineRenderer.widthMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startColor":
                        lineRenderer.startColor = reader.ReadProperty<UnityEngine.Color>();
                        break;
                    case "endColor":
                        lineRenderer.endColor = reader.ReadProperty<UnityEngine.Color>();
                        break;
                    case "colorGradient":
                        lineRenderer.colorGradient = reader.ReadProperty<UnityEngine.Gradient>();
                        break;
                    case "positionCount":
                        lineRenderer.positionCount = reader.ReadProperty<System.Int32>();
                        break;
                    case "useWorldSpace":
                        lineRenderer.useWorldSpace = reader.ReadProperty<System.Boolean>();
                        break;
                    case "loop":
                        lineRenderer.loop = reader.ReadProperty<System.Boolean>();
                        break;
                    case "numCornerVertices":
                        lineRenderer.numCornerVertices = reader.ReadProperty<System.Int32>();
                        break;
                    case "numCapVertices":
                        lineRenderer.numCapVertices = reader.ReadProperty<System.Int32>();
                        break;
                    case "textureMode":
                        lineRenderer.textureMode = reader.ReadProperty<UnityEngine.LineTextureMode>();
                        break;
                    case "alignment":
                        lineRenderer.alignment = reader.ReadProperty<UnityEngine.LineAlignment>();
                        break;
                    case "generateLightingData":
#if UNITY_2017_1_OR_NEWER
                        lineRenderer.generateLightingData = reader.ReadProperty<System.Boolean>();
#else
                        reader.ReadProperty<System.Boolean>();
#endif
                        break;
                    case "enabled":
                        lineRenderer.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "shadowCastingMode":
                        lineRenderer.shadowCastingMode = reader.ReadProperty<UnityEngine.Rendering.ShadowCastingMode>();
                        break;
                    case "receiveShadows":
                        lineRenderer.receiveShadows = reader.ReadProperty<System.Boolean>();
                        break;
                    case "material":
                        if (lineRenderer.material == null)
                        {
                            lineRenderer.material = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(lineRenderer.material);
                        }
                        break;
                    case "sharedMaterial":
                        if (lineRenderer.sharedMaterial == null)
                        {
                            lineRenderer.sharedMaterial = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(lineRenderer.sharedMaterial);
                        }
                        break;
                    case "materials":
                        lineRenderer.materials = reader.ReadProperty<UnityEngine.Material[]>();
                        break;
                    case "sharedMaterials":
                        lineRenderer.sharedMaterials = reader.ReadProperty<UnityEngine.Material[]>();
                        break;
                    case "lightmapIndex":
                        lineRenderer.lightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "realtimeLightmapIndex":
                        lineRenderer.realtimeLightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "lightmapScaleOffset":
                        lineRenderer.lightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "motionVectorGenerationMode":
                        lineRenderer.motionVectorGenerationMode = reader.ReadProperty<UnityEngine.MotionVectorGenerationMode>();
                        break;
                    case "realtimeLightmapScaleOffset":
                        lineRenderer.realtimeLightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "lightProbeUsage":
                        lineRenderer.lightProbeUsage = reader.ReadProperty<UnityEngine.Rendering.LightProbeUsage>();
                        break;
                    case "lightProbeProxyVolumeOverride":
                        if (lineRenderer.lightProbeProxyVolumeOverride == null)
                        {
                            lineRenderer.lightProbeProxyVolumeOverride = reader.ReadProperty<UnityEngine.GameObject>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.GameObject>(lineRenderer.lightProbeProxyVolumeOverride);
                        }
                        break;
                    case "probeAnchor":
                        if (lineRenderer.probeAnchor == null)
                        {
                            lineRenderer.probeAnchor = reader.ReadProperty<UnityEngine.Transform>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Transform>(lineRenderer.probeAnchor);
                        }
                        break;
                    case "reflectionProbeUsage":
                        lineRenderer.reflectionProbeUsage = reader.ReadProperty<UnityEngine.Rendering.ReflectionProbeUsage>();
                        break;
                    case "sortingLayerName":
                        lineRenderer.sortingLayerName = reader.ReadProperty<System.String>();
                        break;
                    case "sortingLayerID":
                        lineRenderer.sortingLayerID = reader.ReadProperty<System.Int32>();
                        break;
                    case "sortingOrder":
                        lineRenderer.sortingOrder = reader.ReadProperty<System.Int32>();
                        break;
                    case "tag":
                        lineRenderer.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        lineRenderer.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        lineRenderer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}