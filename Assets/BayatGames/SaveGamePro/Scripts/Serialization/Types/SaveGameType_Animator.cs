using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Animator serialization implementation.
	/// </summary>
	public class SaveGameType_Animator : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Animator );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Animator animator = ( UnityEngine.Animator )value;
			writer.WriteProperty ( "rootPosition", animator.rootPosition );
			writer.WriteProperty ( "rootRotation", animator.rootRotation );
			writer.WriteProperty ( "applyRootMotion", animator.applyRootMotion );
			writer.WriteProperty ( "linearVelocityBlending", animator.linearVelocityBlending );
			writer.WriteProperty ( "updateMode", animator.updateMode );
			writer.WriteProperty ( "bodyPosition", animator.bodyPosition );
			writer.WriteProperty ( "bodyRotation", animator.bodyRotation );
			writer.WriteProperty ( "stabilizeFeet", animator.stabilizeFeet );
			writer.WriteProperty ( "feetPivotActive", animator.feetPivotActive );
			writer.WriteProperty ( "speed", animator.speed );
			writer.WriteProperty ( "cullingMode", animator.cullingMode );
			writer.WriteProperty ( "playbackTime", animator.playbackTime );
			writer.WriteProperty ( "recorderStartTime", animator.recorderStartTime );
			writer.WriteProperty ( "recorderStopTime", animator.recorderStopTime );
			writer.WriteProperty ( "runtimeAnimatorController", animator.runtimeAnimatorController );
			writer.WriteProperty ( "avatar", animator.avatar );
			writer.WriteProperty ( "layersAffectMassCenter", animator.layersAffectMassCenter );
			writer.WriteProperty ( "logWarnings", animator.logWarnings );
			writer.WriteProperty ( "fireEvents", animator.fireEvents );
			writer.WriteProperty ( "enabled", animator.enabled );
			writer.WriteProperty ( "tag", animator.tag );
			writer.WriteProperty ( "name", animator.name );
			writer.WriteProperty ( "hideFlags", animator.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Animator animator = SaveGameType.CreateComponent<UnityEngine.Animator> ();
			ReadInto ( animator, reader );
			return animator;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Animator animator = ( UnityEngine.Animator )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "rootPosition":
						animator.rootPosition = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "rootRotation":
						animator.rootRotation = reader.ReadProperty<UnityEngine.Quaternion> ();
						break;
					case "applyRootMotion":
						animator.applyRootMotion = reader.ReadProperty<System.Boolean> ();
						break;
					case "linearVelocityBlending":
						animator.linearVelocityBlending = reader.ReadProperty<System.Boolean> ();
						break;
					case "updateMode":
						animator.updateMode = reader.ReadProperty<UnityEngine.AnimatorUpdateMode> ();
						break;
					case "bodyPosition":
						animator.bodyPosition = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "bodyRotation":
						animator.bodyRotation = reader.ReadProperty<UnityEngine.Quaternion> ();
						break;
					case "stabilizeFeet":
						animator.stabilizeFeet = reader.ReadProperty<System.Boolean> ();
						break;
					case "feetPivotActive":
						animator.feetPivotActive = reader.ReadProperty<System.Single> ();
						break;
					case "speed":
						animator.speed = reader.ReadProperty<System.Single> ();
						break;
					case "cullingMode":
						animator.cullingMode = reader.ReadProperty<UnityEngine.AnimatorCullingMode> ();
						break;
					case "playbackTime":
						animator.playbackTime = reader.ReadProperty<System.Single> ();
						break;
					case "recorderStartTime":
						animator.recorderStartTime = reader.ReadProperty<System.Single> ();
						break;
					case "recorderStopTime":
						animator.recorderStopTime = reader.ReadProperty<System.Single> ();
						break;
					case "runtimeAnimatorController":
						if ( animator.runtimeAnimatorController == null )
						{
							animator.runtimeAnimatorController = reader.ReadProperty<UnityEngine.RuntimeAnimatorController> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.RuntimeAnimatorController> ( animator.runtimeAnimatorController );
						}
						break;
					case "avatar":
						if ( animator.avatar == null )
						{
							animator.avatar = reader.ReadProperty<UnityEngine.Avatar> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Avatar> ( animator.avatar );
						}
						break;
					case "layersAffectMassCenter":
						animator.layersAffectMassCenter = reader.ReadProperty<System.Boolean> ();
						break;
					case "logWarnings":
						animator.logWarnings = reader.ReadProperty<System.Boolean> ();
						break;
					case "fireEvents":
						animator.fireEvents = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						animator.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						animator.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						animator.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						animator.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}