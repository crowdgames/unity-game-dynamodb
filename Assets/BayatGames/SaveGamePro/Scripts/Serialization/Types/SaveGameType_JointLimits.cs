using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type JointLimits serialization implementation.
	/// </summary>
	public class SaveGameType_JointLimits : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.JointLimits );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.JointLimits jointLimits = ( UnityEngine.JointLimits )value;
			writer.WriteProperty ( "min", jointLimits.min );
			writer.WriteProperty ( "max", jointLimits.max );
			writer.WriteProperty ( "bounciness", jointLimits.bounciness );
			writer.WriteProperty ( "bounceMinVelocity", jointLimits.bounceMinVelocity );
			writer.WriteProperty ( "contactDistance", jointLimits.contactDistance );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.JointLimits jointLimits = new UnityEngine.JointLimits ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "min":
						jointLimits.min = reader.ReadProperty<System.Single> ();
						break;
					case "max":
						jointLimits.max = reader.ReadProperty<System.Single> ();
						break;
					case "bounciness":
						jointLimits.bounciness = reader.ReadProperty<System.Single> ();
						break;
					case "bounceMinVelocity":
						jointLimits.bounceMinVelocity = reader.ReadProperty<System.Single> ();
						break;
					case "contactDistance":
						jointLimits.contactDistance = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return jointLimits;
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