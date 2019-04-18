using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioDistortionFilter serialization implementation.
	/// </summary>
	public class SaveGameType_AudioDistortionFilter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioDistortionFilter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioDistortionFilter audioDistortionFilter = ( UnityEngine.AudioDistortionFilter )value;
			writer.WriteProperty ( "distortionLevel", audioDistortionFilter.distortionLevel );
			writer.WriteProperty ( "enabled", audioDistortionFilter.enabled );
			writer.WriteProperty ( "tag", audioDistortionFilter.tag );
			writer.WriteProperty ( "name", audioDistortionFilter.name );
			writer.WriteProperty ( "hideFlags", audioDistortionFilter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioDistortionFilter audioDistortionFilter = SaveGameType.CreateComponent<UnityEngine.AudioDistortionFilter> ();
			ReadInto ( audioDistortionFilter, reader );
			return audioDistortionFilter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioDistortionFilter audioDistortionFilter = ( UnityEngine.AudioDistortionFilter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "distortionLevel":
						audioDistortionFilter.distortionLevel = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						audioDistortionFilter.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioDistortionFilter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioDistortionFilter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioDistortionFilter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}