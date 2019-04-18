using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioHighPassFilter serialization implementation.
	/// </summary>
	public class SaveGameType_AudioHighPassFilter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioHighPassFilter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioHighPassFilter audioHighPassFilter = ( UnityEngine.AudioHighPassFilter )value;
			writer.WriteProperty ( "cutoffFrequency", audioHighPassFilter.cutoffFrequency );
			writer.WriteProperty ( "highpassResonanceQ", audioHighPassFilter.highpassResonanceQ );
			writer.WriteProperty ( "enabled", audioHighPassFilter.enabled );
			writer.WriteProperty ( "tag", audioHighPassFilter.tag );
			writer.WriteProperty ( "name", audioHighPassFilter.name );
			writer.WriteProperty ( "hideFlags", audioHighPassFilter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioHighPassFilter audioHighPassFilter = SaveGameType.CreateComponent<UnityEngine.AudioHighPassFilter> ();
			ReadInto ( audioHighPassFilter, reader );
			return audioHighPassFilter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioHighPassFilter audioHighPassFilter = ( UnityEngine.AudioHighPassFilter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "cutoffFrequency":
						audioHighPassFilter.cutoffFrequency = reader.ReadProperty<System.Single> ();
						break;
					case "highpassResonanceQ":
						audioHighPassFilter.highpassResonanceQ = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						audioHighPassFilter.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioHighPassFilter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioHighPassFilter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioHighPassFilter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}