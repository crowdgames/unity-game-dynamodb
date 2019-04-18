using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ExternalForcesModule serialization implementation.
	/// </summary>
	public class SaveGameType_ExternalForcesModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.ExternalForcesModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.ExternalForcesModule externalForcesModule = ( UnityEngine.ParticleSystem.ExternalForcesModule )value;
			writer.WriteProperty ( "enabled", externalForcesModule.enabled );
			writer.WriteProperty ( "multiplier", externalForcesModule.multiplier );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.ExternalForcesModule externalForcesModule = new UnityEngine.ParticleSystem.ExternalForcesModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						externalForcesModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "multiplier":
						externalForcesModule.multiplier = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return externalForcesModule;
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