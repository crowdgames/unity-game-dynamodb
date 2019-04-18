using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BayatGames.SaveGamePro.Utilities
{

    /// <summary>
    /// String utils.
    /// </summary>
    public static class StringUtils
    {

        private static System.Random random = new System.Random();

        /// <summary>
        /// Converts string capitialization from Title Case to camel Case.
        /// </summary>
        /// <returns>The camel case.</returns>
        /// <param name="titleCase">Title case.</param>
        public static string ToCamelCase(string titleCase)
        {
            return char.ToLowerInvariant(titleCase[0]) + titleCase.Substring(1);
        }

        /// <summary>
        /// Generates a random string of the given length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

}