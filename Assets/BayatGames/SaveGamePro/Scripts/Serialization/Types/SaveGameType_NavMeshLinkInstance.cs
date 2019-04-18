using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type NavMeshLinkInstance serialization implementation.
	/// </summary>
	public class SaveGameType_NavMeshLinkInstance : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AI.NavMeshLinkInstance );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AI.NavMeshLinkInstance navMeshLinkInstance = ( UnityEngine.AI.NavMeshLinkInstance )value;
			writer.WriteProperty ( "ownerType", navMeshLinkInstance.owner.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "owner", navMeshLinkInstance.owner );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AI.NavMeshLinkInstance navMeshLinkInstance = new UnityEngine.AI.NavMeshLinkInstance ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "owner":
						Type ownerType = Type.GetType ( reader.ReadProperty<System.String> () );
						navMeshLinkInstance.owner = ( UnityEngine.Object )reader.ReadProperty ( ownerType );
						break;
				}
			}
			return navMeshLinkInstance;
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