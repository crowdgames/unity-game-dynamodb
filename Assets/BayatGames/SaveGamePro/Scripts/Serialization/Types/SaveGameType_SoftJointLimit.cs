using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SoftJointLimit serialization implementation.
	/// </summary>
	public class SaveGameType_SoftJointLimit : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.SoftJointLimit );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.SoftJointLimit softJointLimit = ( UnityEngine.SoftJointLimit )value;
			writer.WriteProperty ( "limit", softJointLimit.limit );
			writer.WriteProperty ( "bounciness", softJointLimit.bounciness );
			writer.WriteProperty ( "contactDistance", softJointLimit.contactDistance );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.SoftJointLimit softJointLimit = new UnityEngine.SoftJointLimit ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "limit":
						softJointLimit.limit = reader.ReadProperty<System.Single> ();
						break;
					case "bounciness":
						softJointLimit.bounciness = reader.ReadProperty<System.Single> ();
						break;
					case "contactDistance":
						softJointLimit.contactDistance = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return softJointLimit;
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