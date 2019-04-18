using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SpringJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_SpringJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.SpringJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.SpringJoint2D springJoint2D = ( UnityEngine.SpringJoint2D )value;
			writer.WriteProperty ( "autoConfigureDistance", springJoint2D.autoConfigureDistance );
			writer.WriteProperty ( "distance", springJoint2D.distance );
			writer.WriteProperty ( "dampingRatio", springJoint2D.dampingRatio );
			writer.WriteProperty ( "frequency", springJoint2D.frequency );
			writer.WriteProperty ( "anchor", springJoint2D.anchor );
			writer.WriteProperty ( "connectedAnchor", springJoint2D.connectedAnchor );
			writer.WriteProperty ( "autoConfigureConnectedAnchor", springJoint2D.autoConfigureConnectedAnchor );
			writer.WriteProperty ( "connectedBody", springJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", springJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", springJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", springJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", springJoint2D.enabled );
			writer.WriteProperty ( "tag", springJoint2D.tag );
			writer.WriteProperty ( "name", springJoint2D.name );
			writer.WriteProperty ( "hideFlags", springJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.SpringJoint2D springJoint2D = SaveGameType.CreateComponent<UnityEngine.SpringJoint2D> ();
			ReadInto ( springJoint2D, reader );
			return springJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.SpringJoint2D springJoint2D = ( UnityEngine.SpringJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "autoConfigureDistance":
						springJoint2D.autoConfigureDistance = reader.ReadProperty<System.Boolean> ();
						break;
					case "distance":
						springJoint2D.distance = reader.ReadProperty<System.Single> ();
						break;
					case "dampingRatio":
						springJoint2D.dampingRatio = reader.ReadProperty<System.Single> ();
						break;
					case "frequency":
						springJoint2D.frequency = reader.ReadProperty<System.Single> ();
						break;
					case "anchor":
						springJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "connectedAnchor":
						springJoint2D.connectedAnchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureConnectedAnchor":
						springJoint2D.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean> ();
						break;
					case "connectedBody":
						if ( springJoint2D.connectedBody == null )
						{
							springJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( springJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						springJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						springJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						springJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						springJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						springJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						springJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						springJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}