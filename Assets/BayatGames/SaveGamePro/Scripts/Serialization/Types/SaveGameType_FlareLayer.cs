using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type FlareLayer serialization implementation.
	/// </summary>
	public class SaveGameType_FlareLayer : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.FlareLayer );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.FlareLayer flareLayer = ( UnityEngine.FlareLayer )value;
			writer.WriteProperty ( "enabled", flareLayer.enabled );
			writer.WriteProperty ( "tag", flareLayer.tag );
			writer.WriteProperty ( "name", flareLayer.name );
			writer.WriteProperty ( "hideFlags", flareLayer.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.FlareLayer flareLayer = SaveGameType.CreateComponent<UnityEngine.FlareLayer> ();
			ReadInto ( flareLayer, reader );
			return flareLayer;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.FlareLayer flareLayer = ( UnityEngine.FlareLayer )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						flareLayer.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						flareLayer.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						flareLayer.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						flareLayer.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}