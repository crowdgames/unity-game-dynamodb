using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioReverbFilter serialization implementation.
	/// </summary>
	public class SaveGameType_AudioReverbFilter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioReverbFilter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioReverbFilter audioReverbFilter = ( UnityEngine.AudioReverbFilter )value;
			writer.WriteProperty ( "reverbPreset", audioReverbFilter.reverbPreset );
			writer.WriteProperty ( "dryLevel", audioReverbFilter.dryLevel );
			writer.WriteProperty ( "room", audioReverbFilter.room );
			writer.WriteProperty ( "roomHF", audioReverbFilter.roomHF );
			writer.WriteProperty ( "decayTime", audioReverbFilter.decayTime );
			writer.WriteProperty ( "decayHFRatio", audioReverbFilter.decayHFRatio );
			writer.WriteProperty ( "reflectionsLevel", audioReverbFilter.reflectionsLevel );
			writer.WriteProperty ( "reflectionsDelay", audioReverbFilter.reflectionsDelay );
			writer.WriteProperty ( "reverbLevel", audioReverbFilter.reverbLevel );
			writer.WriteProperty ( "reverbDelay", audioReverbFilter.reverbDelay );
			writer.WriteProperty ( "diffusion", audioReverbFilter.diffusion );
			writer.WriteProperty ( "density", audioReverbFilter.density );
			writer.WriteProperty ( "hfReference", audioReverbFilter.hfReference );
			writer.WriteProperty ( "roomLF", audioReverbFilter.roomLF );
			writer.WriteProperty ( "lfReference", audioReverbFilter.lfReference );
			writer.WriteProperty ( "enabled", audioReverbFilter.enabled );
			writer.WriteProperty ( "tag", audioReverbFilter.tag );
			writer.WriteProperty ( "name", audioReverbFilter.name );
			writer.WriteProperty ( "hideFlags", audioReverbFilter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioReverbFilter audioReverbFilter = SaveGameType.CreateComponent<UnityEngine.AudioReverbFilter> ();
			ReadInto ( audioReverbFilter, reader );
			return audioReverbFilter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioReverbFilter audioReverbFilter = ( UnityEngine.AudioReverbFilter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "reverbPreset":
						audioReverbFilter.reverbPreset = reader.ReadProperty<UnityEngine.AudioReverbPreset> ();
						break;
					case "dryLevel":
						audioReverbFilter.dryLevel = reader.ReadProperty<System.Single> ();
						break;
					case "room":
						audioReverbFilter.room = reader.ReadProperty<System.Single> ();
						break;
					case "roomHF":
						audioReverbFilter.roomHF = reader.ReadProperty<System.Single> ();
						break;
					case "decayTime":
						audioReverbFilter.decayTime = reader.ReadProperty<System.Single> ();
						break;
					case "decayHFRatio":
						audioReverbFilter.decayHFRatio = reader.ReadProperty<System.Single> ();
						break;
					case "reflectionsLevel":
						audioReverbFilter.reflectionsLevel = reader.ReadProperty<System.Single> ();
						break;
					case "reflectionsDelay":
						audioReverbFilter.reflectionsDelay = reader.ReadProperty<System.Single> ();
						break;
					case "reverbLevel":
						audioReverbFilter.reverbLevel = reader.ReadProperty<System.Single> ();
						break;
					case "reverbDelay":
						audioReverbFilter.reverbDelay = reader.ReadProperty<System.Single> ();
						break;
					case "diffusion":
						audioReverbFilter.diffusion = reader.ReadProperty<System.Single> ();
						break;
					case "density":
						audioReverbFilter.density = reader.ReadProperty<System.Single> ();
						break;
					case "hfReference":
						audioReverbFilter.hfReference = reader.ReadProperty<System.Single> ();
						break;
					case "roomLF":
						audioReverbFilter.roomLF = reader.ReadProperty<System.Single> ();
						break;
					case "lfReference":
						audioReverbFilter.lfReference = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						audioReverbFilter.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioReverbFilter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioReverbFilter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioReverbFilter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}