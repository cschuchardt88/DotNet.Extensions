using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SystemStringParseExtensions
    {
        /// <summary>
        /// Parses string to System.int
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns>System.int of the string. returns 0 if string is null or not a number.</returns>
        public static int ParseInt(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return 0;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return 0;

            int icon = 0;

            int.TryParse(strValue, out icon);

            return icon;
        }

        /// <summary>
        /// Parses string to System.Int16
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns>System.Int16 of the string. returns 0 if string is null or not a number.</returns>
        public static Int32 ParseInt16(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return 0;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return 0;

            Int16 icon = 0;

            Int16.TryParse(strValue, out icon);

            return icon;
        }

        /// <summary>
        /// Parses string to System.Int32
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns>System.Int32 of the string. returns 0 if string is null or not a number.</returns>
        public static Int32 ParseInt32(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return 0;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return 0;

            Int32 icon = 0;

            Int32.TryParse(strValue, out icon);

            return icon;
        }

        /// <summary>
        /// Parses string to System.Int64
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns>System.Int64 of the string. returns 0 if string is null or not a number.</returns>
        public static Int64 ParseInt64(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return 0;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return 0;

            Int64 icon = 0;

            Int64.TryParse(strValue, out icon);

            return icon;
        }

        /// <summary>
        /// Parses string to System.short
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns>System.short of the string. returns 0 if string is null or not a number.</returns>
        public static short ParseShort(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return 0;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return 0;

            short stret = 0;

            short.TryParse(strValue, out stret);

            return stret;
        }

        /// <summary>
        /// Parses string to System.long
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns>System.long of the string. returns 0 if string is null or not a number.</returns>
        public static long ParseLong(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return 0;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return 0;

            long lngRet = 0;

            long.TryParse(strValue, out lngRet);

            return lngRet;
        }

        /// <summary>
        /// Parses string to System.double
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns>System.double of the string. returns 0 if string is null or not a number.</returns>
        public static double ParseDouble(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return 0d;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return 0d;

            double dblRet = 0d;

            Double.TryParse(strValue, out dblRet);

            return dblRet;
        }

        /// <summary>
        /// Parses string to System.decimal
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns>System.decimal of the string. returns 0 if string is null or not a number.</returns>
        public static decimal ParseDecimal(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return 0;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return 0;

            decimal dmlRet = 0;

            Decimal.TryParse(strValue, out dmlRet);

            return dmlRet;
        }

        /// <summary>
        ///  Value can be null, 1, 0, on, off, true, false, yes or no as strings
        /// </summary>
        /// <param name="strValue">Must be a string of at least null, 1, 0, on, off, true, false, yes or no</param>
        /// <returns></returns>
        public static bool ParseBool(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return false;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return false;
            if (strValue.Equals("1", StringComparison.OrdinalIgnoreCase)) return true;
            if (strValue.Equals("on", StringComparison.OrdinalIgnoreCase)) return true;
            if (strValue.Equals("yes", StringComparison.OrdinalIgnoreCase)) return true;

            bool boolRet = false;

            bool.TryParse(strValue, out boolRet);

            return boolRet;
        }

        /// <summary>
        ///  Value can be null, 1, 0, on, off, true, false, yes or no as strings
        /// </summary>
        /// <param name="strValue">Must be a string of at least null, 1, 0, on, off, true, false, yes or no</param>
        /// <returns></returns>
        public static Boolean ParseBoolean(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) return false;
            if (strValue.Equals("null", StringComparison.OrdinalIgnoreCase)) return false;
            if (strValue.Equals("1", StringComparison.OrdinalIgnoreCase)) return true;
            if (strValue.Equals("on", StringComparison.OrdinalIgnoreCase)) return true;
            if (strValue.Equals("yes", StringComparison.OrdinalIgnoreCase)) return true;

            Boolean boolRet = false;

            Boolean.TryParse(strValue, out boolRet);

            return boolRet;
        }

        /// <summary>
        /// Parses string to System.DateTime
        /// </summary>
        /// <param name="strValue">Current string</param>
        /// <returns></returns>
        public static DateTime ParseDateTime(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) throw new NullReferenceException();

            DateTime d;

            if (DateTime.TryParse(strValue, out d) == false)
                throw new FormatException("Can't Parse string to DateTime. Invalid format.");

            return d;
        }
    }
}
