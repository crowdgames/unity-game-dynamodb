using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type LensFlare serialization implementation.
	/// </summary>
	public class SaveGameType_LensFlare : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.LensFlare );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.LensFlare lensFlare = ( UnityEngine.LensFlare )value;
			writer.WriteProperty ( "flare", lensFlare.flare );
			writer.WriteProperty ( "brightness", lensFlare.brightness );
			writer.WriteProperty ( "fadeSpeed", lensFlare.fadeSpeed );
			writer.WriteProperty ( "color", lensFlare.color );
			writer.WriteProperty ( "enabled", lensFlare.enabled );
			writer.WriteProperty ( "tag", lensFlare.tag );
			writer.WriteProperty ( "name", lensFlare.name );
			writer.WriteProperty ( "hideFlags", lensFlare.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.LensFlare lensFlare = SaveGameType.CreateComponent<UnityEngine.LensFlare> ();
			ReadInto ( lensFlare, reader );
			return lensFlare;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.LensFlare lensFlare = ( UnityEngine.LensFlare )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "flare":
						if ( lensFlare.flare == null )
						{
							lensFlare.flare = reader.ReadProperty<UnityEngine.Flare> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Flare> ( lensFlare.flare );
						}
						break;
					case "brightness":
						lensFlare.brightness = reader.ReadProperty<System.Single> ();
						break;
					case "fadeSpeed":
						lensFlare.fadeSpeed = reader.ReadProperty<System.Single> ();
						break;
					case "color":
						lensFlare.color = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "enabled":
						lensFlare.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						lensFlare.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						lensFlare.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						lensFlare.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}