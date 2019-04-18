using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type FrictionJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_FrictionJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.FrictionJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.FrictionJoint2D frictionJoint2D = ( UnityEngine.FrictionJoint2D )value;
			writer.WriteProperty ( "maxForce", frictionJoint2D.maxForce );
			writer.WriteProperty ( "maxTorque", frictionJoint2D.maxTorque );
			writer.WriteProperty ( "anchor", frictionJoint2D.anchor );
			writer.WriteProperty ( "connectedAnchor", frictionJoint2D.connectedAnchor );
			writer.WriteProperty ( "autoConfigureConnectedAnchor", frictionJoint2D.autoConfigureConnectedAnchor );
			writer.WriteProperty ( "connectedBody", frictionJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", frictionJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", frictionJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", frictionJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", frictionJoint2D.enabled );
			writer.WriteProperty ( "tag", frictionJoint2D.tag );
			writer.WriteProperty ( "name", frictionJoint2D.name );
			writer.WriteProperty ( "hideFlags", frictionJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.FrictionJoint2D frictionJoint2D = SaveGameType.CreateComponent<UnityEngine.FrictionJoint2D> ();
			ReadInto ( frictionJoint2D, reader );
			return frictionJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.FrictionJoint2D frictionJoint2D = ( UnityEngine.FrictionJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "maxForce":
						frictionJoint2D.maxForce = reader.ReadProperty<System.Single> ();
						break;
					case "maxTorque":
						frictionJoint2D.maxTorque = reader.ReadProperty<System.Single> ();
						break;
					case "anchor":
						frictionJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "connectedAnchor":
						frictionJoint2D.connectedAnchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureConnectedAnchor":
						frictionJoint2D.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean> ();
						break;
					case "connectedBody":
						if ( frictionJoint2D.connectedBody == null )
						{
							frictionJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( frictionJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						frictionJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						frictionJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						frictionJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						frictionJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						frictionJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						frictionJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						frictionJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}