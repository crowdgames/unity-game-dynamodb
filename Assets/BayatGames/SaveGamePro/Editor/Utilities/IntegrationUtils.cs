using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

using BayatGames.SaveGamePro.Utilities;

namespace BayatGames.SaveGamePro.Editor
{

    /// <summary>
    /// Integration utilities.
    /// </summary>
    public static class IntegrationUtils
    {

        /// <summary>
        /// Retrieves all available integrations.
        /// </summary>
        /// <returns></returns>
        public static IntegrationInfo[] GetIntegrations()
        {
            string[] directories = Directory.GetDirectories(SaveGameConstants.IntegrationFolder);
            IntegrationInfo[] integrations = new IntegrationInfo[directories.Length];
            for (int i = 0; i < directories.Length; i++)
            {
                string directoryName = Path.GetFileName(directories[i]);
                integrations[i] = GetIntegration(directoryName);
            }
            return integrations;
        }

        /// <summary>
        /// Retrieves the integration using it's identifier.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static IntegrationInfo GetIntegration(string identifier)
        {
            return AssetDatabase.LoadAssetAtPath<IntegrationInfo>(string.Format("{0}/{1}/Info.asset", SaveGameConstants.IntegrationFolder, identifier));
        }

        /// <summary>
        /// Uninstalls the integration.
        /// </summary>
        /// <param name="integration"></param>
        /// <returns>Treu if integration successfully uninstalled</returns>
        public static bool UninstallIntegration(IntegrationInfo integration)
        {
            IntegrationInfo[] dependents = GetInstalledDependents(integration);
            if (dependents.Length > 0)
            {
                string dependentsText = "";
                for (int i = 0; i < integration.Dependents.Count; i++)
                {
                    string dependent = integration.Dependents[i];
                    dependentsText += "- " + GetIntegration(dependent).Title + "\n";
                }
                bool uninstall = EditorUtility.DisplayDialog(
                    "Uninstalling Integration",
                    string.Format("The {0} integration has some dependents that need to be uninstalled at first, do you want to uninstall them and continue?\n\nDependents:\n{1}", integration.Title, dependentsText),
                    "Yes", "No");
                if (uninstall)
                {
                    UninstallIntegrationDependents(integration);
                }
                else
                {
                    return false;
                }
            }
            for (int i = 0; i < integration.Contents.Length; i++)
            {
                string contentPath = integration.Contents[i];
                AssetDatabase.DeleteAsset("Assets/" + contentPath);
            }
            integration.Installed = false;
            //AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("Integration Uninstalled", string.Format("{0} Successfully Uninstalled", integration.Title), "Done");
            return true;
        }

        /// <summary>
        /// Installs the integration.
        /// </summary>
        /// <param name="integration"></param>
        /// <param name="showAlerts"></param>
        /// <returns>True when integration successfully installed</returns>
        public static bool InstallIntegration(IntegrationInfo integration, bool showAlerts)
        {
            if (!IsAllDependenciesInstalled(integration))
            {
                string dependenciesText = "";
                for (int i = 0; i < integration.Dependencies.Length; i++)
                {
                    string dependency = integration.Dependencies[i];
                    dependenciesText += "- " + GetIntegration(dependency).Title + "\n";
                }
                bool install = EditorUtility.DisplayDialog(
                    "Installing Integration",
                    string.Format("The {0} integration dependencies is not fully installed, do you want to install all dependencies and continue?\n\nDependencies:\n{1}", integration.Title, dependenciesText),
                    "Yes", "No");
                if (install)
                {
                    InstallIntegrationDependencies(integration);
                }
                else
                {
                    return false;
                }
            }
            string packagePath = string.Format("{0}/{1}/{2}.unitypackage", SaveGameConstants.IntegrationFolder, integration.Identifier, integration.PackageName);
            AssetDatabase.ImportPackageCallback callback = null;
            callback = (string packageName) =>
            {
                if (showAlerts)
                {
                    EditorUtility.DisplayDialog("Integration Installed", string.Format("{0} Successfully Installed", integration.Title), "Done");
                }
                AssetDatabase.importPackageCompleted -= callback;
                //AssetDatabase.Refresh();
            };
            AssetDatabase.importPackageCompleted += callback;
            AssetDatabase.ImportPackage(packagePath, false);
            integration.Installed = true;
            return true;
        }

        /// <summary>
        /// Installs integration dependencies
        /// </summary>
        /// <param name="integration"></param>
        public static void InstallIntegrationDependencies(IntegrationInfo integration)
        {
            for (int i = 0; i < integration.Dependencies.Length; i++)
            {
                string dependency = integration.Dependencies[i];
                InstallIntegration(GetIntegration(dependency), false);
            }
        }

        /// <summary>
        /// Checks whether the integration dependencies are installed or not.
        /// </summary>
        /// <param name="integration"></param>
        /// <returns>True of dependencies are installed and false if not installed</returns>
        public static bool IsAllDependenciesInstalled(IntegrationInfo integration)
        {
            bool isInstalled = true;
            for (int i = 0; i < integration.Dependencies.Length; i++)
            {
                string dependency = integration.Dependencies[i];
                isInstalled &= GetIntegration(dependency).Installed;
            }
            return isInstalled;
        }

        /// <summary>
        /// Gets the integration installed dependencies.
        /// </summary>
        /// <param name="integration"></param>
        /// <returns></returns>
        public static IntegrationInfo[] GetInstalledDepndencies(IntegrationInfo integration)
        {
            List<IntegrationInfo> integrations = new List<IntegrationInfo>();
            for (int i = 0; i < integration.Dependencies.Length; i++)
            {
                string dependency = integration.Dependencies[i];
                IntegrationInfo dependencyIntegration = GetIntegration(dependency);
                if (dependencyIntegration.Installed)
                {
                    integrations.Add(dependencyIntegration);
                }
            }
            return integrations.ToArray();
        }

        /// <summary>
        /// Gets the integration not installed dependencies.
        /// </summary>
        /// <param name="integration"></param>
        /// <returns></returns>
        public static IntegrationInfo[] GetNotInstalledDependencies(IntegrationInfo integration)
        {
            List<IntegrationInfo> integrations = new List<IntegrationInfo>();
            for (int i = 0; i < integration.Dependencies.Length; i++)
            {
                string dependency = integration.Dependencies[i];
                IntegrationInfo dependencyIntegration = GetIntegration(dependency);
                if (!dependencyIntegration.Installed)
                {
                    integrations.Add(dependencyIntegration);
                }
            }
            return integrations.ToArray();
        }

        /// <summary>
        /// Uninstalls integration dependents
        /// </summary>
        /// <param name="integration"></param>
        public static void UninstallIntegrationDependents(IntegrationInfo integration)
        {
            for (int i = 0; i < integration.Dependents.Count; i++)
            {
                string dependent = integration.Dependents[i];
                UninstallIntegration(GetIntegration(dependent));
            }
        }

        /// <summary>
        /// Gets integration installed dependents
        /// </summary>
        /// <param name="integration"></param>
        /// <returns></returns>
        public static IntegrationInfo[] GetInstalledDependents(IntegrationInfo integration)
        {
            List<IntegrationInfo> integrations = new List<IntegrationInfo>();
            for (int i = 0; i < integration.Dependents.Count; i++)
            {
                string dependent = integration.Dependents[i];
                IntegrationInfo dependentIntegration = GetIntegration(dependent);
                if (dependentIntegration.Installed)
                {
                    integrations.Add(dependentIntegration);
                }
            }
            return integrations.ToArray();
        }

    }

}