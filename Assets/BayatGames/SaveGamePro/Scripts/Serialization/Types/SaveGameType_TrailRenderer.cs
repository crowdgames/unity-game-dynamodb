using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type TrailRenderer serialization implementation.
    /// </summary>
    public class SaveGameType_TrailRenderer : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.TrailRenderer);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.TrailRenderer trailRenderer = (UnityEngine.TrailRenderer)value;
            writer.WriteProperty("time", trailRenderer.time);
            writer.WriteProperty("startWidth", trailRenderer.startWidth);
            writer.WriteProperty("endWidth", trailRenderer.endWidth);
            writer.WriteProperty("widthCurve", trailRenderer.widthCurve);
            writer.WriteProperty("widthMultiplier", trailRenderer.widthMultiplier);
            writer.WriteProperty("startColor", trailRenderer.startColor);
            writer.WriteProperty("endColor", trailRenderer.endColor);
            writer.WriteProperty("colorGradient", trailRenderer.colorGradient);
            writer.WriteProperty("autodestruct", trailRenderer.autodestruct);
            writer.WriteProperty("numCornerVertices", trailRenderer.numCornerVertices);
            writer.WriteProperty("numCapVertices", trailRenderer.numCapVertices);
            writer.WriteProperty("minVertexDistance", trailRenderer.minVertexDistance);
            writer.WriteProperty("textureMode", trailRenderer.textureMode);
            writer.WriteProperty("alignment", trailRenderer.alignment);
#if UNITY_2017_1_OR_NEWER
            writer.WriteProperty("generateLightingData", trailRenderer.generateLightingData);
