using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Projector serialization implementation.
	/// </summary>
	public class SaveGameType_Projector : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Projector );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Projector projector = ( UnityEngine.Projector )value;
			writer.WriteProperty ( "nearClipPlane", projector.nearClipPlane );
			writer.WriteProperty ( "farClipPlane", projector.farClipPlane );
			writer.WriteProperty ( "fieldOfView", projector.fieldOfView );
			writer.WriteProperty ( "aspectRatio", projector.aspectRatio );
			writer.WriteProperty ( "orthographic", projector.orthographic );
			writer.WriteProperty ( "orthographicSize", projector.orthographicSize );
			writer.WriteProperty ( "ignoreLayers", projector.ignoreLayers );
			writer.WriteProperty ( "material", projector.material );
			writer.WriteProperty ( "enabled", projector.enabled );
			writer.WriteProperty ( "tag", projector.tag );
			writer.WriteProperty ( "name", projector.name );
			writer.WriteProperty ( "hideFlags", projector.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Projector projector = SaveGameType.CreateComponent<UnityEngine.Projector> ();
			ReadInto ( projector, reader );
			return projector;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Projector projector = ( UnityEngine.Projector )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "nearClipPlane":
						projector.nearClipPlane = reader.ReadProperty<System.Single> ();
						break;
					case "farClipPlane":
						projector.farClipPlane = reader.ReadProperty<System.Single> ();
						break;
					case "fieldOfView":
						projector.fieldOfView = reader.ReadProperty<System.Single> ();
						break;
					case "aspectRatio":
						projector.aspectRatio = reader.ReadProperty<System.Single> ();
						break;
					case "orthographic":
						projector.orthographic = reader.ReadProperty<System.Boolean> ();
						break;
					case "orthographicSize":
						projector.orthographicSize = reader.ReadProperty<System.Single> ();
						break;
					case "ignoreLayers":
						projector.ignoreLayers = reader.ReadProperty<System.Int32> ();
						break;
					case "material":
						if ( projector.material == null )
						{
							projector.material = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( projector.material );
						}
						break;
					case "enabled":
						projector.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						projector.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						projector.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						projector.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}