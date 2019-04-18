using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AnimatorOverrideController serialization implementation.
	/// </summary>
	public class SaveGameType_AnimatorOverrideController : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AnimatorOverrideController );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AnimatorOverrideController animatorOverrideController = ( UnityEngine.AnimatorOverrideController )value;
			writer.WriteProperty ( "runtimeAnimatorController", animatorOverrideController.runtimeAnimatorController );
			writer.WriteProperty ( "name", animatorOverrideController.name );
			writer.WriteProperty ( "hideFlags", animatorOverrideController.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AnimatorOverrideController animatorOverrideController = new UnityEngine.AnimatorOverrideController ();
			ReadInto ( animatorOverrideController, reader );
			return animatorOverrideController;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AnimatorOverrideController animatorOverrideController = ( UnityEngine.AnimatorOverrideController )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "runtimeAnimatorController":
						if ( animatorOverrideController.runtimeAnimatorController == null )
						{
							animatorOverrideController.runtimeAnimatorController = reader.ReadProperty<UnityEngine.RuntimeAnimatorController> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.RuntimeAnimatorController> ( animatorOverrideController.runtimeAnimatorController );
						}
						break;
					case "name":
						animatorOverrideController.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						animatorOverrideController.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}