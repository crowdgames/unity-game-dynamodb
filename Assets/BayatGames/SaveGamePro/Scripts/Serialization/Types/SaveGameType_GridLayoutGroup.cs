using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type GridLayoutGroup serialization implementation.
	/// </summary>
	public class SaveGameType_GridLayoutGroup : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.GridLayoutGroup );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.GridLayoutGroup gridLayoutGroup = ( UnityEngine.UI.GridLayoutGroup )value;
			writer.WriteProperty ( "startCorner", gridLayoutGroup.startCorner );
			writer.WriteProperty ( "startAxis", gridLayoutGroup.startAxis );
			writer.WriteProperty ( "cellSize", gridLayoutGroup.cellSize );
			writer.WriteProperty ( "spacing", gridLayoutGroup.spacing );
			writer.WriteProperty ( "constraint", gridLayoutGroup.constraint );
			writer.WriteProperty ( "constraintCount", gridLayoutGroup.constraintCount );
			writer.WriteProperty ( "padding", gridLayoutGroup.padding );
			writer.WriteProperty ( "childAlignment", gridLayoutGroup.childAlignment );
			writer.WriteProperty ( "useGUILayout", gridLayoutGroup.useGUILayout );
			writer.WriteProperty ( "enabled", gridLayoutGroup.enabled );
			writer.WriteProperty ( "tag", gridLayoutGroup.tag );
			writer.WriteProperty ( "name", gridLayoutGroup.name );
			writer.WriteProperty ( "hideFlags", gridLayoutGroup.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.GridLayoutGroup gridLayoutGroup = SaveGameType.CreateComponent<UnityEngine.UI.GridLayoutGroup> ();
			ReadInto ( gridLayoutGroup, reader );
			return gridLayoutGroup;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.UI.GridLayoutGroup gridLayoutGroup = ( UnityEngine.UI.GridLayoutGroup )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "startCorner":
						gridLayoutGroup.startCorner = reader.ReadProperty<UnityEngine.UI.GridLayoutGroup.Corner> ();
						break;
					case "startAxis":
						gridLayoutGroup.startAxis = reader.ReadProperty<UnityEngine.UI.GridLayoutGroup.Axis> ();
						break;
					case "cellSize":
						gridLayoutGroup.cellSize = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "spacing":
						gridLayoutGroup.spacing = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "constraint":
						gridLayoutGroup.constraint = reader.ReadProperty<UnityEngine.UI.GridLayoutGroup.Constraint> ();
						break;
					case "constraintCount":
						gridLayoutGroup.constraintCount = reader.ReadProperty<System.Int32> ();
						break;
					case "padding":
						gridLayoutGroup.padding = reader.ReadProperty<UnityEngine.RectOffset> ();
						break;
					case "childAlignment":
						gridLayoutGroup.childAlignment = reader.ReadProperty<UnityEngine.TextAnchor> ();
						break;
					case "useGUILayout":
						gridLayoutGroup.useGUILayout = reader.ReadProperty<System.Boolean> ();
						break;
					case "enabled":
						gridLayoutGroup.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "tag":
						gridLayoutGroup.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						gridLayoutGroup.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						gridLayoutGroup.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}