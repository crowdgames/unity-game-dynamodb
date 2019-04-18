using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioListener serialization implementation.
	/// </summary>
	public class SaveGameType_AudioListener : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioListener );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioListener audioListener = ( UnityEngine.AudioListener )value;
			writer.WriteProperty ( "velocityUpdateMode", audioListener.velocityUpdateMode );
			writer.WriteProperty ( "enabled", audioListener.enabled );
			writer.WriteProperty ( "tag", audioListener.tag );
			writer.WriteProperty ( "name", audioListener.name );
			writer.WriteProperty ( "hideFlags", audioListener.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioListener audioListener = SaveGameType.CreateComponent<UnityEngine.AudioListener> ();
			ReadInto ( audioListener, reader );
			return audioListener;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioListener audioListener = ( UnityEngine.AudioListener )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "velocityUpdateMode":
						audioListener.velocityUpdateMode = reader.ReadProperty<UnityEngine.AudioVelocityUpdateMode> ();
						break;
					case "enabled":
						audioListener.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						audioListener.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						audioListener.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioListener.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}