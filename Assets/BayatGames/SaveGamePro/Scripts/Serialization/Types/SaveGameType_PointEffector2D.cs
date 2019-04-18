using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type PointEffector2D serialization implementation.
	/// </summary>
	public class SaveGameType_PointEffector2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.PointEffector2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.PointEffector2D pointEffector2D = ( UnityEngine.PointEffector2D )value;
			writer.WriteProperty ( "forceMagnitude", pointEffector2D.forceMagnitude );
			writer.WriteProperty ( "forceVariation", pointEffector2D.forceVariation );
			writer.WriteProperty ( "distanceScale", pointEffector2D.distanceScale );
			writer.WriteProperty ( "drag", pointEffector2D.drag );
			writer.WriteProperty ( "angularDrag", pointEffector2D.angularDrag );
			writer.WriteProperty ( "forceSource", pointEffector2D.forceSource );
			writer.WriteProperty ( "forceTarget", pointEffector2D.forceTarget );
			writer.WriteProperty ( "forceMode", pointEffector2D.forceMode );
			writer.WriteProperty ( "useColliderMask", pointEffector2D.useColliderMask );
			writer.WriteProperty ( "colliderMask", pointEffector2D.colliderMask );
			writer.WriteProperty ( "enabled", pointEffector2D.enabled );
			writer.WriteProperty ( "tag", pointEffector2D.tag );
			writer.WriteProperty ( "name", pointEffector2D.name );
			writer.WriteProperty ( "hideFlags", pointEffector2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.PointEffector2D pointEffector2D = SaveGameType.CreateComponent<UnityEngine.PointEffector2D> ();
			ReadInto ( pointEffector2D, reader );
			return pointEffector2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.PointEffector2D pointEffector2D = ( UnityEngine.PointEffector2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "forceMagnitude":
						pointEffector2D.forceMagnitude = reader.ReadProperty<System.Single> ();
						break;
					case "forceVariation":
						pointEffector2D.forceVariation = reader.ReadProperty<System.Single> ();
						break;
					case "distanceScale":
						pointEffector2D.distanceScale = reader.ReadProperty<System.Single> ();
						break;
					case "drag":
						pointEffector2D.drag = reader.ReadProperty<System.Single> ();
						break;
					case "angularDrag":
						pointEffector2D.angularDrag = reader.ReadProperty<System.Single> ();
						break;
					case "forceSource":
						pointEffector2D.forceSource = reader.ReadProperty<UnityEngine.EffectorSelection2D> ();
						break;
					case "forceTarget":
						pointEffector2D.forceTarget = reader.ReadProperty<UnityEngine.EffectorSelection2D> ();
						break;
					case "forceMode":
						pointEffector2D.forceMode = reader.ReadProperty<UnityEngine.EffectorForceMode2D> ();
						break;
					case "useColliderMask":
						pointEffector2D.useColliderMask = reader.ReadProperty<System.Boolean> ();
						break;
					case "colliderMask":
						pointEffector2D.colliderMask = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						pointEffector2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						pointEffector2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						pointEffector2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						pointEffector2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}