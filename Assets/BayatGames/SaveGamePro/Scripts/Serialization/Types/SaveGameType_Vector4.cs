using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Vector4 serialization implementation.
	/// </summary>
	public class SaveGameType_Vector4 : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Vector4 );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Vector4 vector4 = ( UnityEngine.Vector4 )value;
			writer.WriteProperty ( "x", vector4.x );
			writer.WriteProperty ( "y", vector4.y );
			writer.WriteProperty ( "z", vector4.z );
			writer.WriteProperty ( "w", vector4.w );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Vector4 vector4 = new UnityEngine.Vector4 ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "x":
						vector4.x = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						vector4.y = reader.ReadProperty<System.Single> ();
						break;
					case "z":
						vector4.z = reader.ReadProperty<System.Single> ();
						break;
					case "w":
						vector4.w = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return vector4;
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