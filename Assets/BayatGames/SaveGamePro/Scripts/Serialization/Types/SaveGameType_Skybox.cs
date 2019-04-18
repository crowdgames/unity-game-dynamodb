using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Skybox serialization implementation.
	/// </summary>
	public class SaveGameType_Skybox : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Skybox );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Skybox skybox = ( UnityEngine.Skybox )value;
			writer.WriteProperty ( "material", skybox.material );
			writer.WriteProperty ( "enabled", skybox.enabled );
			writer.WriteProperty ( "tag", skybox.tag );
			writer.WriteProperty ( "name", skybox.name );
			writer.WriteProperty ( "hideFlags", skybox.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Skybox skybox = SaveGameType.CreateComponent<UnityEngine.Skybox> ();
			ReadInto ( skybox, reader );
			return skybox;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Skybox skybox = ( UnityEngine.Skybox )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "material":
						if ( skybox.material == null )
						{
							skybox.material = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( skybox.material );
						}
						break;
					case "enabled":
						skybox.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						skybox.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						skybox.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						skybox.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}