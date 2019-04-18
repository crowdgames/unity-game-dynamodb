using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Physics2DRaycaster serialization implementation.
	/// </summary>
	public class SaveGameType_Physics2DRaycaster : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.EventSystems.Physics2DRaycaster );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.EventSystems.Physics2DRaycaster physics2DRaycaster = ( UnityEngine.EventSystems.Physics2DRaycaster )value;
			writer.WriteProperty ( "eventMask", physics2DRaycaster.eventMask );
			writer.WriteProperty ( "useGUILayout", physics2DRaycaster.useGUILayout );
			writer.WriteProperty ( "enabled", physics2DRaycaster.enabled );
			writer.WriteProperty ( "tag", physics2DRaycaster.tag );
			writer.WriteProperty ( "name", physics2DRaycaster.name );
			writer.WriteProperty ( "hideFlags", physics2DRaycaster.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.EventSystems.Physics2DRaycaster physics2DRaycaster = SaveGameType.CreateComponent<UnityEngine.EventSystems.Physics2DRaycaster> ();
			ReadInto ( physics2DRaycaster, reader );
			return physics2DRaycaster;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.EventSystems.Physics2DRaycaster physics2DRaycaster = ( UnityEngine.EventSystems.Physics2DRaycaster )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "eventMask":
						physics2DRaycaster.eventMask = reader.ReadProperty<UnityEngine.LayerMask> ();
						break;
					case "useGUILayout":
						physics2DRaycaster.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						physics2DRaycaster.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						physics2DRaycaster.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						physics2DRaycaster.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						physics2DRaycaster.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}