using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Examples
{

	/// <summary>
	/// Save collections example.
	/// </summary>
	public class SaveCollections : MonoBehaviour
	{
		
		/// <summary>
		/// The dictionary.
		/// </summary>
		public static Dictionary<string, string> dictionary = new Dictionary<string, string> () { {
				"Hello",
				"World"
			}
		};
		
		/// <summary>
		/// The nested dictionary.
		/// </summary>
		public static Dictionary<string, Dictionary<string, string>> nestedDictionary = new Dictionary<string, Dictionary<string, string>> () { {
				"Hello",
				new Dictionary<string, string> () { {
						"Hello",
						"World"
					}
				}
			}
		};
		
		/// <summary>
		/// The list.
		/// </summary>
		public static List<string> list = new List<string> () {
			"Hello",
			"World"
		};
		
		/// <summary>
		/// The nested list.
		/// </summary>
		public static List<List<string>> nestedList = new List<List<string>> () {
			new List<string> () {
				"Hello",
				"World"
			}
		};
		
		/// <summary>
		/// The array.
		/// </summary>
		public static string [] array = new string[] {
			"Hello",
			"World"
		};
		
		/// <summary>
		/// The jagged array.
		/// </summary>
		public static string [][] jaggedArray = new string[][] {
			new string[] {
				"Hello",
				"World"
			}
		};
		
		/// <summary>
		/// The multi dimensional array.
		/// </summary>
		public static string [,] multiDimensionalArray = new string[,] {
			{ "Hello", "World" }
		};
		
		/// <summary>
		/// The hashtable.
		/// </summary>
		public static Hashtable hashtable = new Hashtable () {
			{ "Hello", "World" }
		};
		
		/// <summary>
		/// The nested hashtable.
		/// </summary>
		public static Hashtable nestedHashtable = new Hashtable () { {"Hello", new Hashtable () {
					{ "Hello", "World" }
				}
			}
		};

		void Awake ()
		{
			
			// Subscribe to save and load events.
			SaveGame.OnSaved += SaveGame_OnSaved;
			SaveGame.OnLoaded += SaveGame_OnLoaded;
		}

		/// <summary>
		/// Save Event.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="value">Value.</param>
		/// <param name="settings">Settings.</param>
		void SaveGame_OnSaved ( string identifier, object value, SaveGameSettings settings )
		{
			Debug.LogFormat ( "{0} Saved Successfully", identifier );
		}

		/// <summary>
		/// Load Event.
		/// </summary>
		/// <param name="identifier">Identifier.</param>
		/// <param name="result">Result.</param>
		/// <param name="type">Type.</param>
		/// <param name="defaultValue">Default value.</param>
		/// <param name="settings">Settings.</param>
		void SaveGame_OnLoaded ( string identifier, object result, System.Type type, object defaultValue, SaveGameSettings settings )
		{
			Debug.LogFormat ( "{0} Loaded Successfully", identifier );
		}

		/// <summary>
		/// Save the collections.
		/// </summary>
		public void Save ()
		{
			SaveGame.Save ( "dictionary.txt", dictionary );
			SaveGame.Save ( "nestedDictionary.txt", nestedDictionary );
			SaveGame.Save ( "list.txt", list );
			SaveGame.Save ( "nestedList.txt", nestedList );
			SaveGame.Save ( "array.txt", array );
			SaveGame.Save ( "jaggedArray.txt", jaggedArray );
			SaveGame.Save ( "multiDimensionalArray.txt", multiDimensionalArray );
			SaveGame.Save ( "hashtable.txt", hashtable );
			SaveGame.Save ( "nestedHashtable.txt", nestedHashtable );
		}

		/// <summary>
		/// Load the collections.
		/// </summary>
		public void Load ()
		{
			dictionary = SaveGame.Load<Dictionary<string, string>> ( "dictionary.txt" );
			nestedDictionary = SaveGame.Load<Dictionary<string, Dictionary<string, string>>> ( "nestedDictionary.txt" );
			list = SaveGame.Load<List<string>> ( "list.txt" );
			nestedList = SaveGame.Load<List<List<string>>> ( "nestedList.txt" );
			array = SaveGame.Load<string []> ( "array.txt" );
			jaggedArray = SaveGame.Load<string [][]> ( "jaggedArray.txt" );
			multiDimensionalArray = SaveGame.Load<string [,]> ( "multiDimensionalArray.txt" );
			hashtable = SaveGame.Load<Hashtable> ( "hashtable.txt" );
			nestedHashtable = SaveGame.Load<Hashtable> ( "nestedHashtable.txt" );
		}
		
	}

}