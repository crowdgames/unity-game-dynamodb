using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type CullingGroup serialization implementation.
	/// </summary>
	public class SaveGameType_CullingGroup : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.CullingGroup );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.CullingGroup cullingGroup = ( UnityEngine.CullingGroup )value;
			writer.WriteProperty ( "enabled", cullingGroup.enabled );
			writer.WriteProperty ( "targetCamera", cullingGroup.targetCamera );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.CullingGroup cullingGroup = new UnityEngine.CullingGroup ();
			ReadInto ( cullingGroup, reader );
			return cullingGroup;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.CullingGroup cullingGroup = ( UnityEngine.CullingGroup )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "enabled":
						cullingGroup.enabled = reader.ReadProperty<System.Boolean> ();
						break;
					case "targetCamera":
						if ( cullingGroup.targetCamera == null )
						{
							cullingGroup.targetCamera = reader.ReadProperty<UnityEngine.Camera> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Camera> ( cullingGroup.targetCamera );
						}
						break;
				}
			}
		}
		
	}

}