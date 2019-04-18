using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

    /// <summary>
    /// Save Game Type Terrain serialization implementation.
    /// </summary>
    public class SaveGameType_Terrain : SaveGameType
    {

        /// <summary>
        /// Gets the associated type for this custom type.
        /// </summary>
        /// <value>The type of the associated.</value>
        public override Type AssociatedType
        {
            get
            {
                return typeof(UnityEngine.Terrain);
            }
        }

        /// <summary>
        /// Write the specified value using the writer.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="writer">Writer.</param>
        public override void Write(object value, ISaveGameWriter writer)
        {
            UnityEngine.Terrain terrain = (UnityEngine.Terrain)value;
            writer.WriteProperty("terrainData", terrain.terrainData);
            writer.WriteProperty("treeDistance", terrain.treeDistance);
            writer.WriteProperty("treeBillboardDistance", terrain.treeBillboardDistance);
            writer.WriteProperty("treeCrossFadeLength", terrain.treeCrossFadeLength);
            writer.WriteProperty("treeMaximumFullLODCount", terrain.treeMaximumFullLODCount);
            writer.WriteProperty("detailObjectDistance", terrain.detailObjectDistance);
            writer.WriteProperty("detailObjectDensity", terrain.detailObjectDensity);
            writer.WriteProperty("heightmapPixelError", terrain.heightmapPixelError);
            writer.WriteProperty("heightmapMaximumLOD", terrain.heightmapMaximumLOD);
            writer.WriteProperty("basemapDistance", terrain.basemapDistance);
            writer.WriteProperty("lightmapIndex", terrain.lightmapIndex);
            writer.WriteProperty("realtimeLightmapIndex", terrain.realtimeLightmapIndex);
            writer.WriteProperty("lightmapScaleOffset", terrain.lightmapScaleOffset);
            writer.WriteProperty("realtimeLightmapScaleOffset", terrain.realtimeLightmapScaleOffset);
            writer.WriteProperty("castShadows", terrain.castShadows);
            writer.WriteProperty("reflectionProbeUsage", terrain.reflectionProbeUsage);
            writer.WriteProperty("materialType", terrain.materialType);
            writer.WriteProperty("materialTemplate", terrain.materialTemplate);
            writer.WriteProperty("legacySpecular", terrain.legacySpecular);
            writer.WriteProperty("legacyShininess", terrain.legacyShininess);
            writer.WriteProperty("drawHeightmap", terrain.drawHeightmap);
            writer.WriteProperty("drawTreesAndFoliage", terrain.drawTreesAndFoliage);
#if UNITY_2017_1_OR_NEWER
			writer.WriteProperty ( "patchBoundsMultiplier", terrain.patchBoundsMultiplier );
#endif
            writer.WriteProperty("treeLODBiasMultiplier", terrain.treeLODBiasMultiplier);
            writer.WriteProperty("collectDetailPatches", terrain.collectDetailPatches);
            writer.WriteProperty("editorRenderFlags", terrain.editorRenderFlags);
            writer.WriteProperty("enabled", terrain.enabled);
            writer.WriteProperty("tag", terrain.tag);
            writer.WriteProperty("name", terrain.name);
            writer.WriteProperty("hideFlags", terrain.hideFlags);
        }

        /// <summary>
        /// Read the data using the reader.
        /// </summary>
        /// <param name="reader">Reader.</param>
        public override object Read(ISaveGameReader reader)
        {
            UnityEngine.Terrain terrain = SaveGameType.CreateComponent<UnityEngine.Terrain>();
            ReadInto(terrain, reader);
            return terrain;
        }

        /// <summary>
        /// Read the data into the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="reader">Reader.</param>
        public override void ReadInto(object value, ISaveGameReader reader)
        {
            UnityEngine.Terrain terrain = (UnityEngine.Terrain)value;
            foreach (string property in reader.Properties)
            {
                switch (property)
                {
                    case "terrainData":
                        if (terrain.terrainData == null)
                        {
                            terrain.terrainData = reader.ReadProperty<UnityEngine.TerrainData>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.TerrainData>(terrain.terrainData);
                        }
                        break;
                    case "treeDistance":
                        terrain.treeDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "treeBillboardDistance":
                        terrain.treeBillboardDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "treeCrossFadeLength":
                        terrain.treeCrossFadeLength = reader.ReadProperty<System.Single>();
                        break;
                    case "treeMaximumFullLODCount":
                        terrain.treeMaximumFullLODCount = reader.ReadProperty<System.Int32>();
                        break;
                    case "detailObjectDistance":
                        terrain.detailObjectDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "detailObjectDensity":
                        terrain.detailObjectDensity = reader.ReadProperty<System.Single>();
                        break;
                    case "heightmapPixelError":
                        terrain.heightmapPixelError = reader.ReadProperty<System.Single>();
                        break;
                    case "heightmapMaximumLOD":
                        terrain.heightmapMaximumLOD = reader.ReadProperty<System.Int32>();
                        break;
                    case "basemapDistance":
                        terrain.basemapDistance = reader.ReadProperty<System.Single>();
                        break;
                    case "lightmapIndex":
                        terrain.lightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "realtimeLightmapIndex":
                        terrain.realtimeLightmapIndex = reader.ReadProperty<System.Int32>();
                        break;
                    case "lightmapScaleOffset":
                        terrain.lightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "realtimeLightmapScaleOffset":
                        terrain.realtimeLightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4>();
                        break;
                    case "castShadows":
                        terrain.castShadows = reader.ReadProperty<System.Boolean>();
                        break;
                    case "reflectionProbeUsage":
                        terrain.reflectionProbeUsage = reader.ReadProperty<UnityEngine.Rendering.ReflectionProbeUsage>();
                        break;
                    case "materialType":
                        terrain.materialType = reader.ReadProperty<UnityEngine.Terrain.MaterialType>();
                        break;
                    case "materialTemplate":
                        if (terrain.materialTemplate == null)
                        {
                            terrain.materialTemplate = reader.ReadProperty<UnityEngine.Material>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<UnityEngine.Material>(terrain.materialTemplate);
                        }
                        break;
                    case "legacySpecular":
                        terrain.legacySpecular = reader.ReadProperty<UnityEngine.Color>();
                        break;
                    case "legacyShininess":
                        terrain.legacyShininess = reader.ReadProperty<System.Single>();
                        break;
                    case "drawHeightmap":
                        terrain.drawHeightmap = reader.ReadProperty<System.Boolean>();
                        break;
                    case "drawTreesAndFoliage":
                        terrain.drawTreesAndFoliage = reader.ReadProperty<System.Boolean>();
                        break;
                    case "patchBoundsMultiplier":
#if UNITY_2017_1_OR_NEWER
                        terrain.patchBoundsMultiplier = reader.ReadProperty<UnityEngine.Vector3>();
#else
                        reader.ReadProperty<UnityEngine.Vector3>();
#endif
                        break;
                    case "treeLODBiasMultiplier":
                        terrain.treeLODBiasMultiplier = reader.ReadProperty<System.Single>();
                        break;
                    case "collectDetailPatches":
                        terrain.collectDetailPatches = reader.ReadProperty<System.Boolean>();
                        break;
                    case "editorRenderFlags":
                        terrain.editorRenderFlags = reader.ReadProperty<UnityEngine.TerrainRenderFlags>();
                        break;
                    case "enabled":
                        terrain.enabled = reader.ReadProperty<System.Boolean>();
                        break;
                    case "tag":
                        terrain.tag = reader.ReadProperty<System.String>();
                        break;
                    case "name":
                        terrain.name = reader.ReadProperty<System.String>();
                        break;
                    case "hideFlags":
                        terrain.hideFlags = reader.ReadProperty<UnityEngine.HideFlags>();
                        break;
                }
            }
        }

    }

}