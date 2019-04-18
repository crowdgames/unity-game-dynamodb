using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace BayatGames.SaveGamePro.Editor
{

	/// <summary>
	/// Save game define symbols.
	/// Adds Scripting Define symbols for Save Game Pro.
	/// </summary>
	[InitializeOnLoad]
	public class SaveGameDefineSymbols : UnityEditor.Editor
	{

		/// <summary>
		/// Symbols that will be added to the editor
		/// </summary>
		public static readonly string [] Symbols = new string[] {
			"BAYATGAMES",
			"BAYATGAMES_SAVEGAMEPRO"
		};

		/// <summary>
		/// Add define symbols as soon as Unity gets done compiling.
		/// </summary>
		static SaveGameDefineSymbols ()
		{
			string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup ( EditorUserBuildSettings.selectedBuildTargetGroup );
			List<string> allDefines = definesString.Split ( ';' ).ToList ();
			allDefines.AddRange ( Symbols.Except ( allDefines ) );
			PlayerSettings.SetScriptingDefineSymbolsForGroup (
				EditorUserBuildSettings.selectedBuildTargetGroup,
				string.Join ( ";", allDefines.Distinct ().ToArray () ) );
		}
		
	}

}