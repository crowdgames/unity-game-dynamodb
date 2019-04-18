using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AnimationTriggers serialization implementation.
	/// </summary>
	public class SaveGameType_AnimationTriggers : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.AnimationTriggers );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.AnimationTriggers animationTriggers = ( UnityEngine.UI.AnimationTriggers )value;
			writer.WriteProperty ( "normalTrigger", animationTriggers.normalTrigger );
			writer.WriteProperty ( "highlightedTrigger", animationTriggers.highlightedTrigger );
			writer.WriteProperty ( "pressedTrigger", animationTriggers.pressedTrigger );
			writer.WriteProperty ( "disabledTrigger", animationTriggers.disabledTrigger );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.AnimationTriggers animationTriggers = new UnityEngine.UI.AnimationTriggers ();
			ReadInto ( animationTriggers, reader );
			return animationTriggers;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.AnimationTriggers animationTriggers = ( UnityEngine.UI.AnimationTriggers )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "normalTrigger":
						animationTriggers.normalTrigger = reader.ReadProperty<System.String> ();
						break;
					case "highlightedTrigger":
						animationTriggers.highlightedTrigger = reader.ReadProperty<System.String> ();
						break;
					case "pressedTrigger":
						animationTriggers.pressedTrigger = reader.ReadProperty<System.String> ();
						break;
					case "disabledTrigger":
						animationTriggers.disabledTrigger = reader.ReadProperty<System.String> ();
						break;
				}
			}
		}
		
	}

}