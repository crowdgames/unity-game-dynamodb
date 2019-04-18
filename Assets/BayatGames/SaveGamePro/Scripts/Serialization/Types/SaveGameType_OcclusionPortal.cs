using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type OcclusionPortal serialization implementation.
	/// </summary>
	public class SaveGameType_OcclusionPortal : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.OcclusionPortal );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.OcclusionPortal occlusionPortal = ( UnityEngine.OcclusionPortal )value;
			writer.WriteProperty ( "open", occlusionPortal.open );
			writer.WriteProperty ( "tag", occlusionPortal.tag );
			writer.WriteProperty ( "name", occlusionPortal.name );
			writer.WriteProperty ( "hideFlags", occlusionPortal.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.OcclusionPortal occlusionPortal = SaveGameType.CreateComponent<UnityEngine.OcclusionPortal> ();
			ReadInto ( occlusionPortal, reader );
			return occlusionPortal;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.OcclusionPortal occlusionPortal = ( UnityEngine.OcclusionPortal )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "open":
						occlusionPortal.open = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						occlusionPortal.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						occlusionPortal.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						occlusionPortal.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}