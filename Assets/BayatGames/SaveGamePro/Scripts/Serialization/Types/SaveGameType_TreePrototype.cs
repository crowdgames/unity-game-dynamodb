using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type TreePrototype serialization implementation.
	/// </summary>
	public class SaveGameType_TreePrototype : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.TreePrototype );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.TreePrototype treePrototype = ( UnityEngine.TreePrototype )value;
			writer.WriteProperty ( "prefab", treePrototype.prefab );
			writer.WriteProperty ( "bendFactor", treePrototype.bendFactor );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.TreePrototype treePrototype = new UnityEngine.TreePrototype ();
			ReadInto ( treePrototype, reader );
			return treePrototype;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.TreePrototype treePrototype = ( UnityEngine.TreePrototype )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "prefab":
						if ( treePrototype.prefab == null )
						{
							treePrototype.prefab = reader.ReadProperty<UnityEngine.GameObject> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.GameObject> ( treePrototype.prefab );
						}
						break;
					case "bendFactor":
						treePrototype.bendFactor = reader.ReadProperty<System.Single> ();
						break;
				}
			}
		}
		
	}

}