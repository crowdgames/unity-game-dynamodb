using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ScrollRect serialization implementation.
	/// </summary>
	public class SaveGameType_ScrollRect : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.ScrollRect );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.ScrollRect scrollRect = ( UnityEngine.UI.ScrollRect )value;
			writer.WriteProperty ( "content", scrollRect.content );
			writer.WriteProperty ( "horizontal", scrollRect.horizontal );
			writer.WriteProperty ( "vertical", scrollRect.vertical );
			writer.WriteProperty ( "movementType", scrollRect.movementType );
			writer.WriteProperty ( "elasticity", scrollRect.elasticity );
			writer.WriteProperty ( "inertia", scrollRect.inertia );
			writer.WriteProperty ( "decelerationRate", scrollRect.decelerationRate );
			writer.WriteProperty ( "scrollSensitivity", scrollRect.scrollSensitivity );
			writer.WriteProperty ( "viewport", scrollRect.viewport );
			writer.WriteProperty ( "horizontalScrollbar", scrollRect.horizontalScrollbar );
			writer.WriteProperty ( "verticalScrollbar", scrollRect.verticalScrollbar );
			writer.WriteProperty ( "horizontalScrollbarVisibility", scrollRect.horizontalScrollbarVisibility );
			writer.WriteProperty ( "verticalScrollbarVisibility", scrollRect.verticalScrollbarVisibility );
			writer.WriteProperty ( "horizontalScrollbarSpacing", scrollRect.horizontalScrollbarSpacing );
			writer.WriteProperty ( "verticalScrollbarSpacing", scrollRect.verticalScrollbarSpacing );
			writer.WriteProperty ( "velocity", scrollRect.velocity );
			writer.WriteProperty ( "normalizedPosition", scrollRect.normalizedPosition );
			writer.WriteProperty ( "horizontalNormalizedPosition", scrollRect.horizontalNormalizedPosition );
			writer.WriteProperty ( "verticalNormalizedPosition", scrollRect.verticalNormalizedPosition );
			writer.WriteProperty ( "useGUILayout", scrollRect.useGUILayout );
			writer.WriteProperty ( "enabled", scrollRect.enabled );
			writer.WriteProperty ( "tag", scrollRect.tag );
			writer.WriteProperty ( "name", scrollRect.name );
			writer.WriteProperty ( "hideFlags", scrollRect.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.ScrollRect scrollRect = SaveGameType.CreateComponent<UnityEngine.UI.ScrollRect> ();
			ReadInto ( scrollRect, reader );
			return scrollRect;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.ScrollRect scrollRect = ( UnityEngine.UI.ScrollRect )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "content":
						if ( scrollRect.content == null )
						{
							scrollRect.content = reader.ReadProperty<UnityEngine.RectTransform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.RectTransform> ( scrollRect.content );
						}
						break;
					case "horizontal":
						scrollRect.horizontal = reader.ReadProperty<System.Boolean> ();
						break;
					case "vertical":
						scrollRect.vertical = reader.ReadProperty<System.Boolean> ();
						break;
					case "movementType":
						scrollRect.movementType = reader.ReadProperty<UnityEngine.UI.ScrollRect.MovementType> ();
						break;
					case "elasticity":
						scrollRect.elasticity = reader.ReadProperty<System.Single> ();
						break;
					case "inertia":
						scrollRect.inertia = reader.ReadProperty<System.Boolean> ();
						break;
					case "decelerationRate":
						scrollRect.decelerationRate = reader.ReadProperty<System.Single> ();
						break;
					case "scrollSensitivity":
						scrollRect.scrollSensitivity = reader.ReadProperty<System.Single> ();
						break;
					case "viewport":
						if ( scrollRect.viewport == null )
						{
							scrollRect.viewport = reader.ReadProperty<UnityEngine.RectTransform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.RectTransform> ( scrollRect.viewport );
						}
						break;
					case "horizontalScrollbar":
						if ( scrollRect.horizontalScrollbar == null )
						{
							scrollRect.horizontalScrollbar = reader.ReadProperty<UnityEngine.UI.Scrollbar> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Scrollbar> ( scrollRect.horizontalScrollbar );
						}
						break;
					case "verticalScrollbar":
						if ( scrollRect.verticalScrollbar == null )
						{
							scrollRect.verticalScrollbar = reader.ReadProperty<UnityEngine.UI.Scrollbar> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Scrollbar> ( scrollRect.verticalScrollbar );
						}
						break;
					case "horizontalScrollbarVisibility":
						scrollRect.horizontalScrollbarVisibility = reader.ReadProperty<UnityEngine.UI.ScrollRect.ScrollbarVisibility> ();
						break;
					case "verticalScrollbarVisibility":
						scrollRect.verticalScrollbarVisibility = reader.ReadProperty<UnityEngine.UI.ScrollRect.ScrollbarVisibility> ();
						break;
					case "horizontalScrollbarSpacing":
						scrollRect.horizontalScrollbarSpacing = reader.ReadProperty<System.Single> ();
						break;
					case "verticalScrollbarSpacing":
						scrollRect.verticalScrollbarSpacing = reader.ReadProperty<System.Single> ();
						break;
					case "velocity":
						scrollRect.velocity = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "normalizedPosition":
						scrollRect.normalizedPosition = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "horizontalNormalizedPosition":
						scrollRect.horizontalNormalizedPosition = reader.ReadProperty<System.Single> ();
						break;
					case "verticalNormalizedPosition":
						scrollRect.verticalNormalizedPosition = reader.ReadProperty<System.Single> ();
						break;
					case "useGUILayout":
						scrollRect.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						scrollRect.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						scrollRect.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						scrollRect.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						scrollRect.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}