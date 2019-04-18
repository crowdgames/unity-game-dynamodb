using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type SpriteRenderer serialization implementation.
    /// </summary>
    public class SaveGameType_SpriteRenderer : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.SpriteRenderer);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.SpriteRenderer spriteRenderer = (UnityEngine.SpriteRenderer)value;
            writer.WriteProperty("sprite", spriteRenderer.sprite);
            writer.WriteProperty("drawMode", spriteRenderer.drawMode);
            writer.WriteProperty("size", spriteRenderer.size);
            writer.WriteProperty("adaptiveModeThreshold", spriteRenderer.adaptiveModeThreshold);
            writer.WriteProperty("tileMode", spriteRenderer.tileMode);
            writer.WriteProperty("color", spriteRenderer.color);
            writer.WriteProperty("flipX", spriteRenderer.flipX);
            writer.WriteProperty("flipY", spriteRenderer.flipY);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "maskInteraction", spriteRenderer.maskInteraction );
#endif
            writer.WriteProperty("enabled", spriteRenderer.enabled);
            writer.WriteProperty("shadowCastingMode", spriteRenderer.shadowCastingMode);
            writer.WriteProperty("receiveShadows", spriteRenderer.receiveShadows);
            writer.WriteProperty("material", spriteRenderer.material);
            writer.WriteProperty("sharedMaterial", spriteRenderer.sharedMaterial);
            writer.WriteProperty("materials", spriteRenderer.materials);
            writer.WriteProperty("sharedMaterials", spriteRenderer.sharedMaterials);
            writer.WriteProperty("lightmapIndex", spriteRenderer.lightmapIndex);
            writer.WriteProperty("realtimeLightmapIndex", spriteRenderer.realtimeLightmapIndex);
            writer.WriteProperty("lightmapScaleOffset", spriteRenderer.lightmapScaleOffset);
            writer.WriteProperty("motionVectorGenerationMode", spriteRenderer.motionVectorGenerationMode);
            writer.WriteProperty("realtimeLightmapScaleOffset", spriteRenderer.realtimeLightmapScaleOffset);
            writer.WriteProperty("lightProbeUsage", spriteRenderer.lightProbeUsage);
            writer.WriteProperty("lightProbeProxyVolumeOverride", spriteRenderer.lightProbeProxyVolumeOverride);
            writer.WriteProperty("probeAnchor", spriteRenderer.probeAnchor);
            writer.WriteProperty("reflectionProbeUsage", spriteRenderer.reflectionProbeUsage);
            writer.WriteProperty("sortingLayerName", spriteRenderer.sortingLayerName);
            writer.WriteProperty("sortingLayerID", spriteRenderer.sortingLayerID);
            writer.WriteProperty("sortingOrder", spriteRenderer.sortingOrder);
            writer.WriteProperty("tag", spriteRenderer.tag);
            writer.WriteProperty("name", spriteRenderer.name);
            writer.WriteProperty("hideFlags", spriteRenderer.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.SpriteRenderer spriteRenderer = SaveGameType.CreateComponent<UnityEngine.SpriteRenderer>();
            ReadInto(spriteRenderer, reader);
            return spriteRenderer;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.SpriteRenderer spriteRenderer = (UnityEngine.SpriteRenderer)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "sprite":
                        if (spriteRenderer.sprite == null)
                        {
                            spriteRenderer.sprite = reader.ReadProperty<UnityEngine.Sprite>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Sprite>(spriteRenderer.sprite);
                        }
                        break;
                    case "drawMode":
                        spriteRenderer.drawMode = reader.ReadProperty<UnityEngine.SpriteDrawMode>();
                        break;
                    case "size":
                        spriteRenderer.size = reader.ReadProperty<UnityEngine.Vector2>();
                        break;
                    case "adaptiveModeThreshold":
                        spriteRenderer.adaptiveModeThreshold = reader.ReadProperty<System.Single>();
                        break;
                    case "tileMode":
                        spriteRenderer.tileMode = reader.ReadProperty<UnityEngine.SpriteTileMode>();
                        break;
                    case "color":
                        spriteRenderer.color = reader.ReadProperty<UnityEngine.Color>();
                        break;
                    case "flipX":
                        spriteRenderer.flipX = reader.ReadProperty<System.Boolean>();
                        break;
                    case "flipY":
                        spriteRenderer.flipY = reader.ReadProperty<System.Boolean>();
                        break;
                    case "maskInteraction":
#if UNITY_2017_1_OR_NEWER
                        spriteRenderer.maskInteraction = reader.ReadProperty<UnityEngine.SpriteMaskInteraction>();
#endif
                        break;
                    case "enabled":
                        spriteRenderer.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "shadowCastingMode":
                        spriteRenderer.shadowCastingMode = reader.ReadProperty<UnityEngine.Rendering.ShadowCastingMode>();
                        break;
                    case "receiveShadows":
                        spriteRenderer.receiveShadows = reader.ReadProperty<System.Boolean>();
                        break;
                    case "material":
                        if (spriteRenderer.material == null)
                        {
                            spriteRenderer.material = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(spriteRenderer.material);
                        }
                        break;
                    case "sharedMaterial":
                        if (spriteRenderer.sharedMaterial == null)
                        {
                            spriteRenderer.sharedMaterial = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(spriteRenderer.sharedMaterial);
                        }
                        break;
                    case "materials":
                        spriteRenderer.materials = reader.ReadProperty<UnityEngine.Material[]>();
                        break;
                    case "sharedMaterials":
                        spriteRenderer.sharedMaterials = reader.ReadProperty<UnityEngine.Material[]>();
                        break;
                    case "lightmapIndex":
                        spriteRenderer.lightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "realtimeLightmapIndex":
                        spriteRenderer.realtimeLightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "lightmapScaleOffset":
                        spriteRenderer.lightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "motionVectorGenerationMode":
                        spriteRenderer.motionVectorGenerationMode = reader.ReadProperty<UnityEngine.MotionVectorGenerationMode>();
                        break;
                    case "realtimeLightmapScaleOffset":
                        spriteRenderer.realtimeLightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "lightProbeUsage":
                        spriteRenderer.lightProbeUsage = reader.ReadProperty<UnityEngine.Rendering.LightProbeUsage>();
                        break;
                    case "lightProbeProxyVolumeOverride":
                        if (spriteRenderer.lightProbeProxyVolumeOverride == null)
                        {
                            spriteRenderer.lightProbeProxyVolumeOverride = reader.ReadProperty<UnityEngine.GameObject>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.GameObject>(spriteRenderer.lightProbeProxyVolumeOverride);
                        }
                        break;
                    case "probeAnchor":
                        if (spriteRenderer.probeAnchor == null)
                        {
                            spriteRenderer.probeAnchor = reader.ReadProperty<UnityEngine.Transform>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Transform>(spriteRenderer.probeAnchor);
                        }
                        break;
                    case "reflectionProbeUsage":
                        spriteRenderer.reflectionProbeUsage = reader.ReadProperty<UnityEngine.Rendering.ReflectionProbeUsage>();
                        break;
                    case "sortingLayerName":
                        spriteRenderer.sortingLayerName = reader.ReadProperty<System.String>();
                        break;
                    case "sortingLayerID":
                        spriteRenderer.sortingLayerID = reader.ReadProperty<System.Int32>();
                        break;
                    case "sortingOrder":
                        spriteRenderer.sortingOrder = reader.ReadProperty<System.Int32>();
                        break;
                    case "tag":
                        spriteRenderer.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        spriteRenderer.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        spriteRenderer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}