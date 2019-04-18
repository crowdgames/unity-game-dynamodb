using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type BuoyancyEffector2D serialization implementation.
	/// </summary>
	public class SaveGameType_BuoyancyEffector2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.BuoyancyEffector2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.BuoyancyEffector2D buoyancyEffector2D = ( UnityEngine.BuoyancyEffector2D )value;
			writer.WriteProperty ( "surfaceLevel", buoyancyEffector2D.surfaceLevel );
			writer.WriteProperty ( "density", buoyancyEffector2D.density );
			writer.WriteProperty ( "linearDrag", buoyancyEffector2D.linearDrag );
			writer.WriteProperty ( "angularDrag", buoyancyEffector2D.angularDrag );
			writer.WriteProperty ( "flowAngle", buoyancyEffector2D.flowAngle );
			writer.WriteProperty ( "flowMagnitude", buoyancyEffector2D.flowMagnitude );
			writer.WriteProperty ( "flowVariation", buoyancyEffector2D.flowVariation );
			writer.WriteProperty ( "useColliderMask", buoyancyEffector2D.useColliderMask );
			writer.WriteProperty ( "colliderMask", buoyancyEffector2D.colliderMask );
			writer.WriteProperty ( "enabled", buoyancyEffector2D.enabled );
			writer.WriteProperty ( "tag", buoyancyEffector2D.tag );
			writer.WriteProperty ( "name", buoyancyEffector2D.name );
			writer.WriteProperty ( "hideFlags", buoyancyEffector2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.BuoyancyEffector2D buoyancyEffector2D = SaveGameType.CreateComponent<UnityEngine.BuoyancyEffector2D> ();
			ReadInto ( buoyancyEffector2D, reader );
			return buoyancyEffector2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.BuoyancyEffector2D buoyancyEffector2D = ( UnityEngine.BuoyancyEffector2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "surfaceLevel":
						buoyancyEffector2D.surfaceLevel = reader.ReadProperty<System.Single> ();
						break;
					case "density":
						buoyancyEffector2D.density = reader.ReadProperty<System.Single> ();
						break;
					case "linearDrag":
						buoyancyEffector2D.linearDrag = reader.ReadProperty<System.Single> ();
						break;
					case "angularDrag":
						buoyancyEffector2D.angularDrag = reader.ReadProperty<System.Single> ();
						break;
					case "flowAngle":
						buoyancyEffector2D.flowAngle = reader.ReadProperty<System.Single> ();
						break;
					case "flowMagnitude":
						buoyancyEffector2D.flowMagnitude = reader.ReadProperty<System.Single> ();
						break;
					case "flowVariation":
						buoyancyEffector2D.flowVariation = reader.ReadProperty<System.Single> ();
						break;
					case "useColliderMask":
						buoyancyEffector2D.useColliderMask = reader.ReadProperty<System.Boolean> ();
						break;
					case "colliderMask":
						buoyancyEffector2D.colliderMask = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						buoyancyEffector2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						buoyancyEffector2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						buoyancyEffector2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						buoyancyEffector2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}