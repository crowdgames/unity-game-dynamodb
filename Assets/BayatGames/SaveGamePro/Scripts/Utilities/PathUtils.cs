using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BayatGames.SaveGamePro.Utilities
{

    /// <summary>
    /// Path utils.
    /// </summary>
    public static class PathUtils
    {

        /// <summary>
        /// Gets the relative path to the project assets folder path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetAssetsRelativePath(string path)
        {
            if (path.StartsWith(Application.dataPath))
            {
                return "Assets" + path.Substring(Application.dataPath.Length);
            }
            return path;
        }

    }

}