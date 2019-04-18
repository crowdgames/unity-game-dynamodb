using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type CanvasScaler serialization implementation.
	/// </summary>
	public class SaveGameType_CanvasScaler : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.CanvasScaler );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.CanvasScaler canvasScaler = ( UnityEngine.UI.CanvasScaler )value;
			writer.WriteProperty ( "uiScaleMode", canvasScaler.uiScaleMode );
			writer.WriteProperty ( "referencePixelsPerUnit", canvasScaler.referencePixelsPerUnit );
			writer.WriteProperty ( "scaleFactor", canvasScaler.scaleFactor );
			writer.WriteProperty ( "referenceResolution", canvasScaler.referenceResolution );
			writer.WriteProperty ( "screenMatchMode", canvasScaler.screenMatchMode );
			writer.WriteProperty ( "matchWidthOrHeight", canvasScaler.matchWidthOrHeight );
			writer.WriteProperty ( "physicalUnit", canvasScaler.physicalUnit );
			writer.WriteProperty ( "fallbackScreenDPI", canvasScaler.fallbackScreenDPI );
			writer.WriteProperty ( "defaultSpriteDPI", canvasScaler.defaultSpriteDPI );
			writer.WriteProperty ( "dynamicPixelsPerUnit", canvasScaler.dynamicPixelsPerUnit );
			writer.WriteProperty ( "useGUILayout", canvasScaler.useGUILayout );
			writer.WriteProperty ( "enabled", canvasScaler.enabled );
			writer.WriteProperty ( "tag", canvasScaler.tag );
			writer.WriteProperty ( "name", canvasScaler.name );
			writer.WriteProperty ( "hideFlags", canvasScaler.hideFlags );
			
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.CanvasScaler canvasScaler = SaveGameType.CreateComponent<UnityEngine.UI.CanvasScaler> ();
			ReadInto ( canvasScaler, reader );
			return canvasScaler;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.CanvasScaler canvasScaler = ( UnityEngine.UI.CanvasScaler )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "uiScaleMode":
						canvasScaler.uiScaleMode = reader.ReadProperty<UnityEngine.UI.CanvasScaler.ScaleMode> ();
						break;
					case "referencePixelsPerUnit":
						canvasScaler.referencePixelsPerUnit = reader.ReadProperty<System.Single> ();
						break;
					case "scaleFactor":
						canvasScaler.scaleFactor = reader.ReadProperty<System.Single> ();
						break;
					case "referenceResolution":
						canvasScaler.referenceResolution = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "screenMatchMode":
						canvasScaler.screenMatchMode = reader.ReadProperty<UnityEngine.UI.CanvasScaler.ScreenMatchMode> ();
						break;
					case "matchWidthOrHeight":
						canvasScaler.matchWidthOrHeight = reader.ReadProperty<System.Single> ();
						break;
					case "physicalUnit":
						canvasScaler.physicalUnit = reader.ReadProperty<UnityEngine.UI.CanvasScaler.Unit> ();
						break;
					case "fallbackScreenDPI":
						canvasScaler.fallbackScreenDPI = reader.ReadProperty<System.Single> ();
						break;
					case "defaultSpriteDPI":
						canvasScaler.defaultSpriteDPI = reader.ReadProperty<System.Single> ();
						break;
					case "dynamicPixelsPerUnit":
						canvasScaler.dynamicPixelsPerUnit = reader.ReadProperty<System.Single> ();
						break;
					case "useGUILayout":
						canvasScaler.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						canvasScaler.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						canvasScaler.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						canvasScaler.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						canvasScaler.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}