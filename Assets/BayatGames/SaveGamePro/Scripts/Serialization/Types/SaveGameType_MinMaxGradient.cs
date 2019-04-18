using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type MinMaxGradient serialization implementation.
	/// </summary>
	public class SaveGameType_MinMaxGradient : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.MinMaxGradient );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.MinMaxGradient minMaxGradient = ( UnityEngine.ParticleSystem.MinMaxGradient )value;
			writer.WriteProperty ( "mode", minMaxGradient.mode );
			writer.WriteProperty ( "gradientMax", minMaxGradient.gradientMax );
			writer.WriteProperty ( "gradientMin", minMaxGradient.gradientMin );
			writer.WriteProperty ( "colorMax", minMaxGradient.colorMax );
			writer.WriteProperty ( "colorMin", minMaxGradient.colorMin );
			writer.WriteProperty ( "color", minMaxGradient.color );
			writer.WriteProperty ( "gradient", minMaxGradient.gradient );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.MinMaxGradient minMaxGradient = new UnityEngine.ParticleSystem.MinMaxGradient ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "mode":
						minMaxGradient.mode = reader.ReadProperty<UnityEngine.ParticleSystemGradientMode> ();
						break;
					case "gradientMax":
						minMaxGradient.gradientMax = reader.ReadProperty<UnityEngine.Gradient> ();
						break;
					case "gradientMin":
						minMaxGradient.gradientMin = reader.ReadProperty<UnityEngine.Gradient> ();
						break;
					case "colorMax":
						minMaxGradient.colorMax = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "colorMin":
						minMaxGradient.colorMin = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "color":
						minMaxGradient.color = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "gradient":
						minMaxGradient.gradient = reader.ReadProperty<UnityEngine.Gradient> ();
						break;
				}
			}
			return minMaxGradient;
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