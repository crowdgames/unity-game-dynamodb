using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type NavMeshTriangulation serialization implementation.
	/// </summary>
	public class SaveGameType_NavMeshTriangulation : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AI.NavMeshTriangulation );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AI.NavMeshTriangulation navMeshTriangulation = ( UnityEngine.AI.NavMeshTriangulation )value;
			writer.WriteProperty ( "vertices", navMeshTriangulation.vertices );
			writer.WriteProperty ( "indices", navMeshTriangulation.indices );
			writer.WriteProperty ( "areas", navMeshTriangulation.areas );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AI.NavMeshTriangulation navMeshTriangulation = new UnityEngine.AI.NavMeshTriangulation ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "vertices":
						navMeshTriangulation.vertices = reader.ReadProperty<UnityEngine.Vector3[]> ();
						break;
					case "indices":
						navMeshTriangulation.indices = reader.ReadProperty<System.Int32[]> ();
						break;
					case "areas":
						navMeshTriangulation.areas = reader.ReadProperty<System.Int32[]> ();
						break;
				}
			}
			return navMeshTriangulation;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			base.ReadInto ( value, reader );
		}
		
	}

}