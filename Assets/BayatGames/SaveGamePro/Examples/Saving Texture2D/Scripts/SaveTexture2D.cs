using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BayatGames.SaveGamePro.Examples
{

	/// <summary>
	/// Save texture2D example.
	/// </summary>
	public class SaveTexture2D : MonoBehaviour
	{

		/// <summary>
		/// The texture to save.
		/// </summary>
		public Texture2D texture;
		public Image image;

		void Awake ()
		{
			image.sprite = Sprite.Create (
				texture,
				new Rect ( 0f, 0f, texture.width, texture.height ),
				new Vector2 ( 0.5f, 0.5f ) );
		}

		/// <summary>
		/// Clear image sprite.
		/// </summary>
		public void ClearImage ()
		{
			image.sprite = null;
		}

		/// <summary>
		/// Save the target.
		/// </summary>
		public void Save ()
		{
			SaveGame.Save ( "texture", texture );
		}

		/// <summary>
		/// Load the data.
		/// </summary>
		public void Load ()
		{
			texture = SaveGame.Load<Texture2D> ( "texture" );
			image.sprite = Sprite.Create (
				texture,
				new Rect ( 0f, 0f, texture.width, texture.height ),
				new Vector2 ( 0.5f, 0.5f ) );
		}

	}

}