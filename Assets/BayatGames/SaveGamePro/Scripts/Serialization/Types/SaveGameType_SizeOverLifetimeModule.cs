using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SizeOverLifetimeModule serialization implementation.
	/// </summary>
	public class SaveGameType_SizeOverLifetimeModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.SizeOverLifetimeModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = ( UnityEngine.ParticleSystem.SizeOverLifetimeModule )value;
			writer.WriteProperty ( "enabled", sizeOverLifetimeModule.enabled );
			writer.WriteProperty ( "size", sizeOverLifetimeModule.size );
			writer.WriteProperty ( "sizeMultiplier", sizeOverLifetimeModule.sizeMultiplier );
			writer.WriteProperty ( "x", sizeOverLifetimeModule.x );
			writer.WriteProperty ( "xMultiplier", sizeOverLifetimeModule.xMultiplier );
			writer.WriteProperty ( "y", sizeOverLifetimeModule.y );
			writer.WriteProperty ( "yMultiplier", sizeOverLifetimeModule.yMultiplier );
			writer.WriteProperty ( "z", sizeOverLifetimeModule.z );
			writer.WriteProperty ( "zMultiplier", sizeOverLifetimeModule.zMultiplier );
			writer.WriteProperty ( "separateAxes", sizeOverLifetimeModule.separateAxes );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = new UnityEngine.ParticleSystem.SizeOverLifetimeModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						sizeOverLifetimeModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "size":
						sizeOverLifetimeModule.size = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "sizeMultiplier":
						sizeOverLifetimeModule.sizeMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "x":
						sizeOverLifetimeModule.x = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "xMultiplier":
						sizeOverLifetimeModule.xMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						sizeOverLifetimeModule.y = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "yMultiplier":
						sizeOverLifetimeModule.yMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "z":
						sizeOverLifetimeModule.z = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "zMultiplier":
						sizeOverLifetimeModule.zMultiplier = reader.ReadProperty<System.Single> ();
						break;
					case "separateAxes":
						sizeOverLifetimeModule.separateAxes = reader.ReadProperty<System.Boolean> ();
						break;
				}
			}
			return sizeOverLifetimeModule;
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