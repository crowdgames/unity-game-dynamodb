using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

#if UNITY_2017_1_OR_NEWER
    /// <summary>
    /// Save Game Type SpriteMask serialization implementation.
    /// </summary>
    public class SaveGameType_SpriteMask : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.SpriteMask);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.SpriteMask spriteMask = (UnityEngine.SpriteMask)value;
            writer.WriteProperty("sprite", spriteMask.sprite);
            writer.WriteProperty("alphaCutoff", spriteMask.alphaCutoff);
            writer.WriteProperty("isCustomRangeActive", spriteMask.isCustomRangeActive);
            writer.WriteProperty("frontSortingLayerID", spriteMask.frontSortingLayerID);
            writer.WriteProperty("frontSortingOrder", spriteMask.frontSortingOrder);
            writer.WriteProperty("backSortingLayerID", spriteMask.backSortingLayerID);
            writer.WriteProperty("backSortingOrder", spriteMask.backSortingOrder);
            writer.WriteProperty("enabled", spriteMask.enabled);
            writer.WriteProperty("shadowCastingMode", spriteMask.shadowCastingMode);
            writer.WriteProperty("receiveShadows", spriteMask.receiveShadows);
            writer.WriteProperty("material", spriteMask.material);
            writer.WriteProperty("sharedMaterial", spriteMask.sharedMaterial);
            writer.WriteProperty("materials", spriteMask.materials);
            writer.WriteProperty("sharedMaterials", spriteMask.sharedMaterials);
            writer.WriteProperty("lightmapIndex", spriteMask.lightmapIndex);
            writer.WriteProperty("realtimeLightmapIndex", spriteMask.realtimeLightmapIndex);
            writer.WriteProperty("lightmapScaleOffset", spriteMask.lightmapScaleOffset);
            writer.WriteProperty("motionVectorGenerationMode", spriteMask.motionVectorGenerationMode);
            writer.WriteProperty("realtimeLightmapScaleOffset", spriteMask.realtimeLightmapScaleOffset);
            writer.WriteProperty("lightProbeUsage", spriteMask.lightProbeUsage);
            writer.WriteProperty("lightProbeProxyVolumeOverride", spriteMask.lightProbeProxyVolumeOverride);
            writer.WriteProperty("probeAnchor", spriteMask.probeAnchor);
            writer.WriteProperty("reflectionProbeUsage", spriteMask.reflectionProbeUsage);
            writer.WriteProperty("sortingLayerName", spriteMask.sortingLayerName);
            writer.WriteProperty("sortingLayerID", spriteMask.sortingLayerID);
            writer.WriteProperty("sortingOrder", spriteMask.sortingOrder);
            writer.WriteProperty("tag", spriteMask.tag);
            writer.WriteProperty("name", spriteMask.name);
            writer.WriteProperty("hideFlags", spriteMask.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.SpriteMask spriteMask = SaveGameType.CreateComponent<UnityEngine.SpriteMask>();
            ReadInto(spriteMask, reader);
            return spriteMask;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.SpriteMask spriteMask = (UnityEngine.SpriteMask)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "sprite":
                        if (spriteMask.sprite == null)
                        {
                            spriteMask.sprite = reader.ReadProperty<UnityEngine.Sprite>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Sprite>(spriteMask.sprite);
                        }
                        break;
                    case "alphaCutoff":
                        spriteMask.alphaCutoff = reader.ReadProperty<System.Single>();
                        break;
                    case "isCustomRangeActive":
                        spriteMask.isCustomRangeActive = reader.ReadProperty<System.Boolean>();
                        break;
                    case "frontSortingLayerID":
                        spriteMask.frontSortingLayerID = reader.ReadProperty<System.Int32>();
                        break;
                    case "frontSortingOrder":
                        spriteMask.frontSortingOrder = reader.ReadProperty<System.Int32>();
                        break;
                    case "backSortingLayerID":
                        spriteMask.backSortingLayerID = reader.ReadProperty<System.Int32>();
                        break;
                    case "backSortingOrder":
                        spriteMask.backSortingOrder = reader.ReadProperty<System.Int32>();
                        break;
                    case "enabled":
                        spriteMask.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "shadowCastingMode":
                        spriteMask.shadowCastingMode = reader.ReadProperty<UnityEngine.Rendering.ShadowCastingMode>();
                        break;
                    case "receiveShadows":
                        spriteMask.receiveShadows = reader.ReadProperty<System.Boolean>();
                        break;
                    case "material":
                        if (spriteMask.material == null)
                        {
                            spriteMask.material = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(spriteMask.material);
                        }
                        break;
                    case "sharedMaterial":
                        if (spriteMask.sharedMaterial == null)
                        {
                            spriteMask.sharedMaterial = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(spriteMask.sharedMaterial);
                        }
                        break;
                    case "materials":
                        spriteMask.materials = reader.ReadProperty<UnityEngine.Material[]>();
                        break;
                    case "sharedMaterials":
                        spriteMask.sharedMaterials = reader.ReadProperty<UnityEngine.Material[]>();
                        break;
                    case "lightmapIndex":
                        spriteMask.lightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "realtimeLightmapIndex":
                        spriteMask.realtimeLightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "lightmapScaleOffset":
                        spriteMask.lightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "motionVectorGenerationMode":
                        spriteMask.motionVectorGenerationMode = reader.ReadProperty<UnityEngine.MotionVectorGenerationMode>();
                        break;
                    case "realtimeLightmapScaleOffset":
                        spriteMask.realtimeLightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "lightProbeUsage":
                        spriteMask.lightProbeUsage = reader.ReadProperty<UnityEngine.Rendering.LightProbeUsage>();
                        break;
                    case "lightProbeProxyVolumeOverride":
                        if (spriteMask.lightProbeProxyVolumeOverride == null)
                        {
                            spriteMask.lightProbeProxyVolumeOverride = reader.ReadProperty<UnityEngine.GameObject>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.GameObject>(spriteMask.lightProbeProxyVolumeOverride);
                        }
                        break;
                    case "probeAnchor":
                        if (spriteMask.probeAnchor == null)
                        {
                            spriteMask.probeAnchor = reader.ReadProperty<UnityEngine.Transform>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Transform>(spriteMask.probeAnchor);
                        }
                        break;
                    case "reflectionProbeUsage":
                        spriteMask.reflectionProbeUsage = reader.ReadProperty<UnityEngine.Rendering.ReflectionProbeUsage>();
                        break;
                    case "sortingLayerName":
                        spriteMask.sortingLayerName = reader.ReadProperty<System.String>();
                        break;
                    case "sortingLayerID":
                        spriteMask.sortingLayerID = reader.ReadProperty<System.Int32>();
                        break;
                    case "sortingOrder":
                        spriteMask.sortingOrder = reader.ReadProperty<System.Int32>();
                        break;
                    case "tag":
                        spriteMask.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        spriteMask.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        spriteMask.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }
#endif

}