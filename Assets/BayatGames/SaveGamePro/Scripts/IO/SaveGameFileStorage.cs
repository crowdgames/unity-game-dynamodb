using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BayatGames.SaveGamePro.IO
{

	/// <summary>
	/// Save Game File Storage API.
	/// Supports UWP, WSA, Standalone (Windows, Mac, Linux), and any other platform that supports file I/O.
	/// </summary>
	public class SaveGameFileStorage : SaveGameStorage
	{
		
		/// <summary>
		/// Gets a value indicating whether this storage API has file I/O.
		/// </summary>
		/// <value><c>true</c> if this instance has file I; otherwise, <c>false</c>.</value>
		public override bool HasFileIO
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets the read stream.
		/// </summary>
		/// <returns>The read stream.</returns>
		/// <param name="settings">Settings.</param>
		public override Stream GetReadStream ( SaveGameSettings settings )
		{
			string path = GetAbsolutePath ( settings.Identifier, settings.BasePath );
			if ( !File.Exists ( path ) )
			{
				return null;
			}
			return new FileStream ( path, FileMode.Open );
		}

		/// <summary>
		/// Gets the write stream.
		/// </summary>
		/// <returns>The write stream.</returns>
		/// <param name="settings">Settings.</param>
		public override Stream GetWriteStream ( SaveGameSettings settings )
		{
			string path = GetAbsolutePath ( settings.Identifier, settings.BasePath );
			string dirName = Path.GetDirectoryName ( path );
			if ( !Directory.Exists ( dirName ) )
			{
				Directory.CreateDirectory ( dirName );
			}
			return new FileStream ( path, FileMode.Create );
		}

		/// <summary>
		/// Clear the user data on this storage.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public override void Clear ( SaveGameSettings settings )
		{
			string path = GetAbsolutePath ( settings.Identifier, settings.BasePath );
			if ( File.Exists ( path ) )
			{
				Delete ( settings );
				return;
			}
			else if ( string.IsNullOrEmpty ( path ) || !Directory.Exists ( path ) )
			{
				path = settings.BasePath;
			}
			if ( !Directory.Exists ( path ) )
			{
				return;
			}
			DirectoryInfo info = new DirectoryInfo ( path );
			FileInfo [] files = info.GetFiles ();
			for ( int i = 0; i < files.Length; i++ )
			{
				files [ i ].Delete ();
			}
			DirectoryInfo [] directories = info.GetDirectories ();
			for ( int i = 0; i < directories.Length; i++ )
			{
				if ( directories [ i ].Name != "Unity" )
				{
					directories [ i ].Delete ( true );
				}
			}
		}

		/// <summary>
		/// Copy the specified identifier to identifier.
		/// </summary>
		/// <param name="fromIdentifier">From identifier.</param>
		/// <param name="toIdentifier">To identifier.</param>
		/// <param name="settings">Settings.</param>
		public override void Copy ( string fromIdentifier, string toIdentifier, SaveGameSettings settings )
		{
			string fromPath = GetAbsolutePath ( fromIdentifier, settings.BasePath );
			string toPath = GetAbsolutePath ( toIdentifier, settings.BasePath );
			if ( File.Exists ( fromPath ) && !Directory.Exists ( toPath ) )
			{
				File.Copy ( fromPath, toPath );
			}
			else if ( File.Exists ( fromPath ) && Directory.Exists ( toPath ) )
			{
				File.Copy ( fromPath, Path.Combine ( toPath, Path.GetFileName ( fromPath ) ) );
			}
			else if ( Directory.Exists ( fromPath ) && !File.Exists ( toPath ) )
			{
				Directory.CreateDirectory ( toPath );
				DirectoryInfo info = new DirectoryInfo ( fromPath );
				FileInfo [] files = info.GetFiles ();
				for ( int i = 0; i < files.Length; i++ )
				{
					string dest = Path.Combine ( toPath, files [ i ].Name );
					files [ i ].CopyTo ( dest, true );
				}
				DirectoryInfo [] directories = info.GetDirectories ();
				for ( int i = 0; i < directories.Length; i++ )
				{
					string dest = Path.Combine ( toPath, directories [ i ].Name );
					Copy ( directories [ i ].FullName, dest, settings );
				}
			}
		}

		/// <summary>
		/// Delete the specified identifier.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public override void Delete ( SaveGameSettings settings )
		{
			string path = GetAbsolutePath ( settings.Identifier, settings.BasePath );
			if ( File.Exists ( path ) )
			{
				File.Delete ( path );
			}
			else if ( Directory.Exists ( path ) )
			{
				Directory.Delete ( path, true );
			}
		}

		/// <summary>
		/// Checks whether the given storage exists or not.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public override bool Exists ( SaveGameSettings settings )
		{
			string path = GetAbsolutePath ( settings.Identifier, settings.BasePath );
			return File.Exists ( path ) || Directory.Exists ( path );
		}

		/// <summary>
		/// Gets the directories.
		/// </summary>
		/// <returns>The directories.</returns>
		/// <param name="settings">Settings.</param>
		public override DirectoryInfo[] GetDirectories ( SaveGameSettings settings )
		{
			string path = GetAbsolutePath ( settings.Identifier, settings.BasePath );
			DirectoryInfo [] directories = new DirectoryInfo[0];
			if ( Directory.Exists ( path ) )
			{
				DirectoryInfo info = new DirectoryInfo ( path );
				directories = info.GetDirectories ();
			}
			return directories;
		}

		/// <summary>
		/// Gets the files.
		/// </summary>
		/// <returns>The files.</returns>
		/// <param name="settings">Settings.</param>
		public override FileInfo[] GetFiles ( SaveGameSettings settings )
		{
			string path = GetAbsolutePath ( settings.Identifier, settings.BasePath );
			FileInfo [] files = new FileInfo[0];
			if ( Directory.Exists ( path ) )
			{
				DirectoryInfo info = new DirectoryInfo ( path );
				files = info.GetFiles ();
			}
			return files;
		}

		/// <summary>
		/// Move the specified identifier to identifier.
		/// </summary>
		/// <param name="fromIdentifier">From identifier.</param>
		/// <param name="toIdentifier">To identifier.</param>
		/// <param name="settings">Settings.</param>
		public override void Move ( string fromIdentifier, string toIdentifier, SaveGameSettings settings )
		{
			string fromPath = GetAbsolutePath ( fromIdentifier, settings.BasePath );
			string toPath = GetAbsolutePath ( toIdentifier, settings.BasePath );
			if ( File.Exists ( fromPath ) && !Directory.Exists ( toPath ) )
			{
				File.Move ( fromPath, toPath );
			}
			else if ( File.Exists ( fromPath ) && Directory.Exists ( toPath ) )
			{
				File.Move ( fromPath, Path.Combine ( toPath, Path.GetFileName ( fromPath ) ) );
			}
			else if ( Directory.Exists ( fromPath ) && !File.Exists ( toPath ) )
			{
				Directory.Move ( fromPath, toPath );
			}
		}

		/// <summary>
		/// Gets the absolute path.
		/// </summary>
		/// <returns>The absolute path.</returns>
		/// <param name="path">Path.</param>
		/// <param name="basePath">Base path.</param>
		public static string GetAbsolutePath ( string path, string basePath )
		{
			if ( string.IsNullOrEmpty ( path ) )
			{
				return basePath;
			}
			if ( string.IsNullOrEmpty ( basePath ) )
			{
				return path;
			}
			if ( Path.IsPathRooted ( path ) )
			{
				return path;
			}
			else
			{
				return Path.Combine ( basePath, path );
			}
		}
		
	}

}