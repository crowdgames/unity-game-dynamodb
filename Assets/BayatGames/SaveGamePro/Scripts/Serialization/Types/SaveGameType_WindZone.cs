using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type WindZone serialization implementation.
	/// </summary>
	public class SaveGameType_WindZone : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.WindZone );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.WindZone windZone = ( UnityEngine.WindZone )value;
			writer.WriteProperty ( "mode", windZone.mode );
			writer.WriteProperty ( "radius", windZone.radius );
			writer.WriteProperty ( "windMain", windZone.windMain );
			writer.WriteProperty ( "windTurbulence", windZone.windTurbulence );
			writer.WriteProperty ( "windPulseMagnitude", windZone.windPulseMagnitude );
			writer.WriteProperty ( "windPulseFrequency", windZone.windPulseFrequency );
			writer.WriteProperty ( "tag", windZone.tag );
			writer.WriteProperty ( "name", windZone.name );
			writer.WriteProperty ( "hideFlags", windZone.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.WindZone windZone = SaveGameType.CreateComponent<UnityEngine.WindZone> ();
			ReadInto ( windZone, reader );
			return windZone;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.WindZone windZone = ( UnityEngine.WindZone )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "mode":
						windZone.mode = reader.ReadProperty<UnityEngine.WindZoneMode> ();
						break;
					case "radius":
						windZone.radius = reader.ReadProperty<System.Single> ();
						break;
					case "windMain":
						windZone.windMain = reader.ReadProperty<System.Single> ();
						break;
					case "windTurbulence":
						windZone.windTurbulence = reader.ReadProperty<System.Single> ();
						break;
					case "windPulseMagnitude":
						windZone.windPulseMagnitude = reader.ReadProperty<System.Single> ();
						break;
					case "windPulseFrequency":
						windZone.windPulseFrequency = reader.ReadProperty<System.Single> ();
						break;
					case "tag":
						windZone.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						windZone.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						windZone.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}