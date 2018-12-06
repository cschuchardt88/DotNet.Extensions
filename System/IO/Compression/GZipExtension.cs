using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace System.IO.Compression
{
    public static class GZipExtension
    {
        /// <summary>
        /// Compresses data using GZip format
        /// </summary>
        /// <param name="RawData">A byte array that you want to be compressed.</param>
        /// <returns>Compressed bytes</returns>
        public static byte[] GZipCompress(this byte[] RawData)
        {
            if (RawData == null) throw new ArgumentException("RawData");
            if (RawData.Length < 1) throw new ArgumentOutOfRangeException("RawData", "Empty byte array.");

            using(MemoryStream ms = new MemoryStream())
            {
                return ms.TryCatchThrow(p =>
                {
                    using(GZipStream gzs = new GZipStream(p, CompressionMode.Compress))
                    {
                        gzs.Write(RawData, 0, RawData.Length);
                    }

                    return p.ToArray();
                });
            }
        }

        /// <summary>
        /// Compresses data using GZip format
        /// </summary>
        /// <param name="strValue">A string that you want to be compressed.</param>
        /// <returns>Compressed string in base64 encoding</returns>
        public static string GZipCompress(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) throw new ArgumentNullException("strValue");

            byte[] RawData = System.Text.Encoding.UTF8.GetBytes(strValue); // RawData variable memory leak.

            using(MemoryStream ms = new MemoryStream())
            {
                return ms.TryCatchThrow(p =>
                {
                    using(GZipStream gzs = new GZipStream(p, CompressionMode.Compress))
                    {
                        gzs.Write(RawData, 0, RawData.Length);
                    }

                    return Convert.ToBase64String(p.ToArray());
                });
            }
        }

        /// <summary>
        /// Decompresses GZip data to original data.
        /// </summary>
        /// <param name="RawData">Compress GZip data</param>
        /// <returns>Original uncompressed data</returns>
        public static byte[] GZipDecompress(this byte[] RawData)
        {
            if (RawData == null) throw new ArgumentException("RawData");
            if (RawData.Length < 1) throw new ArgumentOutOfRangeException("RawData", "Empty byte array.");

            using(MemoryStream dcmpData = new MemoryStream())
            {
                return dcmpData.TryCatchThrow(p =>
                {
                    using(MemoryStream ms = new MemoryStream(RawData))
                    {
                        GZipStream gzs = new GZipStream(ms, CompressionMode.Decompress);
                        gzs.CopyTo(p);
                    }

                    return p.ToArray();
                });
            }
        }

        public static string GZipDecompress(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) throw new ArgumentNullException("strValue");

            byte[] RawData = Convert.FromBase64String(strValue); // RawData variable memory leak.

            using(MemoryStream dcmpData = new MemoryStream())
            {
                return dcmpData.TryCatchThrow(p =>
                {
                    using(MemoryStream ms = new MemoryStream(RawData))
                    {
                        GZipStream gzs = new GZipStream(ms, CompressionMode.Decompress);
                        gzs.CopyTo(p);
                    }

                    return p.ToString();
                });
            }
        }
    }
}
