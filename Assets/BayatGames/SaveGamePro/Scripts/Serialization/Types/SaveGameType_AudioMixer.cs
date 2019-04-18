using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioMixer serialization implementation.
	/// </summary>
	public class SaveGameType_AudioMixer : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Audio.AudioMixer );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Audio.AudioMixer audioMixer = ( UnityEngine.Audio.AudioMixer )value;
			writer.WriteProperty ( "outputAudioMixerGroup", audioMixer.outputAudioMixerGroup );
			writer.WriteProperty ( "updateMode", audioMixer.updateMode );
			writer.WriteProperty ( "name", audioMixer.name );
			writer.WriteProperty ( "hideFlags", audioMixer.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			return base.Read ( reader );
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Audio.AudioMixer audioMixer = ( UnityEngine.Audio.AudioMixer )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "outputAudioMixerGroup":
						if ( audioMixer.outputAudioMixerGroup == null )
						{
							audioMixer.outputAudioMixerGroup = reader.ReadProperty<UnityEngine.Audio.AudioMixerGroup> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Audio.AudioMixerGroup> ( audioMixer.outputAudioMixerGroup );
						}
						break;
					case "updateMode":
						audioMixer.updateMode = reader.ReadProperty<UnityEngine.Audio.AudioMixerUpdateMode> ();
						break;
					case "name":
						audioMixer.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioMixer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}