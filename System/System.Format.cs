using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SystemFormat
    {
        private const int PRECISION = 2;

        private static IList<string> Units;

        static SystemFormat()
        {
            Units = new List<string>()
            {
                "B", "KB", "MB", "GB", "TB"
            };
        }

        /// <summary>
        /// Formats the value as a filesize in bytes (KB, MB, etc.)
        /// </summary>
        /// <param name="bytes">This value.</param>
        /// <returns>Filesize and quantifier formatted as a string.</returns>
        public static string ToStringFileSizeFormat(this object bytes)
        {
            try {
                double pow = Math.Floor((bytes.ToInt() > 0 ? Math.Log(bytes.ToInt()) : 0) / Math.Log(1024));
                pow = Math.Min(pow, Units.Count - 1);
                double value = bytes.ToDouble() / Math.Pow(1024, pow);
                return value.ToString(pow == 0 ? "F0" : "F" + PRECISION.ToString()) + " " + Units[pow.ToInt()];
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
