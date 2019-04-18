using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AnimatorControllerParameter serialization implementation.
	/// </summary>
	public class SaveGameType_AnimatorControllerParameter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AnimatorControllerParameter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AnimatorControllerParameter animatorControllerParameter = ( UnityEngine.AnimatorControllerParameter )value;
			writer.WriteProperty ( "type", animatorControllerParameter.type );
			writer.WriteProperty ( "defaultFloat", animatorControllerParameter.defaultFloat );
			writer.WriteProperty ( "defaultInt", animatorControllerParameter.defaultInt );
			writer.WriteProperty ( "defaultBool", animatorControllerParameter.defaultBool );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AnimatorControllerParameter animatorControllerParameter = new UnityEngine.AnimatorControllerParameter ();
			ReadInto ( animatorControllerParameter, reader );
			return animatorControllerParameter;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AnimatorControllerParameter animatorControllerParameter = ( UnityEngine.AnimatorControllerParameter )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "type":
						animatorControllerParameter.type = reader.ReadProperty<UnityEngine.AnimatorControllerParameterType> ();
						break;
					case "defaultFloat":
						animatorControllerParameter.defaultFloat = reader.ReadProperty<System.Single> ();
						break;
					case "defaultInt":
						animatorControllerParameter.defaultInt = reader.ReadProperty<System.Int32> ();
						break;
					case "defaultBool":
						animatorControllerParameter.defaultBool = reader.ReadProperty<System.Boolean> ();
						break;
				}
			}
		}
		
	}

}