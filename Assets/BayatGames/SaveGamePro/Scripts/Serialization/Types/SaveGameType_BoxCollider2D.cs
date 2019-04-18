using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type BoxCollider2D serialization implementation.
	/// </summary>
	public class SaveGameType_BoxCollider2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.BoxCollider2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.BoxCollider2D boxCollider2D = ( UnityEngine.BoxCollider2D )value;
			writer.WriteProperty ( "size", boxCollider2D.size );
			writer.WriteProperty ( "edgeRadius", boxCollider2D.edgeRadius );
			writer.WriteProperty ( "autoTiling", boxCollider2D.autoTiling );
			writer.WriteProperty ( "density", boxCollider2D.density );
			writer.WriteProperty ( "isTrigger", boxCollider2D.isTrigger );
			writer.WriteProperty ( "usedByEffector", boxCollider2D.usedByEffector );
			writer.WriteProperty ( "usedByComposite", boxCollider2D.usedByComposite );
			writer.WriteProperty ( "offset", boxCollider2D.offset );
			writer.WriteProperty ( "sharedMaterial", boxCollider2D.sharedMaterial );
			writer.WriteProperty ( "enabled", boxCollider2D.enabled );
			writer.WriteProperty ( "tag", boxCollider2D.tag );
			writer.WriteProperty ( "name", boxCollider2D.name );
			writer.WriteProperty ( "hideFlags", boxCollider2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.BoxCollider2D boxCollider2D = SaveGameType.CreateComponent<UnityEngine.BoxCollider2D> ();
			ReadInto ( boxCollider2D, reader );
			return boxCollider2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.BoxCollider2D boxCollider2D = ( UnityEngine.BoxCollider2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "size":
						boxCollider2D.size = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "edgeRadius":
						boxCollider2D.edgeRadius = reader.ReadProperty<System.Single> ();
						break;
					case "autoTiling":
						boxCollider2D.autoTiling = reader.ReadProperty<System.Boolean> ();
						break;
					case "density":
						boxCollider2D.density = reader.ReadProperty<System.Single> ();
						break;
					case "isTrigger":
						boxCollider2D.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByEffector":
						boxCollider2D.usedByEffector = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByComposite":
						boxCollider2D.usedByComposite = reader.ReadProperty<System.Boolean> ();
						break;
					case "offset":
						boxCollider2D.offset = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "sharedMaterial":
						if ( boxCollider2D.sharedMaterial == null )
						{
							boxCollider2D.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicsMaterial2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicsMaterial2D> ( boxCollider2D.sharedMaterial );
						}
						break;
					case "enabled":
						boxCollider2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						boxCollider2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						boxCollider2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						boxCollider2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}