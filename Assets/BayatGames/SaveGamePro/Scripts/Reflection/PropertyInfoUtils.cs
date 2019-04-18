using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Reflection
{

    /// <summary>
    /// PropertyInfo utilities.
    /// </summary>
    public static class PropertyInfoUtils
    {

        /// <summary>
        /// Determines if the property is savable.
        /// </summary>
        /// <returns><c>true</c> if is savable the specified property; otherwise, <c>false</c>.</returns>
        /// <param name="property">Property.</param>
        public static bool IsSavable(this PropertyInfo property)
        {
            if (property.IsDefined(typeof(NonSavable), false))
            {
                return false;
            }
            if (property.IsDefined(typeof(Savable), false))
            {
                return true;
            }
            return !property.IsDefined(typeof(ObsoleteAttribute), false) &&
            property.CanRead && property.CanWrite && property.GetIndexParameters().Length == 0;
        }

    }

}