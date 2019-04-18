using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Mesh serialization implementation.
	/// </summary>
	public class SaveGameType_Mesh : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Mesh );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Mesh mesh = ( UnityEngine.Mesh )value;
			writer.WriteProperty ( "bounds", mesh.bounds );
			writer.WriteProperty ( "subMeshCount", mesh.subMeshCount );
			writer.WriteProperty ( "boneWeights", mesh.boneWeights );
			writer.WriteProperty ( "bindposes", mesh.bindposes );
			writer.WriteProperty ( "vertices", mesh.vertices );
			writer.WriteProperty ( "normals", mesh.normals );
			writer.WriteProperty ( "tangents", mesh.tangents );
			writer.WriteProperty ( "uv", mesh.uv );
			writer.WriteProperty ( "uv2", mesh.uv2 );
			writer.WriteProperty ( "uv3", mesh.uv3 );
			writer.WriteProperty ( "uv4", mesh.uv4 );
			writer.WriteProperty ( "colors", mesh.colors );
			writer.WriteProperty ( "colors32", mesh.colors32 );
			writer.WriteProperty ( "triangles", mesh.triangles );
			writer.WriteProperty ( "name", mesh.name );
			writer.WriteProperty ( "hideFlags", mesh.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Mesh mesh = new UnityEngine.Mesh ();
			ReadInto ( mesh, reader );
			return mesh;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Mesh mesh = ( UnityEngine.Mesh )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "bounds":
						mesh.bounds = reader.ReadProperty<UnityEngine.Bounds> ();
						break;
					case "subMeshCount":
						mesh.subMeshCount = reader.ReadProperty<System.Int32> ();
						break;
					case "boneWeights":
						mesh.boneWeights = reader.ReadProperty<UnityEngine.BoneWeight []> ();
						break;
					case "bindposes":
						mesh.bindposes = reader.ReadProperty<UnityEngine.Matrix4x4 []> ();
						break;
					case "vertices":
						mesh.vertices = reader.ReadProperty<UnityEngine.Vector3 []> ();
						break;
					case "normals":
						mesh.normals = reader.ReadProperty<UnityEngine.Vector3 []> ();
						break;
					case "tangents":
						mesh.tangents = reader.ReadProperty<UnityEngine.Vector4 []> ();
						break;
					case "uv":
						mesh.uv = reader.ReadProperty<UnityEngine.Vector2 []> ();
						break;
					case "uv2":
						mesh.uv2 = reader.ReadProperty<UnityEngine.Vector2 []> ();
						break;
					case "uv3":
						mesh.uv3 = reader.ReadProperty<UnityEngine.Vector2 []> ();
						break;
					case "uv4":
						mesh.uv4 = reader.ReadProperty<UnityEngine.Vector2 []> ();
						break;
					case "colors":
						mesh.colors = reader.ReadProperty<UnityEngine.Color []> ();
						break;
					case "colors32":
						mesh.colors32 = reader.ReadProperty<UnityEngine.Color32 []> ();
						break;
					case "triangles":
						mesh.triangles = reader.ReadProperty<System.Int32 []> ();
						break;
					case "name":
						mesh.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						mesh.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}