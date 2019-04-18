using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Tree serialization implementation.
	/// </summary>
	public class SaveGameType_Tree : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.Tree );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.Tree tree = ( UnityEngine.Tree )value;
			writer.WriteProperty ( "dataType", tree.data.GetType ().AssemblyQualifiedName );
			writer.WriteProperty ( "data", tree.data );
			writer.WriteProperty ( "tag", tree.tag );
			writer.WriteProperty ( "name", tree.name );
			writer.WriteProperty ( "hideFlags", tree.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.Tree tree = SaveGameType.CreateComponent<UnityEngine.Tree> ();
			ReadInto ( tree, reader );
			return tree;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.Tree tree = ( UnityEngine.Tree )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "data":
						Type dataType = Type.GetType ( reader.ReadProperty<System.String> () );
						if ( tree.data == null )
						{
							tree.data = ( UnityEngine.ScriptableObject )reader.ReadProperty ( dataType );
						}
						else
						{
							reader.ReadIntoProperty ( tree.data );
						}
						break;
					case "tag":
						tree.tag = reader.ReadProperty<System.String> ();
						break;
					case "name":
						tree.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						tree.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}