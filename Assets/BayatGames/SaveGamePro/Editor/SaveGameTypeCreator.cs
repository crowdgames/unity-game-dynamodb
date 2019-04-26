using BayatGames.SaveGamePro.Reflection;
using BayatGames.SaveGamePro.Serialization;
using BayatGames.SaveGamePro.Serialization.Types;
using BayatGames.SaveGamePro.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace BayatGames.SaveGamePro.Editor
{

    /// <summary>
    /// Save Game Pro Type Creator Window.
    /// Currently is in Beta.
    /// </summary>
    public class SaveGameTypeCreator : EditorWindow
    {

        protected Vector2 m_ScrollPosition;
        protected Vector2 m_AssembliesScrollViewPosition;
        protected Vector2 m_TypesScrollViewPosition;
        protected Assembly[] m_AvailableAssemblies;
        protected string[] m_AvailableAssembliesText;
        protected Type[] m_AvailableTypes;
        protected string[] m_AvailableTypesText;
        protected Assembly m_SelectedAssembly;
        protected int m_SelectedAssemblyIndex;
        protected Type m_SelectedType;
        protected int m_SelectedTypeIndex;
        protected string m_AssetPath = "Scripts/Types";
        protected string m_AssemblySearchPattern;
        protected string m_TypeSearchPattern;

        [MenuItem("Window/Save Game Pro/Type Creator")]
        public static void Init()
        {
            SaveGameTypeCreator window = EditorWindow.GetWindow<SaveGameTypeCreator>();
            window.minSize = new Vector2(400f, 100f);
            window.Show();
            UpdateTypeManager();
        }

        protected virtual void OnEnable()
        {
            titleContent = new GUIContent(" Type Creator", Resources.Load<Texture>("savegamepro-icon"));
        }

        protected virtual void Awake()
        {

        }

        protected virtual void OnDestroy()
        {
            UpdateTypeManager();
        }

        public virtual void GetAvailableAssemblies()
        {
            if (string.IsNullOrEmpty(m_AssemblySearchPattern))
            {
                m_AvailableAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly =>
             {
                 return !assembly.GetName().Name.Contains("Editor");
             }).ToArray();
            }
            else
            {
                m_AvailableAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly =>
             {
                 return Regex.IsMatch(assembly.GetName().Name, m_AssemblySearchPattern, RegexOptions.IgnoreCase) &&
                 !assembly.GetName().Name.Contains("Editor");
             }).ToArray();
            }
            m_AvailableAssembliesText = new string[m_AvailableAssemblies.Length];
            for (int i = 0; i < m_AvailableAssemblies.Length; i++)
            {
                m_AvailableAssembliesText[i] = m_AvailableAssemblies[i].GetName().Name;
            }
        }

        public virtual void GetAvailableTypes()
        {
            if (m_SelectedAssembly == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(m_TypeSearchPattern))
            {
                m_AvailableTypes = m_SelectedAssembly.GetExportedTypes().Where(
                    type => !SaveGameTypeManager.HasType(type) && type.IsSavable()).ToArray();
            }
            else
            {
                m_AvailableTypes = m_SelectedAssembly.GetExportedTypes().Where(type =>
             {
                 return Regex.IsMatch(type.Name, m_TypeSearchPattern, RegexOptions.IgnoreCase) &&
                 !SaveGameTypeManager.HasType(type) && type.IsSavable();
             }).ToArray();
            }
            m_AvailableTypesText = new string[m_AvailableTypes.Length];
            for (int i = 0; i < m_AvailableTypes.Length; i++)
            {
                m_AvailableTypesText[i] = m_AvailableTypes[i].Name;
            }
        }

        protected virtual void OnGUI()
        {
            GUIStyle richText = EditorStyles.label;
            richText.richText = true;
            GUI.enabled = !EditorApplication.isUpdating && !EditorApplication.isCompiling &&
            !EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPaused;
            m_ScrollPosition = EditorGUILayout.BeginScrollView(
                m_ScrollPosition,
                false,
                true,
                GUIStyle.none,
                GUI.skin.verticalScrollbar,
                GUIStyle.none);

            EditorGUILayout.Separator();

            EditorGUILayout.BeginVertical(
                GUILayout.MinWidth(400f),
                GUILayout.MaxWidth(Screen.width),
                GUILayout.ExpandWidth(true));
            GUILayout.Label("Type Creator Currently is in Beta", EditorStyles.boldLabel);
            GUILayout.Label(
                "We want to hear your improvements and opinions. Please test all the features and report any bugs to us via Support. It can be used in prodcution.",
                EditorStyles.wordWrappedLabel);
            GUILayout.Label("Type Creator", EditorStyles.boldLabel);
            GUILayout.Label(
                "Here you can create custom Save Game Types and add save support to types that aren't supposed to be saved by searching through assemblies and types by clicks and automatically without writing a single line of code.",
                EditorStyles.wordWrappedLabel);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();

            EditorGUILayout.BeginHorizontal(
                GUILayout.MaxWidth(Screen.width),
                GUILayout.ExpandWidth(true));
            EditorGUILayout.BeginVertical();
            GUILayout.Label("Assemblies", EditorStyles.boldLabel);
            GUILayout.Label(
                "Here is a list of Assemblies, choose one to get a list of exported types, Use the search input to find the desired assembly.",
                EditorStyles.wordWrappedLabel);
            EditorGUILayout.Separator();
            string assemblySearchPattern = EditorGUILayout.TextField("Search Pattern", m_AssemblySearchPattern);
            if (assemblySearchPattern != m_AssemblySearchPattern)
            {
                m_AssemblySearchPattern = assemblySearchPattern;
                GetAvailableAssemblies();
            }
            if (GUILayout.Button("Reload Assemblies") || m_AvailableAssemblies == null || m_AvailableAssemblies.Length == 0)
            {
                GetAvailableAssemblies();
            }
            m_AssembliesScrollViewPosition = EditorGUILayout.BeginScrollView(
                m_AssembliesScrollViewPosition,
                GUILayout.MaxHeight(300f),
                GUILayout.ExpandHeight(true),
                GUILayout.MinWidth(400f),
                GUILayout.MaxWidth(Screen.width),
                GUILayout.ExpandWidth(true));
            m_SelectedAssemblyIndex = GUILayout.SelectionGrid(m_SelectedAssemblyIndex, m_AvailableAssembliesText, 3);
            if (m_SelectedAssemblyIndex >= m_AvailableAssemblies.Length)
            {
                m_SelectedAssembly = null;
            }
            else
            {
                if (m_SelectedAssembly != m_AvailableAssemblies[m_SelectedAssemblyIndex])
                {
                    m_SelectedAssembly = m_AvailableAssemblies[m_SelectedAssemblyIndex];
                    GetAvailableTypes();
                }
                m_SelectedAssembly = m_AvailableAssemblies[m_SelectedAssemblyIndex];
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();

            EditorGUILayout.BeginVertical();
            GUILayout.Label("Types", EditorStyles.boldLabel);
            GUILayout.Label(
                "Here is a list of Types, choose one to create a new Save Game Type from it, Use the search input to find desired type.",
                EditorStyles.wordWrappedLabel);
            EditorGUILayout.Separator();
            string typeSearchPattern = EditorGUILayout.TextField("Search Pattern", m_TypeSearchPattern);
            if (typeSearchPattern != m_TypeSearchPattern)
            {
                m_TypeSearchPattern = typeSearchPattern;
                GetAvailableTypes();
            }
            if (GUILayout.Button("Reload Types") || m_AvailableTypes == null || m_AvailableTypes.Length == 0)
            {
                GetAvailableTypes();
            }
            m_TypesScrollViewPosition = EditorGUILayout.BeginScrollView(
                m_TypesScrollViewPosition,
                GUILayout.MaxHeight(300f),
                GUILayout.ExpandHeight(true),
                GUILayout.MinWidth(400f),
                GUILayout.MaxWidth(Screen.width),
                GUILayout.ExpandWidth(true));
            m_SelectedTypeIndex = GUILayout.SelectionGrid(m_SelectedTypeIndex, m_AvailableTypesText, 3);
            if (m_SelectedTypeIndex >= m_AvailableTypes.Length)
            {
                m_SelectedType = null;
            }
            else
            {
                m_SelectedType = m_AvailableTypes[m_SelectedTypeIndex];
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
            GUILayout.Space(15f);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();
            GUILayout.Label("Selected Type", EditorStyles.boldLabel);
            GUILayout.Label(
                "Here is the details and information of the selected type.",
                EditorStyles.wordWrappedLabel);
            EditorGUILayout.Separator();
            if (m_SelectedType != null)
            {
                GUILayout.Label(string.Format("<b>Name</b>: {0}", m_SelectedType.Name), richText);
                GUILayout.Label(string.Format("<b>Assembly</b>: {0}", m_SelectedType.Assembly.FullName), richText);
                GUILayout.Label(string.Format("<b>Full Name</b>: {0}", m_SelectedType.GetFriendlyName()), richText);
                GUILayout.Label(string.Format("<b>Namespace</b>: {0}", m_SelectedType.Namespace), richText);
                GUILayout.Label(string.Format("<b>Is Value Type</b>: {0}", m_SelectedType.IsValueType), richText);
            }
            else
            {
                GUILayout.Label("<b>No Type is selected, Select one to see details.</b>", richText);
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();

            EditorGUILayout.BeginVertical();
            GUILayout.Label("Create Type", EditorStyles.boldLabel);
            GUILayout.Label(
                "Now specify the asset path to create the specified Save Game Type for the selected type.",
                EditorStyles.wordWrappedLabel);
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginHorizontal();
            m_AssetPath = EditorGUILayout.TextField("Asset Path", m_AssetPath);
            if (GUI.enabled)
            {
                GUI.enabled = m_SelectedType != null;
            }
            if (GUILayout.Button("Create Type"))
            {
                CreateType(m_AssetPath, m_SelectedType);
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Label("Made with ❤️ by Bayat Games", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.Separator();

            EditorGUILayout.EndScrollView();
        }

        public virtual void UpdateCurrentTypes()
        {
            Dictionary<string, MonoScript> scripts = new Dictionary<string, MonoScript>();
            string[] assetPaths = AssetDatabase.GetAllAssetPaths();
            foreach (string assetPath in assetPaths)
            {
                if (assetPath.EndsWith(".cs"))
                {
                    MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
                    Type type = script.GetClass();
                    if (typeof(SaveGameType).IsAssignableFrom(type))
                    {
                        scripts.Add(assetPath, script);
                    }
                }
            }
            foreach (var script in scripts)
            {
                Type scriptType = script.Value.GetClass();
                if (scriptType.IsAbstract)
                {
                    continue;
                }
                string folderPath = Path.GetDirectoryName(script.Key);
                SaveGameType saveGameType = (SaveGameType)Activator.CreateInstance(scriptType);
                CreateType(folderPath, saveGameType.AssociatedType);
            }
        }

        public static void CreateType(string folderPath, Type type)
        {
            if (!type.IsSavable())
            {
                return;
            }
            TextAsset textAsset = Resources.Load<TextAsset>("SaveGameTypeTemplate.cs");
            StringBuilder write = new StringBuilder();
            StringBuilder read = new StringBuilder();
            StringBuilder readInto = new StringBuilder();
            string resultName = StringUtils.ToCamelCase(type.Name);
            write.Append("\t\t\t");
            write.AppendLine(string.Format(@"{0} {1} = ( {0} )value;", type.GetFriendlyName(), resultName));
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            read.Append("\t\t\t");
            StringBuilder targetRead;
            if (type.IsValueType)
            {
                targetRead = read;
                read.AppendLine(string.Format(@"{0} {1} = new {0} ();", type.GetFriendlyName(), resultName));
            }
            else
            {
                targetRead = readInto;
                if (constructor != null || type.IsSubclassOf(typeof(Component)))
                {
                    if (type.IsSubclassOf(typeof(Component)))
                    {
                        read.AppendLine(string.Format(
                            @"{0} {1} = SaveGameType.CreateComponent<{0}> ();",
                            type.GetFriendlyName(),
                            resultName));
                    }
                    else if (constructor != null)
                    {
                        read.AppendLine(string.Format(@"{0} {1} = new {0} ();", type.GetFriendlyName(), resultName));
                    }
                    read.Append("\t\t\t");
                    read.AppendLine(string.Format(@"ReadInto ( {0}, reader );", resultName));
                    read.Append("\t\t\t");
                    read.Append(string.Format(@"return {0};", resultName));
                }
                else
                {
                    read.Append("return base.Read ( reader );");
                }
                readInto.Append("\t\t\t");
                readInto.AppendLine(string.Format(@"{0} {1} = ( {0} )value;", type.GetFriendlyName(), resultName));
            }
            targetRead.Append("\t\t\t");
            targetRead.AppendLine(@"foreach ( string property in reader.Properties )");
            targetRead.Append("\t\t\t");
            targetRead.AppendLine(@"{");
            targetRead.Append("\t\t\t\t");
            targetRead.AppendLine(@"switch ( property )");
            targetRead.Append("\t\t\t\t");
            targetRead.AppendLine(@"{");
            List<FieldInfo> fields = type.GetSavableFields();
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].FieldType.IsAbstract || fields[i].FieldType == typeof(UnityEngine.Object) ||
                     fields[i].FieldType == typeof(UnityEngine.ScriptableObject))
                {
                    write.Append("\t\t\t");
                    write.AppendLine(string.Format(
                        @"writer.WriteProperty ( ""{1}Type"", {0}.{1}.GetType ().AssemblyQualifiedName );",
                        resultName,
                        fields[i].Name));
                }
                write.Append("\t\t\t");
                if (i + 1 >= fields.Count)
                {
                    write.Append(string.Format(
                        @"writer.WriteProperty ( ""{1}"", {0}.{1} );",
                        resultName,
                        fields[i].Name));
                }
                else
                {
                    write.AppendLine(string.Format(
                        @"writer.WriteProperty ( ""{1}"", {0}.{1} );",
                        resultName,
                        fields[i].Name));
                }
                targetRead.Append("\t\t\t\t\t");
                targetRead.AppendLine(string.Format(@"case ""{0}"":", fields[i].Name));
                if (fields[i].FieldType.IsAbstract || fields[i].FieldType == typeof(UnityEngine.Object) ||
                     fields[i].FieldType == typeof(UnityEngine.ScriptableObject))
                {
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(string.Format(
                        @"Type {0}Type = Type.GetType ( reader.ReadProperty<System.String> () );",
                        fields[i].Name));
                }
                targetRead.Append("\t\t\t\t\t\t");
                if (fields[i].FieldType.IsSubclassOf(typeof(UnityEngine.Object)))
                {
                    targetRead.AppendLine(string.Format(
                        @"if ( {0}.{1} == null )",
                        resultName,
                        fields[i].Name));
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"{");
                    targetRead.Append("\t\t\t\t\t\t\t");
                    if (fields[i].FieldType.IsAbstract)
                    {
                        targetRead.AppendLine(string.Format(
                            @"{0}.{1} = ( {2} )reader.ReadProperty ( {1}Type );",
                            resultName,
                            fields[i].Name,
                            fields[i].FieldType.GetFriendlyName()));
                    }
                    else
                    {
                        targetRead.AppendLine(string.Format(
                            @"{0}.{1} = reader.ReadProperty<{2}> ();",
                            resultName,
                            fields[i].Name,
                            fields[i].FieldType.GetFriendlyName()));
                    }
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"}");
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"else");
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"{");
                    targetRead.Append("\t\t\t\t\t\t\t");
                    if (fields[i].FieldType.IsAbstract)
                    {
                        targetRead.AppendLine(string.Format(
                            @"reader.ReadIntoProperty ( {0}.{1} );",
                            resultName,
                            fields[i].Name,
                            fields[i].FieldType.GetFriendlyName()));
                    }
                    else
                    {
                        targetRead.AppendLine(string.Format(
                            @"reader.ReadIntoProperty<{2}> ( {0}.{1} );",
                            resultName,
                            fields[i].Name,
                            fields[i].FieldType.GetFriendlyName()));
                    }
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"}");
                }
                else
                {
                    if (fields[i].FieldType.IsAbstract || fields[i].FieldType == typeof(UnityEngine.Object) ||
                         fields[i].FieldType == typeof(UnityEngine.ScriptableObject))
                    {
                        targetRead.AppendLine(string.Format(
                            @"{0}.{1} = ( {2} )reader.ReadProperty ( {1}Type );",
                            resultName,
                            fields[i].Name,
                            fields[i].FieldType.GetFriendlyName()));
                    }
                    else
                    {
                        targetRead.AppendLine(string.Format(
                            @"{0}.{1} = reader.ReadProperty<{2}> ();",
                            resultName,
                            fields[i].Name,
                            fields[i].FieldType.GetFriendlyName()));
                    }
                }
                targetRead.Append("\t\t\t\t\t\t");
                targetRead.AppendLine("break;");
            }
            List<PropertyInfo> properties = type.GetSavableProperties();
            for (int i = 0; i < properties.Count; i++)
            {
                if (properties[i].PropertyType.IsAbstract || properties[i].PropertyType == typeof(UnityEngine.Object) ||
                     properties[i].PropertyType == typeof(UnityEngine.ScriptableObject))
                {
                    write.Append("\t\t\t");
                    write.AppendLine(string.Format(
                        @"writer.WriteProperty ( ""{1}Type"", {0}.{1}.GetType ().AssemblyQualifiedName );",
                        resultName,
                        properties[i].Name));
                }
                write.Append("\t\t\t");
                if (i + 1 >= properties.Count)
                {
                    write.Append(string.Format(
                        @"writer.WriteProperty ( ""{1}"", {0}.{1} );",
                        resultName,
                        properties[i].Name));
                }
                else
                {
                    write.AppendLine(string.Format(
                        @"writer.WriteProperty ( ""{1}"", {0}.{1} );",
                        resultName,
                        properties[i].Name));
                }
                targetRead.Append("\t\t\t\t\t");
                targetRead.AppendLine(string.Format(@"case ""{0}"":", properties[i].Name));
                if (properties[i].PropertyType.IsAbstract || properties[i].PropertyType == typeof(UnityEngine.Object) ||
                     properties[i].PropertyType == typeof(UnityEngine.ScriptableObject))
                {
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(string.Format(
                        @"Type {0}Type = Type.GetType ( reader.ReadProperty<System.String> () );",
                        properties[i].Name));
                }
                targetRead.Append("\t\t\t\t\t\t");
                if (properties[i].PropertyType.IsSubclassOf(typeof(UnityEngine.Object)))
                {
                    targetRead.AppendLine(string.Format(
                        @"if ( {0}.{1} == null )",
                        resultName,
                        properties[i].Name));
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"{");
                    targetRead.Append("\t\t\t\t\t\t\t");
                    if (properties[i].PropertyType.IsAbstract)
                    {
                        targetRead.AppendLine(string.Format(
                            @"{0}.{1} = ( {2} )reader.ReadProperty ( {1}Type );",
                            resultName,
                            properties[i].Name,
                            properties[i].PropertyType.GetFriendlyName()));
                    }
                    else
                    {
                        targetRead.AppendLine(string.Format(
                            @"{0}.{1} = reader.ReadProperty<{2}> ();",
                            resultName,
                            properties[i].Name,
                            properties[i].PropertyType.GetFriendlyName()));
                    }
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"}");
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"else");
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"{");
                    targetRead.Append("\t\t\t\t\t\t\t");
                    if (properties[i].PropertyType.IsAbstract)
                    {
                        targetRead.AppendLine(string.Format(
                            @"reader.ReadIntoProperty ( {0}.{1} );",
                            resultName,
                            properties[i].Name,
                            properties[i].PropertyType.GetFriendlyName()));
                    }
                    else
                    {
                        targetRead.AppendLine(string.Format(
                            @"reader.ReadIntoProperty<{2}> ( {0}.{1} );",
                            resultName,
                            properties[i].Name,
                            properties[i].PropertyType.GetFriendlyName()));
                    }
                    targetRead.Append("\t\t\t\t\t\t");
                    targetRead.AppendLine(@"}");
                }
                else
                {
                    if (properties[i].PropertyType.IsAbstract || properties[i].PropertyType == typeof(UnityEngine.Object) ||
                         properties[i].PropertyType == typeof(UnityEngine.ScriptableObject))
                    {
                        targetRead.AppendLine(string.Format(
                            @"{0}.{1} = ( {2} )reader.ReadProperty ( {1}Type );",
                            resultName,
                            properties[i].Name,
                            properties[i].PropertyType.GetFriendlyName()));
                    }
                    else
                    {
                        targetRead.AppendLine(string.Format(
                            @"{0}.{1} = reader.ReadProperty<{2}> ();",
                            resultName,
                            properties[i].Name,
                            properties[i].PropertyType.GetFriendlyName()));
                    }
                }
                targetRead.Append("\t\t\t\t\t\t");
                targetRead.AppendLine("break;");
            }
            targetRead.Append("\t\t\t\t");
            targetRead.AppendLine(@"}");
            if (type.IsValueType)
            {
                targetRead.Append("\t\t\t");
                targetRead.AppendLine("}");
                targetRead.Append("\t\t\t" + string.Format(@"return {0};", resultName));
                readInto.Append("\t\t\tbase.ReadInto ( value, reader );");
            }
            else
            {
                targetRead.Append("\t\t\t");
                targetRead.Append("}");
            }
            string script = textAsset.text.Replace("#TYPENAME#", type.Name)
                .Replace("#TYPE#", type.GetFriendlyName())
                .Replace("#WRITE#", write.ToString())
                .Replace("#READ#", read.ToString())
                .Replace("#READINTO#", readInto.ToString());
            string typeName = "SaveGameType_" + type.Name;
            string scriptName = typeName + ".cs";
            if (!folderPath.StartsWith("Assets"))
            {
                folderPath = "Assets/" + folderPath;
            }
            string assetPath = Path.Combine(folderPath, scriptName);
            string path = Path.GetFullPath(assetPath);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, script);
            AssetDatabase.ImportAsset(assetPath);
            if (!EditorApplication.isCompiling && !EditorApplication.isUpdating)
            {
                AssetDatabase.Refresh();
            }
            UpdateTypeManager();
        }

        [InitializeOnLoadMethod]
        public static void UpdateTypeManager()
        {
            string[] files = AssetDatabase.FindAssets("SaveGameTypeManagerTemplate.cs");

            // This means the Unity file system is not yet initialized, we are too early
            if (files.Length == 0) {
                return;
            }
            string templatePath = AssetDatabase.GUIDToAssetPath(files[0]);
            string text = File.ReadAllText(templatePath);
            StringBuilder types = new StringBuilder();
            foreach (var item in SaveGameTypeManager.Types)
            {
                types.AppendLine(string.Format(
                    "\t\t\tAddType ( typeof ( {0} ), new {1} () );",
                    item.Key.GetFriendlyName(),
                    item.Value.GetType().GetFriendlyName()));
            }
            string contents = text.Replace("#ADDTYPES#", types.ToString());
            File.WriteAllText(templatePath, contents);
        }

    }

}