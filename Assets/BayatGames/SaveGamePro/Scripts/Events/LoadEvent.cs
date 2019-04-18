using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BayatGames.SaveGamePro.Events
{

	/// <summary>
	/// Load event.
	/// </summary>
	[Serializable]
	public class LoadEvent : UnityEvent<string, object, SaveGameSettings>
	{
		
	}

}