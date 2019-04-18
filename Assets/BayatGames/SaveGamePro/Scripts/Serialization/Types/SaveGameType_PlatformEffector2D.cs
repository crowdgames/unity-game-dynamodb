using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type PlatformEffector2D serialization implementation.
	/// </summary>
	public class SaveGameType_PlatformEffector2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.PlatformEffector2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.PlatformEffector2D platformEffector2D = ( UnityEngine.PlatformEffector2D )value;
			writer.WriteProperty ( "useOneWay", platformEffector2D.useOneWay );
			writer.WriteProperty ( "useOneWayGrouping", platformEffector2D.useOneWayGrouping );
			writer.WriteProperty ( "useSideFriction", platformEffector2D.useSideFriction );
			writer.WriteProperty ( "useSideBounce", platformEffector2D.useSideBounce );
			writer.WriteProperty ( "surfaceArc", platformEffector2D.surfaceArc );
			writer.WriteProperty ( "sideArc", platformEffector2D.sideArc );
			writer.WriteProperty ( "rotationalOffset", platformEffector2D.rotationalOffset );
			writer.WriteProperty ( "useColliderMask", platformEffector2D.useColliderMask );
			writer.WriteProperty ( "colliderMask", platformEffector2D.colliderMask );
			writer.WriteProperty ( "enabled", platformEffector2D.enabled );
			writer.WriteProperty ( "tag", platformEffector2D.tag );
			writer.WriteProperty ( "name", platformEffector2D.name );
			writer.WriteProperty ( "hideFlags", platformEffector2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.PlatformEffector2D platformEffector2D = SaveGameType.CreateComponent<UnityEngine.PlatformEffector2D> ();
			ReadInto ( platformEffector2D, reader );
			return platformEffector2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.PlatformEffector2D platformEffector2D = ( UnityEngine.PlatformEffector2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "useOneWay":
						platformEffector2D.useOneWay = reader.ReadProperty<System.Boolean> ();
						break;
					case "useOneWayGrouping":
						platformEffector2D.useOneWayGrouping = reader.ReadProperty<System.Boolean> ();
						break;
					case "useSideFriction":
						platformEffector2D.useSideFriction = reader.ReadProperty<System.Boolean> ();
						break;
					case "useSideBounce":
						platformEffector2D.useSideBounce = reader.ReadProperty<System.Boolean> ();
						break;
					case "surfaceArc":
						platformEffector2D.surfaceArc = reader.ReadProperty<System.Single> ();
						break;
					case "sideArc":
						platformEffector2D.sideArc = reader.ReadProperty<System.Single> ();
						break;
					case "rotationalOffset":
						platformEffector2D.rotationalOffset = reader.ReadProperty<System.Single> ();
						break;
					case "useColliderMask":
						platformEffector2D.useColliderMask = reader.ReadProperty<System.Boolean> ();
						break;
					case "colliderMask":
						platformEffector2D.colliderMask = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						platformEffector2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						platformEffector2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						platformEffector2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						platformEffector2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}