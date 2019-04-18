using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AnimationClip serialization implementation.
	/// </summary>
	public class SaveGameType_AnimationClip : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AnimationClip );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AnimationClip animationClip = ( UnityEngine.AnimationClip )value;
			writer.WriteProperty ( "frameRate", animationClip.frameRate );
			writer.WriteProperty ( "wrapMode", animationClip.wrapMode );
			writer.WriteProperty ( "localBounds", animationClip.localBounds );
			writer.WriteProperty ( "legacy", animationClip.legacy );
			writer.WriteProperty ( "events", animationClip.events );
			writer.WriteProperty ( "name", animationClip.name );
			writer.WriteProperty ( "hideFlags", animationClip.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AnimationClip animationClip = new UnityEngine.AnimationClip ();
			ReadInto ( animationClip, reader );
			return animationClip;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AnimationClip animationClip = ( UnityEngine.AnimationClip )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "frameRate":
						animationClip.frameRate = reader.ReadProperty<System.Single> ();
						break;
					case "wrapMode":
						animationClip.wrapMode = reader.ReadProperty<UnityEngine.WrapMode> ();
						break;
					case "localBounds":
						animationClip.localBounds = reader.ReadProperty<UnityEngine.Bounds> ();
						break;
					case "legacy":
						animationClip.legacy = reader.ReadProperty<System.Boolean> ();
						break;
					case "events":
						animationClip.events = reader.ReadProperty<UnityEngine.AnimationEvent[]> ();
						break;
					case "name":
						animationClip.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						animationClip.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}