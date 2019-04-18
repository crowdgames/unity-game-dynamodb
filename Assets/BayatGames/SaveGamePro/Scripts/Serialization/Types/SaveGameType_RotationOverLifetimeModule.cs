using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type RotationOverLifetimeModule serialization implementation.
	/// </summary>
	public class SaveGameType_RotationOverLifetimeModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.RotationOverLifetimeModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = ( UnityEngine.ParticleSystem.RotationOverLifetimeModule )value;
			writer.WriteProperty ( "enabled", rotationOverLifetimeModule.enabled );
			writer.WriteProperty ( "x", rotationOverLifetimeModule.x );
			writer.WriteProperty ( "xMultiplier", rotationOverLifetimeModule.xMultiplier );
			writer.WriteProperty ( "y", rotationOverLifetimeModule.y );
			writer.WriteProperty ( "yMultiplier", rotationOverLifetimeModule.yMultiplier );
			writer.WriteProperty ( "z", rotationOverLifetimeModule.z );
			writer.WriteProperty ( "zMultiplier", rotationOverLifetimeModule.zMultiplier );
			writer.WriteProperty ( "separateAxes", rotationOverLifetimeModule.separateAxes );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = new UnityEngine.ParticleSystem.RotationOverLifetimeModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						rotationOverLifetimeModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "x":
						rotationOverLifetimeModule.x = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "xMultiplier":
						rotationOverLifetimeModule.xMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						rotationOverLifetimeModule.y = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "yMultiplier":
						rotationOverLifetimeModule.yMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "z":
						rotationOverLifetimeModule.z = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "zMultiplier":
						rotationOverLifetimeModule.zMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "separateAxes":
						rotationOverLifetimeModule.separateAxes = reader.ReadProperty<System.Boolean> ();
						break;
				}
			}
			return rotationOverLifetimeModule;
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