using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AnimationState serialization implementation.
	/// </summary>
	public class SaveGameType_AnimationState : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AnimationState );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AnimationState animationState = ( UnityEngine.AnimationState )value;
			writer.WriteProperty ( "enabled", animationState.enabled );
			writer.WriteProperty ( "weight", animationState.weight );
			writer.WriteProperty ( "wrapMode", animationState.wrapMode );
			writer.WriteProperty ( "time", animationState.time );
			writer.WriteProperty ( "normalizedTime", animationState.normalizedTime );
			writer.WriteProperty ( "speed", animationState.speed );
			writer.WriteProperty ( "normalizedSpeed", animationState.normalizedSpeed );
			writer.WriteProperty ( "layer", animationState.layer );
			writer.WriteProperty ( "name", animationState.name );
			writer.WriteProperty ( "blendMode", animationState.blendMode );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AnimationState animationState = new UnityEngine.AnimationState ();
			ReadInto ( animationState, reader );
			return animationState;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AnimationState animationState = ( UnityEngine.AnimationState )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						animationState.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "weight":
						animationState.weight = reader.ReadProperty<System.Single> ();
						break;
					case "wrapMode":
						animationState.wrapMode = reader.ReadProperty<UnityEngine.WrapMode> ();
						break;
					case "time":
						animationState.time = reader.ReadProperty<System.Single> ();
						break;
					case "normalizedTime":
						animationState.normalizedTime = reader.ReadProperty<System.Single> ();
						break;
					case "speed":
						animationState.speed = reader.ReadProperty<System.Single> ();
						break;
					case "normalizedSpeed":
						animationState.normalizedSpeed = reader.ReadProperty<System.Single> ();
						break;
					case "layer":
						animationState.layer = reader.ReadProperty<System.Int32> ();
						break;
					case "name":
						animationState.name = reader.ReadProperty<System.String> ();
						break;
					case "blendMode":
						animationState.blendMode = reader.ReadProperty<UnityEngine.AnimationBlendMode> ();
						break;
				}
			}
		}
		
	}

}