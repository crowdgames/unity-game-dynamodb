using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Shader serialization implementation.
	/// </summary>
	public class SaveGameType_Shader : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Shader );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Shader shader = ( UnityEngine.Shader )value;
			writer.WriteProperty ( "name", shader.name );
			writer.WriteProperty ( "maximumLOD", shader.maximumLOD );
			writer.WriteProperty ( "hideFlags", shader.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Shader shader = Shader.Find ( reader.ReadProperty<System.String> () );
			ReadInto ( shader, reader );
			return shader;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Shader shader = ( UnityEngine.Shader )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "name":
						shader.name = reader.ReadProperty<System.String> ();
						break;
					case "maximumLOD":
						shader.maximumLOD = reader.ReadProperty<System.Int32> ();
						break;
					case "hideFlags":
						shader.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}