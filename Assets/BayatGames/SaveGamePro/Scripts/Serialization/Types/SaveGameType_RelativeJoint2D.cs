using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type RelativeJoint2D serialization implementation.
	/// </summary>
	public class SaveGameType_RelativeJoint2D : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.RelativeJoint2D );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.RelativeJoint2D relativeJoint2D = ( UnityEngine.RelativeJoint2D )value;
			writer.WriteProperty ( "maxForce", relativeJoint2D.maxForce );
			writer.WriteProperty ( "maxTorque", relativeJoint2D.maxTorque );
			writer.WriteProperty ( "correctionScale", relativeJoint2D.correctionScale );
			writer.WriteProperty ( "autoConfigureOffset", relativeJoint2D.autoConfigureOffset );
			writer.WriteProperty ( "linearOffset", relativeJoint2D.linearOffset );
			writer.WriteProperty ( "angularOffset", relativeJoint2D.angularOffset );
			writer.WriteProperty ( "connectedBody", relativeJoint2D.connectedBody );
			writer.WriteProperty ( "enableCollision", relativeJoint2D.enableCollision );
			writer.WriteProperty ( "breakForce", relativeJoint2D.breakForce );
			writer.WriteProperty ( "breakTorque", relativeJoint2D.breakTorque );
			writer.WriteProperty ( "enabled", relativeJoint2D.enabled );
			writer.WriteProperty ( "tag", relativeJoint2D.tag );
			writer.WriteProperty ( "name", relativeJoint2D.name );
			writer.WriteProperty ( "hideFlags", relativeJoint2D.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.RelativeJoint2D relativeJoint2D = SaveGameType.CreateComponent<UnityEngine.RelativeJoint2D> ();
			ReadInto ( relativeJoint2D, reader );
			return relativeJoint2D;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.RelativeJoint2D relativeJoint2D = ( UnityEngine.RelativeJoint2D )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "maxForce":
						relativeJoint2D.maxForce = reader.ReadProperty<System.Single> ();
						break;
					case "maxTorque":
						relativeJoint2D.maxTorque = reader.ReadProperty<System.Single> ();
						break;
					case "correctionScale":
						relativeJoint2D.correctionScale = reader.ReadProperty<System.Single> ();
						break;
					case "autoConfigureOffset":
						relativeJoint2D.autoConfigureOffset = reader.ReadProperty<System.Boolean> ();
						break;
					case "linearOffset":
						relativeJoint2D.linearOffset = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "angularOffset":
						relativeJoint2D.angularOffset = reader.ReadProperty<System.Single> ();
						break;
					case "connectedBody":
						if ( relativeJoint2D.connectedBody == null )
						{
							relativeJoint2D.connectedBody = reader.ReadProperty<UnityEngine.Rigidbody2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Rigidbody2D> ( relativeJoint2D.connectedBody );
						}
						break;
					case "enableCollision":
						relativeJoint2D.enableCollision = reader.ReadProperty<System.Boolean> ();
						break;
					case "breakForce":
						relativeJoint2D.breakForce = reader.ReadProperty<System.Single> ();
						break;
					case "breakTorque":
						relativeJoint2D.breakTorque = reader.ReadProperty<System.Single> ();
						break;
					case "enabled":
						relativeJoint2D.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						relativeJoint2D.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						relativeJoint2D.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						relativeJoint2D.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}