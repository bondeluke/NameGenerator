using System;
using System.Collections.Generic;
using System.Linq;

namespace RNG.Names
{
    public static class WeightedExtensions
    {
        private static readonly Random Rng = new Random();

        public static WeightedDictionary<T> ToWeightedDictionary<T>(this IEnumerable<T> items, Func<T, int> weightSelector)
        {
            return new WeightedDictionary<T>(
                items
                    .Select(item => new Weighted<T>(item, weightSelector(item)))
                    .ToArray()
            );
        }

        public static T GetRandomItem<T>(this WeightedDictionary<T> dict)
        {
            return dict[Rng.Next(dict.TotalWeight)];
        }
    }
}