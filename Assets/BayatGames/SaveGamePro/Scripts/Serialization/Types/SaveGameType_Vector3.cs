using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Vector3 serialization implementation.
	/// </summary>
	public class SaveGameType_Vector3 : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Vector3 );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Vector3 vector3 = ( UnityEngine.Vector3 )value;
			writer.WriteProperty ( "x", vector3.x );
			writer.WriteProperty ( "y", vector3.y );
			writer.WriteProperty ( "z", vector3.z );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Vector3 vector3 = new UnityEngine.Vector3 ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "x":
						vector3.x = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						vector3.y = reader.ReadProperty<System.Single> ();
						break;
					case "z":
						vector3.z = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return vector3;
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