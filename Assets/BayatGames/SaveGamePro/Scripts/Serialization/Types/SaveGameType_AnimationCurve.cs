using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AnimationCurve serialization implementation.
	/// </summary>
	public class SaveGameType_AnimationCurve : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AnimationCurve );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AnimationCurve animationCurve = ( UnityEngine.AnimationCurve )value;
			writer.WriteProperty ( "keys", animationCurve.keys );
			writer.WriteProperty ( "preWrapMode", animationCurve.preWrapMode );
			writer.WriteProperty ( "postWrapMode", animationCurve.postWrapMode );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AnimationCurve animationCurve = new UnityEngine.AnimationCurve ();
			ReadInto ( animationCurve, reader );
			return animationCurve;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AnimationCurve animationCurve = ( UnityEngine.AnimationCurve )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "keys":
						animationCurve.keys = reader.ReadProperty<UnityEngine.Keyframe[]> ();
						break;
					case "preWrapMode":
						animationCurve.preWrapMode = reader.ReadProperty<UnityEngine.WrapMode> ();
						break;
					case "postWrapMode":
						animationCurve.postWrapMode = reader.ReadProperty<UnityEngine.WrapMode> ();
						break;
				}
			}
		}
		
	}

}