using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Scrollbar serialization implementation.
	/// </summary>
	public class SaveGameType_Scrollbar : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Scrollbar );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Scrollbar scrollbar = ( UnityEngine.UI.Scrollbar )value;
			writer.WriteProperty ( "handleRect", scrollbar.handleRect );
			writer.WriteProperty ( "direction", scrollbar.direction );
			writer.WriteProperty ( "value", scrollbar.value );
			writer.WriteProperty ( "size", scrollbar.size );
			writer.WriteProperty ( "numberOfSteps", scrollbar.numberOfSteps );
			writer.WriteProperty ( "navigation", scrollbar.navigation );
			writer.WriteProperty ( "transition", scrollbar.transition );
			writer.WriteProperty ( "colors", scrollbar.colors );
			writer.WriteProperty ( "spriteState", scrollbar.spriteState );
			writer.WriteProperty ( "animationTriggers", scrollbar.animationTriggers );
			writer.WriteProperty ( "targetGraphicType", scrollbar.targetGraphic.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "targetGraphic", scrollbar.targetGraphic );
			writer.WriteProperty ( "interactable", scrollbar.interactable );
			writer.WriteProperty ( "image", scrollbar.image );
			writer.WriteProperty ( "useGUILayout", scrollbar.useGUILayout );
			writer.WriteProperty ( "enabled", scrollbar.enabled );
			writer.WriteProperty ( "tag", scrollbar.tag );
			writer.WriteProperty ( "name", scrollbar.name );
			writer.WriteProperty ( "hideFlags", scrollbar.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Scrollbar scrollbar = SaveGameType.CreateComponent<UnityEngine.UI.Scrollbar> ();
			ReadInto ( scrollbar, reader );
			return scrollbar;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Scrollbar scrollbar = ( UnityEngine.UI.Scrollbar )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "handleRect":
						if ( scrollbar.handleRect == null )
						{
							scrollbar.handleRect = reader.ReadProperty<UnityEngine.RectTransform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.RectTransform> ( scrollbar.handleRect );
						}
						break;
					case "direction":
						scrollbar.direction = reader.ReadProperty<UnityEngine.UI.Scrollbar.Direction> ();
						break;
					case "value":
						scrollbar.value = reader.ReadProperty<System.Single> ();
						break;
					case "size":
						scrollbar.size = reader.ReadProperty<System.Single> ();
						break;
					case "numberOfSteps":
						scrollbar.numberOfSteps = reader.ReadProperty<System.Int32> ();
						break;
					case "navigation":
						scrollbar.navigation = reader.ReadProperty<UnityEngine.UI.Navigation> ();
						break;
					case "transition":
						scrollbar.transition = reader.ReadProperty<UnityEngine.UI.Selectable.Transition> ();
						break;
					case "colors":
						scrollbar.colors = reader.ReadProperty<UnityEngine.UI.ColorBlock> ();
						break;
					case "spriteState":
						scrollbar.spriteState = reader.ReadProperty<UnityEngine.UI.SpriteState> ();
						break;
					case "animationTriggers":
						scrollbar.animationTriggers = reader.ReadProperty<UnityEngine.UI.AnimationTriggers> ();
						break;
					case "targetGraphic":
						Type targetGraphicType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( scrollbar.targetGraphic == null )
						{
							scrollbar.targetGraphic = ( UnityEngine.UI.Graphic )reader.ReadProperty ( targetGraphicType );
						}
						else
						{
							reader.ReadIntoProperty ( scrollbar.targetGraphic );
						}
						break;
					case "interactable":
						scrollbar.interactable = reader.ReadProperty<System.Boolean> ();
						break;
					case "image":
						if ( scrollbar.image == null )
						{
							scrollbar.image = reader.ReadProperty<UnityEngine.UI.Image> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Image> ( scrollbar.image );
						}
						break;
					case "useGUILayout":
						scrollbar.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						scrollbar.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						scrollbar.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						scrollbar.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						scrollbar.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}