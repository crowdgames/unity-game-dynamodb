using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SphereCollider serialization implementation.
	/// </summary>
	public class SaveGameType_SphereCollider : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.SphereCollider );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.SphereCollider sphereCollider = ( UnityEngine.SphereCollider )value;
			writer.WriteProperty ( "center", sphereCollider.center );
			writer.WriteProperty ( "radius", sphereCollider.radius );
			writer.WriteProperty ( "enabled", sphereCollider.enabled );
			writer.WriteProperty ( "isTrigger", sphereCollider.isTrigger );
			writer.WriteProperty ( "contactOffset", sphereCollider.contactOffset );
			writer.WriteProperty ( "material", sphereCollider.material );
			writer.WriteProperty ( "sharedMaterial", sphereCollider.sharedMaterial );
			writer.WriteProperty ( "tag", sphereCollider.tag );
			writer.WriteProperty ( "name", sphereCollider.name );
			writer.WriteProperty ( "hideFlags", sphereCollider.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.SphereCollider sphereCollider = SaveGameType.CreateComponent<UnityEngine.SphereCollider> ();
			ReadInto ( sphereCollider, reader );
			return sphereCollider;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.SphereCollider sphereCollider = ( UnityEngine.SphereCollider )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "center":
						sphereCollider.center = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "radius":
						sphereCollider.radius = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						sphereCollider.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "isTrigger":
						sphereCollider.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "contactOffset":
						sphereCollider.contactOffset = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( sphereCollider.material == null )
						{
							sphereCollider.material = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( sphereCollider.material );
						}
						break;
					case "sharedMaterial":
						if ( sphereCollider.sharedMaterial == null )
						{
							sphereCollider.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( sphereCollider.sharedMaterial );
						}
						break;
					case "tag":
						sphereCollider.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						sphereCollider.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						sphereCollider.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}