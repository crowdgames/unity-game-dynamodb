using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Rigidbody2D serialization implementation.
	/// </summary>
	public class SaveGameType_Rigidbody2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Rigidbody2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Rigidbody2D rigidbody2D = ( UnityEngine.Rigidbody2D )value;
			writer.WriteProperty ( "position", rigidbody2D.position );
			writer.WriteProperty ( "rotation", rigidbody2D.rotation );
			writer.WriteProperty ( "velocity", rigidbody2D.velocity );
			writer.WriteProperty ( "angularVelocity", rigidbody2D.angularVelocity );
			writer.WriteProperty ( "useAutoMass", rigidbody2D.useAutoMass );
			writer.WriteProperty ( "mass", rigidbody2D.mass );
			writer.WriteProperty ( "sharedMaterial", rigidbody2D.sharedMaterial );
			writer.WriteProperty ( "centerOfMass", rigidbody2D.centerOfMass );
			writer.WriteProperty ( "inertia", rigidbody2D.inertia );
			writer.WriteProperty ( "drag", rigidbody2D.drag );
			writer.WriteProperty ( "angularDrag", rigidbody2D.angularDrag );
			writer.WriteProperty ( "gravityScale", rigidbody2D.gravityScale );
			writer.WriteProperty ( "bodyType", rigidbody2D.bodyType );
			writer.WriteProperty ( "useFullKinematicContacts", rigidbody2D.useFullKinematicContacts );
			writer.WriteProperty ( "isKinematic", rigidbody2D.isKinematic );
			writer.WriteProperty ( "freezeRotation", rigidbody2D.freezeRotation );
			writer.WriteProperty ( "constraints", rigidbody2D.constraints );
			writer.WriteProperty ( "simulated", rigidbody2D.simulated );
			writer.WriteProperty ( "interpolation", rigidbody2D.interpolation );
			writer.WriteProperty ( "sleepMode", rigidbody2D.sleepMode );
			writer.WriteProperty ( "collisionDetectionMode", rigidbody2D.collisionDetectionMode );
			writer.WriteProperty ( "tag", rigidbody2D.tag );
			writer.WriteProperty ( "name", rigidbody2D.name );
			writer.WriteProperty ( "hideFlags", rigidbody2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Rigidbody2D rigidbody2D = SaveGameType.CreateComponent<UnityEngine.Rigidbody2D> ();
			ReadInto ( rigidbody2D, reader );
			return rigidbody2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Rigidbody2D rigidbody2D = ( UnityEngine.Rigidbody2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "position":
						rigidbody2D.position = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "rotation":
						rigidbody2D.rotation = reader.ReadProperty<System.Single> ();
						break;
					case "velocity":
						rigidbody2D.velocity = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "angularVelocity":
						rigidbody2D.angularVelocity = reader.ReadProperty<System.Single> ();
						break;
					case "useAutoMass":
						rigidbody2D.useAutoMass = reader.ReadProperty<System.Boolean> ();
						break;
					case "mass":
						rigidbody2D.mass = reader.ReadProperty<System.Single> ();
						break;
					case "sharedMaterial":
						if ( rigidbody2D.sharedMaterial == null )
						{
							rigidbody2D.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicsMaterial2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicsMaterial2D> ( rigidbody2D.sharedMaterial );
						}
						break;
					case "centerOfMass":
						rigidbody2D.centerOfMass = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "inertia":
						rigidbody2D.inertia = reader.ReadProperty<System.Single> ();
						break;
					case "drag":
						rigidbody2D.drag = reader.ReadProperty<System.Single> ();
						break;
					case "angularDrag":
						rigidbody2D.angularDrag = reader.ReadProperty<System.Single> ();
						break;
					case "gravityScale":
						rigidbody2D.gravityScale = reader.ReadProperty<System.Single> ();
						break;
					case "bodyType":
						rigidbody2D.bodyType = reader.ReadProperty<UnityEngine.RigidbodyType2D> ();
						break;
					case "useFullKinematicContacts":
						rigidbody2D.useFullKinematicContacts = reader.ReadProperty<System.Boolean> ();
						break;
					case "isKinematic":
						rigidbody2D.isKinematic = reader.ReadProperty<System.Boolean> ();
						break;
					case "freezeRotation":
						rigidbody2D.freezeRotation = reader.ReadProperty<System.Boolean> ();
						break;
					case "constraints":
						rigidbody2D.constraints = reader.ReadProperty<UnityEngine.RigidbodyConstraints2D> ();
						break;
					case "simulated":
						rigidbody2D.simulated = reader.ReadProperty<System.Boolean> ();
						break;
					case "interpolation":
						rigidbody2D.interpolation = reader.ReadProperty<UnityEngine.RigidbodyInterpolation2D> ();
						break;
					case "sleepMode":
						rigidbody2D.sleepMode = reader.ReadProperty<UnityEngine.RigidbodySleepMode2D> ();
						break;
					case "collisionDetectionMode":
						rigidbody2D.collisionDetectionMode = reader.ReadProperty<UnityEngine.CollisionDetectionMode2D> ();
						break;
					case "tag":
						rigidbody2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						rigidbody2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						rigidbody2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}