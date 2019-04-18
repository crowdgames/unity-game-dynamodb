using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type BoxCollider serialization implementation.
	/// </summary>
	public class SaveGameType_BoxCollider : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.BoxCollider );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.BoxCollider boxCollider = ( UnityEngine.BoxCollider )value;
			writer.WriteProperty ( "center", boxCollider.center );
			writer.WriteProperty ( "size", boxCollider.size );
			writer.WriteProperty ( "enabled", boxCollider.enabled );
			writer.WriteProperty ( "isTrigger", boxCollider.isTrigger );
			writer.WriteProperty ( "contactOffset", boxCollider.contactOffset );
			writer.WriteProperty ( "material", boxCollider.material );
			writer.WriteProperty ( "sharedMaterial", boxCollider.sharedMaterial );
			writer.WriteProperty ( "tag", boxCollider.tag );
			writer.WriteProperty ( "name", boxCollider.name );
			writer.WriteProperty ( "hideFlags", boxCollider.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.BoxCollider boxCollider = SaveGameType.CreateComponent<UnityEngine.BoxCollider> ();
			ReadInto ( boxCollider, reader );
			return boxCollider;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.BoxCollider boxCollider = ( UnityEngine.BoxCollider )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "center":
						boxCollider.center = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "size":
						boxCollider.size = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "enabled":
						boxCollider.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "isTrigger":
						boxCollider.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "contactOffset":
						boxCollider.contactOffset = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( boxCollider.material == null )
						{
							boxCollider.material = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( boxCollider.material );
						}
						break;
					case "sharedMaterial":
						if ( boxCollider.sharedMaterial == null )
						{
							boxCollider.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( boxCollider.sharedMaterial );
						}
						break;
					case "tag":
						boxCollider.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						boxCollider.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						boxCollider.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}