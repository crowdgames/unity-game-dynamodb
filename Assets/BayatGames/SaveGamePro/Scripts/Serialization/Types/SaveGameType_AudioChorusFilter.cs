using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioChorusFilter serialization implementation.
	/// </summary>
	public class SaveGameType_AudioChorusFilter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioChorusFilter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioChorusFilter audioChorusFilter = ( UnityEngine.AudioChorusFilter )value;
			writer.WriteProperty ( "dryMix", audioChorusFilter.dryMix );
			writer.WriteProperty ( "wetMix1", audioChorusFilter.wetMix1 );
			writer.WriteProperty ( "wetMix2", audioChorusFilter.wetMix2 );
			writer.WriteProperty ( "wetMix3", audioChorusFilter.wetMix3 );
			writer.WriteProperty ( "delay", audioChorusFilter.delay );
			writer.WriteProperty ( "rate", audioChorusFilter.rate );
			writer.WriteProperty ( "depth", audioChorusFilter.depth );
			writer.WriteProperty ( "enabled", audioChorusFilter.enabled );
			writer.WriteProperty ( "tag", audioChorusFilter.tag );
			writer.WriteProperty ( "name", audioChorusFilter.name );
			writer.WriteProperty ( "hideFlags", audioChorusFilter.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioChorusFilter audioChorusFilter = SaveGameType.CreateComponent<UnityEngine.AudioChorusFilter> ();
			ReadInto ( audioChorusFilter, reader );
			return audioChorusFilter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioChorusFilter audioChorusFilter = ( UnityEngine.AudioChorusFilter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "dryMix":
						audioChorusFilter.dryMix = reader.ReadProperty<System.Single> ();
						break;
					case "wetMix1":
						audioChorusFilter.wetMix1 = reader.ReadProperty<System.Single> ();
						break;
					case "wetMix2":
						audioChorusFilter.wetMix2 = reader.ReadProperty<System.Single> ();
						break;
					case "wetMix3":
						audioChorusFilter.wetMix3 = reader.ReadProperty<System.Single> ();
						break;
					case "delay":
						audioChorusFilter.delay = reader.ReadProperty<System.Single> ();
						break;
					case "rate":
						audioChorusFilter.rate = reader.ReadProperty<System.Single> ();
						break;
					case "depth":
						audioChorusFilter.depth = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						audioChorusFilter.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioChorusFilter.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioChorusFilter.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioChorusFilter.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}