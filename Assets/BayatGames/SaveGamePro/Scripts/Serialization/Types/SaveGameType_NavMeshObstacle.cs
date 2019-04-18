using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type NavMeshObstacle serialization implementation.
	/// </summary>
	public class SaveGameType_NavMeshObstacle : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AI.NavMeshObstacle );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AI.NavMeshObstacle navMeshObstacle = ( UnityEngine.AI.NavMeshObstacle )value;
			writer.WriteProperty ( "height", navMeshObstacle.height );
			writer.WriteProperty ( "radius", navMeshObstacle.radius );
			writer.WriteProperty ( "velocity", navMeshObstacle.velocity );
			writer.WriteProperty ( "carving", navMeshObstacle.carving );
			writer.WriteProperty ( "carveOnlyStationary", navMeshObstacle.carveOnlyStationary );
			writer.WriteProperty ( "carvingMoveThreshold", navMeshObstacle.carvingMoveThreshold );
			writer.WriteProperty ( "carvingTimeToStationary", navMeshObstacle.carvingTimeToStationary );
			writer.WriteProperty ( "shape", navMeshObstacle.shape );
			writer.WriteProperty ( "center", navMeshObstacle.center );
			writer.WriteProperty ( "size", navMeshObstacle.size );
			writer.WriteProperty ( "enabled", navMeshObstacle.enabled );
			writer.WriteProperty ( "tag", navMeshObstacle.tag );
			writer.WriteProperty ( "name", navMeshObstacle.name );
			writer.WriteProperty ( "hideFlags", navMeshObstacle.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AI.NavMeshObstacle navMeshObstacle = SaveGameType.CreateComponent<UnityEngine.AI.NavMeshObstacle> ();
			ReadInto ( navMeshObstacle, reader );
			return navMeshObstacle;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AI.NavMeshObstacle navMeshObstacle = ( UnityEngine.AI.NavMeshObstacle )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "height":
						navMeshObstacle.height = reader.ReadProperty<System.Single> ();
						break;
					case "radius":
						navMeshObstacle.radius = reader.ReadProperty<System.Single> ();
						break;
					case "velocity":
						navMeshObstacle.velocity = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "carving":
						navMeshObstacle.carving = reader.ReadProperty<System.Boolean> ();
						break;
					case "carveOnlyStationary":
						navMeshObstacle.carveOnlyStationary = reader.ReadProperty<System.Boolean> ();
						break;
					case "carvingMoveThreshold":
						navMeshObstacle.carvingMoveThreshold = reader.ReadProperty<System.Single> ();
						break;
					case "carvingTimeToStationary":
						navMeshObstacle.carvingTimeToStationary = reader.ReadProperty<System.Single> ();
						break;
					case "shape":
						navMeshObstacle.shape = reader.ReadProperty<UnityEngine.AI.NavMeshObstacleShape> ();
						break;
					case "center":
						navMeshObstacle.center = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "size":
						navMeshObstacle.size = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "enabled":
						navMeshObstacle.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						navMeshObstacle.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						navMeshObstacle.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						navMeshObstacle.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}