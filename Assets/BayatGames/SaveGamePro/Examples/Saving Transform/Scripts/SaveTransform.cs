using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Examples
{

	/// <summary>
	/// Save transform example.
	/// </summary>
	public class SaveTransform : MonoBehaviour
	{

		/// <summary>
		/// The target to save.
		/// </summary>
		public Transform target;

		void Awake ()
		{
			if ( target == null )
			{
				target = transform;
			}
		}

		/// <summary>
		/// Destroy target.
		/// </summary>
		public void DestroyTarget ()
		{
			Transform parent = target.parent;
			while ( parent.parent != null )
			{
				parent = parent.parent;
			}
			Destroy ( parent.gameObject );
		}

		/// <summary>
		/// Save the target.
		/// </summary>
		public void Save ()
		{
			SaveGame.Save ( "transform", target );
		}

		/// <summary>
		/// Load the data.
		/// </summary>
		public void Load ()
		{
			if ( target == null )
			{
				target = SaveGame.Load<Transform> ( "transform" );
			}
			else
			{
				SaveGame.LoadInto ( "transform", target );
			}
		}
		
	}

}