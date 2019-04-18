using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Toggle serialization implementation.
	/// </summary>
	public class SaveGameType_Toggle : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Toggle );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Toggle toggle = ( UnityEngine.UI.Toggle )value;
			writer.WriteProperty ( "toggleTransition", toggle.toggleTransition );
			writer.WriteProperty ( "graphicType", toggle.graphic.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "graphic", toggle.graphic );
			writer.WriteProperty ( "group", toggle.group );
			writer.WriteProperty ( "isOn", toggle.isOn );
			writer.WriteProperty ( "navigation", toggle.navigation );
			writer.WriteProperty ( "transition", toggle.transition );
			writer.WriteProperty ( "colors", toggle.colors );
			writer.WriteProperty ( "spriteState", toggle.spriteState );
			writer.WriteProperty ( "animationTriggers", toggle.animationTriggers );
			writer.WriteProperty ( "targetGraphicType", toggle.targetGraphic.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "targetGraphic", toggle.targetGraphic );
			writer.WriteProperty ( "interactable", toggle.interactable );
			writer.WriteProperty ( "image", toggle.image );
			writer.WriteProperty ( "useGUILayout", toggle.useGUILayout );
			writer.WriteProperty ( "enabled", toggle.enabled );
			writer.WriteProperty ( "tag", toggle.tag );
			writer.WriteProperty ( "name", toggle.name );
			writer.WriteProperty ( "hideFlags", toggle.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Toggle toggle = SaveGameType.CreateComponent<UnityEngine.UI.Toggle> ();
			ReadInto ( toggle, reader );
			return toggle;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Toggle toggle = ( UnityEngine.UI.Toggle )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "toggleTransition":
						toggle.toggleTransition = reader.ReadProperty<UnityEngine.UI.Toggle.ToggleTransition> ();
						break;
					case "graphic":
						Type graphicType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( toggle.graphic == null )
						{
							toggle.graphic = ( UnityEngine.UI.Graphic )reader.ReadProperty ( graphicType );
						}
						else
						{
							reader.ReadIntoProperty ( toggle.graphic );
						}
						break;
					case "group":
						if ( toggle.group == null )
						{
							toggle.group = reader.ReadProperty<UnityEngine.UI.ToggleGroup> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.ToggleGroup> ( toggle.group );
						}
						break;
					case "isOn":
						toggle.isOn = reader.ReadProperty<System.Boolean> ();
						break;
					case "navigation":
						toggle.navigation = reader.ReadProperty<UnityEngine.UI.Navigation> ();
						break;
					case "transition":
						toggle.transition = reader.ReadProperty<UnityEngine.UI.Selectable.Transition> ();
						break;
					case "colors":
						toggle.colors = reader.ReadProperty<UnityEngine.UI.ColorBlock> ();
						break;
					case "spriteState":
						toggle.spriteState = reader.ReadProperty<UnityEngine.UI.SpriteState> ();
						break;
					case "animationTriggers":
						toggle.animationTriggers = reader.ReadProperty<UnityEngine.UI.AnimationTriggers> ();
						break;
					case "targetGraphic":
						Type targetGraphicType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( toggle.targetGraphic == null )
						{
							toggle.targetGraphic = ( UnityEngine.UI.Graphic )reader.ReadProperty ( targetGraphicType );
						}
						else
						{
							reader.ReadIntoProperty ( toggle.targetGraphic );
						}
						break;
					case "interactable":
						toggle.interactable = reader.ReadProperty<System.Boolean> ();
						break;
					case "image":
						if ( toggle.image == null )
						{
							toggle.image = reader.ReadProperty<UnityEngine.UI.Image> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Image> ( toggle.image );
						}
						break;
					case "useGUILayout":
						toggle.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						toggle.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						toggle.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						toggle.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						toggle.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}