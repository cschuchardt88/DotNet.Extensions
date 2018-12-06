using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace System.Collections
{
    public static class BitArrayExtension
    {
        /// <summary>
        /// Converts a BitArray type to a byte array.
        /// </summary>
        /// <param name="bitArrayData">BitArray data</param>
        /// <returns>byte array of the BitArray.</returns>
        public static byte[] ToByteArray(this BitArray bitArrayData)
        {
            List<byte> ret = new List<byte>();
            int count = 0;
            byte currentByte = 0;

            foreach(bool b in bitArrayData)
            {
                if (b) currentByte |= (1 << count).ToByte();

                count++;

                if (count == 7) { ret.Add(currentByte); currentByte = 0; count = 0; }
            }

            if (count < 7) ret.Add(currentByte);

            return ret.ToArray();
        }
    }
}
