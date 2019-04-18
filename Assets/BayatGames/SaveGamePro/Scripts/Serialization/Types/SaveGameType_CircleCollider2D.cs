using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type CircleCollider2D serialization implementation.
	/// </summary>
	public class SaveGameType_CircleCollider2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.CircleCollider2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.CircleCollider2D circleCollider2D = ( UnityEngine.CircleCollider2D )value;
			writer.WriteProperty ( "radius", circleCollider2D.radius );
			writer.WriteProperty ( "density", circleCollider2D.density );
			writer.WriteProperty ( "isTrigger", circleCollider2D.isTrigger );
			writer.WriteProperty ( "usedByEffector", circleCollider2D.usedByEffector );
			writer.WriteProperty ( "usedByComposite", circleCollider2D.usedByComposite );
			writer.WriteProperty ( "offset", circleCollider2D.offset );
			writer.WriteProperty ( "sharedMaterial", circleCollider2D.sharedMaterial );
			writer.WriteProperty ( "enabled", circleCollider2D.enabled );
			writer.WriteProperty ( "tag", circleCollider2D.tag );
			writer.WriteProperty ( "name", circleCollider2D.name );
			writer.WriteProperty ( "hideFlags", circleCollider2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.CircleCollider2D circleCollider2D = SaveGameType.CreateComponent<UnityEngine.CircleCollider2D> ();
			ReadInto ( circleCollider2D, reader );
			return circleCollider2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.CircleCollider2D circleCollider2D = ( UnityEngine.CircleCollider2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "radius":
						circleCollider2D.radius = reader.ReadProperty<System.Single> ();
						break;
					case "density":
						circleCollider2D.density = reader.ReadProperty<System.Single> ();
						break;
					case "isTrigger":
						circleCollider2D.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByEffector":
						circleCollider2D.usedByEffector = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByComposite":
						circleCollider2D.usedByComposite = reader.ReadProperty<System.Boolean> ();
						break;
					case "offset":
						circleCollider2D.offset = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "sharedMaterial":
						if ( circleCollider2D.sharedMaterial == null )
						{
							circleCollider2D.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicsMaterial2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicsMaterial2D> ( circleCollider2D.sharedMaterial );
						}
						break;
					case "enabled":
						circleCollider2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						circleCollider2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						circleCollider2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						circleCollider2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}