using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type JointTranslationLimits2D serialization implementation.
	/// </summary>
	public class SaveGameType_JointTranslationLimits2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.JointTranslationLimits2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.JointTranslationLimits2D jointTranslationLimits2D = ( UnityEngine.JointTranslationLimits2D )value;
			writer.WriteProperty ( "min", jointTranslationLimits2D.min );
			writer.WriteProperty ( "max", jointTranslationLimits2D.max );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.JointTranslationLimits2D jointTranslationLimits2D = new UnityEngine.JointTranslationLimits2D ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "min":
						jointTranslationLimits2D.min = reader.ReadProperty<System.Single> ();
						break;
					case "max":
						jointTranslationLimits2D.max = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return jointTranslationLimits2D;
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