using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Animation serialization implementation.
	/// </summary>
	public class SaveGameType_Animation : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Animation );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Animation animation = ( UnityEngine.Animation )value;
			writer.WriteProperty ( "clip", animation.clip );
			writer.WriteProperty ( "playAutomatically", animation.playAutomatically );
			writer.WriteProperty ( "wrapMode", animation.wrapMode );
			writer.WriteProperty ( "animatePhysics", animation.animatePhysics );
			writer.WriteProperty ( "cullingType", animation.cullingType );
			writer.WriteProperty ( "localBounds", animation.localBounds );
			writer.WriteProperty ( "enabled", animation.enabled );
			writer.WriteProperty ( "tag", animation.tag );
			writer.WriteProperty ( "name", animation.name );
			writer.WriteProperty ( "hideFlags", animation.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Animation animation = SaveGameType.CreateComponent<UnityEngine.Animation> ();
			ReadInto ( animation, reader );
			return animation;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Animation animation = ( UnityEngine.Animation )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "clip":
						if ( animation.clip == null )
						{
							animation.clip = reader.ReadProperty<UnityEngine.AnimationClip> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.AnimationClip> ( animation.clip );
						}
						break;
					case "playAutomatically":
						animation.playAutomatically = reader.ReadProperty<System.Boolean> ();
						break;
					case "wrapMode":
						animation.wrapMode = reader.ReadProperty<UnityEngine.WrapMode> ();
						break;
					case "animatePhysics":
						animation.animatePhysics = reader.ReadProperty<System.Boolean> ();
						break;
					case "cullingType":
						animation.cullingType = reader.ReadProperty<UnityEngine.AnimationCullingType> ();
						break;
					case "localBounds":
						animation.localBounds = reader.ReadProperty<UnityEngine.Bounds> ();
						break;
					case "enabled":
						animation.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						animation.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						animation.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						animation.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}