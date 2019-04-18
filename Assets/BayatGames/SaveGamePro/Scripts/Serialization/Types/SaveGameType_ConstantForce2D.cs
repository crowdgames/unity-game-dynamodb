using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type ConstantForce2D serialization implementation.
	/// </summary>
	public class SaveGameType_ConstantForce2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.ConstantForce2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.ConstantForce2D constantForce2D = ( UnityEngine.ConstantForce2D )value;
			writer.WriteProperty ( "force", constantForce2D.force );
			writer.WriteProperty ( "relativeForce", constantForce2D.relativeForce );
			writer.WriteProperty ( "torque", constantForce2D.torque );
			writer.WriteProperty ( "enabled", constantForce2D.enabled );
			writer.WriteProperty ( "tag", constantForce2D.tag );
			writer.WriteProperty ( "name", constantForce2D.name );
			writer.WriteProperty ( "hideFlags", constantForce2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.ConstantForce2D constantForce2D = SaveGameType.CreateComponent<UnityEngine.ConstantForce2D> ();
			ReadInto ( constantForce2D, reader );
			return constantForce2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.ConstantForce2D constantForce2D = ( UnityEngine.ConstantForce2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "force":
						constantForce2D.force = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "relativeForce":
						constantForce2D.relativeForce = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "torque":
						constantForce2D.torque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						constantForce2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						constantForce2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						constantForce2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						constantForce2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}