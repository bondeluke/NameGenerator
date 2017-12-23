using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomNameGenerator
{
    public sealed class WeightedDictionary<T>
    {
        public WeightedDictionary(IEnumerable<Weighted<T>> weightedItems)
        {
            _totalWeight = weightedItems.Sum(x => x.Weight);
            _itemLookup = new KeyValuePairList<int, T>();

            var cumulativeWeight = 0;
            foreach (var item in weightedItems.Where(i => i.Weight > 0))
            {
                _itemLookup.Add(cumulativeWeight, item.Value);
                cumulativeWeight += item.Weight;
            }
            _itemLookup.Add(cumulativeWeight, default(T));
        }

        private readonly KeyValuePairList<int, T> _itemLookup;

        private readonly int _totalWeight;

        public T this[int index]
        {
            get
            {
                if (index < 0 || _totalWeight <= index)
                    throw new ArgumentOutOfRangeException("key");

                for (int i = 0; i < _itemLookup.Count; i++)
                {
                    var currentKey = _itemLookup[i].Key;
                    var nextKey = _itemLookup[i + 1].Key;
                    if (currentKey <= index && index < nextKey)
                    {
                        return _itemLookup[i].Value;
                    }
                }

                throw new Exception();
            }
        }

        public T GetRandomItem(Random random)
        {
            return this[random.Next(_totalWeight)];
        }
    }

    public static class WeightedDictionaryExtensions
    {
        public static WeightedDictionary<T> ToWeightedDictionary<T>(this IEnumerable<Weighted<T>> weightedItems)
        {
            return new WeightedDictionary<T>(weightedItems);
        }

        public static WeightedDictionary<T> ToWeightedDictionary<T>(this IEnumerable<T> items, Func<T, int> weightSelector)
        {
            return items.Select(item => item.ToWeighted(weightSelector)).ToWeightedDictionary();
        }

        public static Weighted<T> ToWeighted<T>(this T item, Func<T, int> weightSelector)
        {
            return new Weighted<T>(item, weightSelector(item));
        }

    }
}
