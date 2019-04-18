using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type MinMaxCurve serialization implementation.
	/// </summary>
	public class SaveGameType_MinMaxCurve : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.MinMaxCurve );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.MinMaxCurve minMaxCurve = ( UnityEngine.ParticleSystem.MinMaxCurve )value;
			writer.WriteProperty ( "mode", minMaxCurve.mode );
			writer.WriteProperty ( "curveMultiplier", minMaxCurve.curveMultiplier );
			writer.WriteProperty ( "curveMax", minMaxCurve.curveMax );
			writer.WriteProperty ( "curveMin", minMaxCurve.curveMin );
			writer.WriteProperty ( "constantMax", minMaxCurve.constantMax );
			writer.WriteProperty ( "constantMin", minMaxCurve.constantMin );
			writer.WriteProperty ( "constant", minMaxCurve.constant );
			writer.WriteProperty ( "curve", minMaxCurve.curve );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.MinMaxCurve minMaxCurve = new UnityEngine.ParticleSystem.MinMaxCurve ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "mode":
						minMaxCurve.mode = reader.ReadProperty<UnityEngine.ParticleSystemCurveMode> ();
						break;
					case "curveMultiplier":
						minMaxCurve.curveMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "curveMax":
						minMaxCurve.curveMax = reader.ReadProperty<UnityEngine.AnimationCurve> ();
						break;
					case "curveMin":
						minMaxCurve.curveMin = reader.ReadProperty<UnityEngine.AnimationCurve> ();
						break;
					case "constantMax":
						minMaxCurve.constantMax = reader.ReadProperty<System.Single> ();
						break;
					case "constantMin":
						minMaxCurve.constantMin = reader.ReadProperty<System.Single> ();
						break;
					case "constant":
						minMaxCurve.constant = reader.ReadProperty<System.Single> ();
						break;
					case "curve":
						minMaxCurve.curve = reader.ReadProperty<UnityEngine.AnimationCurve> ();
						break;
				}
			}
			return minMaxCurve;
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