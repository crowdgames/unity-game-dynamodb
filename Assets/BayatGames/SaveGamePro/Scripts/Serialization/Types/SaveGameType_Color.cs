using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Color serialization implementation.
	/// </summary>
	public class SaveGameType_Color : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Color );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Color color = ( UnityEngine.Color )value;
			writer.WriteProperty ( "r", color.r );
			writer.WriteProperty ( "g", color.g );
			writer.WriteProperty ( "b", color.b );
			writer.WriteProperty ( "a", color.a );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Color color = new UnityEngine.Color ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "r":
						color.r = reader.ReadProperty<System.Single> ();
						break;
					case "g":
						color.g = reader.ReadProperty<System.Single> ();
						break;
					case "b":
						color.b = reader.ReadProperty<System.Single> ();
						break;
					case "a":
						color.a = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return color;
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