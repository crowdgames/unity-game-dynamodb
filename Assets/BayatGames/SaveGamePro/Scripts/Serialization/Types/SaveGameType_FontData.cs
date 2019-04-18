using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type FontData serialization implementation.
	/// </summary>
	public class SaveGameType_FontData : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.FontData );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.FontData fontData = ( UnityEngine.UI.FontData )value;
			writer.WriteProperty ( "font", fontData.font );
			writer.WriteProperty ( "fontSize", fontData.fontSize );
			writer.WriteProperty ( "fontStyle", fontData.fontStyle );
			writer.WriteProperty ( "bestFit", fontData.bestFit );
			writer.WriteProperty ( "minSize", fontData.minSize );
			writer.WriteProperty ( "maxSize", fontData.maxSize );
			writer.WriteProperty ( "alignment", fontData.alignment );
			writer.WriteProperty ( "alignByGeometry", fontData.alignByGeometry );
			writer.WriteProperty ( "richText", fontData.richText );
			writer.WriteProperty ( "horizontalOverflow", fontData.horizontalOverflow );
			writer.WriteProperty ( "verticalOverflow", fontData.verticalOverflow );
			writer.WriteProperty ( "lineSpacing", fontData.lineSpacing );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.FontData fontData = new UnityEngine.UI.FontData ();
			ReadInto ( fontData, reader );
			return fontData;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.FontData fontData = ( UnityEngine.UI.FontData )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "font":
						if ( fontData.font == null )
						{
							fontData.font = reader.ReadProperty<UnityEngine.Font> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Font> ( fontData.font );
						}
						break;
					case "fontSize":
						fontData.fontSize = reader.ReadProperty<System.Int32> ();
						break;
					case "fontStyle":
						fontData.fontStyle = reader.ReadProperty<UnityEngine.FontStyle> ();
						break;
					case "bestFit":
						fontData.bestFit = reader.ReadProperty<System.Boolean> ();
						break;
					case "minSize":
						fontData.minSize = reader.ReadProperty<System.Int32> ();
						break;
					case "maxSize":
						fontData.maxSize = reader.ReadProperty<System.Int32> ();
						break;
					case "alignment":
						fontData.alignment = reader.ReadProperty<UnityEngine.TextAnchor> ();
						break;
					case "alignByGeometry":
						fontData.alignByGeometry = reader.ReadProperty<System.Boolean> ();
						break;
					case "richText":
						fontData.richText = reader.ReadProperty<System.Boolean> ();
						break;
					case "horizontalOverflow":
						fontData.horizontalOverflow = reader.ReadProperty<UnityEngine.HorizontalWrapMode> ();
						break;
					case "verticalOverflow":
						fontData.verticalOverflow = reader.ReadProperty<UnityEngine.VerticalWrapMode> ();
						break;
					case "lineSpacing":
						fontData.lineSpacing = reader.ReadProperty<System.Single> ();
						break;
				}
			}
		}
		
	}

}