using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ConstantForce serialization implementation.
	/// </summary>
	public class SaveGameType_ConstantForce : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ConstantForce );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ConstantForce constantForce = ( UnityEngine.ConstantForce )value;
			writer.WriteProperty ( "force", constantForce.force );
			writer.WriteProperty ( "relativeForce", constantForce.relativeForce );
			writer.WriteProperty ( "torque", constantForce.torque );
			writer.WriteProperty ( "relativeTorque", constantForce.relativeTorque );
			writer.WriteProperty ( "enabled", constantForce.enabled );
			writer.WriteProperty ( "tag", constantForce.tag );
			writer.WriteProperty ( "name", constantForce.name );
			writer.WriteProperty ( "hideFlags", constantForce.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ConstantForce constantForce = SaveGameType.CreateComponent<UnityEngine.ConstantForce> ();
			ReadInto ( constantForce, reader );
			return constantForce;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.ConstantForce constantForce = ( UnityEngine.ConstantForce )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "force":
						constantForce.force = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "relativeForce":
						constantForce.relativeForce = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "torque":
						constantForce.torque = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "relativeTorque":
						constantForce.relativeTorque = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "enabled":
						constantForce.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						constantForce.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						constantForce.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						constantForce.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}