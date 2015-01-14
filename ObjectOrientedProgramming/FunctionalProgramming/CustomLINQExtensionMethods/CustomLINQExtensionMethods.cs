using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomLINQExtensionMethods
{
    public static class CustomLINQExtensionMethods
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(x => !predicate(x));
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            for (int i = 0; i < count; i++)
            {
                foreach (var item in collection)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<string> WhereEndsWith<string>(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            return from suffix in suffixes
                   from item in collection
                   where item.EndsWith(suffix)
                   select item;
        }
    }
}