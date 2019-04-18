using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioReverbZone serialization implementation.
	/// </summary>
	public class SaveGameType_AudioReverbZone : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioReverbZone );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioReverbZone audioReverbZone = ( UnityEngine.AudioReverbZone )value;
			writer.WriteProperty ( "minDistance", audioReverbZone.minDistance );
			writer.WriteProperty ( "maxDistance", audioReverbZone.maxDistance );
			writer.WriteProperty ( "reverbPreset", audioReverbZone.reverbPreset );
			writer.WriteProperty ( "room", audioReverbZone.room );
			writer.WriteProperty ( "roomHF", audioReverbZone.roomHF );
			writer.WriteProperty ( "roomLF", audioReverbZone.roomLF );
			writer.WriteProperty ( "decayTime", audioReverbZone.decayTime );
			writer.WriteProperty ( "decayHFRatio", audioReverbZone.decayHFRatio );
			writer.WriteProperty ( "reflections", audioReverbZone.reflections );
			writer.WriteProperty ( "reflectionsDelay", audioReverbZone.reflectionsDelay );
			writer.WriteProperty ( "reverb", audioReverbZone.reverb );
			writer.WriteProperty ( "reverbDelay", audioReverbZone.reverbDelay );
			writer.WriteProperty ( "HFReference", audioReverbZone.HFReference );
			writer.WriteProperty ( "LFReference", audioReverbZone.LFReference );
			writer.WriteProperty ( "diffusion", audioReverbZone.diffusion );
			writer.WriteProperty ( "density", audioReverbZone.density );
			writer.WriteProperty ( "enabled", audioReverbZone.enabled );
			writer.WriteProperty ( "tag", audioReverbZone.tag );
			writer.WriteProperty ( "name", audioReverbZone.name );
			writer.WriteProperty ( "hideFlags", audioReverbZone.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioReverbZone audioReverbZone = SaveGameType.CreateComponent<UnityEngine.AudioReverbZone> ();
			ReadInto ( audioReverbZone, reader );
			return audioReverbZone;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioReverbZone audioReverbZone = ( UnityEngine.AudioReverbZone )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "minDistance":
						audioReverbZone.minDistance = reader.ReadProperty<System.Single> ();
						break;
					case "maxDistance":
						audioReverbZone.maxDistance = reader.ReadProperty<System.Single> ();
						break;
					case "reverbPreset":
						audioReverbZone.reverbPreset = reader.ReadProperty<UnityEngine.AudioReverbPreset> ();
						break;
					case "room":
						audioReverbZone.room = reader.ReadProperty<System.Int32> ();
						break;
					case "roomHF":
						audioReverbZone.roomHF = reader.ReadProperty<System.Int32> ();
						break;
					case "roomLF":
						audioReverbZone.roomLF = reader.ReadProperty<System.Int32> ();
						break;
					case "decayTime":
						audioReverbZone.decayTime = reader.ReadProperty<System.Single> ();
						break;
					case "decayHFRatio":
						audioReverbZone.decayHFRatio = reader.ReadProperty<System.Single> ();
						break;
					case "reflections":
						audioReverbZone.reflections = reader.ReadProperty<System.Int32> ();
						break;
					case "reflectionsDelay":
						audioReverbZone.reflectionsDelay = reader.ReadProperty<System.Single> ();
						break;
					case "reverb":
						audioReverbZone.reverb = reader.ReadProperty<System.Int32> ();
						break;
					case "reverbDelay":
						audioReverbZone.reverbDelay = reader.ReadProperty<System.Single> ();
						break;
					case "HFReference":
						audioReverbZone.HFReference = reader.ReadProperty<System.Single> ();
						break;
					case "LFReference":
						audioReverbZone.LFReference = reader.ReadProperty<System.Single> ();
						break;
					case "diffusion":
						audioReverbZone.diffusion = reader.ReadProperty<System.Single> ();
						break;
					case "density":
						audioReverbZone.density = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						audioReverbZone.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioReverbZone.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioReverbZone.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioReverbZone.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}