using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SystemDoubleExtensions
    {

        public static bool Precision(this double a, double b, double epsilon)
        {
            double ratio = a / b;
            double diff = Math.Abs(ratio - 1);
            return diff <= epsilon;
        }

        public static bool AlmostEqual(this double a, double b)
        {
            double epsilon = Math.Max(Math.Abs(a), Math.Abs(b)) * 1E-15;
            return Math.Abs(a - b) <= epsilon;
        }
    }
}
