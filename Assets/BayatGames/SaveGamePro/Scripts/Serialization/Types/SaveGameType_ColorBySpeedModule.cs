using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ColorBySpeedModule serialization implementation.
	/// </summary>
	public class SaveGameType_ColorBySpeedModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.ColorBySpeedModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.ColorBySpeedModule colorBySpeedModule = ( UnityEngine.ParticleSystem.ColorBySpeedModule )value;
			writer.WriteProperty ( "enabled", colorBySpeedModule.enabled );
			writer.WriteProperty ( "color", colorBySpeedModule.color );
			writer.WriteProperty ( "range", colorBySpeedModule.range );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.ColorBySpeedModule colorBySpeedModule = new UnityEngine.ParticleSystem.ColorBySpeedModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						colorBySpeedModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "color":
						colorBySpeedModule.color = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxGradient> ();
						break;
					case "range":
						colorBySpeedModule.range = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
				}
			}
			return colorBySpeedModule;
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