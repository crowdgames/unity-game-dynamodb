using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BayatGames.SaveGamePro.IO
{

	/// <summary>
	/// Save Game Core Storage API.
	/// </summary>
	public abstract class SaveGameStorage
	{

		/// <summary>
		/// Gets a value indicating whether this storage API has file I/O.
		/// </summary>
		/// <value><c>true</c> if this instance has file I; otherwise, <c>false</c>.</value>
		public abstract bool HasFileIO { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.IO.SaveGameStorage"/> class.
		/// </summary>
		public SaveGameStorage ()
		{
		}

		/// <summary>
		/// Called before Save.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public virtual void OnSave ( SaveGameSettings settings )
		{
		}

		/// <summary>
		/// Called before Load.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public virtual void OnLoad ( SaveGameSettings settings )
		{
		}

		/// <summary>
		/// Called after Save.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public virtual void OnSaved ( SaveGameSettings settings )
		{
		}

		/// <summary>
		/// Called after Load.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public virtual void OnLoaded ( SaveGameSettings settings )
		{
		}

		/// <summary>
		/// Gets the write stream.
		/// </summary>
		/// <returns>The write stream.</returns>
		/// <param name="settings">Settings.</param>
		public abstract Stream GetWriteStream ( SaveGameSettings settings );

		/// <summary>
		/// Gets the read stream.
		/// </summary>
		/// <returns>The read stream.</returns>
		/// <param name="settings">Settings.</param>
		public abstract Stream GetReadStream ( SaveGameSettings settings );

		/// <summary>
		/// Clear the user data on this storage.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public abstract void Clear ( SaveGameSettings settings );

		/// <summary>
		/// Delete the specified identifier.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public abstract void Delete ( SaveGameSettings settings );

		/// <summary>
		/// Checks whether the given storage exists or not.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public abstract bool Exists ( SaveGameSettings settings );

		/// <summary>
		/// Gets the files.
		/// </summary>
		/// <returns>The files.</returns>
		/// <param name="settings">Settings.</param>
		public abstract FileInfo[] GetFiles ( SaveGameSettings settings );

		/// <summary>
		/// Gets the directories.
		/// </summary>
		/// <returns>The directories.</returns>
		/// <param name="settings">Settings.</param>
		public abstract DirectoryInfo[] GetDirectories ( SaveGameSettings settings );

		/// <summary>
		/// Move the specified identifier to identifier.
		/// </summary>
		/// <param name="fromIdentifier">From identifier.</param>
		/// <param name="toIdentifier">To identifier.</param>
		/// <param name="settings">Settings.</param>
		public abstract void Move ( string fromIdentifier, string toIdentifier, SaveGameSettings settings );

		/// <summary>
		/// Copy the specified identifier to identifier.
		/// </summary>
		/// <param name="fromIdentifier">From identifier.</param>
		/// <param name="toIdentifier">To identifier.</param>
		/// <param name="settings">Settings.</param>
		public abstract void Copy ( string fromIdentifier, string toIdentifier, SaveGameSettings settings );

		/// <summary>
		/// Gets the appropriate storage.
		/// </summary>
		/// <returns>The appropriate.</returns>
		public static SaveGameStorage GetAppropriate ()
		{
			if ( SaveGame.IsFileIOSupported )
			{
				return new SaveGameFileStorage ();
			}
			else
			{
				return new SaveGamePlayerPrefsStorage ();
			}
		}

		/// <summary>
		/// Determines if the specified storage is appropriate on this platform.
		/// </summary>
		/// <returns><c>true</c> if the specified storage is appropriate on this platform; otherwise, <c>false</c>.</returns>
		/// <param name="storage">Storage.</param>
		public static bool IsAppropriate ( SaveGameStorage storage )
		{
			if ( storage == null )
			{
				return false;
			}
			if ( SaveGame.IsFileIOSupported && storage.HasFileIO )
			{
				return true;
			}
			else if ( SaveGame.IsWindowsStore && storage.HasFileIO )
			{
				return true;
			}
			else if ( !storage.HasFileIO )
			{
				return true;
			}
			return false;
		}
		
	}

}