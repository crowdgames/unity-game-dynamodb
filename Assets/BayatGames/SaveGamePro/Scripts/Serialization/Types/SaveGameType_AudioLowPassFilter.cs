using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioLowPassFilter serialization implementation.
	/// </summary>
	public class SaveGameType_AudioLowPassFilter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioLowPassFilter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioLowPassFilter audioLowPassFilter = ( UnityEngine.AudioLowPassFilter )value;
			writer.WriteProperty ( "cutoffFrequency", audioLowPassFilter.cutoffFrequency );
			writer.WriteProperty ( "customCutoffCurve", audioLowPassFilter.customCutoffCurve );
			writer.WriteProperty ( "lowpassResonanceQ", audioLowPassFilter.lowpassResonanceQ );
			writer.WriteProperty ( "enabled", audioLowPassFilter.enabled );
			writer.WriteProperty ( "tag", audioLowPassFilter.tag );
			writer.WriteProperty ( "name", audioLowPassFilter.name );
			writer.WriteProperty ( "hideFlags", audioLowPassFilter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioLowPassFilter audioLowPassFilter = SaveGameType.CreateComponent<UnityEngine.AudioLowPassFilter> ();
			ReadInto ( audioLowPassFilter, reader );
			return audioLowPassFilter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioLowPassFilter audioLowPassFilter = ( UnityEngine.AudioLowPassFilter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "cutoffFrequency":
						audioLowPassFilter.cutoffFrequency = reader.ReadProperty<System.Single> ();
						break;
					case "customCutoffCurve":
						audioLowPassFilter.customCutoffCurve = reader.ReadProperty<UnityEngine.AnimationCurve> ();
						break;
					case "lowpassResonanceQ":
						audioLowPassFilter.lowpassResonanceQ = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						audioLowPassFilter.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioLowPassFilter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioLowPassFilter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioLowPassFilter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}