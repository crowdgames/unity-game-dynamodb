using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type JointMotor serialization implementation.
	/// </summary>
	public class SaveGameType_JointMotor : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.JointMotor );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.JointMotor jointMotor = ( UnityEngine.JointMotor )value;
			writer.WriteProperty ( "targetVelocity", jointMotor.targetVelocity );
			writer.WriteProperty ( "force", jointMotor.force );
			writer.WriteProperty ( "freeSpin", jointMotor.freeSpin );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.JointMotor jointMotor = new UnityEngine.JointMotor ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "targetVelocity":
						jointMotor.targetVelocity = reader.ReadProperty<System.Single> ();
						break;
					case "force":
						jointMotor.force = reader.ReadProperty<System.Single> ();
						break;
					case "freeSpin":
						jointMotor.freeSpin = reader.ReadProperty<System.Boolean> ();
						break;
				}
			}
			return jointMotor;
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