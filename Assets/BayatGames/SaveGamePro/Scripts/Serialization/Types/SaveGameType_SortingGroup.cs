using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SortingGroup serialization implementation.
	/// </summary>
	public class SaveGameType_SortingGroup : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Rendering.SortingGroup );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Rendering.SortingGroup sortingGroup = ( UnityEngine.Rendering.SortingGroup )value;
			writer.WriteProperty ( "sortingLayerName", sortingGroup.sortingLayerName );
			writer.WriteProperty ( "sortingLayerID", sortingGroup.sortingLayerID );
			writer.WriteProperty ( "sortingOrder", sortingGroup.sortingOrder );
			writer.WriteProperty ( "enabled", sortingGroup.enabled );
			writer.WriteProperty ( "tag", sortingGroup.tag );
			writer.WriteProperty ( "name", sortingGroup.name );
			writer.WriteProperty ( "hideFlags", sortingGroup.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Rendering.SortingGroup sortingGroup = SaveGameType.CreateComponent<UnityEngine.Rendering.SortingGroup> ();
			ReadInto ( sortingGroup, reader );
			return sortingGroup;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Rendering.SortingGroup sortingGroup = ( UnityEngine.Rendering.SortingGroup )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "sortingLayerName":
						sortingGroup.sortingLayerName = reader.ReadProperty<System.String> ();
						break;
					case "sortingLayerID":
						sortingGroup.sortingLayerID = reader.ReadProperty<System.Int32> ();
						break;
					case "sortingOrder":
						sortingGroup.sortingOrder = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						sortingGroup.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						sortingGroup.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						sortingGroup.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						sortingGroup.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}