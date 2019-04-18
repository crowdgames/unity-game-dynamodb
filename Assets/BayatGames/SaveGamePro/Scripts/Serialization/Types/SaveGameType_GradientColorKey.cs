using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type GradientColorKey serialization implementation.
	/// </summary>
	public class SaveGameType_GradientColorKey : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.GradientColorKey );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.GradientColorKey gradientColorKey = ( UnityEngine.GradientColorKey )value;
			writer.WriteProperty ( "color", gradientColorKey.color );
			writer.WriteProperty ( "time", gradientColorKey.time );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.GradientColorKey gradientColorKey = new UnityEngine.GradientColorKey ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "color":
						gradientColorKey.color = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "time":
						gradientColorKey.time = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return gradientColorKey;
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