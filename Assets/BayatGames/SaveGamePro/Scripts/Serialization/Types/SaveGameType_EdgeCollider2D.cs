using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type EdgeCollider2D serialization implementation.
	/// </summary>
	public class SaveGameType_EdgeCollider2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.EdgeCollider2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.EdgeCollider2D edgeCollider2D = ( UnityEngine.EdgeCollider2D )value;
			writer.WriteProperty ( "edgeRadius", edgeCollider2D.edgeRadius );
			writer.WriteProperty ( "points", edgeCollider2D.points );
			writer.WriteProperty ( "density", edgeCollider2D.density );
			writer.WriteProperty ( "isTrigger", edgeCollider2D.isTrigger );
			writer.WriteProperty ( "usedByEffector", edgeCollider2D.usedByEffector );
			writer.WriteProperty ( "usedByComposite", edgeCollider2D.usedByComposite );
			writer.WriteProperty ( "offset", edgeCollider2D.offset );
			writer.WriteProperty ( "sharedMaterial", edgeCollider2D.sharedMaterial );
			writer.WriteProperty ( "enabled", edgeCollider2D.enabled );
			writer.WriteProperty ( "tag", edgeCollider2D.tag );
			writer.WriteProperty ( "name", edgeCollider2D.name );
			writer.WriteProperty ( "hideFlags", edgeCollider2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.EdgeCollider2D edgeCollider2D = SaveGameType.CreateComponent<UnityEngine.EdgeCollider2D> ();
			ReadInto ( edgeCollider2D, reader );
			return edgeCollider2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.EdgeCollider2D edgeCollider2D = ( UnityEngine.EdgeCollider2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "edgeRadius":
						edgeCollider2D.edgeRadius = reader.ReadProperty<System.Single> ();
						break;
					case "points":
						edgeCollider2D.points = reader.ReadProperty<UnityEngine.Vector2[]> ();
						break;
					case "density":
						edgeCollider2D.density = reader.ReadProperty<System.Single> ();
						break;
					case "isTrigger":
						edgeCollider2D.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByEffector":
						edgeCollider2D.usedByEffector = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByComposite":
						edgeCollider2D.usedByComposite = reader.ReadProperty<System.Boolean> ();
						break;
					case "offset":
						edgeCollider2D.offset = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "sharedMaterial":
						if ( edgeCollider2D.sharedMaterial == null )
						{
							edgeCollider2D.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicsMaterial2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicsMaterial2D> ( edgeCollider2D.sharedMaterial );
						}
						break;
					case "enabled":
						edgeCollider2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						edgeCollider2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						edgeCollider2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						edgeCollider2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}