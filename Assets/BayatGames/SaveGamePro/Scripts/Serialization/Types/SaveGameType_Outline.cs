using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Outline serialization implementation.
	/// </summary>
	public class SaveGameType_Outline : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Outline );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Outline outline = ( UnityEngine.UI.Outline )value;
			writer.WriteProperty ( "effectColor", outline.effectColor );
			writer.WriteProperty ( "effectDistance", outline.effectDistance );
			writer.WriteProperty ( "useGraphicAlpha", outline.useGraphicAlpha );
			writer.WriteProperty ( "useGUILayout", outline.useGUILayout );
			writer.WriteProperty ( "enabled", outline.enabled );
			writer.WriteProperty ( "tag", outline.tag );
			writer.WriteProperty ( "name", outline.name );
			writer.WriteProperty ( "hideFlags", outline.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Outline outline = SaveGameType.CreateComponent<UnityEngine.UI.Outline> ();
			ReadInto ( outline, reader );
			return outline;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Outline outline = ( UnityEngine.UI.Outline )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "effectColor":
						outline.effectColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "effectDistance":
						outline.effectDistance = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "useGraphicAlpha":
						outline.useGraphicAlpha = reader.ReadProperty<System.Boolean> ();
						break;
					case "useGUILayout":
						outline.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						outline.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						outline.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						outline.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						outline.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}