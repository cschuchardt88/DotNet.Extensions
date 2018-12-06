using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class ByteArrayExtensions
    {

        /// <summary>
        /// Takes a byte array and encodes it to a Base64 string.
        /// </summary>
        /// <param name="btValue">Current byte array</param>
        /// <returns>Base64 encode string.</returns>
        public static string ToBase64(this byte[] btValue)
        {
            if (btValue == null) return String.Empty;
            if (btValue.Length == 0) return String.Empty;

            return Convert.ToBase64String(btValue);
        }

    }
}
