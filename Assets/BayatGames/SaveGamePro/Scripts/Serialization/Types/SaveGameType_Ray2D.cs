using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Ray2D serialization implementation.
	/// </summary>
	public class SaveGameType_Ray2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Ray2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Ray2D ray2D = ( UnityEngine.Ray2D )value;
			writer.WriteProperty ( "origin", ray2D.origin );
			writer.WriteProperty ( "direction", ray2D.direction );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Ray2D ray2D = new UnityEngine.Ray2D ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "origin":
						ray2D.origin = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "direction":
						ray2D.direction = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
				}
			}
			return ray2D;
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