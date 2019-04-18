using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type OcclusionArea serialization implementation.
	/// </summary>
	public class SaveGameType_OcclusionArea : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.OcclusionArea );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.OcclusionArea occlusionArea = ( UnityEngine.OcclusionArea )value;
			writer.WriteProperty ( "center", occlusionArea.center );
			writer.WriteProperty ( "size", occlusionArea.size );
			writer.WriteProperty ( "tag", occlusionArea.tag );
			writer.WriteProperty ( "name", occlusionArea.name );
			writer.WriteProperty ( "hideFlags", occlusionArea.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.OcclusionArea occlusionArea = SaveGameType.CreateComponent<UnityEngine.OcclusionArea> ();
			ReadInto ( occlusionArea, reader );
			return occlusionArea;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.OcclusionArea occlusionArea = ( UnityEngine.OcclusionArea )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "center":
						occlusionArea.center = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "size":
						occlusionArea.size = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "tag":
						occlusionArea.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						occlusionArea.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						occlusionArea.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}