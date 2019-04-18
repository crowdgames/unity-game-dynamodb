using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Touch serialization implementation.
	/// </summary>
	public class SaveGameType_Touch : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Touch );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Touch touch = ( UnityEngine.Touch )value;
			writer.WriteProperty ( "fingerId", touch.fingerId );
			writer.WriteProperty ( "position", touch.position );
			writer.WriteProperty ( "rawPosition", touch.rawPosition );
			writer.WriteProperty ( "deltaPosition", touch.deltaPosition );
			writer.WriteProperty ( "deltaTime", touch.deltaTime );
			writer.WriteProperty ( "tapCount", touch.tapCount );
			writer.WriteProperty ( "phase", touch.phase );
			writer.WriteProperty ( "pressure", touch.pressure );
			writer.WriteProperty ( "maximumPossiblePressure", touch.maximumPossiblePressure );
			writer.WriteProperty ( "type", touch.type );
			writer.WriteProperty ( "altitudeAngle", touch.altitudeAngle );
			writer.WriteProperty ( "azimuthAngle", touch.azimuthAngle );
			writer.WriteProperty ( "radius", touch.radius );
			writer.WriteProperty ( "radiusVariance", touch.radiusVariance );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Touch touch = new UnityEngine.Touch ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "fingerId":
						touch.fingerId = reader.ReadProperty<System.Int32> ();
						break;
					case "position":
						touch.position = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "rawPosition":
						touch.rawPosition = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "deltaPosition":
						touch.deltaPosition = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "deltaTime":
						touch.deltaTime = reader.ReadProperty<System.Single> ();
						break;
					case "tapCount":
						touch.tapCount = reader.ReadProperty<System.Int32> ();
						break;
					case "phase":
						touch.phase = reader.ReadProperty<UnityEngine.TouchPhase> ();
						break;
					case "pressure":
						touch.pressure = reader.ReadProperty<System.Single> ();
						break;
					case "maximumPossiblePressure":
						touch.maximumPossiblePressure = reader.ReadProperty<System.Single> ();
						break;
					case "type":
						touch.type = reader.ReadProperty<UnityEngine.TouchType> ();
						break;
					case "altitudeAngle":
						touch.altitudeAngle = reader.ReadProperty<System.Single> ();
						break;
					case "azimuthAngle":
						touch.azimuthAngle = reader.ReadProperty<System.Single> ();
						break;
					case "radius":
						touch.radius = reader.ReadProperty<System.Single> ();
						break;
					case "radiusVariance":
						touch.radiusVariance = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return touch;
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