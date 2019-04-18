using System;
using System.IO;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Serialization
{

	/// <summary>
	/// Save Game Formatter Interface.
	/// An Interface for Formatters.
	/// </summary>
	public interface ISaveGameFormatter
	{

		/// <summary>
		/// Serialize the specified value to the output stream.
		/// </summary>
		/// <param name="output">Output.</param>
		/// <param name="value">Value.</param>
		/// <param name="settings">Settings.</param>
		void Serialize ( Stream output, object value, SaveGameSettings settings );

		/// <summary>
		/// Deserialize the specified type from the input stream.
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="type">Type.</param>
		/// <param name="settings">Settings.</param>
		object Deserialize ( Stream input, Type type, SaveGameSettings settings );

		/// <summary>
		/// Deserialize the specified type from the input stream to the given value.
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="value">Value.</param>
		/// <param name="settings">Settings.</param>
		void DeserializeInto ( Stream input, object value, SaveGameSettings settings );

		/// <summary>
		/// Determines whether this formatter supports the specified type.
		/// </summary>
		/// <returns><c>true</c> if this formatter supports the specified type; otherwise, <c>false</c>.</returns>
		/// <param name="type">Type.</param>
		bool IsTypeSupported ( Type type );
		
	}

}