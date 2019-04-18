using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BayatGames.SaveGamePro.Events
{

	/// <summary>
	/// Save event.
	/// </summary>
	[Serializable]
	public class SaveEvent : UnityEvent<string, object, SaveGameSettings>
	{

	}

}