using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type WheelHit serialization implementation.
	/// </summary>
	public class SaveGameType_WheelHit : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.WheelHit );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.WheelHit wheelHit = ( UnityEngine.WheelHit )value;
			writer.WriteProperty ( "collider", wheelHit.collider );
			writer.WriteProperty ( "point", wheelHit.point );
			writer.WriteProperty ( "normal", wheelHit.normal );
			writer.WriteProperty ( "forwardDir", wheelHit.forwardDir );
			writer.WriteProperty ( "sidewaysDir", wheelHit.sidewaysDir );
			writer.WriteProperty ( "force", wheelHit.force );
			writer.WriteProperty ( "forwardSlip", wheelHit.forwardSlip );
			writer.WriteProperty ( "sidewaysSlip", wheelHit.sidewaysSlip );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.WheelHit wheelHit = new UnityEngine.WheelHit ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "collider":
						if ( wheelHit.collider == null )
						{
							wheelHit.collider = reader.ReadProperty<UnityEngine.Collider> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Collider> ( wheelHit.collider );
						}
						break;
					case "point":
						wheelHit.point = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "normal":
						wheelHit.normal = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "forwardDir":
						wheelHit.forwardDir = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "sidewaysDir":
						wheelHit.sidewaysDir = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "force":
						wheelHit.force = reader.ReadProperty<System.Single> ();
						break;
					case "forwardSlip":
						wheelHit.forwardSlip = reader.ReadProperty<System.Single> ();
						break;
					case "sidewaysSlip":
						wheelHit.sidewaysSlip = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return wheelHit;
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