using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type CapsuleCollider serialization implementation.
	/// </summary>
	public class SaveGameType_CapsuleCollider : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.CapsuleCollider );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.CapsuleCollider capsuleCollider = ( UnityEngine.CapsuleCollider )value;
			writer.WriteProperty ( "center", capsuleCollider.center );
			writer.WriteProperty ( "radius", capsuleCollider.radius );
			writer.WriteProperty ( "height", capsuleCollider.height );
			writer.WriteProperty ( "direction", capsuleCollider.direction );
			writer.WriteProperty ( "enabled", capsuleCollider.enabled );
			writer.WriteProperty ( "isTrigger", capsuleCollider.isTrigger );
			writer.WriteProperty ( "contactOffset", capsuleCollider.contactOffset );
			writer.WriteProperty ( "material", capsuleCollider.material );
			writer.WriteProperty ( "sharedMaterial", capsuleCollider.sharedMaterial );
			writer.WriteProperty ( "tag", capsuleCollider.tag );
			writer.WriteProperty ( "name", capsuleCollider.name );
			writer.WriteProperty ( "hideFlags", capsuleCollider.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.CapsuleCollider capsuleCollider = SaveGameType.CreateComponent<UnityEngine.CapsuleCollider> ();
			ReadInto ( capsuleCollider, reader );
			return capsuleCollider;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.CapsuleCollider capsuleCollider = ( UnityEngine.CapsuleCollider )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "center":
						capsuleCollider.center = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "radius":
						capsuleCollider.radius = reader.ReadProperty<System.Single> ();
						break;
					case "height":
						capsuleCollider.height = reader.ReadProperty<System.Single> ();
						break;
					case "direction":
						capsuleCollider.direction = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						capsuleCollider.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "isTrigger":
						capsuleCollider.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "contactOffset":
						capsuleCollider.contactOffset = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( capsuleCollider.material == null )
						{
							capsuleCollider.material = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( capsuleCollider.material );
						}
						break;
					case "sharedMaterial":
						if ( capsuleCollider.sharedMaterial == null )
						{
							capsuleCollider.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( capsuleCollider.sharedMaterial );
						}
						break;
					case "tag":
						capsuleCollider.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						capsuleCollider.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						capsuleCollider.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}