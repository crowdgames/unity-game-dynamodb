using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type Navigation serialization implementation.
	/// </summary>
	public class SaveGameType_Navigation : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.UI.Navigation );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.UI.Navigation navigation = ( UnityEngine.UI.Navigation )value;
			writer.WriteProperty ( "mode", navigation.mode );
			writer.WriteProperty ( "selectOnUp", navigation.selectOnUp );
			writer.WriteProperty ( "selectOnDown", navigation.selectOnDown );
			writer.WriteProperty ( "selectOnLeft", navigation.selectOnLeft );
			writer.WriteProperty ( "selectOnRight", navigation.selectOnRight );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.UI.Navigation navigation = new UnityEngine.UI.Navigation ();
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "mode":
						navigation.mode = reader.ReadProperty<UnityEngine.UI.Navigation.Mode> ();
						break;
					case "selectOnUp":
						if ( navigation.selectOnUp == null )
						{
							navigation.selectOnUp = reader.ReadProperty<UnityEngine.UI.Selectable> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Selectable> ( navigation.selectOnUp );
						}
						break;
					case "selectOnDown":
						if ( navigation.selectOnDown == null )
						{
							navigation.selectOnDown = reader.ReadProperty<UnityEngine.UI.Selectable> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Selectable> ( navigation.selectOnDown );
						}
						break;
					case "selectOnLeft":
						if ( navigation.selectOnLeft == null )
						{
							navigation.selectOnLeft = reader.ReadProperty<UnityEngine.UI.Selectable> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Selectable> ( navigation.selectOnLeft );
						}
						break;
					case "selectOnRight":
						if ( navigation.selectOnRight == null )
						{
							navigation.selectOnRight = reader.ReadProperty<UnityEngine.UI.Selectable> ();
						}
						else
						{
							reader.ReadIntoProperty<UnityEngine.UI.Selectable> ( navigation.selectOnRight );
						}
						break;
				}
			}
			return navigation;
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