using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type CompositeCollider2D serialization implementation.
	/// </summary>
	public class SaveGameType_CompositeCollider2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.CompositeCollider2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.CompositeCollider2D compositeCollider2D = ( UnityEngine.CompositeCollider2D )value;
			writer.WriteProperty ( "geometryType", compositeCollider2D.geometryType );
			writer.WriteProperty ( "generationType", compositeCollider2D.generationType );
			writer.WriteProperty ( "vertexDistance", compositeCollider2D.vertexDistance );
			writer.WriteProperty ( "edgeRadius", compositeCollider2D.edgeRadius );
			writer.WriteProperty ( "density", compositeCollider2D.density );
			writer.WriteProperty ( "isTrigger", compositeCollider2D.isTrigger );
			writer.WriteProperty ( "usedByEffector", compositeCollider2D.usedByEffector );
			writer.WriteProperty ( "usedByComposite", compositeCollider2D.usedByComposite );
			writer.WriteProperty ( "offset", compositeCollider2D.offset );
			writer.WriteProperty ( "sharedMaterial", compositeCollider2D.sharedMaterial );
			writer.WriteProperty ( "enabled", compositeCollider2D.enabled );
			writer.WriteProperty ( "tag", compositeCollider2D.tag );
			writer.WriteProperty ( "name", compositeCollider2D.name );
			writer.WriteProperty ( "hideFlags", compositeCollider2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.CompositeCollider2D compositeCollider2D = SaveGameType.CreateComponent<UnityEngine.CompositeCollider2D> ();
			ReadInto ( compositeCollider2D, reader );
			return compositeCollider2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.CompositeCollider2D compositeCollider2D = ( UnityEngine.CompositeCollider2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "geometryType":
						compositeCollider2D.geometryType = reader.ReadProperty<UnityEngine.CompositeCollider2D.GeometryType> ();
						break;
					case "generationType":
						compositeCollider2D.generationType = reader.ReadProperty<UnityEngine.CompositeCollider2D.GenerationType> ();
						break;
					case "vertexDistance":
						compositeCollider2D.vertexDistance = reader.ReadProperty<System.Single> ();
						break;
					case "edgeRadius":
						compositeCollider2D.edgeRadius = reader.ReadProperty<System.Single> ();
						break;
					case "density":
						compositeCollider2D.density = reader.ReadProperty<System.Single> ();
						break;
					case "isTrigger":
						compositeCollider2D.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByEffector":
						compositeCollider2D.usedByEffector = reader.ReadProperty<System.Boolean> ();
						break;
					case "usedByComposite":
						compositeCollider2D.usedByComposite = reader.ReadProperty<System.Boolean> ();
						break;
					case "offset":
						compositeCollider2D.offset = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "sharedMaterial":
						if ( compositeCollider2D.sharedMaterial == null )
						{
							compositeCollider2D.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicsMaterial2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicsMaterial2D> ( compositeCollider2D.sharedMaterial );
						}
						break;
					case "enabled":
						compositeCollider2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						compositeCollider2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						compositeCollider2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						compositeCollider2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}