using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type PhysicsRaycaster serialization implementation.
	/// </summary>
	public class SaveGameType_PhysicsRaycaster : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.EventSystems.PhysicsRaycaster );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.EventSystems.PhysicsRaycaster physicsRaycaster = ( UnityEngine.EventSystems.PhysicsRaycaster )value;
			writer.WriteProperty ( "eventMask", physicsRaycaster.eventMask );
			writer.WriteProperty ( "useGUILayout", physicsRaycaster.useGUILayout );
			writer.WriteProperty ( "enabled", physicsRaycaster.enabled );
			writer.WriteProperty ( "tag", physicsRaycaster.tag );
			writer.WriteProperty ( "name", physicsRaycaster.name );
			writer.WriteProperty ( "hideFlags", physicsRaycaster.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.EventSystems.PhysicsRaycaster physicsRaycaster = SaveGameType.CreateComponent<UnityEngine.EventSystems.PhysicsRaycaster> ();
			ReadInto ( physicsRaycaster, reader );
			return physicsRaycaster;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.EventSystems.PhysicsRaycaster physicsRaycaster = ( UnityEngine.EventSystems.PhysicsRaycaster )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "eventMask":
						physicsRaycaster.eventMask = reader.ReadProperty<UnityEngine.LayerMask> ();
						break;
					case "useGUILayout":
						physicsRaycaster.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						physicsRaycaster.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						physicsRaycaster.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						physicsRaycaster.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						physicsRaycaster.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}