using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace System.IO.Compression
{
    public static class DeflateExtension
    {
        /// <summary>
        /// Compresses data using Deflate format
        /// </summary>
        /// <param name="RawData">A byte array that you want to be compressed.</param>
        /// <returns>Compressed bytes</returns>
        public static byte[] DeflateCompress(this byte[] RawData)
        {
            if (RawData == null) throw new ArgumentException("RawData");
            if (RawData.Length < 1) throw new ArgumentOutOfRangeException("RawData", "Empty byte array.");

            using(MemoryStream ms = new MemoryStream())
            {
                return ms.TryCatchThrow(p =>
                {
                    using(DeflateStream ds = new DeflateStream(p, CompressionMode.Compress))
                    {
                        ds.Write(RawData, 0, RawData.Length);
                    }

                    return p.ToArray();
                }); 
            }
        }

        /// <summary>
        /// Decompresses deflate data to original data.
        /// </summary>
        /// <param name="RawData">Compress deflate data</param>
        /// <returns>Original uncompressed data</returns>
        public static byte[] DeflateDecompress(this byte[] RawData)
        {
            if (RawData == null) throw new ArgumentException("RawData");
            if (RawData.Length < 1) throw new ArgumentOutOfRangeException("RawData", "Empty byte array.");

            using(MemoryStream dcmpData = new MemoryStream())
            {
                return dcmpData.TryCatchThrow(p =>
                {
                    using(MemoryStream ms = new MemoryStream(RawData))
                    {
                        DeflateStream ds = new DeflateStream(ms, CompressionMode.Decompress);
                        ds.CopyTo(p);

                        return p.ToArray();
                    }
                });
            }
        }

        /// <summary>
        /// Decompresses deflate data to original data.
        /// </summary>
        /// <param name="strValue">A string that you want to be compressed.</param>
        /// <returns>Compressed string in base64 encoding</returns>
        public static string DeflateCompress(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) throw new ArgumentNullException("strValue");

            byte[] RawData = System.Text.Encoding.UTF8.GetBytes(strValue); // RawData variable memory leak.

            using(MemoryStream ms = new MemoryStream())
            {
                return ms.TryCatchThrow(p =>
                {
                    using(DeflateStream ds = new DeflateStream(p, CompressionMode.Compress))
                    {
                        ds.Write(RawData, 0, RawData.Length);
                    }

                    return Convert.ToBase64String(p.ToArray());
                });
            }
        }

        /// <summary>
        /// Compresses data using Deflate format
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string DeflateDecompress(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue)) throw new ArgumentNullException("strValue");

            byte[] RawData = Convert.FromBase64String(strValue); // RawData variable memory leak.

            using(MemoryStream dcmpData = new MemoryStream())
            {
                return dcmpData.TryCatchThrow(p =>
                {
                    using(MemoryStream ms = new MemoryStream(RawData))
                    {
                        DeflateStream ds = new DeflateStream(ms, CompressionMode.Decompress);
                        ds.CopyTo(p);
                    }

                    return p.ToString();
                });
            }
        }

    }
}
