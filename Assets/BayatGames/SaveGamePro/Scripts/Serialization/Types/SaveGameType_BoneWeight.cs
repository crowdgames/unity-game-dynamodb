using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type BoneWeight serialization implementation.
	/// </summary>
	public class SaveGameType_BoneWeight : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.BoneWeight );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.BoneWeight boneWeight = ( UnityEngine.BoneWeight )value;
			writer.WriteProperty ( "weight0", boneWeight.weight0 );
			writer.WriteProperty ( "weight1", boneWeight.weight1 );
			writer.WriteProperty ( "weight2", boneWeight.weight2 );
			writer.WriteProperty ( "weight3", boneWeight.weight3 );
			writer.WriteProperty ( "boneIndex0", boneWeight.boneIndex0 );
			writer.WriteProperty ( "boneIndex1", boneWeight.boneIndex1 );
			writer.WriteProperty ( "boneIndex2", boneWeight.boneIndex2 );
			writer.WriteProperty ( "boneIndex3", boneWeight.boneIndex3 );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.BoneWeight boneWeight = new UnityEngine.BoneWeight ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "weight0":
						boneWeight.weight0 = reader.ReadProperty<System.Single> ();
						break;
					case "weight1":
						boneWeight.weight1 = reader.ReadProperty<System.Single> ();
						break;
					case "weight2":
						boneWeight.weight2 = reader.ReadProperty<System.Single> ();
						break;
					case "weight3":
						boneWeight.weight3 = reader.ReadProperty<System.Single> ();
						break;
					case "boneIndex0":
						boneWeight.boneIndex0 = reader.ReadProperty<System.Int32> ();
						break;
					case "boneIndex1":
						boneWeight.boneIndex1 = reader.ReadProperty<System.Int32> ();
						break;
					case "boneIndex2":
						boneWeight.boneIndex2 = reader.ReadProperty<System.Int32> ();
						break;
					case "boneIndex3":
						boneWeight.boneIndex3 = reader.ReadProperty<System.Int32> ();
						break;
				}
			}
			return boneWeight;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			base.ReadInto ( value, reader );
		}
		
	}

}