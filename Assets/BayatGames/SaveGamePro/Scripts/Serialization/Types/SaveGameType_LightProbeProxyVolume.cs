using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type LightProbeProxyVolume serialization implementation.
	/// </summary>
	public class SaveGameType_LightProbeProxyVolume : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.LightProbeProxyVolume );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.LightProbeProxyVolume lightProbeProxyVolume = ( UnityEngine.LightProbeProxyVolume )value;
			writer.WriteProperty ( "sizeCustom", lightProbeProxyVolume.sizeCustom );
			writer.WriteProperty ( "originCustom", lightProbeProxyVolume.originCustom );
			writer.WriteProperty ( "boundingBoxMode", lightProbeProxyVolume.boundingBoxMode );
			writer.WriteProperty ( "resolutionMode", lightProbeProxyVolume.resolutionMode );
			writer.WriteProperty ( "probePositionMode", lightProbeProxyVolume.probePositionMode );
			writer.WriteProperty ( "refreshMode", lightProbeProxyVolume.refreshMode );
			writer.WriteProperty ( "probeDensity", lightProbeProxyVolume.probeDensity );
			writer.WriteProperty ( "gridResolutionX", lightProbeProxyVolume.gridResolutionX );
			writer.WriteProperty ( "gridResolutionY", lightProbeProxyVolume.gridResolutionY );
			writer.WriteProperty ( "gridResolutionZ", lightProbeProxyVolume.gridResolutionZ );
			writer.WriteProperty ( "enabled", lightProbeProxyVolume.enabled );
			writer.WriteProperty ( "tag", lightProbeProxyVolume.tag );
			writer.WriteProperty ( "name", lightProbeProxyVolume.name );
			writer.WriteProperty ( "hideFlags", lightProbeProxyVolume.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.LightProbeProxyVolume lightProbeProxyVolume = SaveGameType.CreateComponent<UnityEngine.LightProbeProxyVolume> ();
			ReadInto ( lightProbeProxyVolume, reader );
			return lightProbeProxyVolume;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.LightProbeProxyVolume lightProbeProxyVolume = ( UnityEngine.LightProbeProxyVolume )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "sizeCustom":
						lightProbeProxyVolume.sizeCustom = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "originCustom":
						lightProbeProxyVolume.originCustom = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "boundingBoxMode":
						lightProbeProxyVolume.boundingBoxMode = reader.ReadProperty<UnityEngine.LightProbeProxyVolume.BoundingBoxMode> ();
						break;
					case "resolutionMode":
						lightProbeProxyVolume.resolutionMode = reader.ReadProperty<UnityEngine.LightProbeProxyVolume.ResolutionMode> ();
						break;
					case "probePositionMode":
						lightProbeProxyVolume.probePositionMode = reader.ReadProperty<UnityEngine.LightProbeProxyVolume.ProbePositionMode> ();
						break;
					case "refreshMode":
						lightProbeProxyVolume.refreshMode = reader.ReadProperty<UnityEngine.LightProbeProxyVolume.RefreshMode> ();
						break;
					case "probeDensity":
						lightProbeProxyVolume.probeDensity = reader.ReadProperty<System.Single> ();
						break;
					case "gridResolutionX":
						lightProbeProxyVolume.gridResolutionX = reader.ReadProperty<System.Int32> ();
						break;
					case "gridResolutionY":
						lightProbeProxyVolume.gridResolutionY = reader.ReadProperty<System.Int32> ();
						break;
					case "gridResolutionZ":
						lightProbeProxyVolume.gridResolutionZ = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						lightProbeProxyVolume.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						lightProbeProxyVolume.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						lightProbeProxyVolume.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						lightProbeProxyVolume.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}