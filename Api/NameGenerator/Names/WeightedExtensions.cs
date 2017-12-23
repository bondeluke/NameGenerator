using System;
using System.Linq;

namespace RNG.Names
{
    public static class WeightedExtensions
    {
        public static WeightedDictionary<T> ToWeightedDictionary<T>(this Weighted<T>[] weightedItems)
        {
            return new WeightedDictionary<T>(weightedItems);
        }

        public static WeightedDictionary<T> ToWeightedDictionary<T>(this T[] items, Func<T, int> weightSelector)
        {
            return items
                .Select(item => item.ToWeighted(weightSelector))
                .ToArray()
                .ToWeightedDictionary();
        }

        public static Weighted<T> ToWeighted<T>(this T item, Func<T, int> weightSelector)
        {
            return new Weighted<T>(item, weightSelector(item));
        }
    }
}