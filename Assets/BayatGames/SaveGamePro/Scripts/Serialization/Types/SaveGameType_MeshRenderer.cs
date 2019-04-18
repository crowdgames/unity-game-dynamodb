using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type MeshRenderer serialization implementation.
    /// </summary>
    public class SaveGameType_MeshRenderer : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.MeshRenderer);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.MeshRenderer meshRenderer = (UnityEngine.MeshRenderer)value;
            writer.WriteProperty("additionalVertexStreams", meshRenderer.additionalVertexStreams);
            writer.WriteProperty("enabled", meshRenderer.enabled);
            writer.WriteProperty("shadowCastingMode", meshRenderer.shadowCastingMode);
            writer.WriteProperty("receiveShadows", meshRenderer.receiveShadows);
            writer.WriteProperty("material", meshRenderer.material);
            writer.WriteProperty("sharedMaterial", meshRenderer.sharedMaterial);
            writer.WriteProperty("materials", meshRenderer.materials);
            writer.WriteProperty("sharedMaterials", meshRenderer.sharedMaterials);
            writer.WriteProperty("lightmapIndex", meshRenderer.lightmapIndex);
            writer.WriteProperty("realtimeLightmapIndex", meshRenderer.realtimeLightmapIndex);
            writer.WriteProperty("lightmapScaleOffset", meshRenderer.lightmapScaleOffset);
            writer.WriteProperty("motionVectorGenerationMode", meshRenderer.motionVectorGenerationMode);
            writer.WriteProperty("realtimeLightmapScaleOffset", meshRenderer.realtimeLightmapScaleOffset);
            writer.WriteProperty("lightProbeUsage", meshRenderer.lightProbeUsage);
            writer.WriteProperty("lightProbeProxyVolumeOverride", meshRenderer.lightProbeProxyVolumeOverride);
            writer.WriteProperty("probeAnchor", meshRenderer.probeAnchor);
            writer.WriteProperty("reflectionProbeUsage", meshRenderer.reflectionProbeUsage);
            writer.WriteProperty("sortingLayerName", meshRenderer.sortingLayerName);
            writer.WriteProperty("sortingLayerID", meshRenderer.sortingLayerID);
            writer.WriteProperty("sortingOrder", meshRenderer.sortingOrder);
            writer.WriteProperty("tag", meshRenderer.tag);
            writer.WriteProperty("name", meshRenderer.name);
            writer.WriteProperty("hideFlags", meshRenderer.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.MeshRenderer meshRenderer = SaveGameType.CreateComponent<UnityEngine.MeshRenderer>();
            ReadInto(meshRenderer, reader);
            return meshRenderer;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.MeshRenderer meshRenderer = (UnityEngine.MeshRenderer)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "additionalVertexStreams":
                        if (meshRenderer.additionalVertexStreams == null)
                        {
                            meshRenderer.additionalVertexStreams = reader.ReadProperty<UnityEngine.Mesh>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Mesh>(meshRenderer.additionalVertexStreams);
                        }
                        break;
                    case "enabled":
                        meshRenderer.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "shadowCastingMode":
                        meshRenderer.shadowCastingMode = reader.ReadProperty<UnityEngine.Rendering.ShadowCastingMode>();
                        break;
                    case "receiveShadows":
                        meshRenderer.receiveShadows = reader.ReadProperty<System.Boolean>();
                        break;
                    case "material":
                        if (meshRenderer.material == null)
                        {
                            meshRenderer.material = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(meshRenderer.material);
                        }
                        break;
                    case "sharedMaterial":
                        if (meshRenderer.sharedMaterial == null)
                        {
                            meshRenderer.sharedMaterial = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(meshRenderer.sharedMaterial);
                        }
                        break;
                    case "materials":
                        //meshRenderer.materials = reader.ReadProperty<UnityEngine.Material[]>();
                        reader.ReadIntoProperty<UnityEngine.Material[]>(meshRenderer.materials);
                        break;
                    case "sharedMaterials":
                        //meshRenderer.sharedMaterials = reader.ReadProperty<UnityEngine.Material[]>();
                        reader.ReadIntoProperty<UnityEngine.Material[]>(meshRenderer.sharedMaterials);
                        break;
                    case "lightmapIndex":
                        meshRenderer.lightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "realtimeLightmapIndex":
                        meshRenderer.realtimeLightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "lightmapScaleOffset":
                        meshRenderer.lightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "motionVectorGenerationMode":
                        meshRenderer.motionVectorGenerationMode = reader.ReadProperty<UnityEngine.MotionVectorGenerationMode>();
                        break;
                    case "realtimeLightmapScaleOffset":
                        meshRenderer.realtimeLightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "lightProbeUsage":
                        meshRenderer.lightProbeUsage = reader.ReadProperty<UnityEngine.Rendering.LightProbeUsage>();
                        break;
                    case "lightProbeProxyVolumeOverride":
                        if (meshRenderer.lightProbeProxyVolumeOverride == null)
                        {
                            meshRenderer.lightProbeProxyVolumeOverride = reader.ReadProperty<UnityEngine.GameObject>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.GameObject>(meshRenderer.lightProbeProxyVolumeOverride);
                        }
                        break;
                    case "probeAnchor":
                        if (meshRenderer.probeAnchor == null)
                        {
                            meshRenderer.probeAnchor = reader.ReadProperty<UnityEngine.Transform>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Transform>(meshRenderer.probeAnchor);
                        }
                        break;
                    case "reflectionProbeUsage":
                        meshRenderer.reflectionProbeUsage = reader.ReadProperty<UnityEngine.Rendering.ReflectionProbeUsage>();
                        break;
                    case "sortingLayerName":
                        meshRenderer.sortingLayerName = reader.ReadProperty<System.String>();
                        break;
                    case "sortingLayerID":
                        meshRenderer.sortingLayerID = reader.ReadProperty<System.Int32>();
                        break;
                    case "sortingOrder":
                        meshRenderer.sortingOrder = reader.ReadProperty<System.Int32>();
                        break;
                    case "tag":
                        meshRenderer.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        meshRenderer.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        meshRenderer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}