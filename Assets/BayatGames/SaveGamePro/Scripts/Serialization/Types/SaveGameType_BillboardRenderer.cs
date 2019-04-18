using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type BillboardRenderer serialization implementation.
	/// </summary>
	public class SaveGameType_BillboardRenderer : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.BillboardRenderer );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.BillboardRenderer billboardRenderer = ( UnityEngine.BillboardRenderer )value;
			writer.WriteProperty ( "billboard", billboardRenderer.billboard );
			writer.WriteProperty ( "enabled", billboardRenderer.enabled );
			writer.WriteProperty ( "shadowCastingMode", billboardRenderer.shadowCastingMode );
			writer.WriteProperty ( "receiveShadows", billboardRenderer.receiveShadows );
			writer.WriteProperty ( "material", billboardRenderer.material );
			writer.WriteProperty ( "sharedMaterial", billboardRenderer.sharedMaterial );
			writer.WriteProperty ( "materials", billboardRenderer.materials );
			writer.WriteProperty ( "sharedMaterials", billboardRenderer.sharedMaterials );
			writer.WriteProperty ( "lightmapIndex", billboardRenderer.lightmapIndex );
			writer.WriteProperty ( "realtimeLightmapIndex", billboardRenderer.realtimeLightmapIndex );
			writer.WriteProperty ( "lightmapScaleOffset", billboardRenderer.lightmapScaleOffset );
			writer.WriteProperty ( "motionVectorGenerationMode", billboardRenderer.motionVectorGenerationMode );
			writer.WriteProperty ( "realtimeLightmapScaleOffset", billboardRenderer.realtimeLightmapScaleOffset );
			writer.WriteProperty ( "lightProbeUsage", billboardRenderer.lightProbeUsage );
			writer.WriteProperty ( "lightProbeProxyVolumeOverride", billboardRenderer.lightProbeProxyVolumeOverride );
			writer.WriteProperty ( "probeAnchor", billboardRenderer.probeAnchor );
			writer.WriteProperty ( "reflectionProbeUsage", billboardRenderer.reflectionProbeUsage );
			writer.WriteProperty ( "sortingLayerName", billboardRenderer.sortingLayerName );
			writer.WriteProperty ( "sortingLayerID", billboardRenderer.sortingLayerID );
			writer.WriteProperty ( "sortingOrder", billboardRenderer.sortingOrder );
			writer.WriteProperty ( "tag", billboardRenderer.tag );
			writer.WriteProperty ( "name", billboardRenderer.name );
			writer.WriteProperty ( "hideFlags", billboardRenderer.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.BillboardRenderer billboardRenderer = SaveGameType.CreateComponent<UnityEngine.BillboardRenderer> ();
			ReadInto ( billboardRenderer, reader );
			return billboardRenderer;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.BillboardRenderer billboardRenderer = ( UnityEngine.BillboardRenderer )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "billboard":
						if ( billboardRenderer.billboard == null )
						{
							billboardRenderer.billboard = reader.ReadProperty<UnityEngine.BillboardAsset> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.BillboardAsset> ( billboardRenderer.billboard );
						}
						break;
					case "enabled":
						billboardRenderer.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "shadowCastingMode":
						billboardRenderer.shadowCastingMode = reader.ReadProperty<UnityEngine.Rendering.ShadowCastingMode> ();
						break;
					case "receiveShadows":
						billboardRenderer.receiveShadows = reader.ReadProperty<System.Boolean> ();
						break;
					case "material":
						if ( billboardRenderer.material == null )
						{
							billboardRenderer.material = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( billboardRenderer.material );
						}
						break;
					case "sharedMaterial":
						if ( billboardRenderer.sharedMaterial == null )
						{
							billboardRenderer.sharedMaterial = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( billboardRenderer.sharedMaterial );
						}
						break;
					case "materials":
						billboardRenderer.materials = reader.ReadProperty<UnityEngine.Material[]> ();
						break;
					case "sharedMaterials":
						billboardRenderer.sharedMaterials = reader.ReadProperty<UnityEngine.Material[]> ();
						break;
					case "lightmapIndex":
						billboardRenderer.lightmapIndex = reader.ReadProperty<System.Int32> ();
						break;
					case "realtimeLightmapIndex":
						billboardRenderer.realtimeLightmapIndex = reader.ReadProperty<System.Int32> ();
						break;
					case "lightmapScaleOffset":
						billboardRenderer.lightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4> ();
						break;
					case "motionVectorGenerationMode":
						billboardRenderer.motionVectorGenerationMode = reader.ReadProperty<UnityEngine.MotionVectorGenerationMode> ();
						break;
					case "realtimeLightmapScaleOffset":
						billboardRenderer.realtimeLightmapScaleOffset = reader.ReadProperty<UnityEngine.Vector4> ();
						break;
					case "lightProbeUsage":
						billboardRenderer.lightProbeUsage = reader.ReadProperty<UnityEngine.Rendering.LightProbeUsage> ();
						break;
					case "lightProbeProxyVolumeOverride":
						if ( billboardRenderer.lightProbeProxyVolumeOverride == null )
						{
							billboardRenderer.lightProbeProxyVolumeOverride = reader.ReadProperty<UnityEngine.GameObject> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.GameObject> ( billboardRenderer.lightProbeProxyVolumeOverride );
						}
						break;
					case "probeAnchor":
						if ( billboardRenderer.probeAnchor == null )
						{
							billboardRenderer.probeAnchor = reader.ReadProperty<UnityEngine.Transform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Transform> ( billboardRenderer.probeAnchor );
						}
						break;
					case "reflectionProbeUsage":
						billboardRenderer.reflectionProbeUsage = reader.ReadProperty<UnityEngine.Rendering.ReflectionProbeUsage> ();
						break;
					case "sortingLayerName":
						billboardRenderer.sortingLayerName = reader.ReadProperty<System.String> ();
						break;
					case "sortingLayerID":
						billboardRenderer.sortingLayerID = reader.ReadProperty<System.Int32> ();
						break;
					case "sortingOrder":
						billboardRenderer.sortingOrder = reader.ReadProperty<System.Int32> ();
						break;
					case "tag":
						billboardRenderer.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						billboardRenderer.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						billboardRenderer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}