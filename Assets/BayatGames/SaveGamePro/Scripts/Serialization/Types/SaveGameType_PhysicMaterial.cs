using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type PhysicMaterial serialization implementation.
	/// </summary>
	public class SaveGameType_PhysicMaterial : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.PhysicMaterial );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.PhysicMaterial physicMaterial = ( UnityEngine.PhysicMaterial )value;
			writer.WriteProperty ( "dynamicFriction", physicMaterial.dynamicFriction );
			writer.WriteProperty ( "staticFriction", physicMaterial.staticFriction );
			writer.WriteProperty ( "bounciness", physicMaterial.bounciness );
			writer.WriteProperty ( "frictionCombine", physicMaterial.frictionCombine );
			writer.WriteProperty ( "bounceCombine", physicMaterial.bounceCombine );
			writer.WriteProperty ( "name", physicMaterial.name );
			writer.WriteProperty ( "hideFlags", physicMaterial.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.PhysicMaterial physicMaterial = new UnityEngine.PhysicMaterial ();
			ReadInto ( physicMaterial, reader );
			return physicMaterial;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.PhysicMaterial physicMaterial = ( UnityEngine.PhysicMaterial )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "dynamicFriction":
						physicMaterial.dynamicFriction = reader.ReadProperty<System.Single> ();
						break;
					case "staticFriction":
						physicMaterial.staticFriction = reader.ReadProperty<System.Single> ();
						break;
					case "bounciness":
						physicMaterial.bounciness = reader.ReadProperty<System.Single> ();
						break;
					case "frictionCombine":
						physicMaterial.frictionCombine = reader.ReadProperty<UnityEngine.PhysicMaterialCombine> ();
						break;
					case "bounceCombine":
						physicMaterial.bounceCombine = reader.ReadProperty<UnityEngine.PhysicMaterialCombine> ();
						break;
					case "name":
						physicMaterial.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						physicMaterial.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}