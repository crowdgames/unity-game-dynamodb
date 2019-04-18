using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type TriggerModule serialization implementation.
	/// </summary>
	public class SaveGameType_TriggerModule : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ParticleSystem.TriggerModule );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ParticleSystem.TriggerModule triggerModule = ( UnityEngine.ParticleSystem.TriggerModule )value;
			writer.WriteProperty ( "enabled", triggerModule.enabled );
			writer.WriteProperty ( "inside", triggerModule.inside );
			writer.WriteProperty ( "outside", triggerModule.outside );
			writer.WriteProperty ( "enter", triggerModule.enter );
			writer.WriteProperty ( "exit", triggerModule.exit );
			writer.WriteProperty ( "radiusScale", triggerModule.radiusScale );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ParticleSystem.TriggerModule triggerModule = new UnityEngine.ParticleSystem.TriggerModule ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						triggerModule.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "inside":
						triggerModule.inside = reader.ReadProperty<UnityEngine.ParticleSystemOverlapAction> ();
						break;
					case "outside":
						triggerModule.outside = reader.ReadProperty<UnityEngine.ParticleSystemOverlapAction> ();
						break;
					case "enter":
						triggerModule.enter = reader.ReadProperty<UnityEngine.ParticleSystemOverlapAction> ();
						break;
					case "exit":
						triggerModule.exit = reader.ReadProperty<UnityEngine.ParticleSystemOverlapAction> ();
						break;
					case "radiusScale":
						triggerModule.radiusScale = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return triggerModule;
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