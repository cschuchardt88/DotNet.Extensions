using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SystemConvertExtensions
    {
        /// <summary>
        /// Tries to convert an object to a System.Byte. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static byte ToByte(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToByte(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Tries to convert an object to a System.Char. If the object is null returns '\0'
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static char ToChar(this object anonymousObject)
        {
            if (anonymousObject == null) return '\0';

            try
            {
                return Convert.ToChar(anonymousObject);
            }
            catch
            {
                return '\0';
            }
        }

        /// <summary>
        /// Tries to convert an object to a System.Decimal. If the object is null returns 0.00m
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static decimal ToDecimal(this object anonymousObject)
        {
            if (anonymousObject == null) return 0.00m;

            try
            {
                return Convert.ToDecimal(anonymousObject);
            }
            catch
            {
                return 0.00m;
            }
        }

        /// <summary>
        /// Tries to convert an object to a System.Double. If the object is null returns 0.00d
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static double ToDouble(this object anonymousObject)
        {
            if (anonymousObject == null) return 0.00d;

            try
            {
                return Convert.ToDouble(anonymousObject);
            }
            catch
            {
                return 0.00d;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.Short. If the objet is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static short ToShort(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToInt16(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.Int16. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static Int16 ToInt16(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToInt16(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.Int32. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static Int32 ToInt32(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToInt32(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.Int. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static int ToInt(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToInt32(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.Int64. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static Int64 ToInt64(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToInt64(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries a to convert a object to a System.Long. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static long ToLong(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToInt64(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to a System.Bool. If the object is null returns false.
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static bool ToBool(this object anonymousObject)
        {
            if (anonymousObject == null) return false;

            try
            {
                return Convert.ToBoolean(anonymousObject);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// tries to convert an object to a System.Boolean. If the object is null returns false.
        /// </summary>
        /// <param name="anonymousObject">Current object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static Boolean ToBoolean(this object anonymousObject)
        {
            if (anonymousObject == null) return false;

            try
            {
                return Convert.ToBoolean(anonymousObject);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tries to convert an object to a System.Single. If the object is null returns 0.00f
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static float ToSingle(this object anonymousObject)
        {
            if (anonymousObject == null) return 0.00f;

            try
            {
                return Convert.ToSingle(anonymousObject);
            }
            catch
            {
                return 0.00f;
            }
        }

        /// <summary>
        /// Tries to covert an object to a System.SByte. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static sbyte ToSByte(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToSByte(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.UShort. If the objet is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static ushort ToUShort(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToUInt16(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.UInt16. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static UInt16 ToUInt16(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToUInt16(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.UInt32. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static UInt32 ToUInt32(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToUInt32(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.UInt. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static uint ToUInt(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToUInt32(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.UInt64. If the object is null returns 0
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static UInt64 ToUInt64(this object anonymousObject)
        {
            if (anonymousObject == null) return 0;

            try
            {
                return Convert.ToUInt64(anonymousObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.IntPtr. If the object is null returns IntPtr.Zero
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static IntPtr ToIntPtr(this object anonymousObject)
        {
            if (anonymousObject == null) return IntPtr.Zero;

            try
            {
                return (IntPtr)anonymousObject;
            }
            catch
            {
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.UIntPtr. If the object is null returns UIntPtr.Zero
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Other wise the null value of data type.</returns>
        public static UIntPtr ToUIntPtr(this object anonymousObject)
        {
            if (anonymousObject == null) return UIntPtr.Zero;

            try
            {
                return (UIntPtr)anonymousObject;
            }
            catch
            {
                return UIntPtr.Zero;
            }
        }

        /// <summary>
        /// tries to convert an object to an System.DateTime.
        /// </summary>
        /// <param name="anonymousObject">Currnet object.</param>
        /// <returns>If data structure can be converted. Throws error.</returns>
        public static DateTime ToDateTime(this object anonymousObject)
        {
            if (anonymousObject == null) throw new ObjectDisposedException("anonymousObject", "Object is null");

            try
            {
                return Convert.ToDateTime(anonymousObject);
            }
            catch
            {
                throw;
            }
        }
    }
}
