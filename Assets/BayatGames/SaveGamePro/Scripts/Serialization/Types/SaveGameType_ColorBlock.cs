using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ColorBlock serialization implementation.
	/// </summary>
	public class SaveGameType_ColorBlock : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.ColorBlock );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.ColorBlock colorBlock = ( UnityEngine.UI.ColorBlock )value;
			writer.WriteProperty ( "normalColor", colorBlock.normalColor );
			writer.WriteProperty ( "highlightedColor", colorBlock.highlightedColor );
			writer.WriteProperty ( "pressedColor", colorBlock.pressedColor );
			writer.WriteProperty ( "disabledColor", colorBlock.disabledColor );
			writer.WriteProperty ( "colorMultiplier", colorBlock.colorMultiplier );
			writer.WriteProperty ( "fadeDuration", colorBlock.fadeDuration );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.ColorBlock colorBlock = new UnityEngine.UI.ColorBlock ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "normalColor":
						colorBlock.normalColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "highlightedColor":
						colorBlock.highlightedColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "pressedColor":
						colorBlock.pressedColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "disabledColor":
						colorBlock.disabledColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "colorMultiplier":
						colorBlock.colorMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "fadeDuration":
						colorBlock.fadeDuration = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return colorBlock;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			base.ReadInto ( value, reader );
		}
		
	}

}