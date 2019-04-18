using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ForceOverLifetimeModule serialization implementation.
	/// </summary>
	public class SaveGameType_ForceOverLifetimeModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.ForceOverLifetimeModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.ForceOverLifetimeModule forceOverLifetimeModule = ( UnityEngine.ParticleSystem.ForceOverLifetimeModule )value;
			writer.WriteProperty ( "enabled", forceOverLifetimeModule.enabled );
			writer.WriteProperty ( "x", forceOverLifetimeModule.x );
			writer.WriteProperty ( "y", forceOverLifetimeModule.y );
			writer.WriteProperty ( "z", forceOverLifetimeModule.z );
			writer.WriteProperty ( "xMultiplier", forceOverLifetimeModule.xMultiplier );
			writer.WriteProperty ( "yMultiplier", forceOverLifetimeModule.yMultiplier );
			writer.WriteProperty ( "zMultiplier", forceOverLifetimeModule.zMultiplier );
			writer.WriteProperty ( "space", forceOverLifetimeModule.space );
			writer.WriteProperty ( "randomized", forceOverLifetimeModule.randomized );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.ForceOverLifetimeModule forceOverLifetimeModule = new UnityEngine.ParticleSystem.ForceOverLifetimeModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						forceOverLifetimeModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "x":
						forceOverLifetimeModule.x = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "y":
						forceOverLifetimeModule.y = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "z":
						forceOverLifetimeModule.z = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "xMultiplier":
						forceOverLifetimeModule.xMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "yMultiplier":
						forceOverLifetimeModule.yMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "zMultiplier":
						forceOverLifetimeModule.zMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "space":
						forceOverLifetimeModule.space = reader.ReadProperty<UnityEngine.ParticleSystemSimulationSpace> ();
						break;
					case "randomized":
						forceOverLifetimeModule.randomized = reader.ReadProperty<System.Boolean> ();
						break;
				}
			}
			return forceOverLifetimeModule;
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