using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type MeshFilter serialization implementation.
	/// </summary>
	public class SaveGameType_MeshFilter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.MeshFilter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.MeshFilter meshFilter = ( UnityEngine.MeshFilter )value;
			writer.WriteProperty ( "mesh", meshFilter.mesh );
			writer.WriteProperty ( "sharedMesh", meshFilter.sharedMesh );
			writer.WriteProperty ( "tag", meshFilter.tag );
			writer.WriteProperty ( "name", meshFilter.name );
			writer.WriteProperty ( "hideFlags", meshFilter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.MeshFilter meshFilter = SaveGameType.CreateComponent<UnityEngine.MeshFilter> ();
			ReadInto ( meshFilter, reader );
			return meshFilter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.MeshFilter meshFilter = ( UnityEngine.MeshFilter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "mesh":
						if ( meshFilter.mesh == null )
						{
							meshFilter.mesh = reader.ReadProperty<UnityEngine.Mesh> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Mesh> ( meshFilter.mesh );
						}
						break;
					case "sharedMesh":
						if ( meshFilter.sharedMesh == null )
						{
							meshFilter.sharedMesh = reader.ReadProperty<UnityEngine.Mesh> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Mesh> ( meshFilter.sharedMesh );
						}
						break;
					case "tag":
						meshFilter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						meshFilter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						meshFilter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}