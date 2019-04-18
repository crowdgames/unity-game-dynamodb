using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type RawImage serialization implementation.
	/// </summary>
	public class SaveGameType_RawImage : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.RawImage );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.RawImage rawImage = ( UnityEngine.UI.RawImage )value;
			writer.WriteProperty ( "texture", rawImage.texture );
			writer.WriteProperty ( "uvRect", rawImage.uvRect );
			writer.WriteProperty ( "maskable", rawImage.maskable );
			writer.WriteProperty ( "color", rawImage.color );
			writer.WriteProperty ( "raycastTarget", rawImage.raycastTarget );
			writer.WriteProperty ( "material", rawImage.material );
			writer.WriteProperty ( "useGUILayout", rawImage.useGUILayout );
			writer.WriteProperty ( "enabled", rawImage.enabled );
			writer.WriteProperty ( "tag", rawImage.tag );
			writer.WriteProperty ( "name", rawImage.name );
			writer.WriteProperty ( "hideFlags", rawImage.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.RawImage rawImage = SaveGameType.CreateComponent<UnityEngine.UI.RawImage> ();
			ReadInto ( rawImage, reader );
			return rawImage;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.RawImage rawImage = ( UnityEngine.UI.RawImage )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "texture":
						if ( rawImage.texture == null )
						{
							rawImage.texture = reader.ReadProperty<UnityEngine.Texture> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Texture> ( rawImage.texture );
						}
						break;
					case "uvRect":
						rawImage.uvRect = reader.ReadProperty<UnityEngine.Rect> ();
						break;
					case "maskable":
						rawImage.maskable = reader.ReadProperty<System.Boolean> ();
						break;
					case "color":
						rawImage.color = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "raycastTarget":
						rawImage.raycastTarget = reader.ReadProperty<System.Boolean> ();
						break;
					case "material":
						if ( rawImage.material == null )
						{
							rawImage.material = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( rawImage.material );
						}
						break;
					case "useGUILayout":
						rawImage.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						rawImage.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						rawImage.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						rawImage.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						rawImage.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}