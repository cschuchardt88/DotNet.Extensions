using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.IO;
using System.Xml.Serialization;
using System.Web;
using System.Reflection;

namespace System.Collections.Generic
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// converts a enumerable collection to a Hashset collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the members of values.</typeparam>
        /// <param name="source">enumerable object to use</param>
        /// <returns>Hastset type of the enumerable.</returns>
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return new HashSet<TSource>(source);
        }

        /// <summary>
        /// Concatenates the members of a collection, using the specified separator between
        /// each member.
        /// </summary>
        /// <typeparam name="TSource">The type of the members of values.</typeparam>
        /// <param name="source">A collection that contains the objects to concatenate.</param>
        /// <param name="seperator">The string to use as a separator.</param>
        /// <returns>
        ///     A string that consists of the members of values delimited by the separator
        ///     string. If values has no members, the method returns System.String.Empty.
        /// </returns>
        public static string JoinString<TSource>(this IEnumerable<TSource> source, string seperator = "")
        {
            if (source == null) throw new ArgumentNullException("source");
            return String.Join(seperator, source);
        }

    }
}
