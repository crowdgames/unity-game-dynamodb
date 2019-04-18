using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type InputField serialization implementation.
	/// </summary>
	public class SaveGameType_InputField : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.InputField );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.InputField inputField = ( UnityEngine.UI.InputField )value;
			writer.WriteProperty ( "shouldHideMobileInput", inputField.shouldHideMobileInput );
			writer.WriteProperty ( "text", inputField.text );
			writer.WriteProperty ( "caretBlinkRate", inputField.caretBlinkRate );
			writer.WriteProperty ( "caretWidth", inputField.caretWidth );
			writer.WriteProperty ( "textComponent", inputField.textComponent );
			writer.WriteProperty ( "placeholderType", inputField.placeholder.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "placeholder", inputField.placeholder );
			writer.WriteProperty ( "caretColor", inputField.caretColor );
			writer.WriteProperty ( "customCaretColor", inputField.customCaretColor );
			writer.WriteProperty ( "selectionColor", inputField.selectionColor );
			writer.WriteProperty ( "characterLimit", inputField.characterLimit );
			writer.WriteProperty ( "contentType", inputField.contentType );
			writer.WriteProperty ( "lineType", inputField.lineType );
			writer.WriteProperty ( "inputType", inputField.inputType );
			writer.WriteProperty ( "keyboardType", inputField.keyboardType );
			writer.WriteProperty ( "characterValidation", inputField.characterValidation );
			writer.WriteProperty ( "readOnly", inputField.readOnly );
			writer.WriteProperty ( "asteriskChar", inputField.asteriskChar );
			writer.WriteProperty ( "caretPosition", inputField.caretPosition );
			writer.WriteProperty ( "selectionAnchorPosition", inputField.selectionAnchorPosition );
			writer.WriteProperty ( "selectionFocusPosition", inputField.selectionFocusPosition );
			writer.WriteProperty ( "navigation", inputField.navigation );
			writer.WriteProperty ( "transition", inputField.transition );
			writer.WriteProperty ( "colors", inputField.colors );
			writer.WriteProperty ( "spriteState", inputField.spriteState );
			writer.WriteProperty ( "animationTriggers", inputField.animationTriggers );
			writer.WriteProperty ( "targetGraphicType", inputField.targetGraphic.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "targetGraphic", inputField.targetGraphic );
			writer.WriteProperty ( "interactable", inputField.interactable );
			writer.WriteProperty ( "image", inputField.image );
			writer.WriteProperty ( "useGUILayout", inputField.useGUILayout );
			writer.WriteProperty ( "enabled", inputField.enabled );
			writer.WriteProperty ( "tag", inputField.tag );
			writer.WriteProperty ( "name", inputField.name );
			writer.WriteProperty ( "hideFlags", inputField.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.InputField inputField = SaveGameType.CreateComponent<UnityEngine.UI.InputField> ();
			ReadInto ( inputField, reader );
			return inputField;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.InputField inputField = ( UnityEngine.UI.InputField )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "shouldHideMobileInput":
						inputField.shouldHideMobileInput = reader.ReadProperty<System.Boolean> ();
						break;
					case "text":
						inputField.text = reader.ReadProperty<System.String> ();
						break;
					case "caretBlinkRate":
						inputField.caretBlinkRate = reader.ReadProperty<System.Single> ();
						break;
					case "caretWidth":
						inputField.caretWidth = reader.ReadProperty<System.Int32> ();
						break;
					case "textComponent":
						if ( inputField.textComponent == null )
						{
							inputField.textComponent = reader.ReadProperty<UnityEngine.UI.Text> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Text> ( inputField.textComponent );
						}
						break;
					case "placeholder":
						Type placeholderType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( inputField.placeholder == null )
						{
							inputField.placeholder = ( UnityEngine.UI.Graphic )reader.ReadProperty ( placeholderType );
						}
						else
						{
							reader.ReadIntoProperty ( inputField.placeholder );
						}
						break;
					case "caretColor":
						inputField.caretColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "customCaretColor":
						inputField.customCaretColor = reader.ReadProperty<System.Boolean> ();
						break;
					case "selectionColor":
						inputField.selectionColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "characterLimit":
						inputField.characterLimit = reader.ReadProperty<System.Int32> ();
						break;
					case "contentType":
						inputField.contentType = reader.ReadProperty<UnityEngine.UI.InputField.ContentType> ();
						break;
					case "lineType":
						inputField.lineType = reader.ReadProperty<UnityEngine.UI.InputField.LineType> ();
						break;
					case "inputType":
						inputField.inputType = reader.ReadProperty<UnityEngine.UI.InputField.InputType> ();
						break;
					case "keyboardType":
						inputField.keyboardType = reader.ReadProperty<UnityEngine.TouchScreenKeyboardType> ();
						break;
					case "characterValidation":
						inputField.characterValidation = reader.ReadProperty<UnityEngine.UI.InputField.CharacterValidation> ();
						break;
					case "readOnly":
						inputField.readOnly = reader.ReadProperty<System.Boolean> ();
						break;
					case "asteriskChar":
						inputField.asteriskChar = reader.ReadProperty<System.Char> ();
						break;
					case "caretPosition":
						inputField.caretPosition = reader.ReadProperty<System.Int32> ();
						break;
					case "selectionAnchorPosition":
						inputField.selectionAnchorPosition = reader.ReadProperty<System.Int32> ();
						break;
					case "selectionFocusPosition":
						inputField.selectionFocusPosition = reader.ReadProperty<System.Int32> ();
						break;
					case "navigation":
						inputField.navigation = reader.ReadProperty<UnityEngine.UI.Navigation> ();
						break;
					case "transition":
						inputField.transition = reader.ReadProperty<UnityEngine.UI.Selectable.Transition> ();
						break;
					case "colors":
						inputField.colors = reader.ReadProperty<UnityEngine.UI.ColorBlock> ();
						break;
					case "spriteState":
						inputField.spriteState = reader.ReadProperty<UnityEngine.UI.SpriteState> ();
						break;
					case "animationTriggers":
						inputField.animationTriggers = reader.ReadProperty<UnityEngine.UI.AnimationTriggers> ();
						break;
					case "targetGraphic":
						Type targetGraphicType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( inputField.targetGraphic == null )
						{
							inputField.targetGraphic = ( UnityEngine.UI.Graphic )reader.ReadProperty ( targetGraphicType );
						}
						else
						{
							reader.ReadIntoProperty ( inputField.targetGraphic );
						}
						break;
					case "interactable":
						inputField.interactable = reader.ReadProperty<System.Boolean> ();
						break;
					case "image":
						if ( inputField.image == null )
						{
							inputField.image = reader.ReadProperty<UnityEngine.UI.Image> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Image> ( inputField.image );
						}
						break;
					case "useGUILayout":
						inputField.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						inputField.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						inputField.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						inputField.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						inputField.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}