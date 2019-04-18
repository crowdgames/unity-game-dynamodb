using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioSource serialization implementation.
	/// </summary>
	public class SaveGameType_AudioSource : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioSource );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioSource audioSource = ( UnityEngine.AudioSource )value;
			writer.WriteProperty ( "volume", audioSource.volume );
			writer.WriteProperty ( "pitch", audioSource.pitch );
			writer.WriteProperty ( "time", audioSource.time );
			writer.WriteProperty ( "timeSamples", audioSource.timeSamples );
			writer.WriteProperty ( "clip", audioSource.clip );
			writer.WriteProperty ( "outputAudioMixerGroup", audioSource.outputAudioMixerGroup );
			writer.WriteProperty ( "loop", audioSource.loop );
			writer.WriteProperty ( "ignoreListenerVolume", audioSource.ignoreListenerVolume );
			writer.WriteProperty ( "playOnAwake", audioSource.playOnAwake );
			writer.WriteProperty ( "ignoreListenerPause", audioSource.ignoreListenerPause );
			writer.WriteProperty ( "velocityUpdateMode", audioSource.velocityUpdateMode );
			writer.WriteProperty ( "panStereo", audioSource.panStereo );
			writer.WriteProperty ( "spatialBlend", audioSource.spatialBlend );
			writer.WriteProperty ( "spatialize", audioSource.spatialize );
			writer.WriteProperty ( "spatializePostEffects", audioSource.spatializePostEffects );
			writer.WriteProperty ( "reverbZoneMix", audioSource.reverbZoneMix );
			writer.WriteProperty ( "bypassEffects", audioSource.bypassEffects );
			writer.WriteProperty ( "bypassListenerEffects", audioSource.bypassListenerEffects );
			writer.WriteProperty ( "bypassReverbZones", audioSource.bypassReverbZones );
			writer.WriteProperty ( "dopplerLevel", audioSource.dopplerLevel );
			writer.WriteProperty ( "spread", audioSource.spread );
			writer.WriteProperty ( "priority", audioSource.priority );
			writer.WriteProperty ( "mute", audioSource.mute );
			writer.WriteProperty ( "minDistance", audioSource.minDistance );
			writer.WriteProperty ( "maxDistance", audioSource.maxDistance );
			writer.WriteProperty ( "rolloffMode", audioSource.rolloffMode );
			writer.WriteProperty ( "enabled", audioSource.enabled );
			writer.WriteProperty ( "tag", audioSource.tag );
			writer.WriteProperty ( "name", audioSource.name );
			writer.WriteProperty ( "hideFlags", audioSource.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioSource audioSource = SaveGameType.CreateComponent<UnityEngine.AudioSource> ();
			ReadInto ( audioSource, reader );
			return audioSource;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioSource audioSource = ( UnityEngine.AudioSource )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "volume":
						audioSource.volume = reader.ReadProperty<System.Single> ();
						break;
					case "pitch":
						audioSource.pitch = reader.ReadProperty<System.Single> ();
						break;
					case "time":
						audioSource.time = reader.ReadProperty<System.Single> ();
						break;
					case "timeSamples":
						audioSource.timeSamples = reader.ReadProperty<System.Int32> ();
						break;
					case "clip":
						if ( audioSource.clip == null )
						{
							audioSource.clip = reader.ReadProperty<UnityEngine.AudioClip> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.AudioClip> ( audioSource.clip );
						}
						break;
					case "outputAudioMixerGroup":
						if ( audioSource.outputAudioMixerGroup == null )
						{
							audioSource.outputAudioMixerGroup = reader.ReadProperty<UnityEngine.Audio.AudioMixerGroup> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Audio.AudioMixerGroup> ( audioSource.outputAudioMixerGroup );
						}
						break;
					case "loop":
						audioSource.loop = reader.ReadProperty<System.Boolean> ();
						break;
					case "ignoreListenerVolume":
						audioSource.ignoreListenerVolume = reader.ReadProperty<System.Boolean> ();
						break;
					case "playOnAwake":
						audioSource.playOnAwake = reader.ReadProperty<System.Boolean> ();
						break;
					case "ignoreListenerPause":
						audioSource.ignoreListenerPause = reader.ReadProperty<System.Boolean> ();
						break;
					case "velocityUpdateMode":
						audioSource.velocityUpdateMode = reader.ReadProperty<UnityEngine.AudioVelocityUpdateMode> ();
						break;
					case "panStereo":
						audioSource.panStereo = reader.ReadProperty<System.Single> ();
						break;
					case "spatialBlend":
						audioSource.spatialBlend = reader.ReadProperty<System.Single> ();
						break;
					case "spatialize":
						audioSource.spatialize = reader.ReadProperty<System.Boolean> ();
						break;
					case "spatializePostEffects":
						audioSource.spatializePostEffects = reader.ReadProperty<System.Boolean> ();
						break;
					case "reverbZoneMix":
						audioSource.reverbZoneMix = reader.ReadProperty<System.Single> ();
						break;
					case "bypassEffects":
						audioSource.bypassEffects = reader.ReadProperty<System.Boolean> ();
						break;
					case "bypassListenerEffects":
						audioSource.bypassListenerEffects = reader.ReadProperty<System.Boolean> ();
						break;
					case "bypassReverbZones":
						audioSource.bypassReverbZones = reader.ReadProperty<System.Boolean> ();
						break;
					case "dopplerLevel":
						audioSource.dopplerLevel = reader.ReadProperty<System.Single> ();
						break;
					case "spread":
						audioSource.spread = reader.ReadProperty<System.Single> ();
						break;
					case "priority":
						audioSource.priority = reader.ReadProperty<System.Int32> ();
						break;
					case "mute":
						audioSource.mute = reader.ReadProperty<System.Boolean> ();
						break;
					case "minDistance":
						audioSource.minDistance = reader.ReadProperty<System.Single> ();
						break;
					case "maxDistance":
						audioSource.maxDistance = reader.ReadProperty<System.Single> ();
						break;
					case "rolloffMode":
						audioSource.rolloffMode = reader.ReadProperty<UnityEngine.AudioRolloffMode> ();
						break;
					case "enabled":
						audioSource.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioSource.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioSource.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioSource.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}