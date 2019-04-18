using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type JointMotor2D serialization implementation.
	/// </summary>
	public class SaveGameType_JointMotor2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.JointMotor2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.JointMotor2D jointMotor2D = ( UnityEngine.JointMotor2D )value;
			writer.WriteProperty ( "motorSpeed", jointMotor2D.motorSpeed );
			writer.WriteProperty ( "maxMotorTorque", jointMotor2D.maxMotorTorque );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.JointMotor2D jointMotor2D = new UnityEngine.JointMotor2D ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "motorSpeed":
						jointMotor2D.motorSpeed = reader.ReadProperty<System.Single> ();
						break;
					case "maxMotorTorque":
						jointMotor2D.maxMotorTorque = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return jointMotor2D;
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