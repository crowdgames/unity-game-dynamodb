using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type SliderJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_SliderJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.SliderJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.SliderJoint2D sliderJoint2D = ( UnityEngine.SliderJoint2D )value;
			writer.WriteProperty ( "autoConfigureAngle", sliderJoint2D.autoConfigureAngle );
			writer.WriteProperty ( "angle", sliderJoint2D.angle );
			writer.WriteProperty ( "useMotor", sliderJoint2D.useMotor );
			writer.WriteProperty ( "useLimits", sliderJoint2D.useLimits );
			writer.WriteProperty ( "motor", sliderJoint2D.motor );
			writer.WriteProperty ( "limits", sliderJoint2D.limits );
			writer.WriteProperty ( "anchor", sliderJoint2D.anchor );
			writer.WriteProperty ( "connectedAnchor", sliderJoint2D.connectedAnchor );
			writer.WriteProperty ( "autoConfigureConnectedAnchor", sliderJoint2D.autoConfigureConnectedAnchor );
			writer.WriteProperty ( "connectedBody", sliderJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", sliderJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", sliderJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", sliderJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", sliderJoint2D.enabled );
			writer.WriteProperty ( "tag", sliderJoint2D.tag );
			writer.WriteProperty ( "name", sliderJoint2D.name );
			writer.WriteProperty ( "hideFlags", sliderJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.SliderJoint2D sliderJoint2D = SaveGameType.CreateComponent<UnityEngine.SliderJoint2D> ();
			ReadInto ( sliderJoint2D, reader );
			return sliderJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.SliderJoint2D sliderJoint2D = ( UnityEngine.SliderJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "autoConfigureAngle":
						sliderJoint2D.autoConfigureAngle = reader.ReadProperty<System.Boolean> ();
						break;
					case "angle":
						sliderJoint2D.angle = reader.ReadProperty<System.Single> ();
						break;
					case "useMotor":
						sliderJoint2D.useMotor = reader.ReadProperty<System.Boolean> ();
						break;
					case "useLimits":
						sliderJoint2D.useLimits = reader.ReadProperty<System.Boolean> ();
						break;
					case "motor":
						sliderJoint2D.motor = reader.ReadProperty<UnityEngine.JointMotor2D> ();
						break;
					case "limits":
						sliderJoint2D.limits = reader.ReadProperty<UnityEngine.JointTranslationLimits2D> ();
						break;
					case "anchor":
						sliderJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "connectedAnchor":
						sliderJoint2D.connectedAnchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureConnectedAnchor":
						sliderJoint2D.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean> ();
						break;
					case "connectedBody":
						if ( sliderJoint2D.connectedBody == null )
						{
							sliderJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( sliderJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						sliderJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						sliderJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						sliderJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						sliderJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						sliderJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						sliderJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						sliderJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}