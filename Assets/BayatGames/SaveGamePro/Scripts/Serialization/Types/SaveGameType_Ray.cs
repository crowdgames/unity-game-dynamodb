using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Ray serialization implementation.
	/// </summary>
	public class SaveGameType_Ray : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Ray );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Ray ray = ( UnityEngine.Ray )value;
			writer.WriteProperty ( "origin", ray.origin );
			writer.WriteProperty ( "direction", ray.direction );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Ray ray = new UnityEngine.Ray ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "origin":
						ray.origin = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "direction":
						ray.direction = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
				}
			}
			return ray;
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