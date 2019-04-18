using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Effector2D serialization implementation.
	/// </summary>
	public class SaveGameType_Effector2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Effector2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Effector2D effector2D = ( UnityEngine.Effector2D )value;
			writer.WriteProperty ( "useColliderMask", effector2D.useColliderMask );
			writer.WriteProperty ( "colliderMask", effector2D.colliderMask );
			writer.WriteProperty ( "enabled", effector2D.enabled );
			writer.WriteProperty ( "tag", effector2D.tag );
			writer.WriteProperty ( "name", effector2D.name );
			writer.WriteProperty ( "hideFlags", effector2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Effector2D effector2D = SaveGameType.CreateComponent<UnityEngine.Effector2D> ();
			ReadInto ( effector2D, reader );
			return effector2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Effector2D effector2D = ( UnityEngine.Effector2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "useColliderMask":
						effector2D.useColliderMask = reader.ReadProperty<System.Boolean> ();
						break;
					case "colliderMask":
						effector2D.colliderMask = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						effector2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						effector2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						effector2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						effector2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}