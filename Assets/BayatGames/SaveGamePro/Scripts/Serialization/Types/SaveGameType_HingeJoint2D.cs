using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type HingeJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_HingeJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.HingeJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.HingeJoint2D hingeJoint2D = ( UnityEngine.HingeJoint2D )value;
			writer.WriteProperty ( "useMotor", hingeJoint2D.useMotor );
			writer.WriteProperty ( "useLimits", hingeJoint2D.useLimits );
			writer.WriteProperty ( "motor", hingeJoint2D.motor );
			writer.WriteProperty ( "limits", hingeJoint2D.limits );
			writer.WriteProperty ( "anchor", hingeJoint2D.anchor );
			writer.WriteProperty ( "connectedAnchor", hingeJoint2D.connectedAnchor );
			writer.WriteProperty ( "autoConfigureConnectedAnchor", hingeJoint2D.autoConfigureConnectedAnchor );
			writer.WriteProperty ( "connectedBody", hingeJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", hingeJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", hingeJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", hingeJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", hingeJoint2D.enabled );
			writer.WriteProperty ( "tag", hingeJoint2D.tag );
			writer.WriteProperty ( "name", hingeJoint2D.name );
			writer.WriteProperty ( "hideFlags", hingeJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.HingeJoint2D hingeJoint2D = SaveGameType.CreateComponent<UnityEngine.HingeJoint2D> ();
			ReadInto ( hingeJoint2D, reader );
			return hingeJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.HingeJoint2D hingeJoint2D = ( UnityEngine.HingeJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "useMotor":
						hingeJoint2D.useMotor = reader.ReadProperty<System.Boolean> ();
						break;
					case "useLimits":
						hingeJoint2D.useLimits = reader.ReadProperty<System.Boolean> ();
						break;
					case "motor":
						hingeJoint2D.motor = reader.ReadProperty<UnityEngine.JointMotor2D> ();
						break;
					case "limits":
						hingeJoint2D.limits = reader.ReadProperty<UnityEngine.JointAngleLimits2D> ();
						break;
					case "anchor":
						hingeJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "connectedAnchor":
						hingeJoint2D.connectedAnchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureConnectedAnchor":
						hingeJoint2D.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean> ();
						break;
					case "connectedBody":
						if ( hingeJoint2D.connectedBody == null )
						{
							hingeJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( hingeJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						hingeJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						hingeJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						hingeJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						hingeJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						hingeJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						hingeJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						hingeJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}