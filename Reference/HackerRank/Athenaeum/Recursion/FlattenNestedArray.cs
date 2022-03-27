using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Recursion
{
    public static class FlattenNestedArray
    {
        public static IEnumerable<object> FlattenArray(IEnumerable<object> source)
        {
            return source
                .SelectMany(x => x is Array ?
                    ((IEnumerable)x).Cast<object>() : Enumerable.Repeat(x, 1));
        }

        public static IEnumerable<object> FlattenNestedArrayRecursive(IEnumerable<object> source)
        {
            static IEnumerable<object> flatten(IEnumerable<object> s) => s.SelectMany(x =>
              {
                  return x is Array ? flatten(((IEnumerable)x).Cast<object>()) : Enumerable.Repeat(x, 1);
              });

            return flatten(source);
        }
    }

    public static class FlattenExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> @this)
        {

            foreach (var item in @this)
            {
                if (item is IEnumerable<T> enumerable)
                {
                    foreach (var subitem in Flatten(enumerable))
                    {
                        yield return subitem;
                    }
                }

                else yield return item;
            }
        }
    }
}
