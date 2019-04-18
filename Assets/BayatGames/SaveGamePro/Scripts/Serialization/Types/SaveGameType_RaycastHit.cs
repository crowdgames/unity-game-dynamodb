using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type RaycastHit serialization implementation.
	/// </summary>
	public class SaveGameType_RaycastHit : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.RaycastHit );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.RaycastHit raycastHit = ( UnityEngine.RaycastHit )value;
			writer.WriteProperty ( "point", raycastHit.point );
			writer.WriteProperty ( "normal", raycastHit.normal );
			writer.WriteProperty ( "barycentricCoordinate", raycastHit.barycentricCoordinate );
			writer.WriteProperty ( "distance", raycastHit.distance );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.RaycastHit raycastHit = new UnityEngine.RaycastHit ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "point":
						raycastHit.point = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "normal":
						raycastHit.normal = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "barycentricCoordinate":
						raycastHit.barycentricCoordinate = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "distance":
						raycastHit.distance = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return raycastHit;
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