using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type JointAngleLimits2D serialization implementation.
	/// </summary>
	public class SaveGameType_JointAngleLimits2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.JointAngleLimits2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.JointAngleLimits2D jointAngleLimits2D = ( UnityEngine.JointAngleLimits2D )value;
			writer.WriteProperty ( "min", jointAngleLimits2D.min );
			writer.WriteProperty ( "max", jointAngleLimits2D.max );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.JointAngleLimits2D jointAngleLimits2D = new UnityEngine.JointAngleLimits2D ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "min":
						jointAngleLimits2D.min = reader.ReadProperty<System.Single> ();
						break;
					case "max":
						jointAngleLimits2D.max = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return jointAngleLimits2D;
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