#endif
            writer.WriteProperty("enabled", trailRenderer.enabled);
            writer.WriteProperty("shadowCastingMode", trailRenderer.shadowCastingMode);
            writer.WriteProperty("receiveShadows", trailRenderer.receiveShadows);
            writer.WriteProperty("material", trailRenderer.material);
            writer.WriteProperty("sharedMaterial", trailRenderer.sharedMaterial);
            writer.WriteProperty("materials", trailRenderer.materials);
            writer.WriteProperty("sharedMaterials", trailRenderer.sharedMaterials);
            writer.WriteProperty("lightmapIndex", trailRenderer.lightmapIndex);
            writer.WriteProperty("realtimeLightmapIndex", trailRenderer.realtimeLightmapIndex);
            writer.WriteProperty("lightmapScaleOffset", trailRenderer.lightmapScaleOffset);
            writer.WriteProperty("motionVectorGenerationMode", trailRenderer.motionVectorGenerationMode);
            writer.WriteProperty("realtimeLightmapScaleOffset", trailRenderer.realtimeLightmapScaleOffset);
            writer.WriteProperty("lightProbeUsage", trailRenderer.lightProbeUsage);
            writer.WriteProperty("lightProbeProxyVolumeOverride", trailRenderer.lightProbeProxyVolumeOverride);
            writer.WriteProperty("probeAnchor", trailRenderer.probeAnchor);
            writer.WriteProperty("reflectionProbeUsage", trailRenderer.reflectionProbeUsage);
            writer.WriteProperty("sortingLayerName", trailRenderer.sortingLayerName);
            writer.WriteProperty("sortingLayerID", trailRenderer.sortingLayerID);
            writer.WriteProperty("sortingOrder", trailRenderer.sortingOrder);
            writer.WriteProperty("tag", trailRenderer.tag);
            writer.WriteProperty("name", trailRenderer.name);
            writer.WriteProperty("hideFlags", trailRenderer.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.TrailRenderer trailRenderer = SaveGameType.CreateComponent<UnityEngine.TrailRenderer>();
            ReadInto(trailRenderer, reader);
            return trailRenderer;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.TrailRenderer trailRenderer = (UnityEngine.TrailRenderer)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "time":
                        trailRenderer.time = reader.ReadProperty<System.Single>();
                        break;
                    case "startWidth":
                        trailRenderer.startWidth = reader.ReadProperty<System.Single>();
                        break;
                    case "endWidth":
                        trailRenderer.endWidth = reader.ReadProperty<System.Single>();
                        break;
                    case "widthCurve":
                        trailRenderer.widthCurve = reader.ReadProperty<UnityEngine.AnimationCurve>();
                        break;
                    case "widthMultiplier":
                        trailRenderer.widthMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "startColor":
                        trailRenderer.startColor = reader.ReadProperty<UnityEngine.Color>();
                        break;
                    case "endColor":
                        trailRenderer.endColor = reader.ReadProperty<UnityEngine.Color>();
                        break;
                    case "colorGradient":
                        trailRenderer.colorGradient = reader.ReadProperty<UnityEngine.Gradient>();
                        break;
                    case "autodestruct":
                        trailRenderer.autodestruct = reader.ReadProperty<System.Boolean>();
                        break;
                    case "numCornerVertices":
                        trailRenderer.numCornerVertices = reader.ReadProperty<System.Int32>();
                        break;
                    case "numCapVertices":
                        trailRenderer.numCapVertices = reader.ReadProperty<System.Int32>();
                        break;
                    case "minVertexDistance":
                        trailRenderer.minVertexDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "textureMode":
                        trailRenderer.textureMode = reader.ReadProperty<UnityEngine.LineTextureMode>();
                        break;
                    case "alignment":
                        trailRenderer.alignment = reader.ReadProperty<UnityEngine.LineAlignment>();
                        break;
                    case "generateLightingData":
#if UNITY_2017_1_OR_NEWER
                        trailRenderer.generateLightingData = reader.ReadProperty<System.Boolean>();
#else
                        reader.ReadProperty<System.Boolean>();
#endif
                        break;
                    case "enabled":
                        trailRenderer.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "shadowCastingMode":
                        trailRenderer.shadowCastingMode = reader.ReadProperty<UnityEngine.Rendering.ShadowCastingMode>();
                        break;
                    case "receiveShadows":
                        trailRenderer.receiveShadows = reader.ReadProperty<System.Boolean>();
                        break;
                    case "material":
                        if (trailRenderer.material == null)
                        {
                            trailRenderer.material = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(trailRenderer.material);
                        }
                        break;
                    case "sharedMaterial":
                        if (trailRenderer.sharedMaterial == null)
                        {
                            trailRenderer.sharedMaterial = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(trailRenderer.sharedMaterial);
                        }
                        break;
                    case "materials":
                        trailRenderer.materials = reader.ReadProperty<UnityEngine.Material[]>();
                        break;
                    case "sharedMaterials":
                        trailRenderer.sharedMaterials = reader.ReadProperty<UnityEngine.Material[]>();
                        break;
                    case "lightmapIndex":
                        trailRenderer.lightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "realtimeLightmapIndex":
                        trailRenderer.realtimeLightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "lightmapScaleOffset":
                        trailRenderer.lightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "motionVectorGenerationMode":
                        trailRenderer.motionVectorGenerationMode = reader.ReadProperty<UnityEngine.MotionVectorGenerationMode>();
                        break;
                    case "realtimeLightmapScaleOffset":
                        trailRenderer.realtimeLightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "lightProbeUsage":
                        trailRenderer.lightProbeUsage = reader.ReadProperty<UnityEngine.Rendering.LightProbeUsage>();
                        break;
                    case "lightProbeProxyVolumeOverride":
                        if (trailRenderer.lightProbeProxyVolumeOverride == null)
                        {
                            trailRenderer.lightProbeProxyVolumeOverride = reader.ReadProperty<UnityEngine.GameObject>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.GameObject>(trailRenderer.lightProbeProxyVolumeOverride);
                        }
                        break;
                    case "probeAnchor":
                        if (trailRenderer.probeAnchor == null)
                        {
                            trailRenderer.probeAnchor = reader.ReadProperty<UnityEngine.Transform>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Transform>(trailRenderer.probeAnchor);
                        }
                        break;
                    case "reflectionProbeUsage":
                        trailRenderer.reflectionProbeUsage = reader.ReadProperty<UnityEngine.Rendering.ReflectionProbeUsage>();
                        break;
                    case "sortingLayerName":
                        trailRenderer.sortingLayerName = reader.ReadProperty<System.String>();
                        break;
                    case "sortingLayerID":
                        trailRenderer.sortingLayerID = reader.ReadProperty<System.Int32>();
                        break;
                    case "sortingOrder":
                        trailRenderer.sortingOrder = reader.ReadProperty<System.Int32>();
                        break;
                    case "tag":
                        trailRenderer.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        trailRenderer.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        trailRenderer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}