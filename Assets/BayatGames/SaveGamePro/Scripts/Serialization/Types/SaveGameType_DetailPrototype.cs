using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type DetailPrototype serialization implementation.
	/// </summary>
	public class SaveGameType_DetailPrototype : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.DetailPrototype );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.DetailPrototype detailPrototype = ( UnityEngine.DetailPrototype )value;
			writer.WriteProperty ( "prototype", detailPrototype.prototype );
			writer.WriteProperty ( "prototypeTexture", detailPrototype.prototypeTexture );
			writer.WriteProperty ( "minWidth", detailPrototype.minWidth );
			writer.WriteProperty ( "maxWidth", detailPrototype.maxWidth );
			writer.WriteProperty ( "minHeight", detailPrototype.minHeight );
			writer.WriteProperty ( "maxHeight", detailPrototype.maxHeight );
			writer.WriteProperty ( "noiseSpread", detailPrototype.noiseSpread );
			writer.WriteProperty ( "bendFactor", detailPrototype.bendFactor );
			writer.WriteProperty ( "healthyColor", detailPrototype.healthyColor );
			writer.WriteProperty ( "dryColor", detailPrototype.dryColor );
			writer.WriteProperty ( "renderMode", detailPrototype.renderMode );
			writer.WriteProperty ( "usePrototypeMesh", detailPrototype.usePrototypeMesh );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.DetailPrototype detailPrototype = new UnityEngine.DetailPrototype ();
			ReadInto ( detailPrototype, reader );
			return detailPrototype;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.DetailPrototype detailPrototype = ( UnityEngine.DetailPrototype )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "prototype":
						if ( detailPrototype.prototype == null )
						{
							detailPrototype.prototype = reader.ReadProperty<UnityEngine.GameObject> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.GameObject> ( detailPrototype.prototype );
						}
						break;
					case "prototypeTexture":
						if ( detailPrototype.prototypeTexture == null )
						{
							detailPrototype.prototypeTexture = reader.ReadProperty<UnityEngine.Texture2D> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.Texture2D> ( detailPrototype.prototypeTexture );
						}
						break;
					case "minWidth":
						detailPrototype.minWidth = reader.ReadProperty<System.Single> ();
						break;
					case "maxWidth":
						detailPrototype.maxWidth = reader.ReadProperty<System.Single> ();
						break;
					case "minHeight":
						detailPrototype.minHeight = reader.ReadProperty<System.Single> ();
						break;
					case "maxHeight":
						detailPrototype.maxHeight = reader.ReadProperty<System.Single> ();
						break;
					case "noiseSpread":
						detailPrototype.noiseSpread = reader.ReadProperty<System.Single> ();
						break;
					case "bendFactor":
						detailPrototype.bendFactor = reader.ReadProperty<System.Single> ();
						break;
					case "healthyColor":
						detailPrototype.healthyColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "dryColor":
						detailPrototype.dryColor = reader.ReadProperty<UnityEngine.Color> ();
						break;
					case "renderMode":
						detailPrototype.renderMode = reader.ReadProperty<UnityEngine.DetailRenderMode> ();
						break;
					case "usePrototypeMesh":
						detailPrototype.usePrototypeMesh = reader.ReadProperty<System.Boolean> ();
						break;
				}
			}
		}
		
	}

}