using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Light serialization implementation.
	/// </summary>
	public class SaveGameType_Light : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Light );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Light light = ( UnityEngine.Light )value;
			writer.WriteProperty ( "type", light.type );
			writer.WriteProperty ( "color", light.color );
			writer.WriteProperty ( "colorTemperature", light.colorTemperature );
			writer.WriteProperty ( "intensity", light.intensity );
			writer.WriteProperty ( "bounceIntensity", light.bounceIntensity );
			writer.WriteProperty ( "shadows", light.shadows );
			writer.WriteProperty ( "shadowStrength", light.shadowStrength );
			writer.WriteProperty ( "shadowResolution", light.shadowResolution );
			writer.WriteProperty ( "shadowCustomResolution", light.shadowCustomResolution );
			writer.WriteProperty ( "shadowBias", light.shadowBias );
			writer.WriteProperty ( "shadowNormalBias", light.shadowNormalBias );
			writer.WriteProperty ( "shadowNearPlane", light.shadowNearPlane );
			writer.WriteProperty ( "range", light.range );
			writer.WriteProperty ( "spotAngle", light.spotAngle );
			writer.WriteProperty ( "cookieSize", light.cookieSize );
			writer.WriteProperty ( "cookie", light.cookie );
			writer.WriteProperty ( "flare", light.flare );
			writer.WriteProperty ( "renderMode", light.renderMode );
			#if UNITY_2017_3_OR_NEWER
			writer.WriteProperty ( "alreadyLightmapped", light.bakingOutput.isBaked );
			#else
			writer.WriteProperty ( "alreadyLightmapped", light.alreadyLightmapped );
			#endif
			writer.WriteProperty ( "cullingMask", light.cullingMask );
			writer.WriteProperty ( "enabled", light.enabled );
			writer.WriteProperty ( "tag", light.tag );
			writer.WriteProperty ( "name", light.name );
			writer.WriteProperty ( "hideFlags", light.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Light light = SaveGameType.CreateComponent<UnityEngine.Light> ();
			ReadInto ( light, reader );
			return light;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Light light = ( UnityEngine.Light )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "type":
						light.type = reader.ReadProperty<UnityEngine.LightType> ();
						break;
					case "color":
						light.color = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "colorTemperature":
						light.colorTemperature = reader.ReadProperty<System.Single> ();
						break;
					case "intensity":
						light.intensity = reader.ReadProperty<System.Single> ();
						break;
					case "bounceIntensity":
						light.bounceIntensity = reader.ReadProperty<System.Single> ();
						break;
					case "shadows":
						light.shadows = reader.ReadProperty<UnityEngine.LightShadows> ();
						break;
					case "shadowStrength":
						light.shadowStrength = reader.ReadProperty<System.Single> ();
						break;
					case "shadowResolution":
						light.shadowResolution = reader.ReadProperty<UnityEngine.Rendering.LightShadowResolution> ();
						break;
					case "shadowCustomResolution":
						light.shadowCustomResolution = reader.ReadProperty<System.Int32> ();
						break;
					case "shadowBias":
						light.shadowBias = reader.ReadProperty<System.Single> ();
						break;
					case "shadowNormalBias":
						light.shadowNormalBias = reader.ReadProperty<System.Single> ();
						break;
					case "shadowNearPlane":
						light.shadowNearPlane = reader.ReadProperty<System.Single> ();
						break;
					case "range":
						light.range = reader.ReadProperty<System.Single> ();
						break;
					case "spotAngle":
						light.spotAngle = reader.ReadProperty<System.Single> ();
						break;
					case "cookieSize":
						light.cookieSize = reader.ReadProperty<System.Single> ();
						break;
					case "cookie":
						if ( light.cookie == null )
						{
							light.cookie = reader.ReadProperty<UnityEngine.Texture> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Texture> ( light.cookie );
						}
						break;
					case "flare":
						if ( light.flare == null )
						{
							light.flare = reader.ReadProperty<UnityEngine.Flare> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Flare> ( light.flare );
						}
						break;
					case "renderMode":
						light.renderMode = reader.ReadProperty<UnityEngine.LightRenderMode> ();
						break;
					case "alreadyLightmapped":
						#if UNITY_2017_3_OR_NEWER
						LightBakingOutput bakingOutput = light.bakingOutput;
						bakingOutput.isBaked = reader.ReadProperty<System.Boolean> ();
						light.bakingOutput = bakingOutput;
						#else
						light.alreadyLightmapped = reader.ReadProperty<System.Boolean> ();
						#endif
						break;
					case "cullingMask":
						light.cullingMask = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						light.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						light.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						light.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						light.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}