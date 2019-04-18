using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type NavMeshQueryFilter serialization implementation.
	/// </summary>
	public class SaveGameType_NavMeshQueryFilter : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AI.NavMeshQueryFilter );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AI.NavMeshQueryFilter navMeshQueryFilter = ( UnityEngine.AI.NavMeshQueryFilter )value;
			writer.WriteProperty ( "areaMask", navMeshQueryFilter.areaMask );
			writer.WriteProperty ( "agentTypeID", navMeshQueryFilter.agentTypeID );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AI.NavMeshQueryFilter navMeshQueryFilter = new UnityEngine.AI.NavMeshQueryFilter ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "areaMask":
						navMeshQueryFilter.areaMask = reader.ReadProperty<System.Int32> ();
						break;
					case "agentTypeID":
						navMeshQueryFilter.agentTypeID = reader.ReadProperty<System.Int32> ();
						break;
				}
			}
			return navMeshQueryFilter;
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