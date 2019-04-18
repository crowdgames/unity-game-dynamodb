using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Flare serialization implementation.
	/// </summary>
	public class SaveGameType_Flare : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Flare );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Flare flare = ( UnityEngine.Flare )value;
			writer.WriteProperty ( "name", flare.name );
			writer.WriteProperty ( "hideFlags", flare.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Flare flare = new UnityEngine.Flare ();
			ReadInto ( flare, reader );
			return flare;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Flare flare = ( UnityEngine.Flare )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "name":
						flare.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						flare.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}