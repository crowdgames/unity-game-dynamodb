using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Examples
{

	/// <summary>
	/// Save custom data example.
	/// </summary>
	public class SaveCustomData : MonoBehaviour
	{

		/// <summary>
		/// The custom data.
		/// </summary>
		[System.Serializable]
		public class CustomData
		{
	
			public string playerName = "Hello World";
			public int score = 12;
			
			/// <summary>
			/// Sample non-saved field, this field will not saved, because marked as NonSavable.
			/// </summary>
			[NonSavable]
			public bool test;
			
		}

		/// <summary>
		/// The identifier.
		/// </summary>
		public string identifier = "customData.txt";
		
		/// <summary>
		/// The data.
		/// </summary>
		public CustomData data;

		/// <summary>
		/// Save the custom data.
		/// </summary>
		public void Save ()
		{
			SaveGame.Save ( identifier, data );
			Debug.Log ( "Data Saved" );
		}

		/// <summary>
		/// Load the custom data.
		/// </summary>
		public void Load ()
		{
			data = SaveGame.Load<CustomData> ( identifier );
			Debug.Log ( "Data Loaded" );
			Debug.Log ( data.playerName );
			Debug.Log ( data.score );
		}
		
	}

}