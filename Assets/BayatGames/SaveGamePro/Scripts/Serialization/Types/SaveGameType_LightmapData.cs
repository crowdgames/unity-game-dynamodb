using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type LightmapData serialization implementation.
	/// </summary>
	public class SaveGameType_LightmapData : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.LightmapData );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.LightmapData lightmapData = ( UnityEngine.LightmapData )value;
			writer.WriteProperty ( "lightmapColor", lightmapData.lightmapColor );
			writer.WriteProperty ( "lightmapDir", lightmapData.lightmapDir );
			writer.WriteProperty ( "shadowMask", lightmapData.shadowMask );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.LightmapData lightmapData = new UnityEngine.LightmapData ();
			ReadInto ( lightmapData, reader );
			return lightmapData;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.LightmapData lightmapData = ( UnityEngine.LightmapData )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "lightmapColor":
						if ( lightmapData.lightmapColor == null )
						{
							lightmapData.lightmapColor = reader.ReadProperty<UnityEngine.Texture2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Texture2D> ( lightmapData.lightmapColor );
						}
						break;
					case "lightmapDir":
						if ( lightmapData.lightmapDir == null )
						{
							lightmapData.lightmapDir = reader.ReadProperty<UnityEngine.Texture2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Texture2D> ( lightmapData.lightmapDir );
						}
						break;
					case "shadowMask":
						if ( lightmapData.shadowMask == null )
						{
							lightmapData.shadowMask = reader.ReadProperty<UnityEngine.Texture2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Texture2D> ( lightmapData.shadowMask );
						}
						break;
				}
			}
		}
		
	}

}