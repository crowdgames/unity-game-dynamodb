using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type CharacterController serialization implementation.
	/// </summary>
	public class SaveGameType_CharacterController : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.CharacterController );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.CharacterController characterController = ( UnityEngine.CharacterController )value;
			writer.WriteProperty ( "radius", characterController.radius );
			writer.WriteProperty ( "height", characterController.height );
			writer.WriteProperty ( "center", characterController.center );
			writer.WriteProperty ( "slopeLimit", characterController.slopeLimit );
			writer.WriteProperty ( "stepOffset", characterController.stepOffset );
			writer.WriteProperty ( "skinWidth", characterController.skinWidth );
			writer.WriteProperty ( "minMoveDistance", characterController.minMoveDistance );
			writer.WriteProperty ( "detectCollisions", characterController.detectCollisions );
			writer.WriteProperty ( "enableOverlapRecovery", characterController.enableOverlapRecovery );
			writer.WriteProperty ( "enabled", characterController.enabled );
			writer.WriteProperty ( "isTrigger", characterController.isTrigger );
			writer.WriteProperty ( "contactOffset", characterController.contactOffset );
			writer.WriteProperty ( "material", characterController.material );
			writer.WriteProperty ( "sharedMaterial", characterController.sharedMaterial );
			writer.WriteProperty ( "tag", characterController.tag );
			writer.WriteProperty ( "name", characterController.name );
			writer.WriteProperty ( "hideFlags", characterController.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.CharacterController characterController = SaveGameType.CreateComponent<UnityEngine.CharacterController> ();
			ReadInto ( characterController, reader );
			return characterController;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.CharacterController characterController = ( UnityEngine.CharacterController )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "radius":
						characterController.radius = reader.ReadProperty<System.Single> ();
						break;
					case "height":
						characterController.height = reader.ReadProperty<System.Single> ();
						break;
					case "center":
						characterController.center = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "slopeLimit":
						characterController.slopeLimit = reader.ReadProperty<System.Single> ();
						break;
					case "stepOffset":
						characterController.stepOffset = reader.ReadProperty<System.Single> ();
						break;
					case "skinWidth":
						characterController.skinWidth = reader.ReadProperty<System.Single> ();
						break;
					case "minMoveDistance":
						characterController.minMoveDistance = reader.ReadProperty<System.Single> ();
						break;
					case "detectCollisions":
						characterController.detectCollisions = reader.ReadProperty<System.Boolean> ();
						break;
					case "enableOverlapRecovery":
						characterController.enableOverlapRecovery = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						characterController.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "isTrigger":
						characterController.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "contactOffset":
						characterController.contactOffset = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( characterController.material == null )
						{
							characterController.material = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( characterController.material );
						}
						break;
					case "sharedMaterial":
						if ( characterController.sharedMaterial == null )
						{
							characterController.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( characterController.sharedMaterial );
						}
						break;
					case "tag":
						characterController.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						characterController.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						characterController.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}