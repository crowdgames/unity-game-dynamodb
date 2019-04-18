using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type EventSystem serialization implementation.
	/// </summary>
	public class SaveGameType_EventSystem : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.EventSystems.EventSystem );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.EventSystems.EventSystem eventSystem = ( UnityEngine.EventSystems.EventSystem )value;
			writer.WriteProperty ( "sendNavigationEvents", eventSystem.sendNavigationEvents );
			writer.WriteProperty ( "pixelDragThreshold", eventSystem.pixelDragThreshold );
			writer.WriteProperty ( "firstSelectedGameObject", eventSystem.firstSelectedGameObject );
			writer.WriteProperty ( "useGUILayout", eventSystem.useGUILayout );
			writer.WriteProperty ( "enabled", eventSystem.enabled );
			writer.WriteProperty ( "tag", eventSystem.tag );
			writer.WriteProperty ( "name", eventSystem.name );
			writer.WriteProperty ( "hideFlags", eventSystem.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.EventSystems.EventSystem eventSystem = SaveGameType.CreateComponent<UnityEngine.EventSystems.EventSystem> ();
			ReadInto ( eventSystem, reader );
			return eventSystem;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.EventSystems.EventSystem eventSystem = ( UnityEngine.EventSystems.EventSystem )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "sendNavigationEvents":
						eventSystem.sendNavigationEvents = reader.ReadProperty<System.Boolean> ();
						break;
					case "pixelDragThreshold":
						eventSystem.pixelDragThreshold = reader.ReadProperty<System.Int32> ();
						break;
					case "firstSelectedGameObject":
						if ( eventSystem.firstSelectedGameObject == null )
						{
							eventSystem.firstSelectedGameObject = reader.ReadProperty<UnityEngine.GameObject> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.GameObject> ( eventSystem.firstSelectedGameObject );
						}
						break;
					case "useGUILayout":
						eventSystem.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						eventSystem.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						eventSystem.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						eventSystem.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						eventSystem.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}