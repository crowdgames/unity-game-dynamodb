using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SurfaceEffector2D serialization implementation.
	/// </summary>
	public class SaveGameType_SurfaceEffector2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.SurfaceEffector2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.SurfaceEffector2D surfaceEffector2D = ( UnityEngine.SurfaceEffector2D )value;
			writer.WriteProperty ( "speed", surfaceEffector2D.speed );
			writer.WriteProperty ( "speedVariation", surfaceEffector2D.speedVariation );
			writer.WriteProperty ( "forceScale", surfaceEffector2D.forceScale );
			writer.WriteProperty ( "useContactForce", surfaceEffector2D.useContactForce );
			writer.WriteProperty ( "useFriction", surfaceEffector2D.useFriction );
			writer.WriteProperty ( "useBounce", surfaceEffector2D.useBounce );
			writer.WriteProperty ( "useColliderMask", surfaceEffector2D.useColliderMask );
			writer.WriteProperty ( "colliderMask", surfaceEffector2D.colliderMask );
			writer.WriteProperty ( "enabled", surfaceEffector2D.enabled );
			writer.WriteProperty ( "tag", surfaceEffector2D.tag );
			writer.WriteProperty ( "name", surfaceEffector2D.name );
			writer.WriteProperty ( "hideFlags", surfaceEffector2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.SurfaceEffector2D surfaceEffector2D = SaveGameType.CreateComponent<UnityEngine.SurfaceEffector2D> ();
			ReadInto ( surfaceEffector2D, reader );
			return surfaceEffector2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.SurfaceEffector2D surfaceEffector2D = ( UnityEngine.SurfaceEffector2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "speed":
						surfaceEffector2D.speed = reader.ReadProperty<System.Single> ();
						break;
					case "speedVariation":
						surfaceEffector2D.speedVariation = reader.ReadProperty<System.Single> ();
						break;
					case "forceScale":
						surfaceEffector2D.forceScale = reader.ReadProperty<System.Single> ();
						break;
					case "useContactForce":
						surfaceEffector2D.useContactForce = reader.ReadProperty<System.Boolean> ();
						break;
					case "useFriction":
						surfaceEffector2D.useFriction = reader.ReadProperty<System.Boolean> ();
						break;
					case "useBounce":
						surfaceEffector2D.useBounce = reader.ReadProperty<System.Boolean> ();
						break;
					case "useColliderMask":
						surfaceEffector2D.useColliderMask = reader.ReadProperty<System.Boolean> ();
						break;
					case "colliderMask":
						surfaceEffector2D.colliderMask = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						surfaceEffector2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						surfaceEffector2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						surfaceEffector2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						surfaceEffector2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}