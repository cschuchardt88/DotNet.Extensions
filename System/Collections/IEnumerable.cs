using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    public static class IEnumerableExtensions
    {

        public static int Count(this IEnumerable source)
        {
            int count = 0;

            foreach (var item in source)
                count++;

            return count;
        }
    }
}
