using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BayatGames.SaveGamePro.Examples
{

	/// <summary>
	/// Save simple data example.
	/// </summary>
	public class SaveSimpleData : MonoBehaviour
	{
		
		/// <summary>
		/// The text identifier.
		/// </summary>
		public string textIdentifier = "saveSimpleData-text.txt";
		
		/// <summary>
		/// The number identifier.
		/// </summary>
		public string numberIdentifier = "saveSimpleData-number.txt";
		
		/// <summary>
		/// The text input field.
		/// </summary>
		public InputField textInputField;
		
		/// <summary>
		/// The number input field.
		/// </summary>
		public InputField numberInputField;

		void Awake ()
		{
			
			// Subscribe to save and load events.
			SaveGame.OnSaved += OnSaved;
			SaveGame.OnLoaded += OnLoaded;
		}

		/// <summary>
		/// Save the text and number.
		/// </summary>
		public void Save ()
		{
			SaveGame.Save ( textIdentifier, textInputField.text );
			SaveGame.Save (
				numberIdentifier,
				string.IsNullOrEmpty ( numberInputField.text ) ? 0 : int.Parse ( numberInputField.text ) );
		}

		/// <summary>
		/// Load the text and number.
		/// </summary>
		public void Load ()
		{
			textInputField.text = SaveGame.Load<string> ( textIdentifier, "Hello World" );
			numberInputField.text = SaveGame.Load<int> ( numberIdentifier, 0 ).ToString ();
		}

		void OnSaved ( string identifier, object value, SaveGameSettings settings )
		{
			Debug.LogFormat ( "Data Saved Successfully by Identifier: {0}", identifier );
		}

		void OnLoaded ( string identifier, object result, System.Type type, object defaultValue, SaveGameSettings settings )
		{
			Debug.LogFormat ( "Data Loaded Successfully by Identifier: {0}", identifier );
		}
	
	}
	
}