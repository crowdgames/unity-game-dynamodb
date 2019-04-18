using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BayatGames.SaveGamePro.Serialization;

namespace BayatGames.SaveGamePro
{

	/// <summary>
	/// Identifies the class as Savable for serialization and provides custom serialization and deserialization for the class.
	/// </summary>
	public interface ISavable
	{

		/// <summary>
		/// Called when Writing.
		/// </summary>
		/// <param name="writer">Writer.</param>
		void OnWrite ( ISaveGameWriter writer );

		/// <summary>
		/// Called when Reading.
		/// </summary>
		/// <param name="reader">Reader.</param>
		void OnRead ( ISaveGameReader reader );

	}

}