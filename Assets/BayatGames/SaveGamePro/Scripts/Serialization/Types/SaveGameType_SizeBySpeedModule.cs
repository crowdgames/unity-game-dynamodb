using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SizeBySpeedModule serialization implementation.
	/// </summary>
	public class SaveGameType_SizeBySpeedModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.SizeBySpeedModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.SizeBySpeedModule sizeBySpeedModule = ( UnityEngine.ParticleSystem.SizeBySpeedModule )value;
			writer.WriteProperty ( "enabled", sizeBySpeedModule.enabled );
			writer.WriteProperty ( "size", sizeBySpeedModule.size );
			writer.WriteProperty ( "sizeMultiplier", sizeBySpeedModule.sizeMultiplier );
			writer.WriteProperty ( "x", sizeBySpeedModule.x );
			writer.WriteProperty ( "xMultiplier", sizeBySpeedModule.xMultiplier );
			writer.WriteProperty ( "y", sizeBySpeedModule.y );
			writer.WriteProperty ( "yMultiplier", sizeBySpeedModule.yMultiplier );
			writer.WriteProperty ( "z", sizeBySpeedModule.z );
			writer.WriteProperty ( "zMultiplier", sizeBySpeedModule.zMultiplier );
			writer.WriteProperty ( "separateAxes", sizeBySpeedModule.separateAxes );
			writer.WriteProperty ( "range", sizeBySpeedModule.range );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.SizeBySpeedModule sizeBySpeedModule = new UnityEngine.ParticleSystem.SizeBySpeedModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						sizeBySpeedModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "size":
						sizeBySpeedModule.size = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "sizeMultiplier":
						sizeBySpeedModule.sizeMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "x":
						sizeBySpeedModule.x = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "xMultiplier":
						sizeBySpeedModule.xMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						sizeBySpeedModule.y = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "yMultiplier":
						sizeBySpeedModule.yMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "z":
						sizeBySpeedModule.z = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "zMultiplier":
						sizeBySpeedModule.zMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "separateAxes":
						sizeBySpeedModule.separateAxes = reader.ReadProperty<System.Boolean> ();
						break;
					case "range":
						sizeBySpeedModule.range = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
				}
			}
			return sizeBySpeedModule;
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