using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BayatGames.SaveGamePro.Serialization.Formatters.Json
{

	/// <summary>
	/// Json extensions.
	/// </summary>
	public static class JsonExtensions
	{

		/// <summary>
		/// Serializes the objec to it's json representation.
		/// </summary>
		/// <returns>The json.</returns>
		/// <param name="value">Value.</param>
		public static string ToJson ( this object value )
		{
			return JsonFormatter.SerializeObject ( value );
		}

		/// <summary>
		/// Appends the string until end. (Reaches to quotation mark)
		/// </summary>
		/// <param name="builder">Builder.</param>
		/// <param name="json">Json.</param>
		/// <param name="index">Index.</param>
		public static void AppendUntilStringEnd ( this StringBuilder builder, string json, ref int index )
		{
			if ( json.Length <= index )
			{
				return;
			}
			builder.Append ( json [ index ] );
			index++;
			while ( json [ index ] != '\"' )
			{
				builder.Append ( json [ index ] );
				index++;
			}
			builder.Append ( json [ index ] );
		}

		/// <summary>
		/// Removes the whitespace.
		/// </summary>
		/// <returns>The whitespace.</returns>
		/// <param name="json">Json.</param>
		public static string RemoveWhitespaceJson ( this string json )
		{
			if ( string.IsNullOrEmpty ( json ) )
			{
				return json;
			}
			StringBuilder builder = new StringBuilder ();
			for ( int i = 0; i < json.Length; i++ )
			{
				if ( json [ i ] == '\"' )
				{
					builder.AppendUntilStringEnd ( json, ref i );
					continue;
				}
				else if ( char.IsWhiteSpace ( json [ i ] ) )
				{
					continue;
				}
				else
				{
					builder.Append ( json [ i ] );
				}
			}
			return builder.ToString ();
		}

		/// <summary>
		/// Split the specified json.
		/// </summary>
		/// <param name="json">Json.</param>
		public static string[] SplitJson ( this string json )
		{
			if ( string.IsNullOrEmpty ( json ) )
			{
				return new string[0];
			}
			List<string> result = new List<string> ();

			// Prevent going deeper
			int depth = 0;
			StringBuilder builder = new StringBuilder ();
			for ( int i = 1; i < json.Length - 1; i++ )
			{
				switch ( json [ i ] )
				{
					case '[':
					case '{':
						depth++;
						break;
					case ']':
					case '}':
						depth--;
						break;
					case '\"':
						builder.AppendUntilStringEnd ( json, ref i );
						continue;
					case ',':
					case ':':
						// Stop going deep
						if ( depth == 0 )
						{
							result.Add ( builder.ToString () );
							builder.Length = 0;
							continue;
						}
						break;
				}
				builder.Append ( json [ i ] );
			}

			// Add ending entry
			result.Add ( builder.ToString () );
			return result.ToArray ();
		}

		public static string EscapeStringJson ( this string str )
		{
			StringBuilder builder = new StringBuilder ();
			for ( int i = 0; i < str.Length; i++ )
			{
				char currentChar = str [ i ];
				string escapedValue = "";
				switch ( currentChar )
				{
					case '\t':
						escapedValue = @"\t";
						break;
					case '\n':
						escapedValue = @"\n";
						break;
					case '\r':
						escapedValue = @"\r";
						break;
					case '\f':
						escapedValue = @"\f";
						break;
					case '\b':
						escapedValue = @"\b";
						break;
					case '\\':
						escapedValue = @"\\";
						break;
//					case '\u0085': // Next Line
//						escapedValue = @"\u0085";
//						break;
//					case '\u2028': // Line Separator
//						escapedValue = @"\u2028";
//						break;
//					case '\u2029': // Paragraph Separator
//						escapedValue = @"\u2029";
//						break;
					case '\'':
						escapedValue = @"\'";
						break;
					case '"':
						escapedValue = @"\""";
						break;
				}
				if ( string.IsNullOrEmpty ( escapedValue ) )
				{
					builder.Append ( currentChar );
				}
				else
				{
					builder.Append ( escapedValue );
				}
			}
			return builder.ToString ();
		}

		public static string UnEscapeStringJson ( this string str )
		{
			StringBuilder builder = new StringBuilder ();
			for ( int i = 0; i < str.Length; i++ )
			{
				char currentChar = str [ i ];
				switch ( currentChar )
				{
					case '\\':
						switch ( currentChar )
						{
							case 'b':
								builder.Append ( '\b' );
								break;
							case 't':
								builder.Append ( '\t' );
								break;
							case 'n':
								builder.Append ( '\n' );
								break;
							case 'f':
								builder.Append ( '\f' );
								break;
							case 'r':
								builder.Append ( '\r' );
								break;
							case '\\':
								builder.Append ( '\\' );
								break;
							case '"':
							case '\'':
							case '/':
								builder.Append ( currentChar );
								break;
						}
						break;
					default:
						builder.Append ( currentChar );
						break;
				}
			}
			return builder.ToString ();
		}
	
	}

}