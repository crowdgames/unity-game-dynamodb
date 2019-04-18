using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type OptionDataList serialization implementation.
	/// </summary>
	public class SaveGameType_OptionDataList : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Dropdown.OptionDataList );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Dropdown.OptionDataList optionDataList = ( UnityEngine.UI.Dropdown.OptionDataList )value;
			writer.WriteProperty ( "options", optionDataList.options );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Dropdown.OptionDataList optionDataList = new UnityEngine.UI.Dropdown.OptionDataList ();
			ReadInto ( optionDataList, reader );
			return optionDataList;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Dropdown.OptionDataList optionDataList = ( UnityEngine.UI.Dropdown.OptionDataList )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "options":
						optionDataList.options = reader.ReadProperty<System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData>> ();
						break;
				}
			}
		}
		
	}

}