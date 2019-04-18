using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type GraphicRaycaster serialization implementation.
	/// </summary>
	public class SaveGameType_GraphicRaycaster : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.GraphicRaycaster );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.GraphicRaycaster graphicRaycaster = ( UnityEngine.UI.GraphicRaycaster )value;
			writer.WriteProperty ( "ignoreReversedGraphics", graphicRaycaster.ignoreReversedGraphics );
			writer.WriteProperty ( "blockingObjects", graphicRaycaster.blockingObjects );
			writer.WriteProperty ( "useGUILayout", graphicRaycaster.useGUILayout );
			writer.WriteProperty ( "enabled", graphicRaycaster.enabled );
			writer.WriteProperty ( "tag", graphicRaycaster.tag );
			writer.WriteProperty ( "name", graphicRaycaster.name );
			writer.WriteProperty ( "hideFlags", graphicRaycaster.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.GraphicRaycaster graphicRaycaster = SaveGameType.CreateComponent<UnityEngine.UI.GraphicRaycaster> ();
			ReadInto ( graphicRaycaster, reader );
			return graphicRaycaster;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.GraphicRaycaster graphicRaycaster = ( UnityEngine.UI.GraphicRaycaster )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "ignoreReversedGraphics":
						graphicRaycaster.ignoreReversedGraphics = reader.ReadProperty<System.Boolean> ();
						break;
					case "blockingObjects":
						graphicRaycaster.blockingObjects = reader.ReadProperty<UnityEngine.UI.GraphicRaycaster.BlockingObjects> ();
						break;
					case "useGUILayout":
						graphicRaycaster.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						graphicRaycaster.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						graphicRaycaster.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						graphicRaycaster.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						graphicRaycaster.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}