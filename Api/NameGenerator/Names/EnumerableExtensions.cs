using System;
using System.Collections.Generic;

namespace RNG.Names
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Select<T>(this int natural, Func<int, T> selector)
        {
            for (var i = 0; i < natural; i++)
            {
                yield return selector(i);
            }
        }
    }
}
