using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type WheelFrictionCurve serialization implementation.
	/// </summary>
	public class SaveGameType_WheelFrictionCurve : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.WheelFrictionCurve );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.WheelFrictionCurve wheelFrictionCurve = ( UnityEngine.WheelFrictionCurve )value;
			writer.WriteProperty ( "extremumSlip", wheelFrictionCurve.extremumSlip );
			writer.WriteProperty ( "extremumValue", wheelFrictionCurve.extremumValue );
			writer.WriteProperty ( "asymptoteSlip", wheelFrictionCurve.asymptoteSlip );
			writer.WriteProperty ( "asymptoteValue", wheelFrictionCurve.asymptoteValue );
			writer.WriteProperty ( "stiffness", wheelFrictionCurve.stiffness );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.WheelFrictionCurve wheelFrictionCurve = new UnityEngine.WheelFrictionCurve ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "extremumSlip":
						wheelFrictionCurve.extremumSlip = reader.ReadProperty<System.Single> ();
						break;
					case "extremumValue":
						wheelFrictionCurve.extremumValue = reader.ReadProperty<System.Single> ();
						break;
					case "asymptoteSlip":
						wheelFrictionCurve.asymptoteSlip = reader.ReadProperty<System.Single> ();
						break;
					case "asymptoteValue":
						wheelFrictionCurve.asymptoteValue = reader.ReadProperty<System.Single> ();
						break;
					case "stiffness":
						wheelFrictionCurve.stiffness = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return wheelFrictionCurve;
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