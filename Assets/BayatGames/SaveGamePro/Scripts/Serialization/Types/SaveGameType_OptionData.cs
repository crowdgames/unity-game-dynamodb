using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type OptionData serialization implementation.
	/// </summary>
	public class SaveGameType_OptionData : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Dropdown.OptionData );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Dropdown.OptionData optionData = ( UnityEngine.UI.Dropdown.OptionData )value;
			writer.WriteProperty ( "text", optionData.text );
			writer.WriteProperty ( "image", optionData.image );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Dropdown.OptionData optionData = new UnityEngine.UI.Dropdown.OptionData ();
			ReadInto ( optionData, reader );
			return optionData;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Dropdown.OptionData optionData = ( UnityEngine.UI.Dropdown.OptionData )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "text":
						optionData.text = reader.ReadProperty<System.String> ();
						break;
					case "image":
						if ( optionData.image == null )
						{
							optionData.image = reader.ReadProperty<UnityEngine.Sprite> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Sprite> ( optionData.image );
						}
						break;
				}
			}
		}
		
	}

}