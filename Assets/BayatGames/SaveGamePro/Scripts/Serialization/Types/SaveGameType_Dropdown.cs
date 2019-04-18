using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Dropdown serialization implementation.
	/// </summary>
	public class SaveGameType_Dropdown : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Dropdown );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Dropdown dropdown = ( UnityEngine.UI.Dropdown )value;
			writer.WriteProperty ( "template", dropdown.template );
			writer.WriteProperty ( "captionText", dropdown.captionText );
			writer.WriteProperty ( "captionImage", dropdown.captionImage );
			writer.WriteProperty ( "itemText", dropdown.itemText );
			writer.WriteProperty ( "itemImage", dropdown.itemImage );
			writer.WriteProperty ( "options", dropdown.options );
			writer.WriteProperty ( "value", dropdown.value );
			writer.WriteProperty ( "navigation", dropdown.navigation );
			writer.WriteProperty ( "transition", dropdown.transition );
			writer.WriteProperty ( "colors", dropdown.colors );
			writer.WriteProperty ( "spriteState", dropdown.spriteState );
			writer.WriteProperty ( "animationTriggers", dropdown.animationTriggers );
			writer.WriteProperty ( "targetGraphicType", dropdown.targetGraphic.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "targetGraphic", dropdown.targetGraphic );
			writer.WriteProperty ( "interactable", dropdown.interactable );
			writer.WriteProperty ( "image", dropdown.image );
			writer.WriteProperty ( "useGUILayout", dropdown.useGUILayout );
			writer.WriteProperty ( "enabled", dropdown.enabled );
			writer.WriteProperty ( "tag", dropdown.tag );
			writer.WriteProperty ( "name", dropdown.name );
			writer.WriteProperty ( "hideFlags", dropdown.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Dropdown dropdown = SaveGameType.CreateComponent<UnityEngine.UI.Dropdown> ();
			ReadInto ( dropdown, reader );
			return dropdown;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Dropdown dropdown = ( UnityEngine.UI.Dropdown )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "template":
						if ( dropdown.template == null )
						{
							dropdown.template = reader.ReadProperty<UnityEngine.RectTransform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.RectTransform> ( dropdown.template );
						}
						break;
					case "captionText":
						if ( dropdown.captionText == null )
						{
							dropdown.captionText = reader.ReadProperty<UnityEngine.UI.Text> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Text> ( dropdown.captionText );
						}
						break;
					case "captionImage":
						if ( dropdown.captionImage == null )
						{
							dropdown.captionImage = reader.ReadProperty<UnityEngine.UI.Image> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Image> ( dropdown.captionImage );
						}
						break;
					case "itemText":
						if ( dropdown.itemText == null )
						{
							dropdown.itemText = reader.ReadProperty<UnityEngine.UI.Text> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Text> ( dropdown.itemText );
						}
						break;
					case "itemImage":
						if ( dropdown.itemImage == null )
						{
							dropdown.itemImage = reader.ReadProperty<UnityEngine.UI.Image> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Image> ( dropdown.itemImage );
						}
						break;
					case "options":
						dropdown.options = reader.ReadProperty<System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData>> ();
						break;
					case "value":
						dropdown.value = reader.ReadProperty<System.Int32> ();
						break;
					case "navigation":
						dropdown.navigation = reader.ReadProperty<UnityEngine.UI.Navigation> ();
						break;
					case "transition":
						dropdown.transition = reader.ReadProperty<UnityEngine.UI.Selectable.Transition> ();
						break;
					case "colors":
						dropdown.colors = reader.ReadProperty<UnityEngine.UI.ColorBlock> ();
						break;
					case "spriteState":
						dropdown.spriteState = reader.ReadProperty<UnityEngine.UI.SpriteState> ();
						break;
					case "animationTriggers":
						dropdown.animationTriggers = reader.ReadProperty<UnityEngine.UI.AnimationTriggers> ();
						break;
					case "targetGraphic":
						Type targetGraphicType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( dropdown.targetGraphic == null )
						{
							dropdown.targetGraphic = ( UnityEngine.UI.Graphic )reader.ReadProperty ( targetGraphicType );
						}
						else
						{
							reader.ReadIntoProperty ( dropdown.targetGraphic );
						}
						break;
					case "interactable":
						dropdown.interactable = reader.ReadProperty<System.Boolean> ();
						break;
					case "image":
						if ( dropdown.image == null )
						{
							dropdown.image = reader.ReadProperty<UnityEngine.UI.Image> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Image> ( dropdown.image );
						}
						break;
					case "useGUILayout":
						dropdown.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						dropdown.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						dropdown.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						dropdown.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						dropdown.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}