using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AnchoredJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_AnchoredJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AnchoredJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AnchoredJoint2D anchoredJoint2D = ( UnityEngine.AnchoredJoint2D )value;
			writer.WriteProperty ( "anchor", anchoredJoint2D.anchor );
			writer.WriteProperty ( "connectedAnchor", anchoredJoint2D.connectedAnchor );
			writer.WriteProperty ( "autoConfigureConnectedAnchor", anchoredJoint2D.autoConfigureConnectedAnchor );
			writer.WriteProperty ( "connectedBody", anchoredJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", anchoredJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", anchoredJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", anchoredJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", anchoredJoint2D.enabled );
			writer.WriteProperty ( "tag", anchoredJoint2D.tag );
			writer.WriteProperty ( "name", anchoredJoint2D.name );
			writer.WriteProperty ( "hideFlags", anchoredJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AnchoredJoint2D anchoredJoint2D = SaveGameType.CreateComponent<UnityEngine.AnchoredJoint2D> ();
			ReadInto ( anchoredJoint2D, reader );
			return anchoredJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AnchoredJoint2D anchoredJoint2D = ( UnityEngine.AnchoredJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "anchor":
						anchoredJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "connectedAnchor":
						anchoredJoint2D.connectedAnchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureConnectedAnchor":
						anchoredJoint2D.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean> ();
						break;
					case "connectedBody":
						if ( anchoredJoint2D.connectedBody == null )
						{
							anchoredJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( anchoredJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						anchoredJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						anchoredJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						anchoredJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						anchoredJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						anchoredJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						anchoredJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						anchoredJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}