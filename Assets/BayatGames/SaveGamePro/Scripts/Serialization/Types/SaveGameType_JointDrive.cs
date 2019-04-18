using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type JointDrive serialization implementation.
	/// </summary>
	public class SaveGameType_JointDrive : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.JointDrive );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.JointDrive jointDrive = ( UnityEngine.JointDrive )value;
			writer.WriteProperty ( "positionSpring", jointDrive.positionSpring );
			writer.WriteProperty ( "positionDamper", jointDrive.positionDamper );
			writer.WriteProperty ( "maximumForce", jointDrive.maximumForce );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.JointDrive jointDrive = new UnityEngine.JointDrive ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "positionSpring":
						jointDrive.positionSpring = reader.ReadProperty<System.Single> ();
						break;
					case "positionDamper":
						jointDrive.positionDamper = reader.ReadProperty<System.Single> ();
						break;
					case "maximumForce":
						jointDrive.maximumForce = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return jointDrive;
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