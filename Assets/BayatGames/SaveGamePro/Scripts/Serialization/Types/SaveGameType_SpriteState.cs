using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SpriteState serialization implementation.
	/// </summary>
	public class SaveGameType_SpriteState : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.SpriteState );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.SpriteState spriteState = ( UnityEngine.UI.SpriteState )value;
			writer.WriteProperty ( "highlightedSprite", spriteState.highlightedSprite );
			writer.WriteProperty ( "pressedSprite", spriteState.pressedSprite );
			writer.WriteProperty ( "disabledSprite", spriteState.disabledSprite );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.SpriteState spriteState = new UnityEngine.UI.SpriteState ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "highlightedSprite":
						if ( spriteState.highlightedSprite == null )
						{
							spriteState.highlightedSprite = reader.ReadProperty<UnityEngine.Sprite> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Sprite> ( spriteState.highlightedSprite );
						}
						break;
					case "pressedSprite":
						if ( spriteState.pressedSprite == null )
						{
							spriteState.pressedSprite = reader.ReadProperty<UnityEngine.Sprite> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Sprite> ( spriteState.pressedSprite );
						}
						break;
					case "disabledSprite":
						if ( spriteState.disabledSprite == null )
						{
							spriteState.disabledSprite = reader.ReadProperty<UnityEngine.Sprite> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Sprite> ( spriteState.disabledSprite );
						}
						break;
				}
			}
			return spriteState;
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