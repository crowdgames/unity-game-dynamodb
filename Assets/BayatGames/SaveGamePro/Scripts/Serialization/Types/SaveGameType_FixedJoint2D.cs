using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type FixedJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_FixedJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.FixedJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.FixedJoint2D fixedJoint2D = ( UnityEngine.FixedJoint2D )value;
			writer.WriteProperty ( "dampingRatio", fixedJoint2D.dampingRatio );
			writer.WriteProperty ( "frequency", fixedJoint2D.frequency );
			writer.WriteProperty ( "anchor", fixedJoint2D.anchor );
			writer.WriteProperty ( "connectedAnchor", fixedJoint2D.connectedAnchor );
			writer.WriteProperty ( "autoConfigureConnectedAnchor", fixedJoint2D.autoConfigureConnectedAnchor );
			writer.WriteProperty ( "connectedBody", fixedJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", fixedJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", fixedJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", fixedJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", fixedJoint2D.enabled );
			writer.WriteProperty ( "tag", fixedJoint2D.tag );
			writer.WriteProperty ( "name", fixedJoint2D.name );
			writer.WriteProperty ( "hideFlags", fixedJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.FixedJoint2D fixedJoint2D = SaveGameType.CreateComponent<UnityEngine.FixedJoint2D> ();
			ReadInto ( fixedJoint2D, reader );
			return fixedJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.FixedJoint2D fixedJoint2D = ( UnityEngine.FixedJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "dampingRatio":
						fixedJoint2D.dampingRatio = reader.ReadProperty<System.Single> ();
						break;
					case "frequency":
						fixedJoint2D.frequency = reader.ReadProperty<System.Single> ();
						break;
					case "anchor":
						fixedJoint2D.anchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "connectedAnchor":
						fixedJoint2D.connectedAnchor = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "autoConfigureConnectedAnchor":
						fixedJoint2D.autoConfigureConnectedAnchor = reader.ReadProperty<System.Boolean> ();
						break;
					case "connectedBody":
						if ( fixedJoint2D.connectedBody == null )
						{
							fixedJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( fixedJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						fixedJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						fixedJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						fixedJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						fixedJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						fixedJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						fixedJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						fixedJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}