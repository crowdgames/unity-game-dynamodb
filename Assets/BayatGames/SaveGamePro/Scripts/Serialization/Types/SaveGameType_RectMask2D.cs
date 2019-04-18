using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type RectMask2D serialization implementation.
	/// </summary>
	public class SaveGameType_RectMask2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.RectMask2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.RectMask2D rectMask2D = ( UnityEngine.UI.RectMask2D )value;
			writer.WriteProperty ( "useGUILayout", rectMask2D.useGUILayout );
			writer.WriteProperty ( "enabled", rectMask2D.enabled );
			writer.WriteProperty ( "tag", rectMask2D.tag );
			writer.WriteProperty ( "name", rectMask2D.name );
			writer.WriteProperty ( "hideFlags", rectMask2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.RectMask2D rectMask2D = SaveGameType.CreateComponent<UnityEngine.UI.RectMask2D> ();
			ReadInto ( rectMask2D, reader );
			return rectMask2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.RectMask2D rectMask2D = ( UnityEngine.UI.RectMask2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "useGUILayout":
						rectMask2D.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						rectMask2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						rectMask2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						rectMask2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						rectMask2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}