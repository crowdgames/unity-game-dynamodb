using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type HorizontalLayoutGroup serialization implementation.
	/// </summary>
	public class SaveGameType_HorizontalLayoutGroup : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.HorizontalLayoutGroup );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.HorizontalLayoutGroup horizontalLayoutGroup = ( UnityEngine.UI.HorizontalLayoutGroup )value;
			writer.WriteProperty ( "spacing", horizontalLayoutGroup.spacing );
			writer.WriteProperty ( "childForceExpandWidth", horizontalLayoutGroup.childForceExpandWidth );
			writer.WriteProperty ( "childForceExpandHeight", horizontalLayoutGroup.childForceExpandHeight );
			writer.WriteProperty ( "childControlWidth", horizontalLayoutGroup.childControlWidth );
			writer.WriteProperty ( "childControlHeight", horizontalLayoutGroup.childControlHeight );
			writer.WriteProperty ( "padding", horizontalLayoutGroup.padding );
			writer.WriteProperty ( "childAlignment", horizontalLayoutGroup.childAlignment );
			writer.WriteProperty ( "useGUILayout", horizontalLayoutGroup.useGUILayout );
			writer.WriteProperty ( "enabled", horizontalLayoutGroup.enabled );
			writer.WriteProperty ( "tag", horizontalLayoutGroup.tag );
			writer.WriteProperty ( "name", horizontalLayoutGroup.name );
			writer.WriteProperty ( "hideFlags", horizontalLayoutGroup.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.HorizontalLayoutGroup horizontalLayoutGroup = SaveGameType.CreateComponent<UnityEngine.UI.HorizontalLayoutGroup> ();
			ReadInto ( horizontalLayoutGroup, reader );
			return horizontalLayoutGroup;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.HorizontalLayoutGroup horizontalLayoutGroup = ( UnityEngine.UI.HorizontalLayoutGroup )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "spacing":
						horizontalLayoutGroup.spacing = reader.ReadProperty<System.Single> ();
						break;
					case "childForceExpandWidth":
						horizontalLayoutGroup.childForceExpandWidth = reader.ReadProperty<System.Boolean> ();
						break;
					case "childForceExpandHeight":
						horizontalLayoutGroup.childForceExpandHeight = reader.ReadProperty<System.Boolean> ();
						break;
					case "childControlWidth":
						horizontalLayoutGroup.childControlWidth = reader.ReadProperty<System.Boolean> ();
						break;
					case "childControlHeight":
						horizontalLayoutGroup.childControlHeight = reader.ReadProperty<System.Boolean> ();
						break;
					case "padding":
						horizontalLayoutGroup.padding = reader.ReadProperty<UnityEngine.RectOffset> ();
						break;
					case "childAlignment":
						horizontalLayoutGroup.childAlignment = reader.ReadProperty<UnityEngine.TextAnchor> ();
						break;
					case "useGUILayout":
						horizontalLayoutGroup.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						horizontalLayoutGroup.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						horizontalLayoutGroup.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						horizontalLayoutGroup.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						horizontalLayoutGroup.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}