using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Text serialization implementation.
	/// </summary>
	public class SaveGameType_Text : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Text );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Text text = ( UnityEngine.UI.Text )value;
			writer.WriteProperty ( "font", text.font );
			writer.WriteProperty ( "text", text.text );
			writer.WriteProperty ( "supportRichText", text.supportRichText );
			writer.WriteProperty ( "resizeTextForBestFit", text.resizeTextForBestFit );
			writer.WriteProperty ( "resizeTextMinSize", text.resizeTextMinSize );
			writer.WriteProperty ( "resizeTextMaxSize", text.resizeTextMaxSize );
			writer.WriteProperty ( "alignment", text.alignment );
			writer.WriteProperty ( "alignByGeometry", text.alignByGeometry );
			writer.WriteProperty ( "fontSize", text.fontSize );
			writer.WriteProperty ( "horizontalOverflow", text.horizontalOverflow );
			writer.WriteProperty ( "verticalOverflow", text.verticalOverflow );
			writer.WriteProperty ( "lineSpacing", text.lineSpacing );
			writer.WriteProperty ( "fontStyle", text.fontStyle );
			writer.WriteProperty ( "maskable", text.maskable );
			writer.WriteProperty ( "color", text.color );
			writer.WriteProperty ( "raycastTarget", text.raycastTarget );
			writer.WriteProperty ( "material", text.material );
			writer.WriteProperty ( "useGUILayout", text.useGUILayout );
			writer.WriteProperty ( "enabled", text.enabled );
			writer.WriteProperty ( "tag", text.tag );
			writer.WriteProperty ( "name", text.name );
			writer.WriteProperty ( "hideFlags", text.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Text text = SaveGameType.CreateComponent<UnityEngine.UI.Text> ();
			ReadInto ( text, reader );
			return text;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Text text = ( UnityEngine.UI.Text )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "font":
						if ( text.font == null )
						{
							text.font = reader.ReadProperty<UnityEngine.Font> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Font> ( text.font );
						}
						break;
					case "text":
						text.text = reader.ReadProperty<System.String> ();
						break;
					case "supportRichText":
						text.supportRichText = reader.ReadProperty<System.Boolean> ();
						break;
					case "resizeTextForBestFit":
						text.resizeTextForBestFit = reader.ReadProperty<System.Boolean> ();
						break;
					case "resizeTextMinSize":
						text.resizeTextMinSize = reader.ReadProperty<System.Int32> ();
						break;
					case "resizeTextMaxSize":
						text.resizeTextMaxSize = reader.ReadProperty<System.Int32> ();
						break;
					case "alignment":
						text.alignment = reader.ReadProperty<UnityEngine.TextAnchor> ();
						break;
					case "alignByGeometry":
						text.alignByGeometry = reader.ReadProperty<System.Boolean> ();
						break;
					case "fontSize":
						text.fontSize = reader.ReadProperty<System.Int32> ();
						break;
					case "horizontalOverflow":
						text.horizontalOverflow = reader.ReadProperty<UnityEngine.HorizontalWrapMode> ();
						break;
					case "verticalOverflow":
						text.verticalOverflow = reader.ReadProperty<UnityEngine.VerticalWrapMode> ();
						break;
					case "lineSpacing":
						text.lineSpacing = reader.ReadProperty<System.Single> ();
						break;
					case "fontStyle":
						text.fontStyle = reader.ReadProperty<UnityEngine.FontStyle> ();
						break;
					case "maskable":
						text.maskable = reader.ReadProperty<System.Boolean> ();
						break;
					case "color":
						text.color = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "raycastTarget":
						text.raycastTarget = reader.ReadProperty<System.Boolean> ();
						break;
					case "material":
						if ( text.material == null )
						{
							text.material = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( text.material );
						}
						break;
					case "useGUILayout":
						text.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						text.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						text.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						text.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						text.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}