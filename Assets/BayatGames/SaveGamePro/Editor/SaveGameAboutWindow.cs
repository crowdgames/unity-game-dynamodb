using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BayatGames.SaveGamePro
{

    /// <summary>
    /// Save Game Pro About Window.
    /// </summary>
    public class SaveGameAboutWindow : EditorWindow
    {

        public static readonly Vector2 Size = new Vector2(500f, 140f);
        public static Texture Logo;

        [MenuItem("Window/Save Game Pro/About")]
        public static void Init()
        {
            SaveGameAboutWindow window = EditorWindow.GetWindow<SaveGameAboutWindow>();
            window.minSize = Size;
            window.maxSize = Size + Vector2.one;
            Logo = Resources.Load<Texture>("savegamepro-logo");
            window.Show();
        }

        protected virtual void OnEnable()
        {
            titleContent = new GUIContent(" About", Resources.Load<Texture>("savegamepro-icon"));
        }

        protected virtual void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Box(Logo);
            EditorGUILayout.BeginVertical();
            GUILayout.Label("Sava Game Pro", EditorStyles.boldLabel);
            GUILayout.Label(string.Format("Version: {0}", SaveGame.Version));
            GUILayout.Label("Creator: Bayat Games");
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }

    }

}