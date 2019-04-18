using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioMixerGroup serialization implementation.
	/// </summary>
	public class SaveGameType_AudioMixerGroup : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Audio.AudioMixerGroup );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Audio.AudioMixerGroup audioMixerGroup = ( UnityEngine.Audio.AudioMixerGroup )value;
			writer.WriteProperty ( "name", audioMixerGroup.name );
			writer.WriteProperty ( "hideFlags", audioMixerGroup.hideFlags );
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
			UnityEngine.Audio.AudioMixerGroup audioMixerGroup = ( UnityEngine.Audio.AudioMixerGroup )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "name":
						audioMixerGroup.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioMixerGroup.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}