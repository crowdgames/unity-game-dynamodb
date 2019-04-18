using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro
{

	/// <summary>
	/// Save Game Auto Behaviour.
	/// Extend this class to automatically save your Behaviour fields and properties.
	/// </summary>
	public abstract class SaveGameAutoBehaviour : SaveGameBehaviour
	{
		
		#region Methods

		protected virtual void Awake ()
		{
			Load ();
		}

		protected virtual void OnDisable ()
		{
			Save ();
		}

		protected virtual void OnDestroy ()
		{
			Save ();
		}

		protected virtual void OnApplicationPause ()
		{
			Save ();
		}

		protected virtual void OnApplicationQuit ()
		{
			Save ();
		}

		#endregion
		
	}

}