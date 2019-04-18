using System;
using System.IO;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Serialization
{

	/// <summary>
	/// Save Game Writer Interface.
	/// An Interface for Data Writers.
	/// </summary>
	public interface ISaveGameWriter
	{
		
		/// <summary>
		/// Write the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		void Write ( object value );

		/// <summary>
		/// Write the property.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="value">Value.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		void WriteProperty<T> ( string identifier, T value );

		/// <summary>
		/// Write the property.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="value">Value.</param>
		void WriteProperty ( string identifier, object value );

		/// <summary>
		/// Writes the savable members.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="type">Type.</param>
		void WriteSavableMembers ( object obj, Type type );

	}

}