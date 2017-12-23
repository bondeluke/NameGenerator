using System;
using System.Collections.Generic;

namespace RNG.Names
{
    public delegate T Selector<T>(int index, int totalCount, T previous);

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Enumerate<T>(this int natural, Selector<T> selector)
        {
            var previous = default(T);

            for (var i = 0; i < natural; i++)
            {
                yield return previous = selector(i, natural, previous);
            }
        }
    }
}
