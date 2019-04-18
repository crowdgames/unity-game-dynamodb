using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ToggleGroup serialization implementation.
	/// </summary>
	public class SaveGameType_ToggleGroup : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.ToggleGroup );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.ToggleGroup toggleGroup = ( UnityEngine.UI.ToggleGroup )value;
			writer.WriteProperty ( "allowSwitchOff", toggleGroup.allowSwitchOff );
			writer.WriteProperty ( "useGUILayout", toggleGroup.useGUILayout );
			writer.WriteProperty ( "enabled", toggleGroup.enabled );
			writer.WriteProperty ( "tag", toggleGroup.tag );
			writer.WriteProperty ( "name", toggleGroup.name );
			writer.WriteProperty ( "hideFlags", toggleGroup.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.ToggleGroup toggleGroup = SaveGameType.CreateComponent<UnityEngine.UI.ToggleGroup> ();
			ReadInto ( toggleGroup, reader );
			return toggleGroup;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.ToggleGroup toggleGroup = ( UnityEngine.UI.ToggleGroup )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "allowSwitchOff":
						toggleGroup.allowSwitchOff = reader.ReadProperty<System.Boolean> ();
						break;
					case "useGUILayout":
						toggleGroup.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						toggleGroup.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						toggleGroup.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						toggleGroup.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						toggleGroup.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}