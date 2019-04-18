using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type EventTrigger serialization implementation.
	/// </summary>
	public class SaveGameType_EventTrigger : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.EventSystems.EventTrigger );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.EventSystems.EventTrigger eventTrigger = ( UnityEngine.EventSystems.EventTrigger )value;
			writer.WriteProperty ( "triggers", eventTrigger.triggers );
			writer.WriteProperty ( "useGUILayout", eventTrigger.useGUILayout );
			writer.WriteProperty ( "enabled", eventTrigger.enabled );
			writer.WriteProperty ( "tag", eventTrigger.tag );
			writer.WriteProperty ( "name", eventTrigger.name );
			writer.WriteProperty ( "hideFlags", eventTrigger.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.EventSystems.EventTrigger eventTrigger = SaveGameType.CreateComponent<UnityEngine.EventSystems.EventTrigger> ();
			ReadInto ( eventTrigger, reader );
			return eventTrigger;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.EventSystems.EventTrigger eventTrigger = ( UnityEngine.EventSystems.EventTrigger )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "triggers":
						eventTrigger.triggers = reader.ReadProperty<System.Collections.Generic.List<UnityEngine.EventSystems.EventTrigger.Entry>> ();
						break;
					case "useGUILayout":
						eventTrigger.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						eventTrigger.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						eventTrigger.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						eventTrigger.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						eventTrigger.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}