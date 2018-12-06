using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Numerics
{
    public static class NumberCheckerExtension
    {
        public static bool isPositive(this object num)
        {
            dynamic dynObj = num;
            
            try { return (dynObj > 0); }
            catch { return false; }
        }

        public static bool isNegative(this object num)
        {
            dynamic dynObj = num;

            try { return (dynObj < 0); }
            catch { return false; }
        }

        public static bool isZero(this object num)
        {
            dynamic dynObj = num;

            try { return (dynObj == 0); }
            catch { return false; }
        }

        public static bool isEven(this object num)
        {
            dynamic dynObj = num;

            try { return (dynObj % 2 == 0); }
            catch { return false; }
        }

        public static bool isOdd(this object num)
        {
            dynamic dynObj = num;

            try { return (dynObj % 2 != 0); }
            catch { return false; }
        }

        public static bool isPrime(this object num)
        {
            dynamic dynObj = num;

            try
            {
                if (dynObj % 2 == 0)
                {
                    if (dynObj == 2)
                    {
                        return true;
                    }
                    return false;
                }

                int max = Math.Sqrt(dynObj);

                for (int i = 3; i <= max; i += 2)
                {
                    if ((dynObj % i) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch { return false; }
        }
    }
}
