using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type CapsuleCollider2D serialization implementation.
	/// </summary>
	public class SaveGameType_CapsuleCollider2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.CapsuleCollider2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.CapsuleCollider2D capsuleCollider2D = ( UnityEngine.CapsuleCollider2D )value;
			writer.WriteProperty ( "size", capsuleCollider2D.size );
			writer.WriteProperty ( "direction", capsuleCollider2D.direction );
			writer.WriteProperty ( "density", capsuleCollider2D.density );
			writer.WriteProperty ( "isTrigger", capsuleCollider2D.isTrigger );
			writer.WriteProperty ( "usedByEffector", capsuleCollider2D.usedByEffector );
			writer.WriteProperty ( "usedByComposite", capsuleCollider2D.usedByComposite );
			writer.WriteProperty ( "offset", capsuleCollider2D.offset );
			writer.WriteProperty ( "sharedMaterial", capsuleCollider2D.sharedMaterial );
			writer.WriteProperty ( "enabled", capsuleCollider2D.enabled );
			writer.WriteProperty ( "tag", capsuleCollider2D.tag );
			writer.WriteProperty ( "name", capsuleCollider2D.name );
			writer.WriteProperty ( "hideFlags", capsuleCollider2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.CapsuleCollider2D capsuleCollider2D = SaveGameType.CreateComponent<UnityEngine.CapsuleCollider2D> ();
			ReadInto ( capsuleCollider2D, reader );
			return capsuleCollider2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.CapsuleCollider2D capsuleCollider2D = ( UnityEngine.CapsuleCollider2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "size":
						capsuleCollider2D.size = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "direction":
						capsuleCollider2D.direction = reader.ReadProperty<UnityEngine.CapsuleDirection2D> ();
						break;
					case "density":
						capsuleCollider2D.density = reader.ReadProperty<System.Single> ();
						break;
					case "isTrigger":
						capsuleCollider2D.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByEffector":
						capsuleCollider2D.usedByEffector = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByComposite":
						capsuleCollider2D.usedByComposite = reader.ReadProperty<System.Boolean> ();
						break;
					case "offset":
						capsuleCollider2D.offset = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "sharedMaterial":
						if ( capsuleCollider2D.sharedMaterial == null )
						{
							capsuleCollider2D.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicsMaterial2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicsMaterial2D> ( capsuleCollider2D.sharedMaterial );
						}
						break;
					case "enabled":
						capsuleCollider2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						capsuleCollider2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						capsuleCollider2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						capsuleCollider2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}