using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type CharacterInfo serialization implementation.
	/// </summary>
	public class SaveGameType_CharacterInfo : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.CharacterInfo );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.CharacterInfo characterInfo = ( UnityEngine.CharacterInfo )value;
			writer.WriteProperty ( "index", characterInfo.index );
			writer.WriteProperty ( "size", characterInfo.size );
			writer.WriteProperty ( "style", characterInfo.style );
			writer.WriteProperty ( "advance", characterInfo.advance );
			writer.WriteProperty ( "glyphWidth", characterInfo.glyphWidth );
			writer.WriteProperty ( "glyphHeight", characterInfo.glyphHeight );
			writer.WriteProperty ( "bearing", characterInfo.bearing );
			writer.WriteProperty ( "minY", characterInfo.minY );
			writer.WriteProperty ( "maxY", characterInfo.maxY );
			writer.WriteProperty ( "minX", characterInfo.minX );
			writer.WriteProperty ( "maxX", characterInfo.maxX );
			writer.WriteProperty ( "uvBottomLeft", characterInfo.uvBottomLeft );
			writer.WriteProperty ( "uvBottomRight", characterInfo.uvBottomRight );
			writer.WriteProperty ( "uvTopRight", characterInfo.uvTopRight );
			writer.WriteProperty ( "uvTopLeft", characterInfo.uvTopLeft );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.CharacterInfo characterInfo = new UnityEngine.CharacterInfo ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "index":
						characterInfo.index = reader.ReadProperty<System.Int32> ();
						break;
					case "size":
						characterInfo.size = reader.ReadProperty<System.Int32> ();
						break;
					case "style":
						characterInfo.style = reader.ReadProperty<UnityEngine.FontStyle> ();
						break;
					case "advance":
						characterInfo.advance = reader.ReadProperty<System.Int32> ();
						break;
					case "glyphWidth":
						characterInfo.glyphWidth = reader.ReadProperty<System.Int32> ();
						break;
					case "glyphHeight":
						characterInfo.glyphHeight = reader.ReadProperty<System.Int32> ();
						break;
					case "bearing":
						characterInfo.bearing = reader.ReadProperty<System.Int32> ();
						break;
					case "minY":
						characterInfo.minY = reader.ReadProperty<System.Int32> ();
						break;
					case "maxY":
						characterInfo.maxY = reader.ReadProperty<System.Int32> ();
						break;
					case "minX":
						characterInfo.minX = reader.ReadProperty<System.Int32> ();
						break;
					case "maxX":
						characterInfo.maxX = reader.ReadProperty<System.Int32> ();
						break;
					case "uvBottomLeft":
						characterInfo.uvBottomLeft = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "uvBottomRight":
						characterInfo.uvBottomRight = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "uvTopRight":
						characterInfo.uvTopRight = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "uvTopLeft":
						characterInfo.uvTopLeft = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
				}
			}
			return characterInfo;
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