using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SoftJointLimitSpring serialization implementation.
	/// </summary>
	public class SaveGameType_SoftJointLimitSpring : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.SoftJointLimitSpring );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.SoftJointLimitSpring softJointLimitSpring = ( UnityEngine.SoftJointLimitSpring )value;
			writer.WriteProperty ( "spring", softJointLimitSpring.spring );
			writer.WriteProperty ( "damper", softJointLimitSpring.damper );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.SoftJointLimitSpring softJointLimitSpring = new UnityEngine.SoftJointLimitSpring ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "spring":
						softJointLimitSpring.spring = reader.ReadProperty<System.Single> ();
						break;
					case "damper":
						softJointLimitSpring.damper = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return softJointLimitSpring;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			base.ReadInto ( value, reader );
		}
		
	}

}