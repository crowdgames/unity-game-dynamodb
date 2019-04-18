using System;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Serialization.Formatters.Json
{

	/// <summary>
	/// Json writer.
	/// </summary>
	public abstract class JsonWriter : IDisposable, ISaveGameWriter
	{
		
		#region Fields

		/// <summary>
		/// The settings.
		/// </summary>
		protected SaveGameSettings m_Settings;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the settings.
		/// </summary>
		/// <value>The settings.</value>
		public virtual SaveGameSettings Settings
		{
			get
			{
				return m_Settings;
			}
			set
			{
				m_Settings = value;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonWriter"/> class.
		/// </summary>
		/// <param name="settings">Settings.</param>
		public JsonWriter ( SaveGameSettings settings )
		{
			m_Settings = settings;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Write the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public virtual void Write<T> ( T value )
		{
			Write ( ( object )value );
		}

		/// <summary>
		/// Write the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		public abstract void Write ( object value );

		/// <summary>
		/// Writes the property.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="value">Value.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public virtual void WriteProperty<T> ( string identifier, T value )
		{
			WriteProperty ( identifier, ( object )value );
		}

		/// <summary>
		/// Writes the property.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="value">Value.</param>
		public abstract void WriteProperty ( string identifier, object value );

		/// <summary>
		/// Writes the savable members.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="type">Type.</param>
		public abstract void WriteSavableMembers ( object obj, Type type );

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the
		/// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonWriter"/>. The <see cref="Dispose"/> method
		/// leaves the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonWriter"/> in an unusable state.
		/// After calling <see cref="Dispose"/>, you must release all references to the
		/// <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonWriter"/> so the garbage collector can reclaim
		/// the memory that the <see cref="BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonWriter"/> was occupying.</remarks>
		public abstract void Dispose ();

		#endregion
		
	}

}