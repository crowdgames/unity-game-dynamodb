using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type WheelJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_WheelJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.WheelJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.WheelJoint2D wheelJoint2D = ( UnityEngine.WheelJoint2D )value;
			writer.WriteProperty ( "suspension", wheelJoint2D.suspension );
			writer.WriteProperty ( "useMotor", wheelJoint2D.useMotor );
			writer.WriteProperty ( "motor", wheelJoint2D.motor );
			writer.WriteProperty ( "anchor", wheelJoint2D.anchor );
			writer.WriteProperty ( "connectedAnchor", wheelJoint2D.connectedAnchor );
			writer.WriteProperty ( "autoConfigureConnectedAnchor", wheelJoint2D.autoConfigureConnectedAnchor );
			writer.WriteProperty ( "connectedBody", wheelJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", wheelJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", wheelJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", wheelJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", wheelJoint2D.enabled );
			writer.WriteProperty ( "tag", wheelJoint2D.tag );
			writer.WriteProperty ( "name", wheelJoint2D.name );
			writer.WriteProperty ( "hideFlags", wheelJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.WheelJoint2D wheelJoint2D = SaveGameType.CreateComponent<UnityEngine.WheelJoint2D> ();
			ReadInto ( wheelJoint2D, reader );
			return wheelJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.WheelJoint2D wheelJoint2D = ( UnityEngine.WheelJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "suspension":
						wheelJoint2D.suspension = reader.ReadProperty<UnityEngine.JointSuspension2D> ();
						break;
					case "useMotor":
						wheelJoint2D.useMotor = reader.ReadProperty<System.Boolean> ();
						break;
					case "motor":
						wheelJoint2D.motor = reader.ReadProperty<UnityEngine.JointMotor2D> ();
						break;
					case "anchor":
						wheelJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "connectedAnchor":
						wheelJoint2D.connectedAnchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureConnectedAnchor":
						wheelJoint2D.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean> ();
						break;
					case "connectedBody":
						if ( wheelJoint2D.connectedBody == null )
						{
							wheelJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( wheelJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						wheelJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						wheelJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						wheelJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						wheelJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						wheelJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						wheelJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						wheelJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}