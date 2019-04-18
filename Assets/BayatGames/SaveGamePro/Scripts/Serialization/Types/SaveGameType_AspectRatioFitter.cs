using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AspectRatioFitter serialization implementation.
	/// </summary>
	public class SaveGameType_AspectRatioFitter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.AspectRatioFitter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.AspectRatioFitter aspectRatioFitter = ( UnityEngine.UI.AspectRatioFitter )value;
			writer.WriteProperty ( "aspectMode", aspectRatioFitter.aspectMode );
			writer.WriteProperty ( "aspectRatio", aspectRatioFitter.aspectRatio );
			writer.WriteProperty ( "useGUILayout", aspectRatioFitter.useGUILayout );
			writer.WriteProperty ( "enabled", aspectRatioFitter.enabled );
			writer.WriteProperty ( "tag", aspectRatioFitter.tag );
			writer.WriteProperty ( "name", aspectRatioFitter.name );
			writer.WriteProperty ( "hideFlags", aspectRatioFitter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.AspectRatioFitter aspectRatioFitter = SaveGameType.CreateComponent<UnityEngine.UI.AspectRatioFitter> ();
			ReadInto ( aspectRatioFitter, reader );
			return aspectRatioFitter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.AspectRatioFitter aspectRatioFitter = ( UnityEngine.UI.AspectRatioFitter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "aspectMode":
						aspectRatioFitter.aspectMode = reader.ReadProperty<UnityEngine.UI.AspectRatioFitter.AspectMode> ();
						break;
					case "aspectRatio":
						aspectRatioFitter.aspectRatio = reader.ReadProperty<System.Single> ();
						break;
					case "useGUILayout":
						aspectRatioFitter.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						aspectRatioFitter.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						aspectRatioFitter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						aspectRatioFitter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						aspectRatioFitter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}