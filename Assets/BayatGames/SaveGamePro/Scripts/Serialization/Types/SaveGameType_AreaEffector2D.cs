using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AreaEffector2D serialization implementation.
	/// </summary>
	public class SaveGameType_AreaEffector2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AreaEffector2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AreaEffector2D areaEffector2D = ( UnityEngine.AreaEffector2D )value;
			writer.WriteProperty ( "forceAngle", areaEffector2D.forceAngle );
			writer.WriteProperty ( "useGlobalAngle", areaEffector2D.useGlobalAngle );
			writer.WriteProperty ( "forceMagnitude", areaEffector2D.forceMagnitude );
			writer.WriteProperty ( "forceVariation", areaEffector2D.forceVariation );
			writer.WriteProperty ( "drag", areaEffector2D.drag );
			writer.WriteProperty ( "angularDrag", areaEffector2D.angularDrag );
			writer.WriteProperty ( "forceTarget", areaEffector2D.forceTarget );
			writer.WriteProperty ( "useColliderMask", areaEffector2D.useColliderMask );
			writer.WriteProperty ( "colliderMask", areaEffector2D.colliderMask );
			writer.WriteProperty ( "enabled", areaEffector2D.enabled );
			writer.WriteProperty ( "tag", areaEffector2D.tag );
			writer.WriteProperty ( "name", areaEffector2D.name );
			writer.WriteProperty ( "hideFlags", areaEffector2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AreaEffector2D areaEffector2D = SaveGameType.CreateComponent<UnityEngine.AreaEffector2D> ();
			ReadInto ( areaEffector2D, reader );
			return areaEffector2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AreaEffector2D areaEffector2D = ( UnityEngine.AreaEffector2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "forceAngle":
						areaEffector2D.forceAngle = reader.ReadProperty<System.Single> ();
						break;
					case "useGlobalAngle":
						areaEffector2D.useGlobalAngle = reader.ReadProperty<System.Boolean> ();
						break;
					case "forceMagnitude":
						areaEffector2D.forceMagnitude = reader.ReadProperty<System.Single> ();
						break;
					case "forceVariation":
						areaEffector2D.forceVariation = reader.ReadProperty<System.Single> ();
						break;
					case "drag":
						areaEffector2D.drag = reader.ReadProperty<System.Single> ();
						break;
					case "angularDrag":
						areaEffector2D.angularDrag = reader.ReadProperty<System.Single> ();
						break;
					case "forceTarget":
						areaEffector2D.forceTarget = reader.ReadProperty<UnityEngine.EffectorSelection2D> ();
						break;
					case "useColliderMask":
						areaEffector2D.useColliderMask = reader.ReadProperty<System.Boolean> ();
						break;
					case "colliderMask":
						areaEffector2D.colliderMask = reader.ReadProperty<System.Int32> ();
						break;
					case "enabled":
						areaEffector2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						areaEffector2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						areaEffector2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						areaEffector2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}