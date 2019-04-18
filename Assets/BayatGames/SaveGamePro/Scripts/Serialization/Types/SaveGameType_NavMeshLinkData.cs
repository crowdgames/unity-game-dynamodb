using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type NavMeshLinkData serialization implementation.
	/// </summary>
	public class SaveGameType_NavMeshLinkData : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AI.NavMeshLinkData );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AI.NavMeshLinkData navMeshLinkData = ( UnityEngine.AI.NavMeshLinkData )value;
			writer.WriteProperty ( "startPosition", navMeshLinkData.startPosition );
			writer.WriteProperty ( "endPosition", navMeshLinkData.endPosition );
			writer.WriteProperty ( "costModifier", navMeshLinkData.costModifier );
			writer.WriteProperty ( "bidirectional", navMeshLinkData.bidirectional );
			writer.WriteProperty ( "width", navMeshLinkData.width );
			writer.WriteProperty ( "area", navMeshLinkData.area );
			writer.WriteProperty ( "agentTypeID", navMeshLinkData.agentTypeID );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AI.NavMeshLinkData navMeshLinkData = new UnityEngine.AI.NavMeshLinkData ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "startPosition":
						navMeshLinkData.startPosition = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "endPosition":
						navMeshLinkData.endPosition = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "costModifier":
						navMeshLinkData.costModifier = reader.ReadProperty<System.Single> ();
						break;
					case "bidirectional":
						navMeshLinkData.bidirectional = reader.ReadProperty<System.Boolean> ();
						break;
					case "width":
						navMeshLinkData.width = reader.ReadProperty<System.Single> ();
						break;
					case "area":
						navMeshLinkData.area = reader.ReadProperty<System.Int32> ();
						break;
					case "agentTypeID":
						navMeshLinkData.agentTypeID = reader.ReadProperty<System.Int32> ();
						break;
				}
			}
			return navMeshLinkData;
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