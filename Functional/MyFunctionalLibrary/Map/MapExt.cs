using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFunctionalLibrary.Map
{
    public static class MapExt
    {
        /// <summary>
        /// Applies a function to each element of the given enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="ts"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static IEnumerable<TR> Map<T, TR>(this IEnumerable<T> ts, Func<T, TR> f)
            => ts.Select(f);

        // TODO - Option<T> Map
    }
}