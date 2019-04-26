using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BayatGames.SaveGamePro.Utilities
{

    /// <summary>
    /// Stream utils.
    /// </summary>
    public static class StreamUtils
    {

        /// <summary>
        /// Reads the stream fully and returns the byte array.
        /// </summary>
        /// <returns>The byte array.</returns>
        /// <param name="input">Input.</param>
        public static byte[] ReadFully(this Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }

}