using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioConfiguration serialization implementation.
	/// </summary>
	public class SaveGameType_AudioConfiguration : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioConfiguration );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioConfiguration audioConfiguration = ( UnityEngine.AudioConfiguration )value;
			writer.WriteProperty ( "speakerMode", audioConfiguration.speakerMode );
			writer.WriteProperty ( "dspBufferSize", audioConfiguration.dspBufferSize );
			writer.WriteProperty ( "sampleRate", audioConfiguration.sampleRate );
			writer.WriteProperty ( "numRealVoices", audioConfiguration.numRealVoices );
			writer.WriteProperty ( "numVirtualVoices", audioConfiguration.numVirtualVoices );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioConfiguration audioConfiguration = new UnityEngine.AudioConfiguration ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "speakerMode":
						audioConfiguration.speakerMode = reader.ReadProperty<UnityEngine.AudioSpeakerMode> ();
						break;
					case "dspBufferSize":
						audioConfiguration.dspBufferSize = reader.ReadProperty<System.Int32> ();
						break;
					case "sampleRate":
						audioConfiguration.sampleRate = reader.ReadProperty<System.Int32> ();
						break;
					case "numRealVoices":
						audioConfiguration.numRealVoices = reader.ReadProperty<System.Int32> ();
						break;
					case "numVirtualVoices":
						audioConfiguration.numVirtualVoices = reader.ReadProperty<System.Int32> ();
						break;
				}
			}
			return audioConfiguration;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			base.ReadInto ( value, reader );
		}
		
	}

}