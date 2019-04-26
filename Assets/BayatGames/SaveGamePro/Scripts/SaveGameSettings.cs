using System;
using System.IO;
using System.Security.Cryptography;
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

        // General Settings
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

        // Encryption Settings
        private static bool m_DefaultEncrypt = true;
        private static string m_DefaultEncryptionPassword = "SGPEP";
        private static int m_DefaultEncryptionIterations = 2;
        private static int m_DefaultEncryptionKeySize = 256;
        private static string m_DefaultEncryptionHash = "SHA1";
        private static string m_DefaultEncryptionSalt = "aselrias38490a32";
        private static string m_DefaultEncryptionVector = "8947az34awl34kjq";

        [SerializeField]
        private bool m_Encrypt;
        [SerializeField]
        private string m_EncryptionPassword;
        [SerializeField]
        private int m_EncryptionIterations;
        [SerializeField]
        private int m_EncryptionKeySize;
        [SerializeField]
        private string m_EncryptionHash;
        [SerializeField]
        private string m_EncryptionSalt;
        [SerializeField]
        private string m_EncryptionVector;

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
                if (!SaveGame.IsFileIOSupported)
                {
                    m_DefaultBasePath = string.Empty;
                }
                else if (string.IsNullOrEmpty(m_DefaultBasePath))
                {
                    m_DefaultBasePath = SaveGame.PersistentDataPath.Replace('\\', '/');
                }
                return m_DefaultBasePath;
            }
            set
            {
                if (!File.Exists(value))
                {
                    m_DefaultBasePath = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the default encryption.
        /// </summary>
        /// <value>The default encryption.</value>
        public static bool DefaultEncrypt
        {
            get
            {
                return m_DefaultEncrypt;
            }
            set
            {
                m_DefaultEncrypt = value;
            }
        }

        /// <summary>
        /// Gets or sets the default encryption password.
        /// </summary>
        /// <value>The default encryption password.</value>
        public static string DefaultEncryptionPassword
        {
            get
            {
                if (string.IsNullOrEmpty(m_DefaultEncryptionPassword))
                {
                    m_DefaultEncryptionPassword = "SGPEP";
                }
                return m_DefaultEncryptionPassword;
            }
            set
            {
                m_DefaultEncryptionPassword = value;
            }
        }

        /// <summary>
        /// Gets or sets the default encryption iterations.
        /// </summary>
        /// <value>The default encryption iterations.</value>
        public static int DefaultEncryptionIterations
        {
            get
            {
                return m_DefaultEncryptionIterations;
            }
            set
            {
                m_DefaultEncryptionIterations = value;
            }
        }

        /// <summary>
        /// Gets or sets the default encryption key size.
        /// </summary>
        /// <value>The default encryption key size.</value>
        public static int DefaultEncryptionKeySize
        {
            get
            {
                return m_DefaultEncryptionKeySize;
            }
            set
            {
                m_DefaultEncryptionKeySize = value;
            }
        }

        /// <summary>
        /// Gets or sets the default encryption hash.
        /// </summary>
        /// <value>The default encryption hash.</value>
        public static string DefaultEncryptionHash
        {
            get
            {
                if (string.IsNullOrEmpty(m_DefaultEncryptionHash))
                {
                    m_DefaultEncryptionHash = "SHA1";
                }
                return m_DefaultEncryptionHash;
            }
            set
            {
                m_DefaultEncryptionHash = value;
            }
        }

        /// <summary>
        /// Gets or sets the default encryption salt.
        /// </summary>
        /// <value>The default encryption salt.</value>
        public static string DefaultEncryptionSalt
        {
            get
            {
                if (string.IsNullOrEmpty(m_DefaultEncryptionSalt))
                {
                    m_DefaultEncryptionSalt = "aselrias38490a32";
                }
                return m_DefaultEncryptionSalt;
            }
            set
            {
                m_DefaultEncryptionSalt = value;
            }
        }

        /// <summary>
        /// Gets or sets the default encryption vector.
        /// </summary>
        /// <value>The default encryption vector.</value>
        public static string DefaultEncryptionVector
        {
            get
            {
                if (string.IsNullOrEmpty(m_DefaultEncryptionVector))
                {
                    m_DefaultEncryptionVector = "8947az34awl34kjq";
                }
                return m_DefaultEncryptionVector;
            }
            set
            {
                m_DefaultEncryptionVector = value;
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
                if (m_DefaultFormatter == null)
                {
                    m_DefaultFormatter = new BinaryFormatter(SaveGame.DefaultSettings);
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
                if (!SaveGameStorage.IsAppropriate(m_DefaultStorage))
                {
                    m_DefaultStorage = SaveGameStorage.GetAppropriate();
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
                if (m_DefaultEncoding == null)
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
                m_Identifier = value.Replace('\\', '/');
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
                if (!SaveGame.IsFileIOSupported)
                {
                    m_BasePath = string.Empty;
                }
                else if (string.IsNullOrEmpty(m_BasePath))
                {
                    m_BasePath = DefaultBasePath.Replace('\\', '/');
                }
                return m_BasePath;
            }
            set
            {
                if (!File.Exists(value))
                {
                    m_BasePath = value.Replace('\\', '/');
                }
            }
        }

        /// <summary>
        /// Gets or sets the encrypt.
        /// </summary>
        /// <value>The encrypt.</value>
        public bool Encrypt
        {
            get
            {
                return m_Encrypt;
            }
            set
            {
                m_Encrypt = value;
            }
        }

        /// <summary>
        /// Gets or sets the encryption password.
        /// </summary>
        /// <value>The encryption password.</value>
        public string EncryptionPassword
        {
            get
            {
                if (string.IsNullOrEmpty(m_EncryptionPassword))
                {
                    m_EncryptionPassword = DefaultEncryptionPassword;
                }
                return m_EncryptionPassword;
            }
            set
            {
                m_EncryptionPassword = value;
            }
        }

        /// <summary>
        /// Gets or sets the encryption iterations.
        /// </summary>
        /// <value>The encryption iterations.</value>
        public int EncryptionIterations
        {
            get
            {
                if (m_EncryptionIterations <= 0)
                {
                    m_EncryptionIterations = DefaultEncryptionIterations;
                }
                return m_EncryptionIterations;
            }
            set
            {
                m_EncryptionIterations = value;
            }
        }

        /// <summary>
        /// Gets or sets the encryption key size.
        /// </summary>
        /// <value>The encryption key size.</value>
        public int EncryptionKeySize
        {
            get
            {
                if (m_EncryptionKeySize <= 0)
                {
                    m_EncryptionKeySize = DefaultEncryptionKeySize;
                }
                return m_EncryptionKeySize;
            }
            set
            {
                m_EncryptionKeySize = value;
            }
        }

        /// <summary>
        /// Gets or sets the encryption hash.
        /// </summary>
        /// <value>The encryption hash.</value>
        public string EncryptionHash
        {
            get
            {
                if (string.IsNullOrEmpty(m_EncryptionHash))
                {
                    m_EncryptionHash = DefaultEncryptionHash;
                }
                return m_EncryptionHash;
            }
            set
            {
                m_EncryptionHash = value;
            }
        }

        /// <summary>
        /// Gets or sets the encryption salt.
        /// </summary>
        /// <value>The encryption salt.</value>
        public string EncryptionSalt
        {
            get
            {
                if (string.IsNullOrEmpty(m_EncryptionSalt))
                {
                    m_EncryptionSalt = DefaultEncryptionSalt;
                }
                return m_EncryptionSalt;
            }
            set
            {
                m_EncryptionSalt = value;
            }
        }

        /// <summary>
        /// Gets or sets the encryption vector.
        /// </summary>
        /// <value>The encryption vector.</value>
        public string EncryptionVector
        {
            get
            {
                if (string.IsNullOrEmpty(m_EncryptionVector))
                {
                    m_EncryptionVector = DefaultEncryptionVector;
                }
                return m_EncryptionVector;
            }
            set
            {
                m_EncryptionVector = value;
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
                if (m_Formatter == null)
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
                if (!SaveGameStorage.IsAppropriate(m_Storage))
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
                if (m_Encoding == null)
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

        /// <summary>
        /// Creates a new encryptor using the AesManaged class and the specified settings.
        /// </summary>
        public ICryptoTransform Encryptor
        {
            get
            {
                AesManaged aes = new AesManaged();
                byte[] vectorBytes = Encoding.ASCII.GetBytes(EncryptionVector);
                byte[] saltBytes = Encoding.ASCII.GetBytes(EncryptionSalt);
                PasswordDeriveBytes passwordBytes = new PasswordDeriveBytes(EncryptionPassword, saltBytes, EncryptionHash, EncryptionIterations);
                byte[] keyBytes = passwordBytes.GetBytes(EncryptionKeySize / 8);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                return aes.CreateEncryptor(keyBytes, vectorBytes);
            }
        }

        /// <summary>
        /// Creates a new decryptor using the AesManaged class and the specified settings.
        /// </summary>
        public ICryptoTransform Decryptor
        {
            get
            {
                AesManaged aes = new AesManaged();
                byte[] vectorBytes = Encoding.ASCII.GetBytes(EncryptionVector);
                byte[] saltBytes = Encoding.ASCII.GetBytes(EncryptionSalt);
                PasswordDeriveBytes passwordBytes = new PasswordDeriveBytes(EncryptionPassword, saltBytes, EncryptionHash, EncryptionIterations);
                byte[] keyBytes = passwordBytes.GetBytes(EncryptionKeySize / 8);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                return aes.CreateDecryptor(keyBytes, vectorBytes);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        public SaveGameSettings(string identifier) : this(identifier, DefaultBasePath, DefaultFormatter, DefaultStorage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="basePath">Base path.</param>
        public SaveGameSettings(string identifier, string basePath) : this(identifier, basePath, DefaultFormatter, DefaultStorage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="formatter">Formatter.</param>
        public SaveGameSettings(string identifier, ISaveGameFormatter formatter) : this(identifier, DefaultBasePath, formatter, DefaultStorage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="storage">Storage.</param>
        public SaveGameSettings(string identifier, SaveGameStorage storage) : this(identifier, DefaultBasePath, DefaultFormatter, storage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.SaveGameSettings"/> struct.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="basePath">Base path.</param>
        /// <param name="formatter">Formatter.</param>
        /// <param name="storage">Storage.</param>
        public SaveGameSettings(string identifier, string basePath, ISaveGameFormatter formatter, SaveGameStorage storage)
        {

            // General
            m_Identifier = identifier.Replace('\\', '/');
            m_BasePath = basePath.Replace('\\', '/');
            m_Formatter = formatter;
            m_Storage = storage;
            m_Encoding = DefaultEncoding;

            // Encryption
            m_Encrypt = DefaultEncrypt;
            m_EncryptionPassword = DefaultEncryptionPassword;
            m_EncryptionIterations = DefaultEncryptionIterations;
            m_EncryptionKeySize = DefaultEncryptionKeySize;
            m_EncryptionHash = DefaultEncryptionHash;
            m_EncryptionSalt = DefaultEncryptionSalt;
            m_EncryptionVector = DefaultEncryptionVector;
        }

        #endregion

    }

}