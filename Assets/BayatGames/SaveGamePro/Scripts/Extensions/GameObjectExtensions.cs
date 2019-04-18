using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Extensions
{

	/// <summary>
	/// Game object extensions.
	/// </summary>
	public static class GameObjectExtensions
	{

		/// <summary>
		/// Destroies the child.
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		/// <param name="index">Index.</param>
		public static void DestroyChild ( this GameObject gameObject, int index )
		{
			gameObject.transform.DestroyChild ( index );
		}

		/// <summary>
		/// Destroies the childs.
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public static void DestroyChilds ( this GameObject gameObject )
		{
			gameObject.transform.DestroyChilds ();
		}
		
	}

}