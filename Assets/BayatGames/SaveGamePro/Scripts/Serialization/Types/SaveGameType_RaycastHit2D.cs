using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type RaycastHit2D serialization implementation.
	/// </summary>
	public class SaveGameType_RaycastHit2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.RaycastHit2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.RaycastHit2D raycastHit2D = ( UnityEngine.RaycastHit2D )value;
			writer.WriteProperty ( "centroid", raycastHit2D.centroid );
			writer.WriteProperty ( "point", raycastHit2D.point );
			writer.WriteProperty ( "normal", raycastHit2D.normal );
			writer.WriteProperty ( "distance", raycastHit2D.distance );
			writer.WriteProperty ( "fraction", raycastHit2D.fraction );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.RaycastHit2D raycastHit2D = new UnityEngine.RaycastHit2D ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "centroid":
						raycastHit2D.centroid = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "point":
						raycastHit2D.point = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "normal":
						raycastHit2D.normal = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "distance":
						raycastHit2D.distance = reader.ReadProperty<System.Single> ();
						break;
					case "fraction":
						raycastHit2D.fraction = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return raycastHit2D;
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