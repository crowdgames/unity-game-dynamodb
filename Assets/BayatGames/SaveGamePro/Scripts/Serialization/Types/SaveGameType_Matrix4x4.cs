using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Matrix4x4 serialization implementation.
	/// </summary>
	public class SaveGameType_Matrix4x4 : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Matrix4x4 );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Matrix4x4 matrix4x4 = ( UnityEngine.Matrix4x4 )value;
			writer.WriteProperty ( "m00", matrix4x4.m00 );
			writer.WriteProperty ( "m10", matrix4x4.m10 );
			writer.WriteProperty ( "m20", matrix4x4.m20 );
			writer.WriteProperty ( "m30", matrix4x4.m30 );
			writer.WriteProperty ( "m01", matrix4x4.m01 );
			writer.WriteProperty ( "m11", matrix4x4.m11 );
			writer.WriteProperty ( "m21", matrix4x4.m21 );
			writer.WriteProperty ( "m31", matrix4x4.m31 );
			writer.WriteProperty ( "m02", matrix4x4.m02 );
			writer.WriteProperty ( "m12", matrix4x4.m12 );
			writer.WriteProperty ( "m22", matrix4x4.m22 );
			writer.WriteProperty ( "m32", matrix4x4.m32 );
			writer.WriteProperty ( "m03", matrix4x4.m03 );
			writer.WriteProperty ( "m13", matrix4x4.m13 );
			writer.WriteProperty ( "m23", matrix4x4.m23 );
			writer.WriteProperty ( "m33", matrix4x4.m33 );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Matrix4x4 matrix4x4 = new UnityEngine.Matrix4x4 ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "m00":
						matrix4x4.m00 = reader.ReadProperty<System.Single> ();
						break;
					case "m10":
						matrix4x4.m10 = reader.ReadProperty<System.Single> ();
						break;
					case "m20":
						matrix4x4.m20 = reader.ReadProperty<System.Single> ();
						break;
					case "m30":
						matrix4x4.m30 = reader.ReadProperty<System.Single> ();
						break;
					case "m01":
						matrix4x4.m01 = reader.ReadProperty<System.Single> ();
						break;
					case "m11":
						matrix4x4.m11 = reader.ReadProperty<System.Single> ();
						break;
					case "m21":
						matrix4x4.m21 = reader.ReadProperty<System.Single> ();
						break;
					case "m31":
						matrix4x4.m31 = reader.ReadProperty<System.Single> ();
						break;
					case "m02":
						matrix4x4.m02 = reader.ReadProperty<System.Single> ();
						break;
					case "m12":
						matrix4x4.m12 = reader.ReadProperty<System.Single> ();
						break;
					case "m22":
						matrix4x4.m22 = reader.ReadProperty<System.Single> ();
						break;
					case "m32":
						matrix4x4.m32 = reader.ReadProperty<System.Single> ();
						break;
					case "m03":
						matrix4x4.m03 = reader.ReadProperty<System.Single> ();
						break;
					case "m13":
						matrix4x4.m13 = reader.ReadProperty<System.Single> ();
						break;
					case "m23":
						matrix4x4.m23 = reader.ReadProperty<System.Single> ();
						break;
					case "m33":
						matrix4x4.m33 = reader.ReadProperty<System.Single> ();
						break;
				}
			}
			return matrix4x4;
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