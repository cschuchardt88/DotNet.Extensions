using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace System.Linq
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts a Enumerable collection to a SerializableDictionary class.
        /// </summary>
        /// <typeparam name="TSource">Enumerable collection</typeparam>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TElement">The value type.</typeparam>
        /// <param name="source">Enumerable collection</param>
        /// <param name="keySelector">Key selector function</param>
        /// <param name="elementSelector">Value selector function</param>
        /// <returns>SerializableDictionary type of the enumerable collection.</returns>
        public static SerializableDictionary<TKey, TElement> ToSerializableDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            if (source == null) throw new ArgumentNullException("source");

            SerializableDictionary<TKey, TElement> cur = new SerializableDictionary<TKey, TElement>();

            foreach(TSource item in source)
                cur.Add(keySelector(item), elementSelector(item));

            return cur;
        }

        /// <summary>
        /// Finds all indexes of a value.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static int[] FindAllIndexOf<TSource>(this IEnumerable<TSource> items, TSource value)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Select((b, i) => Object.Equals(b, value) ? i : -1).Where(i => i != -1).ToArray();
        }

        /// <summary>
        /// Finds all indexes of a value.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static int[] FindAllIndexOf<TSource>(this IEnumerable<TSource> items, Func<TSource, bool> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");

            return items.Select((b, i) => predicate(b) ? i : -1).Where(i => i != -1).ToArray();
        }

        /// <summary>
        /// Finds an index of a value from a enumerable collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the members of values.</typeparam>
        /// <param name="items">Enumerable collection</param>
        /// <param name="predicate">expression to find.</param>
        /// <returns>Index location from the collection.</returns>
        public static int FindIndex<TSource>(this IEnumerable<TSource> items, Func<TSource, bool> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            int retVal = 0;
            foreach(var item in items)
            {
                if (predicate(item)) return retVal;
                retVal++;
            }
            return -1;
        }

        /// <summary>
        /// Finds an index of a value from a enumerable collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the members of values.</typeparam>
        /// <param name="items">Enumerable collection</param>
        /// <param name="item">Item value to find.</param>
        /// <returns>Index location from the collection.</returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> items, TSource item)
        {
            return items.FindIndex(i => EqualityComparer<TSource>.Default.Equals(item, i));
        }

        /// <summary>
        /// Finds duplicates in a enumerable collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the members of values.</typeparam>
        /// <param name="source">Enumerable collection</param>
        /// <returns>
        /// A enumerable collection of the duplicates. Collection will
        /// have a count/length of zero, if no duplicates.
        /// </returns>
        public static IEnumerable<TSource> GetDuplicates<TSource>(this IEnumerable<TSource> source)
        {
            HashSet<TSource> itemsSeen = new HashSet<TSource>();
            HashSet<TSource> itemsYielded = new HashSet<TSource>();

            foreach(TSource item in source)
            {
                if (!itemsSeen.Add(item))
                {
                    if (itemsYielded.Add(item))
                    {
                        yield return item;
                    }
                }
            }

            itemsSeen.Clear();
            itemsSeen = null;
            itemsYielded.Clear();
            itemsYielded = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null) throw new NullReferenceException();
            
            foreach(var x in source)
                action(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="fromInclusive"></param>
        /// <param name="toExclusive"></param>
        /// <param name="action"></param>
        public static void For<TSource>(this IEnumerable<TSource> source, int fromInclusive, int toExclusive, Action<TSource, int> action)
        {
            if (source == null) throw new NullReferenceException();
            if (fromInclusive > toExclusive) throw new IndexOutOfRangeException();
            if (fromInclusive < 0) throw new IndexOutOfRangeException();
            if (toExclusive > source.Count()) throw new IndexOutOfRangeException();

            int retVal = 0;

            foreach (var x in source)
            {
                if (retVal >= fromInclusive && retVal < toExclusive)
                    action(source.ElementAt(retVal), retVal);

                retVal++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="fromInclusive"></param>
        /// <param name="toExclusive"></param>
        /// <param name="action"></param>
        public static void For<TSource>(this IEnumerable<TSource> source, int fromInclusive, int toExclusive, Action<int> action)
        {
            if (source == null) throw new NullReferenceException();
            if (fromInclusive > toExclusive) throw new IndexOutOfRangeException();
            if (fromInclusive < 0) throw new IndexOutOfRangeException();
            if (toExclusive > source.Count()) throw new IndexOutOfRangeException();

            int retVal = 0;

            foreach(var x in source)
            {
                if (retVal >= fromInclusive && retVal < toExclusive)
                    action(retVal);

                retVal++;
            }
        }

    }
}
