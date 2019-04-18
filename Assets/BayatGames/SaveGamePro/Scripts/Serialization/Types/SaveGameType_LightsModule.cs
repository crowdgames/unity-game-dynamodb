using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type LightsModule serialization implementation.
	/// </summary>
	public class SaveGameType_LightsModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.LightsModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.LightsModule lightsModule = ( UnityEngine.ParticleSystem.LightsModule )value;
			writer.WriteProperty ( "enabled", lightsModule.enabled );
			writer.WriteProperty ( "ratio", lightsModule.ratio );
			writer.WriteProperty ( "useRandomDistribution", lightsModule.useRandomDistribution );
			writer.WriteProperty ( "light", lightsModule.light );
			writer.WriteProperty ( "useParticleColor", lightsModule.useParticleColor );
			writer.WriteProperty ( "sizeAffectsRange", lightsModule.sizeAffectsRange );
			writer.WriteProperty ( "alphaAffectsIntensity", lightsModule.alphaAffectsIntensity );
			writer.WriteProperty ( "range", lightsModule.range );
			writer.WriteProperty ( "rangeMultiplier", lightsModule.rangeMultiplier );
			writer.WriteProperty ( "intensity", lightsModule.intensity );
			writer.WriteProperty ( "intensityMultiplier", lightsModule.intensityMultiplier );
			writer.WriteProperty ( "maxLights", lightsModule.maxLights );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.LightsModule lightsModule = new UnityEngine.ParticleSystem.LightsModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						lightsModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "ratio":
						lightsModule.ratio = reader.ReadProperty<System.Single> ();
						break;
					case "useRandomDistribution":
						lightsModule.useRandomDistribution = reader.ReadProperty<System.Boolean> ();
						break;
					case "light":
						if ( lightsModule.light == null )
						{
							lightsModule.light = reader.ReadProperty<UnityEngine.Light> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Light> ( lightsModule.light );
						}
						break;
					case "useParticleColor":
						lightsModule.useParticleColor = reader.ReadProperty<System.Boolean> ();
						break;
					case "sizeAffectsRange":
						lightsModule.sizeAffectsRange = reader.ReadProperty<System.Boolean> ();
						break;
					case "alphaAffectsIntensity":
						lightsModule.alphaAffectsIntensity = reader.ReadProperty<System.Boolean> ();
						break;
					case "range":
						lightsModule.range = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "rangeMultiplier":
						lightsModule.rangeMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "intensity":
						lightsModule.intensity = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "intensityMultiplier":
						lightsModule.intensityMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "maxLights":
						lightsModule.maxLights = reader.ReadProperty<System.Int32> ();
						break;
				}
			}
			return lightsModule;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			base.ReadInto ( value, reader );
		}
		
	}

}