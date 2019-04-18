using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type TerrainCollider serialization implementation.
	/// </summary>
	public class SaveGameType_TerrainCollider : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.TerrainCollider );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.TerrainCollider terrainCollider = ( UnityEngine.TerrainCollider )value;
			writer.WriteProperty ( "terrainData", terrainCollider.terrainData );
			writer.WriteProperty ( "enabled", terrainCollider.enabled );
			writer.WriteProperty ( "isTrigger", terrainCollider.isTrigger );
			writer.WriteProperty ( "contactOffset", terrainCollider.contactOffset );
			writer.WriteProperty ( "material", terrainCollider.material );
			writer.WriteProperty ( "sharedMaterial", terrainCollider.sharedMaterial );
			writer.WriteProperty ( "tag", terrainCollider.tag );
			writer.WriteProperty ( "name", terrainCollider.name );
			writer.WriteProperty ( "hideFlags", terrainCollider.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.TerrainCollider terrainCollider = SaveGameType.CreateComponent<UnityEngine.TerrainCollider> ();
			ReadInto ( terrainCollider, reader );
			return terrainCollider;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.TerrainCollider terrainCollider = ( UnityEngine.TerrainCollider )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "terrainData":
						if ( terrainCollider.terrainData == null )
						{
							terrainCollider.terrainData = reader.ReadProperty<UnityEngine.TerrainData> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.TerrainData> ( terrainCollider.terrainData );
						}
						break;
					case "enabled":
						terrainCollider.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "isTrigger":
						terrainCollider.isTrigger = reader.ReadProperty<System.Boolean> ();
						break;
					case "contactOffset":
						terrainCollider.contactOffset = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( terrainCollider.material == null )
						{
							terrainCollider.material = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( terrainCollider.material );
						}
						break;
					case "sharedMaterial":
						if ( terrainCollider.sharedMaterial == null )
						{
							terrainCollider.sharedMaterial = reader.ReadProperty<UnityEngine.PhysicMaterial> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.PhysicMaterial> ( terrainCollider.sharedMaterial );
						}
						break;
					case "tag":
						terrainCollider.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						terrainCollider.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						terrainCollider.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}