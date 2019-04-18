using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type.
	/// Extend this class to implement a custom type serialization.
	/// </summary>
	public abstract class SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public abstract Type AssociatedType { get; }

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public abstract void Write ( object value, ISaveGameWriter writer );

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public virtual object Read ( ISaveGameReader reader )
		{
			Debug.LogWarningFormat (
				"SaveGamePro: The {0} does not have a default reading method, use the LoadInto or ReadInto methods.",
				AssociatedType.Name );
			return null;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public virtual void ReadInto ( object value, ISaveGameReader reader )
		{
			Debug.LogWarningFormat (
				"SaveGamePro: The {0} does not have a ReadInto method, use the default Load or Read methods.",
				AssociatedType.Name );
			return;
		}

		/// <summary>
		/// Create the component using the given type.
		/// </summary>
		/// <returns>The component.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T CreateComponent<T> () where T : Component
		{
			return ( T )CreateComponent ( typeof ( T ) );
		}

		/// <summary>
		/// Create the component using the given type.
		/// </summary>
		/// <returns>The component.</returns>
		/// <param name="type">Type.</param>
		public static Component CreateComponent ( Type type )
		{
			GameObject go = new GameObject ( type.Name );
			Component component = go.GetComponent ( type );
			if ( component == null )
			{
				component = go.AddComponent ( type );
			}
			return component;
		}
		
	}

}