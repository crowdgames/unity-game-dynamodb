using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type StandaloneInputModule serialization implementation.
	/// </summary>
	public class SaveGameType_StandaloneInputModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.EventSystems.StandaloneInputModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.EventSystems.StandaloneInputModule standaloneInputModule = ( UnityEngine.EventSystems.StandaloneInputModule )value;
			writer.WriteProperty ( "forceModuleActive", standaloneInputModule.forceModuleActive );
			writer.WriteProperty ( "inputActionsPerSecond", standaloneInputModule.inputActionsPerSecond );
			writer.WriteProperty ( "repeatDelay", standaloneInputModule.repeatDelay );
			writer.WriteProperty ( "horizontalAxis", standaloneInputModule.horizontalAxis );
			writer.WriteProperty ( "verticalAxis", standaloneInputModule.verticalAxis );
			writer.WriteProperty ( "submitButton", standaloneInputModule.submitButton );
			writer.WriteProperty ( "cancelButton", standaloneInputModule.cancelButton );
			writer.WriteProperty ( "useGUILayout", standaloneInputModule.useGUILayout );
			writer.WriteProperty ( "enabled", standaloneInputModule.enabled );
			writer.WriteProperty ( "tag", standaloneInputModule.tag );
			writer.WriteProperty ( "name", standaloneInputModule.name );
			writer.WriteProperty ( "hideFlags", standaloneInputModule.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.EventSystems.StandaloneInputModule standaloneInputModule = SaveGameType.CreateComponent<UnityEngine.EventSystems.StandaloneInputModule> ();
			ReadInto ( standaloneInputModule, reader );
			return standaloneInputModule;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.EventSystems.StandaloneInputModule standaloneInputModule = ( UnityEngine.EventSystems.StandaloneInputModule )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "forceModuleActive":
						standaloneInputModule.forceModuleActive = reader.ReadProperty<System.Boolean> ();
						break;
					case "inputActionsPerSecond":
						standaloneInputModule.inputActionsPerSecond = reader.ReadProperty<System.Single> ();
						break;
					case "repeatDelay":
						standaloneInputModule.repeatDelay = reader.ReadProperty<System.Single> ();
						break;
					case "horizontalAxis":
						standaloneInputModule.horizontalAxis = reader.ReadProperty<System.String> ();
						break;
					case "verticalAxis":
						standaloneInputModule.verticalAxis = reader.ReadProperty<System.String> ();
						break;
					case "submitButton":
						standaloneInputModule.submitButton = reader.ReadProperty<System.String> ();
						break;
					case "cancelButton":
						standaloneInputModule.cancelButton = reader.ReadProperty<System.String> ();
						break;
					case "useGUILayout":
						standaloneInputModule.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						standaloneInputModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						standaloneInputModule.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						standaloneInputModule.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						standaloneInputModule.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}