using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Collider2D serialization implementation.
	/// </summary>
	public class SaveGameType_Collider2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Collider2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Collider2D collider2D = ( UnityEngine.Collider2D )value;
			writer.WriteProperty ( "density", collider2D.density );
			writer.WriteProperty ( "isTrigger", collider2D.isTrigger );
			writer.WriteProperty ( "usedByEffector", collider2D.usedByEffector );
			writer.WriteProperty ( "usedByComposite", collider2D.usedByComposite );
			writer.WriteProperty ( "offset", collider2D.offset );
			writer.WriteProperty ( "sharedMaterial", collider2D.sharedMaterial );
			writer.WriteProperty ( "enabled", collider2D.enabled );
			writer.WriteProperty ( "tag", collider2D.tag );
			writer.WriteProperty ( "name", collider2D.name );
			writer.WriteProperty ( "hideFlags", collider2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Collider2D collider2D = SaveGameType.CreateComponent<UnityEngine.Collider2D> ();
			ReadInto ( collider2D, reader );
			return collider2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Collider2D collider2D = ( UnityEngine.Collider2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "density":
						collider2D.density = reader.ReadProperty<System.Single> ();
						break;
					case "isTrigger":
						collider2D.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByEffector":
						collider2D.usedByEffector = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByComposite":
						collider2D.usedByComposite = reader.ReadProperty<System.Boolean> ();
						break;
					case "offset":
						collider2D.offset = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "sharedMaterial":
						if ( collider2D.sharedMaterial == null )
						{
							collider2D.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicsMaterial2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicsMaterial2D> ( collider2D.sharedMaterial );
						}
						break;
					case "enabled":
						collider2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						collider2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						collider2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						collider2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}