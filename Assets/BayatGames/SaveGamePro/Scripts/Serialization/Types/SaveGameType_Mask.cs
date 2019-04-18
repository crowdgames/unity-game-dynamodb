using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Mask serialization implementation.
	/// </summary>
	public class SaveGameType_Mask : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Mask );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Mask mask = ( UnityEngine.UI.Mask )value;
			writer.WriteProperty ( "showMaskGraphic", mask.showMaskGraphic );
			writer.WriteProperty ( "useGUILayout", mask.useGUILayout );
			writer.WriteProperty ( "enabled", mask.enabled );
			writer.WriteProperty ( "tag", mask.tag );
			writer.WriteProperty ( "name", mask.name );
			writer.WriteProperty ( "hideFlags", mask.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Mask mask = SaveGameType.CreateComponent<UnityEngine.UI.Mask> ();
			ReadInto ( mask, reader );
			return mask;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.Mask mask = ( UnityEngine.UI.Mask )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "showMaskGraphic":
						mask.showMaskGraphic = reader.ReadProperty<System.Boolean> ();
						break;
					case "useGUILayout":
						mask.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						mask.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						mask.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						mask.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						mask.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}