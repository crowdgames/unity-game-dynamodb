using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using BayatGames.SaveGamePro.Utilities;

namespace BayatGames.SaveGamePro.Editor
{

    /// <summary>
    /// Save Game Settings Window.
    /// </summary>
    public class SaveGameSettingsWindow : EditorWindow
    {

        protected Vector2 scrollPosition;
        protected int selectedTab;
        protected string[] tabs = new string[] {
            "General",
            "Integrations",
            "Support & News"
        };
        protected Dictionary<string, IntegrationInfo> integrations;

        [MenuItem("Window/Save Game Pro/Settings")]
        public static void Initialize()
        {
            SaveGameSettingsWindow window = EditorWindow.GetWindow<SaveGameSettingsWindow>();
            window.minSize = new Vector2(400f, 100f);
            window.Show();
        }

        protected virtual void OnEnable()
        {
            titleContent = new GUIContent(" Settings", Resources.Load<Texture>("savegamepro-icon"));
            this.integrations = new Dictionary<string, IntegrationInfo>();
            foreach (IntegrationInfo integration in IntegrationUtils.GetIntegrations())
            {
                integration.Dependents = new List<string>();
                this.integrations.Add(integration.Identifier, integration);
            }
            foreach (IntegrationInfo integration in this.integrations.Values)
            {
                for (int i = 0; i < integration.Dependencies.Length; i++)
                {
                    string dependency = integration.Dependencies[i];
                    this.integrations[dependency].Dependents.Add(integration.Identifier);
                }
            }
        }

        protected virtual void OnGUI()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            this.selectedTab = GUILayout.Toolbar(this.selectedTab, this.tabs, EditorStyles.toolbarButton);
            EditorGUILayout.EndHorizontal();
            this.scrollPosition = EditorGUILayout.BeginScrollView(this.scrollPosition);
            EditorGUILayout.BeginVertical();
            switch (this.selectedTab)
            {
                case 0:
                    GeneralTab();
                    break;
                case 1:
                    IntegrationsTab();
                    break;
                case 2:
                    SupportTab();
                    break;
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Made with ❤️ by Bayat Games", EditorStyles.centeredGreyMiniLabel);
        }

