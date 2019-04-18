using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type LimitVelocityOverLifetimeModule serialization implementation.
	/// </summary>
	public class SaveGameType_LimitVelocityOverLifetimeModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetimeModule = ( UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule )value;
			writer.WriteProperty ( "enabled", limitVelocityOverLifetimeModule.enabled );
			writer.WriteProperty ( "limitX", limitVelocityOverLifetimeModule.limitX );
			writer.WriteProperty ( "limitXMultiplier", limitVelocityOverLifetimeModule.limitXMultiplier );
			writer.WriteProperty ( "limitY", limitVelocityOverLifetimeModule.limitY );
			writer.WriteProperty ( "limitYMultiplier", limitVelocityOverLifetimeModule.limitYMultiplier );
			writer.WriteProperty ( "limitZ", limitVelocityOverLifetimeModule.limitZ );
			writer.WriteProperty ( "limitZMultiplier", limitVelocityOverLifetimeModule.limitZMultiplier );
			writer.WriteProperty ( "limit", limitVelocityOverLifetimeModule.limit );
			writer.WriteProperty ( "limitMultiplier", limitVelocityOverLifetimeModule.limitMultiplier );
			writer.WriteProperty ( "dampen", limitVelocityOverLifetimeModule.dampen );
			writer.WriteProperty ( "separateAxes", limitVelocityOverLifetimeModule.separateAxes );
			writer.WriteProperty ( "space", limitVelocityOverLifetimeModule.space );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetimeModule = new UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						limitVelocityOverLifetimeModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "limitX":
						limitVelocityOverLifetimeModule.limitX = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "limitXMultiplier":
						limitVelocityOverLifetimeModule.limitXMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "limitY":
						limitVelocityOverLifetimeModule.limitY = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "limitYMultiplier":
						limitVelocityOverLifetimeModule.limitYMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "limitZ":
						limitVelocityOverLifetimeModule.limitZ = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "limitZMultiplier":
						limitVelocityOverLifetimeModule.limitZMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "limit":
						limitVelocityOverLifetimeModule.limit = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "limitMultiplier":
						limitVelocityOverLifetimeModule.limitMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "dampen":
						limitVelocityOverLifetimeModule.dampen = reader.ReadProperty<System.Single> ();
						break;
					case "separateAxes":
						limitVelocityOverLifetimeModule.separateAxes = reader.ReadProperty<System.Boolean> ();
						break;
					case "space":
						limitVelocityOverLifetimeModule.space = reader.ReadProperty<UnityEngine.ParticleSystemSimulationSpace> ();
						break;
				}
			}
			return limitVelocityOverLifetimeModule;
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