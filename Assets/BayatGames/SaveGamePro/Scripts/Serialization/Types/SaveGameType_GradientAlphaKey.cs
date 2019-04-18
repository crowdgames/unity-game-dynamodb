using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type GradientAlphaKey serialization implementation.
	/// </summary>
	public class SaveGameType_GradientAlphaKey : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.GradientAlphaKey );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.GradientAlphaKey gradientAlphaKey = ( UnityEngine.GradientAlphaKey )value;
			writer.WriteProperty ( "alpha", gradientAlphaKey.alpha );
			writer.WriteProperty ( "time", gradientAlphaKey.time );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.GradientAlphaKey gradientAlphaKey = new UnityEngine.GradientAlphaKey ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "alpha":
						gradientAlphaKey.alpha = reader.ReadProperty<System.Single> ();
						break;
					case "time":
						gradientAlphaKey.time = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return gradientAlphaKey;
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