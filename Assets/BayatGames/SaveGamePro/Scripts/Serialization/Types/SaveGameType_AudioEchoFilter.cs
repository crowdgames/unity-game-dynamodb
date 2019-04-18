using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioEchoFilter serialization implementation.
	/// </summary>
	public class SaveGameType_AudioEchoFilter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioEchoFilter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioEchoFilter audioEchoFilter = ( UnityEngine.AudioEchoFilter )value;
			writer.WriteProperty ( "delay", audioEchoFilter.delay );
			writer.WriteProperty ( "decayRatio", audioEchoFilter.decayRatio );
			writer.WriteProperty ( "dryMix", audioEchoFilter.dryMix );
			writer.WriteProperty ( "wetMix", audioEchoFilter.wetMix );
			writer.WriteProperty ( "enabled", audioEchoFilter.enabled );
			writer.WriteProperty ( "tag", audioEchoFilter.tag );
			writer.WriteProperty ( "name", audioEchoFilter.name );
			writer.WriteProperty ( "hideFlags", audioEchoFilter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioEchoFilter audioEchoFilter = SaveGameType.CreateComponent<UnityEngine.AudioEchoFilter> ();
			ReadInto ( audioEchoFilter, reader );
			return audioEchoFilter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioEchoFilter audioEchoFilter = ( UnityEngine.AudioEchoFilter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "delay":
						audioEchoFilter.delay = reader.ReadProperty<System.Single> ();
						break;
					case "decayRatio":
						audioEchoFilter.decayRatio = reader.ReadProperty<System.Single> ();
						break;
					case "dryMix":
						audioEchoFilter.dryMix = reader.ReadProperty<System.Single> ();
						break;
					case "wetMix":
						audioEchoFilter.wetMix = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						audioEchoFilter.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioEchoFilter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioEchoFilter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioEchoFilter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}