        protected virtual void GeneralTab()
        {
            GUILayout.Label("Actions", EditorStyles.boldLabel);
            GUILayout.Label("The below are some general actions you can apply and manage the data on this device", EditorStyles.wordWrappedLabel);
            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            if (GUILayout.Button("Clear Saved Data", GUILayout.Width(150f)))
            {
                bool clear = EditorUtility.DisplayDialog(
                    "Clearing Saved Data",
                    "Are you sure you want to clear all saved data on this device?",
                    "Yes", "No");
                if (clear)
                {
                    SaveGame.Clear();
                }
            }
            if (GUILayout.Button("Save Random Data", GUILayout.Width(150f)))
            {
                string randomIdentifier = StringUtils.RandomString(8) + ".txt";
                SaveGame.Save(randomIdentifier, "This is random data");
                EditorUtility.DisplayDialog(
                    "Saving Random Data",
                    string.Format("Random Data genereated and saved successfully with the below information:\n- Identifier: {0}", randomIdentifier),
                    "Done");
            }
            if (GUILayout.Button("Uninstall Save Game Pro", GUILayout.Width(200f)))
            {
                bool uninstall = EditorUtility.DisplayDialog(
                    "Uninstalling Save Game Pro",
                    "Are you sure you want to Uninstall Save Game Pro?\nNote: This action will delete all files and folders under BayatGames/SaveGamePro folder, so make sure that you don't have any folder or files under this folder.",
                    "Yes", "No");
                if (uninstall)
                {
                    Close();
                    AssetDatabase.DeleteAsset(SaveGameConstants.SaveGameProFolder);
                    EditorUtility.DisplayDialog(
                        "Uninstalling Save Game Pro",
                        "Save Game Pro Successfully Uninstalled",
                        "Done");
                }
            }
            EditorGUILayout.EndVertical();
            GUILayout.Label("Information", EditorStyles.boldLabel);
            GUILayout.Label("The below are informational and readonly fields for copy/paste and such porpuses.", EditorStyles.wordWrappedLabel);
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.TextField("Persistent Data Path", Application.persistentDataPath);
            if (GUILayout.Button("Copy", GUILayout.Width(80f)))
            {
                EditorGUIUtility.systemCopyBuffer = Application.persistentDataPath;
            }
            if (GUILayout.Button("Open", GUILayout.Width(80f)))
            {
                EditorUtility.RevealInFinder(Application.persistentDataPath);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.TextField("Data Path", Application.dataPath);
            if (GUILayout.Button("Copy", GUILayout.Width(80f)))
            {
                EditorGUIUtility.systemCopyBuffer = Application.dataPath;
            }
            if (GUILayout.Button("Open", GUILayout.Width(80f)))
            {
                EditorUtility.RevealInFinder(Application.dataPath);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        protected virtual void IntegrationsTab()
        {
            GUILayout.Label("Integrations", EditorStyles.boldLabel);
            GUILayout.Label("Install & Uninstall integrations and manage them all at one glance.", EditorStyles.wordWrappedLabel);
            foreach (IntegrationInfo integration in this.integrations.Values)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(integration.Title, EditorStyles.boldLabel);
                EditorGUILayout.BeginVertical();
                GUILayout.Space(5f);
                if (GUILayout.Button(integration.Installed ? "Uninstall" : "Install", EditorStyles.miniButton))
                {
                    if (integration.Installed)
                    {
                        IntegrationUtils.UninstallIntegration(integration);
                    }
                    else
                    {
                        IntegrationUtils.InstallIntegration(integration, true);
                    }
                }
                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
                GUILayout.Label(integration.Description, EditorStyles.wordWrappedLabel);
                if (integration.Dependencies.Length > 0)
                {
                    string dependenciesText = "Dependencies:\n";
                    string[] dependencies = integration.Dependencies;
                    for (int i = 0; i < dependencies.Length; i++)
                    {
                        IntegrationInfo dependency = IntegrationUtils.GetIntegration(dependencies[i]);
                        dependenciesText += "- ";
                        dependenciesText += dependency.Title;
                        dependenciesText += " (" + (dependency.Installed ? "Installed" : "Not Installed") + ")";
                        if (i + 1 < dependencies.Length)
                        {
                            dependenciesText += "\n";
                        }
                    }
                    GUILayout.Label(dependenciesText, EditorStyles.wordWrappedLabel);
                }
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(string.Format("Version {0}", integration.Version), EditorStyles.miniButton))
                {
                    EditorUtility.DisplayDialog(string.Format("{0} Changelog", integration.Title), string.Format("Version {0}\n{1}", integration.Version, integration.Changelog), "Done");
                }
                GUILayout.FlexibleSpace();
                if (integration.Links != null)
                {
                    for (int i = 0; i < integration.Links.Length; i++)
                    {
                        if (GUILayout.Button(integration.Links[i].text, GUILayout.Width(100f)))
                        {
                            Application.OpenURL(integration.Links[i].url);
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }
        }

        protected virtual void SupportTab()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            GUILayout.Label("Useful Links for Support & News", new GUIStyle(EditorStyles.boldLabel)
            {
                alignment = TextAnchor.MiddleCenter
            });
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("Documentation"))
            {
                Application.OpenURL("https://bayatgames.com/docs");
            }
            if (GUILayout.Button("Support Page"))
            {
                Application.OpenURL("https://github.com/BayatGames/Support");
            }
            if (GUILayout.Button("Issue Tracker"))
            {
                Application.OpenURL("https://github.com/BayatGames/SaveGamePro/issues");
            }
            if (GUILayout.Button("Email"))
            {
                Application.OpenURL("mailto:hasanbayat1393@gmail.com");
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("Unity Asset Store"))
            {
                Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/89198");
            }
            if (GUILayout.Button("YouTube"))
            {
                Application.OpenURL("https://www.youtube.com/channel/UCDLJbvqDKJyBKU2E8TMEQpQ");
            }
            if (GUILayout.Button("Trello"))
            {
                Application.OpenURL("https://trello.com/bayatgames");
            }
            if (GUILayout.Button("Discord"))
            {
                Application.OpenURL("https://discordapp.com/channels/307041709701988352/307041709701988352");
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("GitHub"))
            {
                Application.OpenURL("https://github.com/BayatGames/SaveGamePro");
            }
            if (GUILayout.Button("Facebook"))
            {
                Application.OpenURL("https://www.facebook.com/BayatGames");
            }
            if (GUILayout.Button("Twitter"))
            {
                Application.OpenURL("https://twitter.com/BayatGames");
            }
            if (GUILayout.Button("Instagram"))
            {
                Application.OpenURL("https://www.instagram.com/gamesbayat/");
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

    }

}