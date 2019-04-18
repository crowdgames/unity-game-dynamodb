using System;
using System.IO;
using System.Text;
using UnityEngine;

using BayatGames.SaveGamePro.IO;
using BayatGames.SaveGamePro.Serialization;
using BayatGames.SaveGamePro.Serialization.Formatters.Binary;

namespace BayatGames.SaveGamePro
{

	/// <summary>
	/// Save Game Settings.
	/// Options for controlling the API and Storage API behaviour.
	/// </summary>
	[Serializable]
	public struct SaveGameSettings
	{

		#region Fields

		private static string m_DefaultBasePath;
		private static ISaveGameFormatter m_DefaultFormatter;
		private static SaveGameStorage m_DefaultStorage;
		private static Encoding m_DefaultEncoding;

		[SerializeField]
		private string m_Identifier;
		[SerializeField]
		private string m_BasePath;
		private ISaveGameFormatter m_Formatter;
		private SaveGameStorage m_Storage;
		private Encoding m_Encoding;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the default base path.
		/// </summary>
		/// <value>The default base path.</value>
		public static string DefaultBasePath
		{
			get
			{
				if ( !SaveGame.IsFileIOSupported )
				{
					m_DefaultBasePath = string.Empty;
				}
				else if ( string.IsNullOrEmpty ( m_DefaultBasePath ) )
				{
					m_DefaultBasePath = Application.persistentDataPath.Replace ( '\\', '/' );
				}
				return m_DefaultBasePath;
			}
			set
			{
				if ( !File.Exists ( value ) )
				{
					m_DefaultBasePath = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the default formatter.
		/// </summary>
		/// <value>The default formatter.</value>
		public static ISaveGameFormatter DefaultFormatter
		{
			get
			{
				if ( m_DefaultFormatter == null )
				{
					m_DefaultFormatter = new BinaryFormatter ( SaveGame.DefaultSettings );
				}
				return m_DefaultFormatter;
			}
			set
			{
				m_DefaultFormatter = value;
			}
		}

		/// <summary>
		/// Gets or sets the default storage.
		/// </summary>
		/// <value>The default storage.</value>
		public static SaveGameStorage DefaultStorage
		{
			get
			{
				if ( !SaveGameStorage.IsAppropriate ( m_DefaultStorage ) )
				{
					m_DefaultStorage = SaveGameStorage.GetAppropriate ();
				}
				return m_DefaultStorage;
			}
			set
			{
				m_DefaultStorage = value;
			}
		}

		/// <summary>
		/// Gets or sets the default encoding.
		/// </summary>
		/// <value>The default encoding.</value>
		public static Encoding DefaultEncoding
		{
			get
			{
				if ( m_DefaultEncoding == null )
				{
					m_DefaultEncoding = Encoding.UTF8;
				}
				return m_DefaultEncoding;
			}
			set
			{
				m_DefaultEncoding = value;
			}
		}

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public string Identifier
		{
			get
			{
				return m_Identifier;
			}
			set
			{
				m_Identifier = value.Replace ( '\\', '/' );
			}
		}

		/// <summary>
		/// Gets or sets the base path.
		/// </summary>
		/// <value>The base path.</value>
		public string BasePath
		{
			get
			{
				if ( !SaveGame.IsFileIOSupported )
				{
					m_BasePath = string.Empty;
				}
				else if ( string.IsNullOrEmpty ( m_BasePath ) )
				{
					m_BasePath = DefaultBasePath.Replace ( '\\', '/' );
				}
				return m_BasePath;
			}
			set
			{
				if ( !File.Exists ( value ) )
				{
					m_BasePath = value.Replace ( '\\', '/' );
				}
			}
		}

		/// <summary>
		/// Gets or sets the formatter.
		/// </summary>
		/// <value>The formatter.</value>
		public ISaveGameFormatter Formatter
		{
			get
			{
				if ( m_Formatter == null )
				{
					m_Formatter = DefaultFormatter;
				}
				return m_Formatter;
			}
			set
			{
				m_Formatter = value;
			}
		}

		/// <summary>
		/// Gets or sets the storage.
		/// </summary>
		/// <value>The storage.</value>
		public SaveGameStorage Storage
		{
			get
			{
				if ( !SaveGameStorage.IsAppropriate ( m_Storage ) )
				{
					m_Storage = DefaultStorage;
				}
				return m_Storage;
			}
			set
			{
				m_Storage = value;
			}
		}

		/// <summary>
		/// Gets or sets the encoding.
		/// </summary>
		/// <value>The encoding.</value>
		public Encoding Encoding
		{
			get
			{
				if ( m_Encoding == null )
				{
					m_Encoding = DefaultEncoding;
				}
				return m_Encoding;
			}
			set
			{
				m_Encoding = value;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		public SaveGameSettings ( string identifier ) : this ( identifier, DefaultBasePath, DefaultFormatter, DefaultStorage )
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="basePath">Base path.</param>
		public SaveGameSettings ( string identifier, string basePath ) : this ( identifier, basePath, DefaultFormatter, DefaultStorage )
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="formatter">Formatter.</param>
		public SaveGameSettings ( string identifier, ISaveGameFormatter formatter ) : this ( identifier, DefaultBasePath, formatter, DefaultStorage )
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="storage">Storage.</param>
		public SaveGameSettings ( string identifier, SaveGameStorage storage ) : this ( identifier, DefaultBasePath, DefaultFormatter, storage )
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="basePath">Base path.</param>
		/// <param name="formatter">Formatter.</param>
		/// <param name="storage">Storage.</param>
		public SaveGameSettings ( string identifier, string basePath, ISaveGameFormatter formatter, SaveGameStorage storage )
		{
			m_Identifier = identifier.Replace ( '\\', '/' );
			m_BasePath = basePath.Replace ( '\\', '/' );
			m_Formatter = formatter;
			m_Storage = storage;
			m_Encoding = Encoding.UTF8;
		}

		#endregion
	
	}

}