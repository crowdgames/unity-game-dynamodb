using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Rigidbody serialization implementation.
	/// </summary>
	public class SaveGameType_Rigidbody : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Rigidbody );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Rigidbody rigidbody = ( UnityEngine.Rigidbody )value;
			writer.WriteProperty ( "velocity", rigidbody.velocity );
			writer.WriteProperty ( "angularVelocity", rigidbody.angularVelocity );
			writer.WriteProperty ( "drag", rigidbody.drag );
			writer.WriteProperty ( "angularDrag", rigidbody.angularDrag );
			writer.WriteProperty ( "mass", rigidbody.mass );
			writer.WriteProperty ( "useGravity", rigidbody.useGravity );
			writer.WriteProperty ( "maxDepenetrationVelocity", rigidbody.maxDepenetrationVelocity );
			writer.WriteProperty ( "isKinematic", rigidbody.isKinematic );
			writer.WriteProperty ( "freezeRotation", rigidbody.freezeRotation );
			writer.WriteProperty ( "constraints", rigidbody.constraints );
			writer.WriteProperty ( "collisionDetectionMode", rigidbody.collisionDetectionMode );
			writer.WriteProperty ( "centerOfMass", rigidbody.centerOfMass );
			writer.WriteProperty ( "inertiaTensorRotation", rigidbody.inertiaTensorRotation );
			writer.WriteProperty ( "inertiaTensor", rigidbody.inertiaTensor );
			writer.WriteProperty ( "detectCollisions", rigidbody.detectCollisions );
			writer.WriteProperty ( "position", rigidbody.position );
			writer.WriteProperty ( "rotation", rigidbody.rotation );
			writer.WriteProperty ( "interpolation", rigidbody.interpolation );
			writer.WriteProperty ( "solverIterations", rigidbody.solverIterations );
			writer.WriteProperty ( "solverVelocityIterations", rigidbody.solverVelocityIterations );
			writer.WriteProperty ( "sleepThreshold", rigidbody.sleepThreshold );
			writer.WriteProperty ( "maxAngularVelocity", rigidbody.maxAngularVelocity );
			writer.WriteProperty ( "tag", rigidbody.tag );
			writer.WriteProperty ( "name", rigidbody.name );
			writer.WriteProperty ( "hideFlags", rigidbody.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Rigidbody rigidbody = SaveGameType.CreateComponent<UnityEngine.Rigidbody> ();
			ReadInto ( rigidbody, reader );
			return rigidbody;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Rigidbody rigidbody = ( UnityEngine.Rigidbody )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "velocity":
						rigidbody.velocity = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "angularVelocity":
						rigidbody.angularVelocity = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "drag":
						rigidbody.drag = reader.ReadProperty<System.Single> ();
						break;
					case "angularDrag":
						rigidbody.angularDrag = reader.ReadProperty<System.Single> ();
						break;
					case "mass":
						rigidbody.mass = reader.ReadProperty<System.Single> ();
						break;
					case "useGravity":
						rigidbody.useGravity = reader.ReadProperty<System.Boolean> ();
						break;
					case "maxDepenetrationVelocity":
						rigidbody.maxDepenetrationVelocity = reader.ReadProperty<System.Single> ();
						break;
					case "isKinematic":
						rigidbody.isKinematic = reader.ReadProperty<System.Boolean> ();
						break;
					case "freezeRotation":
						rigidbody.freezeRotation = reader.ReadProperty<System.Boolean> ();
						break;
					case "constraints":
						rigidbody.constraints = reader.ReadProperty<UnityEngine.RigidbodyConstraints> ();
						break;
					case "collisionDetectionMode":
						rigidbody.collisionDetectionMode = reader.ReadProperty<UnityEngine.CollisionDetectionMode> ();
						break;
					case "centerOfMass":
						rigidbody.centerOfMass = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "inertiaTensorRotation":
						rigidbody.inertiaTensorRotation = reader.ReadProperty<UnityEngine.Quaternion> ();
						break;
					case "inertiaTensor":
						rigidbody.inertiaTensor = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "detectCollisions":
						rigidbody.detectCollisions = reader.ReadProperty<System.Boolean> ();
						break;
					case "position":
						rigidbody.position = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "rotation":
						rigidbody.rotation = reader.ReadProperty<UnityEngine.Quaternion> ();
						break;
					case "interpolation":
						rigidbody.interpolation = reader.ReadProperty<UnityEngine.RigidbodyInterpolation> ();
						break;
					case "solverIterations":
						rigidbody.solverIterations = reader.ReadProperty<System.Int32> ();
						break;
					case "solverVelocityIterations":
						rigidbody.solverVelocityIterations = reader.ReadProperty<System.Int32> ();
						break;
					case "sleepThreshold":
						rigidbody.sleepThreshold = reader.ReadProperty<System.Single> ();
						break;
					case "maxAngularVelocity":
						rigidbody.maxAngularVelocity = reader.ReadProperty<System.Single> ();
						break;
					case "tag":
						rigidbody.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						rigidbody.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						rigidbody.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}