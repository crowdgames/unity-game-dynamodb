using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type NavMeshDataInstance serialization implementation.
	/// </summary>
	public class SaveGameType_NavMeshDataInstance : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AI.NavMeshDataInstance );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AI.NavMeshDataInstance navMeshDataInstance = ( UnityEngine.AI.NavMeshDataInstance )value;
			writer.WriteProperty ( "ownerType", navMeshDataInstance.owner.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "owner", navMeshDataInstance.owner );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AI.NavMeshDataInstance navMeshDataInstance = new UnityEngine.AI.NavMeshDataInstance ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "owner":
						Type ownerType = Type.GetType ( reader.ReadProperty<System.String> () );
						navMeshDataInstance.owner = ( UnityEngine.Object )reader.ReadProperty ( ownerType );
						break;
				}
			}
			return navMeshDataInstance;
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