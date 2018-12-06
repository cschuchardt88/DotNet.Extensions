using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class CharExtensions
    {
        /// <summary>
        /// Get System.Char from a System.String by passing in the index of the string array.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="CharIndex"></param>
        /// <returns></returns>
        public static char CharAt(this string strValue, int CharIndex)
        {
            if (String.IsNullOrEmpty(strValue)) return '\0';

            return strValue.TryCatchThrow(s => s[CharIndex]);
        }

        /// <summary>
        /// Set a System.Char at the string array index.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="CharIndex"></param>
        /// <param name="SetChar"></param>
        /// <returns></returns>
        public static string SetCharAt(this string strValue, int CharIndex, char SetChar)
        {
            if (String.IsNullOrEmpty(strValue)) return String.Empty;
            if (CharIndex < 0) return String.Empty;
            if (SetChar.CompareTo(Char.MinValue) < 0) return String.Empty;
            if (SetChar.CompareTo(Char.MaxValue) > 0) return String.Empty;

            char[] SomeStupidArray = strValue.ToCharArray(); // Memory leak

            if (CharIndex > SomeStupidArray.Count()) return String.Empty;

            SomeStupidArray[CharIndex] = SetChar;

            SomethingStupidArray = null;

            return new string(SomeStupidArray);
        }

    }
}
