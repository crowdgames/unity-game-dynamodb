using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

using BayatGames.SaveGamePro.Extensions;

namespace BayatGames.SaveGamePro.Examples
{

	/// <summary>
	/// List saved files example.
	/// </summary>
	public class ListSavedFiles : MonoBehaviour
	{
		
		/// <summary>
		/// The list container.
		/// </summary>
		public Transform listContainer;
		
		/// <summary>
		/// The list item prefab.
		/// </summary>
		public ListItem listItemPrefab;
		
		/// <summary>
		/// The identifier input field.
		/// </summary>
		public InputField identifierInputField;

		void Start ()
		{
			
			// Update list at start
			UpdateList ();
		}

		/// <summary>
		/// Save the specified identifier with a dummy data.
		/// </summary>
		public void Save ()
		{
			SaveGame.Save ( identifierInputField.text, "Hello World" );
			UpdateList ();
		}

		/// <summary>
		/// Update the list.
		/// </summary>
		public void UpdateList ()
		{
			
			// Destroy all list childs.
			listContainer.DestroyChilds ();
			
			// Retrieve the files.
			FileInfo [] files = SaveGame.GetFiles ();
			
			// Create list items.
			for ( int i = 0; i < files.Length; i++ )
			{
				ListItem item = GameObject.Instantiate<ListItem> ( listItemPrefab, listContainer );
				item.file = files [ i ];
			}
		}
		
	}

}