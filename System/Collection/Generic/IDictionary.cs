using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    public static class IDictionaryExtensions
    {
        public static IDictionary<TKey, TValue> AddRange<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey[] tKeys, TValue[] tVals)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (tKeys == null) throw new ArgumentNullException();
            if (tKeys.Length == 0) throw new ArgumentNullException();


            IDictionary<TKey, TValue> cur = new Dictionary<TKey, TValue>();

            for(int i = 0; i < tKeys.Length; i++)
                source.Add(new KeyValuePair<TKey, TValue>(tKeys[i], tVals[i]));

            return cur;
        }

        /// <summary>
        /// Extension method that turns a dictionary of string and object to an ExpandoObject
        /// </summary>
        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
        {
            if (dictionary == null) throw new NullReferenceException("dictionary");
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando; // invaild type...

            // go through the items in the dictionary and copy over the key value pairs)
            foreach (var kvp in dictionary)
            {
                // if the value can also be turned into an ExpandoObject, then do it!
                if (kvp.Value is IDictionary<string, object>)
                {
                    var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
                    expandoDic.Add(kvp.Key, expandoValue);
                }
                else if (kvp.Value is ICollection)
                {
                    // iterate through the collection and convert any strin-object dictionaries
                    // along the way into expando objects
                    var itemList = new List<object>();
                    foreach (var item in (ICollection)kvp.Value)
                    {
                        if (item is IDictionary<string, object>)
                        {
                            var expandoItem = ((IDictionary<string, object>)item).ToExpando();
                            itemList.Add(expandoItem);
                        }
                        else
                        {
                            itemList.Add(item);
                        }
                    }

                    expandoDic.Add(kvp.Key, itemList);
                }
                else
                {
                    expandoDic.Add(kvp);
                }
            }

            return expando;
        }
    }
}
