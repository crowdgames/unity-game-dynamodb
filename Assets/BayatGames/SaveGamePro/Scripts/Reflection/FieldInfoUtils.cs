using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Reflection
{

    /// <summary>
    /// FieldInfo utilities.
    /// </summary>
    public static class FieldInfoUtils
    {

        /// <summary>
        /// Determines if the field is savable.
        /// </summary>
        /// <returns><c>true</c> if is savable the specified field; otherwise, <c>false</c>.</returns>
        /// <param name="field">Field.</param>
        public static bool IsSavable(this FieldInfo field)
        {
            if (field.IsDefined(typeof(NonSavable), false))
            {
                return false;
            }
            if (field.IsDefined(typeof(Savable), false))
            {
                return true;
            }
            return !field.IsDefined(typeof(ObsoleteAttribute), false) &&
            !field.IsInitOnly && !field.IsLiteral && !field.IsDefined(typeof(NonSerializedAttribute), false) && !IsBackingField(field);
        }

        /// <summary>
        /// Determines if the field is a backing field for auto-property.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static bool IsBackingField(this FieldInfo field)
        {
            return field.IsDefined(typeof(CompilerGeneratedAttribute), false);
        }

    }

}