using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type TextMesh serialization implementation.
	/// </summary>
	public class SaveGameType_TextMesh : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.TextMesh );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.TextMesh textMesh = ( UnityEngine.TextMesh )value;
			writer.WriteProperty ( "text", textMesh.text );
			writer.WriteProperty ( "font", textMesh.font );
			writer.WriteProperty ( "fontSize", textMesh.fontSize );
			writer.WriteProperty ( "fontStyle", textMesh.fontStyle );
			writer.WriteProperty ( "offsetZ", textMesh.offsetZ );
			writer.WriteProperty ( "alignment", textMesh.alignment );
			writer.WriteProperty ( "anchor", textMesh.anchor );
			writer.WriteProperty ( "characterSize", textMesh.characterSize );
			writer.WriteProperty ( "lineSpacing", textMesh.lineSpacing );
			writer.WriteProperty ( "tabSize", textMesh.tabSize );
			writer.WriteProperty ( "richText", textMesh.richText );
			writer.WriteProperty ( "color", textMesh.color );
			writer.WriteProperty ( "tag", textMesh.tag );
			writer.WriteProperty ( "name", textMesh.name );
			writer.WriteProperty ( "hideFlags", textMesh.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.TextMesh textMesh = SaveGameType.CreateComponent<UnityEngine.TextMesh> ();
			ReadInto ( textMesh, reader );
			return textMesh;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.TextMesh textMesh = ( UnityEngine.TextMesh )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "text":
						textMesh.text = reader.ReadProperty<System.String> ();
						break;
					case "font":
						if ( textMesh.font == null )
						{
							textMesh.font = reader.ReadProperty<UnityEngine.Font> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Font> ( textMesh.font );
						}
						break;
					case "fontSize":
						textMesh.fontSize = reader.ReadProperty<System.Int32> ();
						break;
					case "fontStyle":
						textMesh.fontStyle = reader.ReadProperty<UnityEngine.FontStyle> ();
						break;
					case "offsetZ":
						textMesh.offsetZ = reader.ReadProperty<System.Single> ();
						break;
					case "alignment":
						textMesh.alignment = reader.ReadProperty<UnityEngine.TextAlignment> ();
						break;
					case "anchor":
						textMesh.anchor = reader.ReadProperty<UnityEngine.TextAnchor> ();
						break;
					case "characterSize":
						textMesh.characterSize = reader.ReadProperty<System.Single> ();
						break;
					case "lineSpacing":
						textMesh.lineSpacing = reader.ReadProperty<System.Single> ();
						break;
					case "tabSize":
						textMesh.tabSize = reader.ReadProperty<System.Single> ();
						break;
					case "richText":
						textMesh.richText = reader.ReadProperty<System.Boolean> ();
						break;
					case "color":
						textMesh.color = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "tag":
						textMesh.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						textMesh.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						textMesh.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}