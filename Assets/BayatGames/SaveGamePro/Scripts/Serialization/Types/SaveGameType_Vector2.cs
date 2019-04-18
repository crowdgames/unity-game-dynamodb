using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Vector2 serialization implementation.
	/// </summary>
	public class SaveGameType_Vector2 : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Vector2 );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Vector2 vector2 = ( UnityEngine.Vector2 )value;
			writer.WriteProperty ( "x", vector2.x );
			writer.WriteProperty ( "y", vector2.y );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Vector2 vector2 = new UnityEngine.Vector2 ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "x":
						vector2.x = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						vector2.y = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return vector2;
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