using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type DistanceJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_DistanceJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.DistanceJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.DistanceJoint2D distanceJoint2D = ( UnityEngine.DistanceJoint2D )value;
			writer.WriteProperty ( "autoConfigureDistance", distanceJoint2D.autoConfigureDistance );
			writer.WriteProperty ( "distance", distanceJoint2D.distance );
			writer.WriteProperty ( "maxDistanceOnly", distanceJoint2D.maxDistanceOnly );
			writer.WriteProperty ( "anchor", distanceJoint2D.anchor );
			writer.WriteProperty ( "connectedAnchor", distanceJoint2D.connectedAnchor );
			writer.WriteProperty ( "autoConfigureConnectedAnchor", distanceJoint2D.autoConfigureConnectedAnchor );
			writer.WriteProperty ( "connectedBody", distanceJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", distanceJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", distanceJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", distanceJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", distanceJoint2D.enabled );
			writer.WriteProperty ( "tag", distanceJoint2D.tag );
			writer.WriteProperty ( "name", distanceJoint2D.name );
			writer.WriteProperty ( "hideFlags", distanceJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.DistanceJoint2D distanceJoint2D = SaveGameType.CreateComponent<UnityEngine.DistanceJoint2D> ();
			ReadInto ( distanceJoint2D, reader );
			return distanceJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.DistanceJoint2D distanceJoint2D = ( UnityEngine.DistanceJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "autoConfigureDistance":
						distanceJoint2D.autoConfigureDistance = reader.ReadProperty<System.Boolean> ();
						break;
					case "distance":
						distanceJoint2D.distance = reader.ReadProperty<System.Single> ();
						break;
					case "maxDistanceOnly":
						distanceJoint2D.maxDistanceOnly = reader.ReadProperty<System.Boolean> ();
						break;
					case "anchor":
						distanceJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "connectedAnchor":
						distanceJoint2D.connectedAnchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureConnectedAnchor":
						distanceJoint2D.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean> ();
						break;
					case "connectedBody":
						if ( distanceJoint2D.connectedBody == null )
						{
							distanceJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( distanceJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						distanceJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						distanceJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						distanceJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						distanceJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						distanceJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						distanceJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						distanceJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}