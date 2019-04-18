using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type TerrainData serialization implementation.
	/// </summary>
	public class SaveGameType_TerrainData : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.TerrainData );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.TerrainData terrainData = ( UnityEngine.TerrainData )value;
			float [,,] alphamaps = terrainData.GetAlphamaps ( 0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight );
			float [,] heights = terrainData.GetHeights ( 0, 0, terrainData.heightmapWidth, terrainData.heightmapHeight );
			writer.WriteProperty ( "alphamaps", alphamaps );
			writer.WriteProperty ( "heights", heights );
			writer.WriteProperty ( "heightmapResolution", terrainData.heightmapResolution );
			writer.WriteProperty ( "size", terrainData.size );
			writer.WriteProperty ( "thickness", terrainData.thickness );
			writer.WriteProperty ( "wavingGrassStrength", terrainData.wavingGrassStrength );
			writer.WriteProperty ( "wavingGrassAmount", terrainData.wavingGrassAmount );
			writer.WriteProperty ( "wavingGrassSpeed", terrainData.wavingGrassSpeed );
			writer.WriteProperty ( "wavingGrassTint", terrainData.wavingGrassTint );
			writer.WriteProperty ( "detailPrototypes", terrainData.detailPrototypes );
			writer.WriteProperty ( "treeInstances", terrainData.treeInstances );
			writer.WriteProperty ( "treePrototypes", terrainData.treePrototypes );
			writer.WriteProperty ( "alphamapResolution", terrainData.alphamapResolution );
			writer.WriteProperty ( "baseMapResolution", terrainData.baseMapResolution );
			writer.WriteProperty ( "splatPrototypes", terrainData.splatPrototypes );
			writer.WriteProperty ( "name", terrainData.name );
			writer.WriteProperty ( "hideFlags", terrainData.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.TerrainData terrainData = new UnityEngine.TerrainData ();
			ReadInto ( terrainData, reader );
			return terrainData;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.TerrainData terrainData = ( UnityEngine.TerrainData )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "alphamaps":
						terrainData.SetAlphamaps ( 0, 0, reader.ReadProperty<float [,,]> () );
						break;
					case "heights":
						terrainData.SetHeights ( 0, 0, reader.ReadProperty<float [,]> () );
						break;
					case "heightmapResolution":
						terrainData.heightmapResolution = reader.ReadProperty<System.Int32> ();
						break;
					case "size":
						terrainData.size = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "thickness":
						terrainData.thickness = reader.ReadProperty<System.Single> ();
						break;
					case "wavingGrassStrength":
						terrainData.wavingGrassStrength = reader.ReadProperty<System.Single> ();
						break;
					case "wavingGrassAmount":
						terrainData.wavingGrassAmount = reader.ReadProperty<System.Single> ();
						break;
					case "wavingGrassSpeed":
						terrainData.wavingGrassSpeed = reader.ReadProperty<System.Single> ();
						break;
					case "wavingGrassTint":
						terrainData.wavingGrassTint = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "detailPrototypes":
						terrainData.detailPrototypes = reader.ReadProperty<UnityEngine.DetailPrototype []> ();
						break;
					case "treeInstances":
						terrainData.treeInstances = reader.ReadProperty<UnityEngine.TreeInstance []> ();
						break;
					case "treePrototypes":
						terrainData.treePrototypes = reader.ReadProperty<UnityEngine.TreePrototype []> ();
						break;
					case "alphamapResolution":
						terrainData.alphamapResolution = reader.ReadProperty<System.Int32> ();
						break;
					case "baseMapResolution":
						terrainData.baseMapResolution = reader.ReadProperty<System.Int32> ();
						break;
					case "splatPrototypes":
						terrainData.splatPrototypes = reader.ReadProperty<UnityEngine.SplatPrototype []> ();
						break;
					case "name":
						terrainData.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						terrainData.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}