using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type MeshCollider serialization implementation.
	/// </summary>
	public class SaveGameType_MeshCollider : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.MeshCollider );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.MeshCollider meshCollider = ( UnityEngine.MeshCollider )value;
			writer.WriteProperty ( "sharedMesh", meshCollider.sharedMesh );
			writer.WriteProperty ( "convex", meshCollider.convex );
			writer.WriteProperty ( "inflateMesh", meshCollider.inflateMesh );
			writer.WriteProperty ( "skinWidth", meshCollider.skinWidth );
			writer.WriteProperty ( "enabled", meshCollider.enabled );
			writer.WriteProperty ( "isTrigger", meshCollider.isTrigger );
			writer.WriteProperty ( "contactOffset", meshCollider.contactOffset );
			writer.WriteProperty ( "material", meshCollider.material );
			writer.WriteProperty ( "sharedMaterial", meshCollider.sharedMaterial );
			writer.WriteProperty ( "tag", meshCollider.tag );
			writer.WriteProperty ( "name", meshCollider.name );
			writer.WriteProperty ( "hideFlags", meshCollider.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.MeshCollider meshCollider = SaveGameType.CreateComponent<UnityEngine.MeshCollider> ();
			ReadInto ( meshCollider, reader );
			return meshCollider;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.MeshCollider meshCollider = ( UnityEngine.MeshCollider )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "sharedMesh":
						if ( meshCollider.sharedMesh == null )
						{
							meshCollider.sharedMesh = reader.ReadProperty<UnityEngine.Mesh> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Mesh> ( meshCollider.sharedMesh );
						}
						break;
					case "convex":
						meshCollider.convex = reader.ReadProperty<System.Boolean> ();
						break;
					case "inflateMesh":
						meshCollider.inflateMesh = reader.ReadProperty<System.Boolean> ();
						break;
					case "skinWidth":
						meshCollider.skinWidth = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						meshCollider.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "isTrigger":
						meshCollider.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "contactOffset":
						meshCollider.contactOffset = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( meshCollider.material == null )
						{
							meshCollider.material = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( meshCollider.material );
						}
						break;
					case "sharedMaterial":
						if ( meshCollider.sharedMaterial == null )
						{
							meshCollider.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( meshCollider.sharedMaterial );
						}
						break;
					case "tag":
						meshCollider.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						meshCollider.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						meshCollider.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}