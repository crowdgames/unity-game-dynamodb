using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type OffMeshLink serialization implementation.
	/// </summary>
	public class SaveGameType_OffMeshLink : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AI.OffMeshLink );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AI.OffMeshLink offMeshLink = ( UnityEngine.AI.OffMeshLink )value;
			writer.WriteProperty ( "activated", offMeshLink.activated );
			writer.WriteProperty ( "costOverride", offMeshLink.costOverride );
			writer.WriteProperty ( "biDirectional", offMeshLink.biDirectional );
			writer.WriteProperty ( "area", offMeshLink.area );
			writer.WriteProperty ( "autoUpdatePositions", offMeshLink.autoUpdatePositions );
			writer.WriteProperty ( "startTransform", offMeshLink.startTransform );
			writer.WriteProperty ( "endTransform", offMeshLink.endTransform );
			writer.WriteProperty ( "enabled", offMeshLink.enabled );
			writer.WriteProperty ( "tag", offMeshLink.tag );
			writer.WriteProperty ( "name", offMeshLink.name );
			writer.WriteProperty ( "hideFlags", offMeshLink.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AI.OffMeshLink offMeshLink = SaveGameType.CreateComponent<UnityEngine.AI.OffMeshLink> ();
			ReadInto ( offMeshLink, reader );
			return offMeshLink;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AI.OffMeshLink offMeshLink = ( UnityEngine.AI.OffMeshLink )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "activated":
						offMeshLink.activated = reader.ReadProperty<System.Boolean> ();
						break;
					case "costOverride":
						offMeshLink.costOverride = reader.ReadProperty<System.Single> ();
						break;
					case "biDirectional":
						offMeshLink.biDirectional = reader.ReadProperty<System.Boolean> ();
						break;
					case "area":
						offMeshLink.area = reader.ReadProperty<System.Int32> ();
						break;
					case "autoUpdatePositions":
						offMeshLink.autoUpdatePositions = reader.ReadProperty<System.Boolean> ();
						break;
					case "startTransform":
						if ( offMeshLink.startTransform == null )
						{
							offMeshLink.startTransform = reader.ReadProperty<UnityEngine.Transform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Transform> ( offMeshLink.startTransform );
						}
						break;
					case "endTransform":
						if ( offMeshLink.endTransform == null )
						{
							offMeshLink.endTransform = reader.ReadProperty<UnityEngine.Transform> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Transform> ( offMeshLink.endTransform );
						}
						break;
					case "enabled":
						offMeshLink.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						offMeshLink.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						offMeshLink.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						offMeshLink.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}