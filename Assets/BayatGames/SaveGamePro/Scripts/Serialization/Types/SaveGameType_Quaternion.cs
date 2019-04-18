using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Quaternion serialization implementation.
	/// </summary>
	public class SaveGameType_Quaternion : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Quaternion );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Quaternion quaternion = ( UnityEngine.Quaternion )value;
			writer.WriteProperty ( "x", quaternion.x );
			writer.WriteProperty ( "y", quaternion.y );
			writer.WriteProperty ( "z", quaternion.z );
			writer.WriteProperty ( "w", quaternion.w );			writer.WriteProperty ( "eulerAngles", quaternion.eulerAngles );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Quaternion quaternion = new UnityEngine.Quaternion ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "x":
						quaternion.x = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						quaternion.y = reader.ReadProperty<System.Single> ();
						break;
					case "z":
						quaternion.z = reader.ReadProperty<System.Single> ();
						break;
					case "w":
						quaternion.w = reader.ReadProperty<System.Single> ();
						break;
					case "eulerAngles":
						quaternion.eulerAngles = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
				}
			}
			return quaternion;
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