using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Color32 serialization implementation.
	/// </summary>
	public class SaveGameType_Color32 : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Color32 );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Color32 color32 = ( UnityEngine.Color32 )value;
			writer.WriteProperty ( "r", color32.r );
			writer.WriteProperty ( "g", color32.g );
			writer.WriteProperty ( "b", color32.b );
			writer.WriteProperty ( "a", color32.a );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Color32 color32 = new UnityEngine.Color32 ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "r":
						color32.r = reader.ReadProperty<System.Byte> ();
						break;
					case "g":
						color32.g = reader.ReadProperty<System.Byte> ();
						break;
					case "b":
						color32.b = reader.ReadProperty<System.Byte> ();
						break;
					case "a":
						color32.a = reader.ReadProperty<System.Byte> ();
						break;
				}
			}
			return color32;
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