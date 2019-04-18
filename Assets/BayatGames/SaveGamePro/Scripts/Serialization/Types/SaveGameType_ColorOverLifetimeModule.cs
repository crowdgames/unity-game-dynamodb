using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ColorOverLifetimeModule serialization implementation.
	/// </summary>
	public class SaveGameType_ColorOverLifetimeModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.ColorOverLifetimeModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = ( UnityEngine.ParticleSystem.ColorOverLifetimeModule )value;
			writer.WriteProperty ( "enabled", colorOverLifetimeModule.enabled );
			writer.WriteProperty ( "color", colorOverLifetimeModule.color );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = new UnityEngine.ParticleSystem.ColorOverLifetimeModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						colorOverLifetimeModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "color":
						colorOverLifetimeModule.color = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxGradient> ();
						break;
				}
			}
			return colorOverLifetimeModule;
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