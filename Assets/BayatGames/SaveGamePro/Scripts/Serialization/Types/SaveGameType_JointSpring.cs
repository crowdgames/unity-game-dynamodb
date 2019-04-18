using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type JointSpring serialization implementation.
	/// </summary>
	public class SaveGameType_JointSpring : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.JointSpring );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.JointSpring jointSpring = ( UnityEngine.JointSpring )value;
			writer.WriteProperty ( "spring", jointSpring.spring );
			writer.WriteProperty ( "damper", jointSpring.damper );
			writer.WriteProperty ( "targetPosition", jointSpring.targetPosition );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.JointSpring jointSpring = new UnityEngine.JointSpring ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "spring":
						jointSpring.spring = reader.ReadProperty<System.Single> ();
						break;
					case "damper":
						jointSpring.damper = reader.ReadProperty<System.Single> ();
						break;
					case "targetPosition":
						jointSpring.targetPosition = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return jointSpring;
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