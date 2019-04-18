using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type VerticalLayoutGroup serialization implementation.
	/// </summary>
	public class SaveGameType_VerticalLayoutGroup : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.VerticalLayoutGroup );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup = ( UnityEngine.UI.VerticalLayoutGroup )value;
			writer.WriteProperty ( "spacing", verticalLayoutGroup.spacing );
			writer.WriteProperty ( "childForceExpandWidth", verticalLayoutGroup.childForceExpandWidth );
			writer.WriteProperty ( "childForceExpandHeight", verticalLayoutGroup.childForceExpandHeight );
			writer.WriteProperty ( "childControlWidth", verticalLayoutGroup.childControlWidth );
			writer.WriteProperty ( "childControlHeight", verticalLayoutGroup.childControlHeight );
			writer.WriteProperty ( "padding", verticalLayoutGroup.padding );
			writer.WriteProperty ( "childAlignment", verticalLayoutGroup.childAlignment );
			writer.WriteProperty ( "useGUILayout", verticalLayoutGroup.useGUILayout );
			writer.WriteProperty ( "enabled", verticalLayoutGroup.enabled );
			writer.WriteProperty ( "tag", verticalLayoutGroup.tag );
			writer.WriteProperty ( "name", verticalLayoutGroup.name );
			writer.WriteProperty ( "hideFlags", verticalLayoutGroup.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup = SaveGameType.CreateComponent<UnityEngine.UI.VerticalLayoutGroup> ();
			ReadInto ( verticalLayoutGroup, reader );
			return verticalLayoutGroup;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup = ( UnityEngine.UI.VerticalLayoutGroup )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "spacing":
						verticalLayoutGroup.spacing = reader.ReadProperty<System.Single> ();
						break;
					case "childForceExpandWidth":
						verticalLayoutGroup.childForceExpandWidth = reader.ReadProperty<System.Boolean> ();
						break;
					case "childForceExpandHeight":
						verticalLayoutGroup.childForceExpandHeight = reader.ReadProperty<System.Boolean> ();
						break;
					case "childControlWidth":
						verticalLayoutGroup.childControlWidth = reader.ReadProperty<System.Boolean> ();
						break;
					case "childControlHeight":
						verticalLayoutGroup.childControlHeight = reader.ReadProperty<System.Boolean> ();
						break;
					case "padding":
						verticalLayoutGroup.padding = reader.ReadProperty<UnityEngine.RectOffset> ();
						break;
					case "childAlignment":
						verticalLayoutGroup.childAlignment = reader.ReadProperty<UnityEngine.TextAnchor> ();
						break;
					case "useGUILayout":
						verticalLayoutGroup.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						verticalLayoutGroup.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						verticalLayoutGroup.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						verticalLayoutGroup.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						verticalLayoutGroup.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}