using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Extensions
{

	/// <summary>
	/// Transform extensions.
	/// </summary>
	public static class TransformExtensions
	{

		/// <summary>
		/// Destroies the child.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="index">Index.</param>
		public static void DestroyChild ( this Transform transform, int index )
		{
			GameObject.Destroy ( transform.GetChild ( index ).gameObject );
		}

		/// <summary>
		/// Destroies the childs.
		/// </summary>
		/// <param name="transform">Transform.</param>
		public static void DestroyChilds ( this Transform transform )
		{
			List<GameObject> childs = new List<GameObject> ();
			for ( int i = 0; i < transform.childCount; i++ )
			{
				childs.Add ( transform.GetChild ( i ).gameObject );
			}
			for ( int i = 0; i < childs.Count; i++ )
			{
				GameObject.Destroy ( childs [ i ] );
			}
		}

	}

}