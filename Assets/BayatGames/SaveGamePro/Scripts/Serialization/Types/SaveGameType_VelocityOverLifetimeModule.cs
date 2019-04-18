using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type VelocityOverLifetimeModule serialization implementation.
	/// </summary>
	public class SaveGameType_VelocityOverLifetimeModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.VelocityOverLifetimeModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = ( UnityEngine.ParticleSystem.VelocityOverLifetimeModule )value;
			writer.WriteProperty ( "enabled", velocityOverLifetimeModule.enabled );
			writer.WriteProperty ( "x", velocityOverLifetimeModule.x );
			writer.WriteProperty ( "y", velocityOverLifetimeModule.y );
			writer.WriteProperty ( "z", velocityOverLifetimeModule.z );
			writer.WriteProperty ( "xMultiplier", velocityOverLifetimeModule.xMultiplier );
			writer.WriteProperty ( "yMultiplier", velocityOverLifetimeModule.yMultiplier );
			writer.WriteProperty ( "zMultiplier", velocityOverLifetimeModule.zMultiplier );
			writer.WriteProperty ( "space", velocityOverLifetimeModule.space );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = new UnityEngine.ParticleSystem.VelocityOverLifetimeModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						velocityOverLifetimeModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "x":
						velocityOverLifetimeModule.x = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "y":
						velocityOverLifetimeModule.y = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "z":
						velocityOverLifetimeModule.z = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "xMultiplier":
						velocityOverLifetimeModule.xMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "yMultiplier":
						velocityOverLifetimeModule.yMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "zMultiplier":
						velocityOverLifetimeModule.zMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "space":
						velocityOverLifetimeModule.space = reader.ReadProperty<UnityEngine.ParticleSystemSimulationSpace> ();
						break;
				}
			}
			return velocityOverLifetimeModule;
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