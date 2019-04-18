using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type NavMeshHit serialization implementation.
	/// </summary>
	public class SaveGameType_NavMeshHit : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AI.NavMeshHit );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AI.NavMeshHit navMeshHit = ( UnityEngine.AI.NavMeshHit )value;
			writer.WriteProperty ( "position", navMeshHit.position );
			writer.WriteProperty ( "normal", navMeshHit.normal );
			writer.WriteProperty ( "distance", navMeshHit.distance );
			writer.WriteProperty ( "mask", navMeshHit.mask );
			writer.WriteProperty ( "hit", navMeshHit.hit );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AI.NavMeshHit navMeshHit = new UnityEngine.AI.NavMeshHit ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "position":
						navMeshHit.position = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "normal":
						navMeshHit.normal = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "distance":
						navMeshHit.distance = reader.ReadProperty<System.Single> ();
						break;
					case "mask":
						navMeshHit.mask = reader.ReadProperty<System.Int32> ();
						break;
					case "hit":
						navMeshHit.hit = reader.ReadProperty<System.Boolean> ();
						break;
				}
			}
			return navMeshHit;
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