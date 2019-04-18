using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace BayatGames.SaveGamePro.IO
{

	/// <summary>
	/// Save Game PlayerPrefs Storage API.
	/// Supports ALL platforms.
	/// </summary>
	public class SaveGamePlayerPrefsStorage : SaveGameStorage
	{

		/// <summary>
		/// The temporary memory stream for storing the data.
		/// </summary>
		protected MemoryStream m_TempStream;

		/// <summary>
		/// Gets a value indicating whether this storage API has file I/O.
		/// </summary>
		/// <value>true</value>
		/// <c>false</c>
		public override bool HasFileIO
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Gets the read stream.
		/// </summary>
		/// <returns>The read stream.</returns>
		/// <param name="settings">Settings.</param>
		public override Stream GetReadStream ( SaveGameSettings settings )
		{
			return new MemoryStream ( Convert.FromBase64String ( PlayerPrefs.GetString ( settings.Identifier ) ) );
		}

		/// <summary>
		/// Gets the write stream.
		/// </summary>
		/// <returns>The write stream.</returns>
		/// <param name="settings">Settings.</param>
		public override Stream GetWriteStream ( SaveGameSettings settings )
		{
			m_TempStream = new MemoryStream ();
			return m_TempStream;
		}

		/// <summary>
		/// Called after Save.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public override void OnSaved ( SaveGameSettings settings )
		{
			PlayerPrefs.SetString ( settings.Identifier, Convert.ToBase64String ( m_TempStream.ToArray () ) );
			PlayerPrefs.Save ();
			m_TempStream.Dispose ();
		}

		/// <summary>
		/// Clear the user data on this storage.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public override void Clear ( SaveGameSettings settings )
		{
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.Save ();
		}

		/// <summary>
		/// Copy the specified identifier to identifier.
		/// </summary>
		/// <param name="fromIdentifier">From identifier.</param>
		/// <param name="toIdentifier">To identifier.</param>
		/// <param name="settings">Settings.</param>
		public override void Copy ( string fromIdentifier, string toIdentifier, SaveGameSettings settings )
		{
			PlayerPrefs.SetString ( toIdentifier, PlayerPrefs.GetString ( fromIdentifier ) );
			PlayerPrefs.Save ();
		}

		/// <summary>
		/// Delete the specified identifier.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public override void Delete ( SaveGameSettings settings )
		{
			PlayerPrefs.DeleteKey ( settings.Identifier );
			PlayerPrefs.Save ();
		}

		/// <summary>
		/// Checks whether the given storage exists or not.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public override bool Exists ( SaveGameSettings settings )
		{
			return PlayerPrefs.HasKey ( settings.Identifier );
		}

		/// <summary>
		/// Gets the files.
		/// </summary>
		/// <returns>The files.</returns>
		/// <param name="settings">Settings.</param>
		public override FileInfo[] GetFiles ( SaveGameSettings settings )
		{
			return new FileInfo[0];
		}

		/// <summary>
		/// Gets the directories.
		/// </summary>
		/// <returns>The directories.</returns>
		/// <param name="settings">Settings.</param>
		public override DirectoryInfo[] GetDirectories ( SaveGameSettings settings )
		{
			return new DirectoryInfo[0];
		}

		/// <summary>
		/// Move the specified identifier to identifier.
		/// </summary>
		/// <param name="fromIdentifier">From identifier.</param>
		/// <param name="toIdentifier">To identifier.</param>
		/// <param name="settings">Settings.</param>
		public override void Move ( string fromIdentifier, string toIdentifier, SaveGameSettings settings )
		{
			Copy ( fromIdentifier, toIdentifier, settings );
			settings.Identifier = fromIdentifier;
			Delete ( settings );
		}

	}

}