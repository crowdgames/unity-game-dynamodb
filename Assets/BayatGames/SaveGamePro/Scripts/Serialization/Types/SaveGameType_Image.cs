using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Image serialization implementation.
	/// </summary>
	public class SaveGameType_Image : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Image );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Image image = ( UnityEngine.UI.Image )value;
			writer.WriteProperty ( "sprite", image.sprite );
			writer.WriteProperty ( "overrideSprite", image.overrideSprite );
			writer.WriteProperty ( "type", image.type );
			writer.WriteProperty ( "preserveAspect", image.preserveAspect );
			writer.WriteProperty ( "fillCenter", image.fillCenter );
			writer.WriteProperty ( "fillMethod", image.fillMethod );
			writer.WriteProperty ( "fillAmount", image.fillAmount );
			writer.WriteProperty ( "fillClockwise", image.fillClockwise );
			writer.WriteProperty ( "fillOrigin", image.fillOrigin );
			writer.WriteProperty ( "alphaHitTestMinimumThreshold", image.alphaHitTestMinimumThreshold );
			writer.WriteProperty ( "material", image.material );
			writer.WriteProperty ( "maskable", image.maskable );
			writer.WriteProperty ( "color", image.color );
			writer.WriteProperty ( "raycastTarget", image.raycastTarget );
			writer.WriteProperty ( "useGUILayout", image.useGUILayout );
			writer.WriteProperty ( "enabled", image.enabled );
			writer.WriteProperty ( "tag", image.tag );
			writer.WriteProperty ( "name", image.name );
			writer.WriteProperty ( "hideFlags", image.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Image image = SaveGameType.CreateComponent<UnityEngine.UI.Image> ();
			ReadInto ( image, reader );
			return image;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Image image = ( UnityEngine.UI.Image )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "sprite":
						if ( image.sprite == null )
						{
							image.sprite = reader.ReadProperty<UnityEngine.Sprite> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Sprite> ( image.sprite );
						}
						break;
					case "overrideSprite":
						if ( image.overrideSprite == null )
						{
							image.overrideSprite = reader.ReadProperty<UnityEngine.Sprite> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Sprite> ( image.overrideSprite );
						}
						break;
					case "type":
						image.type = reader.ReadProperty<UnityEngine.UI.Image.Type> ();
						break;
					case "preserveAspect":
						image.preserveAspect = reader.ReadProperty<System.Boolean> ();
						break;
					case "fillCenter":
						image.fillCenter = reader.ReadProperty<System.Boolean> ();
						break;
					case "fillMethod":
						image.fillMethod = reader.ReadProperty<UnityEngine.UI.Image.FillMethod> ();
						break;
					case "fillAmount":
						image.fillAmount = reader.ReadProperty<System.Single> ();
						break;
					case "fillClockwise":
						image.fillClockwise = reader.ReadProperty<System.Boolean> ();
						break;
					case "fillOrigin":
						image.fillOrigin = reader.ReadProperty<System.Int32> ();
						break;
					case "alphaHitTestMinimumThreshold":
						image.alphaHitTestMinimumThreshold = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( image.material == null )
						{
							image.material = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( image.material );
						}
						break;
					case "maskable":
						image.maskable = reader.ReadProperty<System.Boolean> ();
						break;
					case "color":
						image.color = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "raycastTarget":
						image.raycastTarget = reader.ReadProperty<System.Boolean> ();
						break;
					case "useGUILayout":
						image.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						image.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						image.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						image.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						image.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}