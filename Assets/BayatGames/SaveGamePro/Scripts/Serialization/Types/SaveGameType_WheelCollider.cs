using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type WheelCollider serialization implementation.
	/// </summary>
	public class SaveGameType_WheelCollider : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.WheelCollider );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.WheelCollider wheelCollider = ( UnityEngine.WheelCollider )value;
			writer.WriteProperty ( "center", wheelCollider.center );
			writer.WriteProperty ( "radius", wheelCollider.radius );
			writer.WriteProperty ( "suspensionDistance", wheelCollider.suspensionDistance );
			writer.WriteProperty ( "suspensionSpring", wheelCollider.suspensionSpring );
			writer.WriteProperty ( "forceAppPointDistance", wheelCollider.forceAppPointDistance );
			writer.WriteProperty ( "mass", wheelCollider.mass );
			writer.WriteProperty ( "wheelDampingRate", wheelCollider.wheelDampingRate );
			writer.WriteProperty ( "forwardFriction", wheelCollider.forwardFriction );
			writer.WriteProperty ( "sidewaysFriction", wheelCollider.sidewaysFriction );
			writer.WriteProperty ( "motorTorque", wheelCollider.motorTorque );
			writer.WriteProperty ( "brakeTorque", wheelCollider.brakeTorque );
			writer.WriteProperty ( "steerAngle", wheelCollider.steerAngle );
			writer.WriteProperty ( "enabled", wheelCollider.enabled );
			writer.WriteProperty ( "isTrigger", wheelCollider.isTrigger );
			writer.WriteProperty ( "contactOffset", wheelCollider.contactOffset );
			writer.WriteProperty ( "material", wheelCollider.material );
			writer.WriteProperty ( "sharedMaterial", wheelCollider.sharedMaterial );
			writer.WriteProperty ( "tag", wheelCollider.tag );
			writer.WriteProperty ( "name", wheelCollider.name );
			writer.WriteProperty ( "hideFlags", wheelCollider.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.WheelCollider wheelCollider = SaveGameType.CreateComponent<UnityEngine.WheelCollider> ();
			ReadInto ( wheelCollider, reader );
			return wheelCollider;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.WheelCollider wheelCollider = ( UnityEngine.WheelCollider )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "center":
						wheelCollider.center = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "radius":
						wheelCollider.radius = reader.ReadProperty<System.Single> ();
						break;
					case "suspensionDistance":
						wheelCollider.suspensionDistance = reader.ReadProperty<System.Single> ();
						break;
					case "suspensionSpring":
						wheelCollider.suspensionSpring = reader.ReadProperty<UnityEngine.JointSpring> ();
						break;
					case "forceAppPointDistance":
						wheelCollider.forceAppPointDistance = reader.ReadProperty<System.Single> ();
						break;
					case "mass":
						wheelCollider.mass = reader.ReadProperty<System.Single> ();
						break;
					case "wheelDampingRate":
						wheelCollider.wheelDampingRate = reader.ReadProperty<System.Single> ();
						break;
					case "forwardFriction":
						wheelCollider.forwardFriction = reader.ReadProperty<UnityEngine.WheelFrictionCurve> ();
						break;
					case "sidewaysFriction":
						wheelCollider.sidewaysFriction = reader.ReadProperty<UnityEngine.WheelFrictionCurve> ();
						break;
					case "motorTorque":
						wheelCollider.motorTorque = reader.ReadProperty<System.Single> ();
						break;
					case "brakeTorque":
						wheelCollider.brakeTorque = reader.ReadProperty<System.Single> ();
						break;
					case "steerAngle":
						wheelCollider.steerAngle = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						wheelCollider.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "isTrigger":
						wheelCollider.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "contactOffset":
						wheelCollider.contactOffset = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( wheelCollider.material == null )
						{
							wheelCollider.material = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( wheelCollider.material );
						}
						break;
					case "sharedMaterial":
						if ( wheelCollider.sharedMaterial == null )
						{
							wheelCollider.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( wheelCollider.sharedMaterial );
						}
						break;
					case "tag":
						wheelCollider.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						wheelCollider.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						wheelCollider.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}