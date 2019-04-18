using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type JointSuspension2D serialization implementation.
	/// </summary>
	public class SaveGameType_JointSuspension2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.JointSuspension2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.JointSuspension2D jointSuspension2D = ( UnityEngine.JointSuspension2D )value;
			writer.WriteProperty ( "dampingRatio", jointSuspension2D.dampingRatio );
			writer.WriteProperty ( "frequency", jointSuspension2D.frequency );
			writer.WriteProperty ( "angle", jointSuspension2D.angle );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.JointSuspension2D jointSuspension2D = new UnityEngine.JointSuspension2D ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "dampingRatio":
						jointSuspension2D.dampingRatio = reader.ReadProperty<System.Single> ();
						break;
					case "frequency":
						jointSuspension2D.frequency = reader.ReadProperty<System.Single> ();
						break;
					case "angle":
						jointSuspension2D.angle = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return jointSuspension2D;
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