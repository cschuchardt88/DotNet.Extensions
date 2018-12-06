using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace System.Dynamic
{
    public static class DynamicHelper
    {
        /// <summary>
        /// Checks to see if a Property exists on dynamic type.
        /// </summary>
        /// <param name="dynObj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool DynamicPropertyExists(dynamic dynObj, string propertyName, bool IgnoreCase = true)
        {
            if (dynObj == null) throw new ArgumentNullException("dynObj");
            if (String.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("propertyName");

            DynamicObject DynDictionary;

            try
            {
                DynDictionary = dynObj as DynamicObject;
            }
            catch { throw; }

            return (DynDictionary.GetDynamicMemberNames().TryCatchThrow(w => w.Where(p => (IgnoreCase == true ? p.Equals(propertyName, StringComparison.OrdinalIgnoreCase) : p.Equals(propertyName))).Count() > 0));
        }

        /// <summary>
        /// Gets a list of Properties on a dynamic type.
        /// </summary>
        /// <param name="dynObj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetDynmaicProperties(dynamic dynObj)
        {
            if (dynObj == null) throw new ArgumentNullException("dynObj");

            DynamicObject DynDictionary;

            try
            {
                DynDictionary = dynObj as DynamicObject;
            }
            catch { throw; }

            return DynDictionary.GetDynamicMemberNames();
        }
    }
}
