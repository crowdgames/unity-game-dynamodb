using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type InheritVelocityModule serialization implementation.
	/// </summary>
	public class SaveGameType_InheritVelocityModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.InheritVelocityModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.InheritVelocityModule inheritVelocityModule = ( UnityEngine.ParticleSystem.InheritVelocityModule )value;
			writer.WriteProperty ( "enabled", inheritVelocityModule.enabled );
			writer.WriteProperty ( "mode", inheritVelocityModule.mode );
			writer.WriteProperty ( "curve", inheritVelocityModule.curve );
			writer.WriteProperty ( "curveMultiplier", inheritVelocityModule.curveMultiplier );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.InheritVelocityModule inheritVelocityModule = new UnityEngine.ParticleSystem.InheritVelocityModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						inheritVelocityModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "mode":
						inheritVelocityModule.mode = reader.ReadProperty<UnityEngine.ParticleSystemInheritVelocityMode> ();
						break;
					case "curve":
						inheritVelocityModule.curve = reader.ReadProperty<UnityEngine.ParticleSystem.MinMaxCurve> ();
						break;
					case "curveMultiplier":
						inheritVelocityModule.curveMultiplier = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return inheritVelocityModule;
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