using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro
{

	/// <summary>
	/// Save game auto.
	/// Automatically saves the given objects.
	/// </summary>
	[AddComponentMenu ( "Save Game Pro/Auto Save" )]
	public class SaveGameAuto : SaveGameAutoBehaviour
	{
		
		/// <summary>
		/// List of objects to save.
		/// </summary>
		[SerializeField]
		protected List<Object> m_Objects;

		/// <summary>
		/// Gets the list of objects for save.
		/// </summary>
		/// <value>The objects.</value>
		public virtual List<Object> Objects
		{
			get
			{
				return m_Objects;
			}
		}

		/// <summary>
		/// Save this instance.
		/// </summary>
		public override void Save ()
		{
			SaveGame.Save ( SaveSettings.Identifier, m_Objects );
		}

		/// <summary>
		/// Load this instance.
		/// </summary>
		public override void Load ()
		{
			SaveGame.LoadInto<List<Object>> ( SaveSettings.Identifier, m_Objects );
		}
		
	}

}