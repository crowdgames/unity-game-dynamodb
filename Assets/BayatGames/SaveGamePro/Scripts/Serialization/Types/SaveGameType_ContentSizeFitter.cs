using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ContentSizeFitter serialization implementation.
	/// </summary>
	public class SaveGameType_ContentSizeFitter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.ContentSizeFitter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.ContentSizeFitter contentSizeFitter = ( UnityEngine.UI.ContentSizeFitter )value;
			writer.WriteProperty ( "horizontalFit", contentSizeFitter.horizontalFit );
			writer.WriteProperty ( "verticalFit", contentSizeFitter.verticalFit );
			writer.WriteProperty ( "useGUILayout", contentSizeFitter.useGUILayout );
			writer.WriteProperty ( "enabled", contentSizeFitter.enabled );
			writer.WriteProperty ( "tag", contentSizeFitter.tag );
			writer.WriteProperty ( "name", contentSizeFitter.name );
			writer.WriteProperty ( "hideFlags", contentSizeFitter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.ContentSizeFitter contentSizeFitter = SaveGameType.CreateComponent<UnityEngine.UI.ContentSizeFitter> ();
			ReadInto ( contentSizeFitter, reader );
			return contentSizeFitter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.ContentSizeFitter contentSizeFitter = ( UnityEngine.UI.ContentSizeFitter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "horizontalFit":
						contentSizeFitter.horizontalFit = reader.ReadProperty<UnityEngine.UI.ContentSizeFitter.FitMode> ();
						break;
					case "verticalFit":
						contentSizeFitter.verticalFit = reader.ReadProperty<UnityEngine.UI.ContentSizeFitter.FitMode> ();
						break;
					case "useGUILayout":
						contentSizeFitter.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						contentSizeFitter.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						contentSizeFitter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						contentSizeFitter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						contentSizeFitter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}