using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Gradient serialization implementation.
	/// </summary>
	public class SaveGameType_Gradient : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Gradient );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Gradient gradient = ( UnityEngine.Gradient )value;
			writer.WriteProperty ( "colorKeys", gradient.colorKeys );
			writer.WriteProperty ( "alphaKeys", gradient.alphaKeys );
			writer.WriteProperty ( "mode", gradient.mode );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Gradient gradient = new UnityEngine.Gradient ();
			ReadInto ( gradient, reader );
			return gradient;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Gradient gradient = ( UnityEngine.Gradient )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "colorKeys":
						gradient.colorKeys = reader.ReadProperty<UnityEngine.GradientColorKey[]> ();
						break;
					case "alphaKeys":
						gradient.alphaKeys = reader.ReadProperty<UnityEngine.GradientAlphaKey[]> ();
						break;
					case "mode":
						gradient.mode = reader.ReadProperty<UnityEngine.GradientMode> ();
						break;
				}
			}
		}
		
	}

}