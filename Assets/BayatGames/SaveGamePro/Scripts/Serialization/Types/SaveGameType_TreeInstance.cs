using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type TreeInstance serialization implementation.
	/// </summary>
	public class SaveGameType_TreeInstance : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.TreeInstance );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.TreeInstance treeInstance = ( UnityEngine.TreeInstance )value;
			writer.WriteProperty ( "position", treeInstance.position );
			writer.WriteProperty ( "widthScale", treeInstance.widthScale );
			writer.WriteProperty ( "heightScale", treeInstance.heightScale );
			writer.WriteProperty ( "rotation", treeInstance.rotation );
			writer.WriteProperty ( "color", treeInstance.color );
			writer.WriteProperty ( "lightmapColor", treeInstance.lightmapColor );
			writer.WriteProperty ( "prototypeIndex", treeInstance.prototypeIndex );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.TreeInstance treeInstance = new UnityEngine.TreeInstance ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "position":
						treeInstance.position = reader.ReadProperty<UnityEngine.Vector3> ();
						break;
					case "widthScale":
						treeInstance.widthScale = reader.ReadProperty<System.Single> ();
						break;
					case "heightScale":
						treeInstance.heightScale = reader.ReadProperty<System.Single> ();
						break;
					case "rotation":
						treeInstance.rotation = reader.ReadProperty<System.Single> ();
						break;
					case "color":
						treeInstance.color = reader.ReadProperty<UnityEngine.Color32> ();
						break;
					case "lightmapColor":
						treeInstance.lightmapColor = reader.ReadProperty<UnityEngine.Color32> ();
						break;
					case "prototypeIndex":
						treeInstance.prototypeIndex = reader.ReadProperty<System.Int32> ();
						break;
				}
			}
			return treeInstance;
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