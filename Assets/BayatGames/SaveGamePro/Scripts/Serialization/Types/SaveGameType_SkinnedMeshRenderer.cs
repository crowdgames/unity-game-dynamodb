using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SkinnedMeshRenderer serialization implementation.
	/// </summary>
	public class SaveGameType_SkinnedMeshRenderer : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.SkinnedMeshRenderer );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer = ( UnityEngine.SkinnedMeshRenderer )value;
			List<float> blendShapeWeights = new List<float> ();
			for ( int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++ )
			{
				blendShapeWeights.Add ( skinnedMeshRenderer.GetBlendShapeWeight ( i ) );
			}
			writer.WriteProperty ( "blendShapeWeights", blendShapeWeights );
			writer.WriteProperty ( "bones", skinnedMeshRenderer.bones );
			writer.WriteProperty ( "rootBone", skinnedMeshRenderer.rootBone );
			writer.WriteProperty ( "quality", skinnedMeshRenderer.quality );
			writer.WriteProperty ( "sharedMesh", skinnedMeshRenderer.sharedMesh );
			writer.WriteProperty ( "updateWhenOffscreen", skinnedMeshRenderer.updateWhenOffscreen );
			writer.WriteProperty ( "skinnedMotionVectors", skinnedMeshRenderer.skinnedMotionVectors );
			writer.WriteProperty ( "localBounds", skinnedMeshRenderer.localBounds );
			writer.WriteProperty ( "enabled", skinnedMeshRenderer.enabled );
			writer.WriteProperty ( "shadowCastingMode", skinnedMeshRenderer.shadowCastingMode );
			writer.WriteProperty ( "receiveShadows", skinnedMeshRenderer.receiveShadows );
			writer.WriteProperty ( "material", skinnedMeshRenderer.material );
			writer.WriteProperty ( "sharedMaterial", skinnedMeshRenderer.sharedMaterial );
			writer.WriteProperty ( "materials", skinnedMeshRenderer.materials );
			writer.WriteProperty ( "sharedMaterials", skinnedMeshRenderer.sharedMaterials );
			writer.WriteProperty ( "lightmapIndex", skinnedMeshRenderer.lightmapIndex );
			writer.WriteProperty ( "realtimeLightmapIndex", skinnedMeshRenderer.realtimeLightmapIndex );
			writer.WriteProperty ( "lightmapScaleOffset", skinnedMeshRenderer.lightmapScaleOffset );
			writer.WriteProperty ( "motionVectorGenerationMode", skinnedMeshRenderer.motionVectorGenerationMode );
			writer.WriteProperty ( "realtimeLightmapScaleOffset", skinnedMeshRenderer.realtimeLightmapScaleOffset );
			writer.WriteProperty ( "lightProbeUsage", skinnedMeshRenderer.lightProbeUsage );
			writer.WriteProperty ( "lightProbeProxyVolumeOverride", skinnedMeshRenderer.lightProbeProxyVolumeOverride );
			writer.WriteProperty ( "probeAnchor", skinnedMeshRenderer.probeAnchor );
			writer.WriteProperty ( "reflectionProbeUsage", skinnedMeshRenderer.reflectionProbeUsage );
			writer.WriteProperty ( "sortingLayerName", skinnedMeshRenderer.sortingLayerName );
			writer.WriteProperty ( "sortingLayerID", skinnedMeshRenderer.sortingLayerID );
			writer.WriteProperty ( "sortingOrder", skinnedMeshRenderer.sortingOrder );
			writer.WriteProperty ( "tag", skinnedMeshRenderer.tag );
			writer.WriteProperty ( "name", skinnedMeshRenderer.name );
			writer.WriteProperty ( "hideFlags", skinnedMeshRenderer.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer = SaveGameType.CreateComponent<UnityEngine.SkinnedMeshRenderer> ();
			ReadInto ( skinnedMeshRenderer, reader );
			return skinnedMeshRenderer;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer = ( UnityEngine.SkinnedMeshRenderer )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "blendShapeWeights":
						List<float> blendShapeWeights = reader.ReadProperty<List<float>> ();
						for ( int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++ )
						{
							skinnedMeshRenderer.SetBlendShapeWeight ( i, blendShapeWeights [ i ] );
						}
						break;
					case "bones":
						skinnedMeshRenderer.bones = reader.ReadProperty<UnityEngine.Transform []> ();
						break;
					case "rootBone":
						if ( skinnedMeshRenderer.rootBone == null )
						{
							skinnedMeshRenderer.rootBone = reader.ReadProperty<UnityEngine.Transform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Transform> ( skinnedMeshRenderer.rootBone );
						}
						break;
					case "quality":
						skinnedMeshRenderer.quality = reader.ReadProperty<UnityEngine.SkinQuality> ();
						break;
					case "sharedMesh":
						if ( skinnedMeshRenderer.sharedMesh == null )
						{
							skinnedMeshRenderer.sharedMesh = reader.ReadProperty<UnityEngine.Mesh> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Mesh> ( skinnedMeshRenderer.sharedMesh );
						}
						break;
					case "updateWhenOffscreen":
						skinnedMeshRenderer.updateWhenOffscreen = reader.ReadProperty<System.Boolean> ();
						break;
					case "skinnedMotionVectors":
						skinnedMeshRenderer.skinnedMotionVectors = reader.ReadProperty<System.Boolean> ();
						break;
					case "localBounds":
						skinnedMeshRenderer.localBounds = reader.ReadProperty<UnityEngine.Bounds> ();
						break;
					case "enabled":
						skinnedMeshRenderer.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "shadowCastingMode":
						skinnedMeshRenderer.shadowCastingMode = reader.ReadProperty<UnityEngine.Rendering.ShadowCastingMode> ();
						break;
					case "receiveShadows":
						skinnedMeshRenderer.receiveShadows = reader.ReadProperty<System.Boolean> ();
						break;
					case "material":
						if ( skinnedMeshRenderer.material == null )
						{
							skinnedMeshRenderer.material = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( skinnedMeshRenderer.material );
						}
						break;
					case "sharedMaterial":
						if ( skinnedMeshRenderer.sharedMaterial == null )
						{
							skinnedMeshRenderer.sharedMaterial = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( skinnedMeshRenderer.sharedMaterial );
						}
						break;
					case "materials":
						skinnedMeshRenderer.materials = reader.ReadProperty<UnityEngine.Material []> ();
						break;
					case "sharedMaterials":
						skinnedMeshRenderer.sharedMaterials = reader.ReadProperty<UnityEngine.Material []> ();
						break;
					case "lightmapIndex":
						skinnedMeshRenderer.lightmapIndex = reader.ReadProperty<System.Int32> ();
						break;
					case "realtimeLightmapIndex":
						skinnedMeshRenderer.realtimeLightmapIndex = reader.ReadProperty<System.Int32> ();
						break;
					case "lightmapScaleOffset":
						skinnedMeshRenderer.lightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4> ();
						break;
					case "motionVectorGenerationMode":
						skinnedMeshRenderer.motionVectorGenerationMode = reader.ReadProperty<UnityEngine.MotionVectorGenerationMode> ();
						break;
					case "realtimeLightmapScaleOffset":
						skinnedMeshRenderer.realtimeLightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4> ();
						break;
					case "lightProbeUsage":
						skinnedMeshRenderer.lightProbeUsage = reader.ReadProperty<UnityEngine.Rendering.LightProbeUsage> ();
						break;
					case "lightProbeProxyVolumeOverride":
						if ( skinnedMeshRenderer.lightProbeProxyVolumeOverride == null )
						{
							skinnedMeshRenderer.lightProbeProxyVolumeOverride = reader.ReadProperty<UnityEngine.GameObject> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.GameObject> ( skinnedMeshRenderer.lightProbeProxyVolumeOverride );
						}
						break;
					case "probeAnchor":
						if ( skinnedMeshRenderer.probeAnchor == null )
						{
							skinnedMeshRenderer.probeAnchor = reader.ReadProperty<UnityEngine.Transform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Transform> ( skinnedMeshRenderer.probeAnchor );
						}
						break;
					case "reflectionProbeUsage":
						skinnedMeshRenderer.reflectionProbeUsage = reader.ReadProperty<UnityEngine.Rendering.ReflectionProbeUsage> ();
						break;
					case "sortingLayerName":
						skinnedMeshRenderer.sortingLayerName = reader.ReadProperty<System.String> ();
						break;
					case "sortingLayerID":
						skinnedMeshRenderer.sortingLayerID = reader.ReadProperty<System.Int32> ();
						break;
					case "sortingOrder":
						skinnedMeshRenderer.sortingOrder = reader.ReadProperty<System.Int32> ();
						break;
					case "tag":
						skinnedMeshRenderer.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						skinnedMeshRenderer.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						skinnedMeshRenderer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}