using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type EmissionModule serialization implementation.
	/// </summary>
	public class SaveGameType_EmissionModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.EmissionModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.EmissionModule emissionModule = ( UnityEngine.ParticleSystem.EmissionModule )value;
			writer.WriteProperty ( "enabled", emissionModule.enabled );
			writer.WriteProperty ( "rateOverTime", emissionModule.rateOverTime );
			writer.WriteProperty ( "rateOverTimeMultiplier", emissionModule.rateOverTimeMultiplier );
			writer.WriteProperty ( "rateOverDistance", emissionModule.rateOverDistance );
			writer.WriteProperty ( "rateOverDistanceMultiplier", emissionModule.rateOverDistanceMultiplier );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.EmissionModule emissionModule = new UnityEngine.ParticleSystem.EmissionModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						emissionModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "rateOverTime":
						emissionModule.rateOverTime = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "rateOverTimeMultiplier":
						emissionModule.rateOverTimeMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "rateOverDistance":
						emissionModule.rateOverDistance = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "rateOverDistanceMultiplier":
						emissionModule.rateOverDistanceMultiplier = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return emissionModule;
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