using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AvatarMask serialization implementation.
	/// </summary>
	public class SaveGameType_AvatarMask : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AvatarMask );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AvatarMask avatarMask = ( UnityEngine.AvatarMask )value;
			writer.WriteProperty ( "transformCount", avatarMask.transformCount );
			writer.WriteProperty ( "name", avatarMask.name );
			writer.WriteProperty ( "hideFlags", avatarMask.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AvatarMask avatarMask = new UnityEngine.AvatarMask ();
			ReadInto ( avatarMask, reader );
			return avatarMask;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AvatarMask avatarMask = ( UnityEngine.AvatarMask )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "transformCount":
						avatarMask.transformCount = reader.ReadProperty<System.Int32> ();
						break;
					case "name":
						avatarMask.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						avatarMask.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}