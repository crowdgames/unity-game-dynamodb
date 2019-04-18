using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type PhysicsMaterial2D serialization implementation.
	/// </summary>
	public class SaveGameType_PhysicsMaterial2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.PhysicsMaterial2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.PhysicsMaterial2D physicsMaterial2D = ( UnityEngine.PhysicsMaterial2D )value;
			writer.WriteProperty ( "bounciness", physicsMaterial2D.bounciness );
			writer.WriteProperty ( "friction", physicsMaterial2D.friction );
			writer.WriteProperty ( "name", physicsMaterial2D.name );
			writer.WriteProperty ( "hideFlags", physicsMaterial2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.PhysicsMaterial2D physicsMaterial2D = new UnityEngine.PhysicsMaterial2D ();
			ReadInto ( physicsMaterial2D, reader );
			return physicsMaterial2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.PhysicsMaterial2D physicsMaterial2D = ( UnityEngine.PhysicsMaterial2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "bounciness":
						physicsMaterial2D.bounciness = reader.ReadProperty<System.Single> ();
						break;
					case "friction":
						physicsMaterial2D.friction = reader.ReadProperty<System.Single> ();
						break;
					case "name":
						physicsMaterial2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						physicsMaterial2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}