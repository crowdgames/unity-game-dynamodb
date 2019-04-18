using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Rect serialization implementation.
	/// </summary>
	public class SaveGameType_Rect : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Rect );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Rect rect = ( UnityEngine.Rect )value;
			writer.WriteProperty ( "x", rect.x );
			writer.WriteProperty ( "y", rect.y );
			writer.WriteProperty ( "position", rect.position );
			writer.WriteProperty ( "center", rect.center );
			writer.WriteProperty ( "min", rect.min );
			writer.WriteProperty ( "max", rect.max );
			writer.WriteProperty ( "width", rect.width );
			writer.WriteProperty ( "height", rect.height );
			writer.WriteProperty ( "size", rect.size );
			writer.WriteProperty ( "xMin", rect.xMin );
			writer.WriteProperty ( "yMin", rect.yMin );
			writer.WriteProperty ( "xMax", rect.xMax );
			writer.WriteProperty ( "yMax", rect.yMax );

		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Rect rect = new UnityEngine.Rect ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "x":
						rect.x = reader.ReadProperty<System.Single> ();
						break;
					case "y":
						rect.y = reader.ReadProperty<System.Single> ();
						break;
					case "position":
						rect.position = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "center":
						rect.center = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "min":
						rect.min = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "max":
						rect.max = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "width":
						rect.width = reader.ReadProperty<System.Single> ();
						break;
					case "height":
						rect.height = reader.ReadProperty<System.Single> ();
						break;
					case "size":
						rect.size = reader.ReadProperty<UnityEngine.Vector2> ();
						break;
					case "xMin":
						rect.xMin = reader.ReadProperty<System.Single> ();
						break;
					case "yMin":
						rect.yMin = reader.ReadProperty<System.Single> ();
						break;
					case "xMax":
						rect.xMax = reader.ReadProperty<System.Single> ();
						break;
					case "yMax":
						rect.yMax = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return rect;
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