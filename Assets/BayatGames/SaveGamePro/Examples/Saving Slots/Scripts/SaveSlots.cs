using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BayatGames.SaveGamePro.Examples
{

	/// <summary>
	/// Slot based Save example.
	/// </summary>
	[ExecuteInEditMode]
	public class SaveSlots : MonoBehaviour
	{

		/// <summary>
		/// The target to save based on slots.
		/// </summary>
		public Transform target;
		
		/// <summary>
		/// The slot dropdown.
		/// </summary>
		public Dropdown slotDropdown;
		
		/// <summary>
		/// The slots.
		/// </summary>
		[SerializeField]
		private string [] _slots = new string[3] {
			"Slot 1",
			"Slot 2",
			"Slot 3"
		};
		
		/// <summary>
		/// The current slot.
		/// </summary>
		[SerializeField]
		private int _currentSlot = 0;

		/// <summary>
		/// Gets or sets the current slot.
		/// </summary>
		/// <value>The current slot.</value>
		public int currentSlot
		{
			get
			{
				return _currentSlot;
			}
			set
			{
				if ( value >= 0 || value < _slots.Length )
				{
					_currentSlot = value;
				}
			}
		}
		
		#if UNITY_EDITOR
		void Update ()
		{
			if ( _slots == null || _slots.Length == 0 )
			{
				_slots = new string[3] {
					"Slot 1",
					"Slot 2",
					"Slot 3"
				};
				Debug.LogWarning ( "The Slots count must be at least 2" );
			}
			if ( _currentSlot < 0 )
			{
				_currentSlot = 0;
				Debug.LogWarning ( "Current Slot index must be greater than 0" );
			}
			if ( _currentSlot >= _slots.Length )
			{
				_currentSlot = _slots.Length - 1;
				Debug.LogWarning ( "Current Slot index must be lower than Slots count" );
			}
			CreateSlotDropdown ();
		}

		/// <summary>
		/// Update slots dropdown list.
		/// </summary>
		public void CreateSlotDropdown ()
		{
			slotDropdown.ClearOptions ();
			slotDropdown.AddOptions ( new List<string> ( _slots ) );
		}
		#endif

		/// <summary>
		/// Save the target in the specified slot.
		/// </summary>
		public void Save ()
		{
			SaveGame.Save ( GetSlotIdentifier ( "target" ), target );
		}

		/// <summary>
		/// Load the data from the specified slot.
		/// </summary>
		public void Load ()
		{
			if ( SaveGame.Exists ( GetSlotIdentifier ( "target" ) ) )
			{
				SaveGame.LoadInto ( GetSlotIdentifier ( "target" ), target );
			}
			else
			{
				target.position = Vector3.zero;
				target.rotation = Quaternion.identity;
				target.localScale = Vector3.one;
			}
		}

		/// <summary>
		/// Gets the slot identifier.
		/// </summary>
		/// <returns>The slot identifier.</returns>
		/// <param name="identifier">Identifier.</param>
		public string GetSlotIdentifier ( string identifier )
		{
			return string.Format ( "{0}/{1}", _slots [ currentSlot ], identifier );
		}
		
	}

}