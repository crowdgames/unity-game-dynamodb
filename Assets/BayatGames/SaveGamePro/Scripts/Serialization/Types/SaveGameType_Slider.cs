using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Slider serialization implementation.
	/// </summary>
	public class SaveGameType_Slider : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Slider );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Slider slider = ( UnityEngine.UI.Slider )value;
			writer.WriteProperty ( "fillRect", slider.fillRect );
			writer.WriteProperty ( "handleRect", slider.handleRect );
			writer.WriteProperty ( "direction", slider.direction );
			writer.WriteProperty ( "minValue", slider.minValue );
			writer.WriteProperty ( "maxValue", slider.maxValue );
			writer.WriteProperty ( "wholeNumbers", slider.wholeNumbers );
			writer.WriteProperty ( "value", slider.value );
			writer.WriteProperty ( "normalizedValue", slider.normalizedValue );
			writer.WriteProperty ( "navigation", slider.navigation );
			writer.WriteProperty ( "transition", slider.transition );
			writer.WriteProperty ( "colors", slider.colors );
			writer.WriteProperty ( "spriteState", slider.spriteState );
			writer.WriteProperty ( "animationTriggers", slider.animationTriggers );
			writer.WriteProperty ( "targetGraphicType", slider.targetGraphic.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "targetGraphic", slider.targetGraphic );
			writer.WriteProperty ( "interactable", slider.interactable );
			writer.WriteProperty ( "image", slider.image );
			writer.WriteProperty ( "useGUILayout", slider.useGUILayout );
			writer.WriteProperty ( "enabled", slider.enabled );
			writer.WriteProperty ( "tag", slider.tag );
			writer.WriteProperty ( "name", slider.name );
			writer.WriteProperty ( "hideFlags", slider.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Slider slider = SaveGameType.CreateComponent<UnityEngine.UI.Slider> ();
			ReadInto ( slider, reader );
			return slider;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Slider slider = ( UnityEngine.UI.Slider )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "fillRect":
						if ( slider.fillRect == null )
						{
							slider.fillRect = reader.ReadProperty<UnityEngine.RectTransform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.RectTransform> ( slider.fillRect );
						}
						break;
					case "handleRect":
						if ( slider.handleRect == null )
						{
							slider.handleRect = reader.ReadProperty<UnityEngine.RectTransform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.RectTransform> ( slider.handleRect );
						}
						break;
					case "direction":
						slider.direction = reader.ReadProperty<UnityEngine.UI.Slider.Direction> ();
						break;
					case "minValue":
						slider.minValue = reader.ReadProperty<System.Single> ();
						break;
					case "maxValue":
						slider.maxValue = reader.ReadProperty<System.Single> ();
						break;
					case "wholeNumbers":
						slider.wholeNumbers = reader.ReadProperty<System.Boolean> ();
						break;
					case "value":
						slider.value = reader.ReadProperty<System.Single> ();
						break;
					case "normalizedValue":
						slider.normalizedValue = reader.ReadProperty<System.Single> ();
						break;
					case "navigation":
						slider.navigation = reader.ReadProperty<UnityEngine.UI.Navigation> ();
						break;
					case "transition":
						slider.transition = reader.ReadProperty<UnityEngine.UI.Selectable.Transition> ();
						break;
					case "colors":
						slider.colors = reader.ReadProperty<UnityEngine.UI.ColorBlock> ();
						break;
					case "spriteState":
						slider.spriteState = reader.ReadProperty<UnityEngine.UI.SpriteState> ();
						break;
					case "animationTriggers":
						slider.animationTriggers = reader.ReadProperty<UnityEngine.UI.AnimationTriggers> ();
						break;
					case "targetGraphic":
						Type targetGraphicType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( slider.targetGraphic == null )
						{
							slider.targetGraphic = ( UnityEngine.UI.Graphic )reader.ReadProperty ( targetGraphicType );
						}
						else
						{
							reader.ReadIntoProperty ( slider.targetGraphic );
						}
						break;
					case "interactable":
						slider.interactable = reader.ReadProperty<System.Boolean> ();
						break;
					case "image":
						if ( slider.image == null )
						{
							slider.image = reader.ReadProperty<UnityEngine.UI.Image> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Image> ( slider.image );
						}
						break;
					case "useGUILayout":
						slider.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						slider.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						slider.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						slider.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						slider.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}