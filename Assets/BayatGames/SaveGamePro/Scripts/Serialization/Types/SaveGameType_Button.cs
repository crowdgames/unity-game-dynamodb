using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Button serialization implementation.
	/// </summary>
	public class SaveGameType_Button : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Button );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Button button = ( UnityEngine.UI.Button )value;
			writer.WriteProperty ( "navigation", button.navigation );
			writer.WriteProperty ( "transition", button.transition );
			writer.WriteProperty ( "colors", button.colors );
			writer.WriteProperty ( "spriteState", button.spriteState );
			writer.WriteProperty ( "animationTriggers", button.animationTriggers );
			writer.WriteProperty ( "targetGraphicType", button.targetGraphic.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "targetGraphic", button.targetGraphic );
			writer.WriteProperty ( "interactable", button.interactable );
			writer.WriteProperty ( "image", button.image );
			writer.WriteProperty ( "useGUILayout", button.useGUILayout );
			writer.WriteProperty ( "enabled", button.enabled );
			writer.WriteProperty ( "tag", button.tag );
			writer.WriteProperty ( "name", button.name );
			writer.WriteProperty ( "hideFlags", button.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Button button = SaveGameType.CreateComponent<UnityEngine.UI.Button> ();
			ReadInto ( button, reader );
			return button;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Button button = ( UnityEngine.UI.Button )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "navigation":
						button.navigation = reader.ReadProperty<UnityEngine.UI.Navigation> ();
						break;
					case "transition":
						button.transition = reader.ReadProperty<UnityEngine.UI.Selectable.Transition> ();
						break;
					case "colors":
						button.colors = reader.ReadProperty<UnityEngine.UI.ColorBlock> ();
						break;
					case "spriteState":
						button.spriteState = reader.ReadProperty<UnityEngine.UI.SpriteState> ();
						break;
					case "animationTriggers":
						button.animationTriggers = reader.ReadProperty<UnityEngine.UI.AnimationTriggers> ();
						break;
					case "targetGraphic":
						Type targetGraphicType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( button.targetGraphic == null )
						{
							button.targetGraphic = ( UnityEngine.UI.Graphic )reader.ReadProperty ( targetGraphicType );
						}
						else
						{
							reader.ReadIntoProperty ( button.targetGraphic );
						}
						break;
					case "interactable":
						button.interactable = reader.ReadProperty<System.Boolean> ();
						break;
					case "image":
						if ( button.image == null )
						{
							button.image = reader.ReadProperty<UnityEngine.UI.Image> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Image> ( button.image );
						}
						break;
					case "useGUILayout":
						button.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						button.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						button.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						button.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						button.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}