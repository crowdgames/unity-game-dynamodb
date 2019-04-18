using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Collider serialization implementation.
	/// </summary>
	public class SaveGameType_Collider : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Collider );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Collider collider = ( UnityEngine.Collider )value;
			writer.WriteProperty ( "enabled", collider.enabled );
			writer.WriteProperty ( "isTrigger", collider.isTrigger );
			writer.WriteProperty ( "contactOffset", collider.contactOffset );
			writer.WriteProperty ( "material", collider.material );
			writer.WriteProperty ( "sharedMaterial", collider.sharedMaterial );
			writer.WriteProperty ( "tag", collider.tag );
			writer.WriteProperty ( "name", collider.name );
			writer.WriteProperty ( "hideFlags", collider.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Collider collider = SaveGameType.CreateComponent<UnityEngine.Collider> ();
			ReadInto ( collider, reader );
			return collider;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Collider collider = ( UnityEngine.Collider )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						collider.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "isTrigger":
						collider.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "contactOffset":
						collider.contactOffset = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( collider.material == null )
						{
							collider.material = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( collider.material );
						}
						break;
					case "sharedMaterial":
						if ( collider.sharedMaterial == null )
						{
							collider.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( collider.sharedMaterial );
						}
						break;
					case "tag":
						collider.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						collider.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						collider.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}