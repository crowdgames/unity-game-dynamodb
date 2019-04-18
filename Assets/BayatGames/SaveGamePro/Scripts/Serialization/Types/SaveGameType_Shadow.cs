using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Shadow serialization implementation.
	/// </summary>
	public class SaveGameType_Shadow : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Shadow );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Shadow shadow = ( UnityEngine.UI.Shadow )value;
			writer.WriteProperty ( "effectColor", shadow.effectColor );
			writer.WriteProperty ( "effectDistance", shadow.effectDistance );
			writer.WriteProperty ( "useGraphicAlpha", shadow.useGraphicAlpha );
			writer.WriteProperty ( "useGUILayout", shadow.useGUILayout );
			writer.WriteProperty ( "enabled", shadow.enabled );
			writer.WriteProperty ( "tag", shadow.tag );
			writer.WriteProperty ( "name", shadow.name );
			writer.WriteProperty ( "hideFlags", shadow.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Shadow shadow = SaveGameType.CreateComponent<UnityEngine.UI.Shadow> ();
			ReadInto ( shadow, reader );
			return shadow;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Shadow shadow = ( UnityEngine.UI.Shadow )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "effectColor":
						shadow.effectColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "effectDistance":
						shadow.effectDistance = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "useGraphicAlpha":
						shadow.useGraphicAlpha = reader.ReadProperty<System.Boolean> ();
						break;
					case "useGUILayout":
						shadow.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						shadow.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						shadow.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						shadow.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						shadow.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}