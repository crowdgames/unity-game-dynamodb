using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type RotationBySpeedModule serialization implementation.
	/// </summary>
	public class SaveGameType_RotationBySpeedModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.RotationBySpeedModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.RotationBySpeedModule rotationBySpeedModule = ( UnityEngine.ParticleSystem.RotationBySpeedModule )value;
			writer.WriteProperty ( "enabled", rotationBySpeedModule.enabled );
			writer.WriteProperty ( "x", rotationBySpeedModule.x );
			writer.WriteProperty ( "xMultiplier", rotationBySpeedModule.xMultiplier );
			writer.WriteProperty ( "y", rotationBySpeedModule.y );
			writer.WriteProperty ( "yMultiplier", rotationBySpeedModule.yMultiplier );
			writer.WriteProperty ( "z", rotationBySpeedModule.z );
			writer.WriteProperty ( "zMultiplier", rotationBySpeedModule.zMultiplier );
			writer.WriteProperty ( "separateAxes", rotationBySpeedModule.separateAxes );
			writer.WriteProperty ( "range", rotationBySpeedModule.range );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.RotationBySpeedModule rotationBySpeedModule = new UnityEngine.ParticleSystem.RotationBySpeedModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						rotationBySpeedModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "x":
						rotationBySpeedModule.x = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "xMultiplier":
						rotationBySpeedModule.xMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						rotationBySpeedModule.y = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "yMultiplier":
						rotationBySpeedModule.yMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "z":
						rotationBySpeedModule.z = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "zMultiplier":
						rotationBySpeedModule.zMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "separateAxes":
						rotationBySpeedModule.separateAxes = reader.ReadProperty<System.Boolean> ();
						break;
					case "range":
						rotationBySpeedModule.range = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
				}
			}
			return rotationBySpeedModule;
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