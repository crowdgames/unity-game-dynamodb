using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type PolygonCollider2D serialization implementation.
	/// </summary>
	public class SaveGameType_PolygonCollider2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.PolygonCollider2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.PolygonCollider2D polygonCollider2D = ( UnityEngine.PolygonCollider2D )value;
			writer.WriteProperty ( "points", polygonCollider2D.points );
			writer.WriteProperty ( "pathCount", polygonCollider2D.pathCount );
			writer.WriteProperty ( "autoTiling", polygonCollider2D.autoTiling );
			writer.WriteProperty ( "density", polygonCollider2D.density );
			writer.WriteProperty ( "isTrigger", polygonCollider2D.isTrigger );
			writer.WriteProperty ( "usedByEffector", polygonCollider2D.usedByEffector );
			writer.WriteProperty ( "usedByComposite", polygonCollider2D.usedByComposite );
			writer.WriteProperty ( "offset", polygonCollider2D.offset );
			writer.WriteProperty ( "sharedMaterial", polygonCollider2D.sharedMaterial );
			writer.WriteProperty ( "enabled", polygonCollider2D.enabled );
			writer.WriteProperty ( "tag", polygonCollider2D.tag );
			writer.WriteProperty ( "name", polygonCollider2D.name );
			writer.WriteProperty ( "hideFlags", polygonCollider2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.PolygonCollider2D polygonCollider2D = SaveGameType.CreateComponent<UnityEngine.PolygonCollider2D> ();
			ReadInto ( polygonCollider2D, reader );
			return polygonCollider2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.PolygonCollider2D polygonCollider2D = ( UnityEngine.PolygonCollider2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "points":
						polygonCollider2D.points = reader.ReadProperty<UnityEngine.Vector2[]> ();
						break;
					case "pathCount":
						polygonCollider2D.pathCount = reader.ReadProperty<System.Int32> ();
						break;
					case "autoTiling":
						polygonCollider2D.autoTiling = reader.ReadProperty<System.Boolean> ();
						break;
					case "density":
						polygonCollider2D.density = reader.ReadProperty<System.Single> ();
						break;
					case "isTrigger":
						polygonCollider2D.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByEffector":
						polygonCollider2D.usedByEffector = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByComposite":
						polygonCollider2D.usedByComposite = reader.ReadProperty<System.Boolean> ();
						break;
					case "offset":
						polygonCollider2D.offset = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "sharedMaterial":
						if ( polygonCollider2D.sharedMaterial == null )
						{
							polygonCollider2D.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicsMaterial2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicsMaterial2D> ( polygonCollider2D.sharedMaterial );
						}
						break;
					case "enabled":
						polygonCollider2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						polygonCollider2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						polygonCollider2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						polygonCollider2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}