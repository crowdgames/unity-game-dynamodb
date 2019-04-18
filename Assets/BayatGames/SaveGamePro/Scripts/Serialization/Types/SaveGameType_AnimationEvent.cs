using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AnimationEvent serialization implementation.
	/// </summary>
	public class SaveGameType_AnimationEvent : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AnimationEvent );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AnimationEvent animationEvent = ( UnityEngine.AnimationEvent )value;
			writer.WriteProperty ( "stringParameter", animationEvent.stringParameter );
			writer.WriteProperty ( "floatParameter", animationEvent.floatParameter );
			writer.WriteProperty ( "intParameter", animationEvent.intParameter );
			writer.WriteProperty ( "objectReferenceParameterType", animationEvent.objectReferenceParameter.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "objectReferenceParameter", animationEvent.objectReferenceParameter );
			writer.WriteProperty ( "functionName", animationEvent.functionName );
			writer.WriteProperty ( "time", animationEvent.time );
			writer.WriteProperty ( "messageOptions", animationEvent.messageOptions );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AnimationEvent animationEvent = new UnityEngine.AnimationEvent ();
			ReadInto ( animationEvent, reader );
			return animationEvent;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AnimationEvent animationEvent = ( UnityEngine.AnimationEvent )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "stringParameter":
						animationEvent.stringParameter = reader.ReadProperty<System.String> ();
						break;
					case "floatParameter":
						animationEvent.floatParameter = reader.ReadProperty<System.Single> ();
						break;
					case "intParameter":
						animationEvent.intParameter = reader.ReadProperty<System.Int32> ();
						break;
					case "objectReferenceParameter":
						Type objectReferenceParameterType = Type.GetType ( reader.ReadProperty<System.String> () );
						animationEvent.objectReferenceParameter = ( UnityEngine.Object )reader.ReadProperty ( objectReferenceParameterType );
						break;
					case "functionName":
						animationEvent.functionName = reader.ReadProperty<System.String> ();
						break;
					case "time":
						animationEvent.time = reader.ReadProperty<System.Single> ();
						break;
					case "messageOptions":
						animationEvent.messageOptions = reader.ReadProperty<UnityEngine.SendMessageOptions> ();
						break;
				}
			}
		}
		
	}

}