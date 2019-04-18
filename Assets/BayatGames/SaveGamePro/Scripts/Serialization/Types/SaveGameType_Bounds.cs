using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Bounds serialization implementation.
	/// </summary>
	public class SaveGameType_Bounds : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Bounds );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Bounds bounds = ( UnityEngine.Bounds )value;
			writer.WriteProperty ( "center", bounds.center );
			writer.WriteProperty ( "size", bounds.size );
			writer.WriteProperty ( "extents", bounds.extents );
			writer.WriteProperty ( "min", bounds.min );
			writer.WriteProperty ( "max", bounds.max );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Bounds bounds = new UnityEngine.Bounds ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "center":
						bounds.center = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "size":
						bounds.size = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "extents":
						bounds.extents = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "min":
						bounds.min = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "max":
						bounds.max = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
				}
			}
			return bounds;
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