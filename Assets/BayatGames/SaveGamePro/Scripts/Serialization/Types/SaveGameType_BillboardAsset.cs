using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type BillboardAsset serialization implementation.
	/// </summary>
	public class SaveGameType_BillboardAsset : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.BillboardAsset );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.BillboardAsset billboardAsset = ( UnityEngine.BillboardAsset )value;
			writer.WriteProperty ( "imageTexCoords", billboardAsset.GetImageTexCoords () );
			writer.WriteProperty ( "indices", billboardAsset.GetIndices () );
			writer.WriteProperty ( "vertices", billboardAsset.GetVertices () );
			writer.WriteProperty ( "width", billboardAsset.width );
			writer.WriteProperty ( "height", billboardAsset.height );
			writer.WriteProperty ( "bottom", billboardAsset.bottom );
			writer.WriteProperty ( "material", billboardAsset.material );
			writer.WriteProperty ( "name", billboardAsset.name );
			writer.WriteProperty ( "hideFlags", billboardAsset.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.BillboardAsset billboardAsset = new UnityEngine.BillboardAsset ();
			ReadInto ( billboardAsset, reader );
			return billboardAsset;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.BillboardAsset billboardAsset = ( UnityEngine.BillboardAsset )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "imageTexCoords":
						billboardAsset.SetImageTexCoords ( reader.ReadProperty<UnityEngine.Vector4 []> () );
						break;
					case "indices":
						billboardAsset.SetIndices ( reader.ReadProperty<ushort []> () );
						break;
					case "vertices":
						billboardAsset.SetVertices ( reader.ReadProperty<UnityEngine.Vector2 []> () );
						break;
					case "width":
						billboardAsset.width = reader.ReadProperty<System.Single> ();
						break;
					case "height":
						billboardAsset.height = reader.ReadProperty<System.Single> ();
						break;
					case "bottom":
						billboardAsset.bottom = reader.ReadProperty<System.Single> ();
						break;
					case "material":
						if ( billboardAsset.material == null )
						{
							billboardAsset.material = reader.ReadProperty<UnityEngine.Material> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Material> ( billboardAsset.material );
						}
						break;
					case "name":
						billboardAsset.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						billboardAsset.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}