using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type TargetJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_TargetJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.TargetJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.TargetJoint2D targetJoint2D = ( UnityEngine.TargetJoint2D )value;
			writer.WriteProperty ( "anchor", targetJoint2D.anchor );
			writer.WriteProperty ( "target", targetJoint2D.target );
			writer.WriteProperty ( "autoConfigureTarget", targetJoint2D.autoConfigureTarget );
			writer.WriteProperty ( "maxForce", targetJoint2D.maxForce );
			writer.WriteProperty ( "dampingRatio", targetJoint2D.dampingRatio );
			writer.WriteProperty ( "frequency", targetJoint2D.frequency );
			writer.WriteProperty ( "connectedBody", targetJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", targetJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", targetJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", targetJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", targetJoint2D.enabled );
			writer.WriteProperty ( "tag", targetJoint2D.tag );
			writer.WriteProperty ( "name", targetJoint2D.name );
			writer.WriteProperty ( "hideFlags", targetJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.TargetJoint2D targetJoint2D = SaveGameType.CreateComponent<UnityEngine.TargetJoint2D> ();
			ReadInto ( targetJoint2D, reader );
			return targetJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.TargetJoint2D targetJoint2D = ( UnityEngine.TargetJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "anchor":
						targetJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "target":
						targetJoint2D.target = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureTarget":
						targetJoint2D.autoConfigureTarget = reader.ReadProperty<System.Boolean> ();
						break;
					case "maxForce":
						targetJoint2D.maxForce = reader.ReadProperty<System.Single> ();
						break;
					case "dampingRatio":
						targetJoint2D.dampingRatio = reader.ReadProperty<System.Single> ();
						break;
					case "frequency":
						targetJoint2D.frequency = reader.ReadProperty<System.Single> ();
						break;
					case "connectedBody":
						if ( targetJoint2D.connectedBody == null )
						{
							targetJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( targetJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						targetJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						targetJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						targetJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						targetJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						targetJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						targetJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						targetJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}