using System;
using System.Collections.Generic;
using System.Linq;

namespace RNG.Names
{
    public sealed class WeightedDictionary<T>
    {
        public WeightedDictionary(Weighted<T>[] weightedItems)
        {
            TotalWeight = weightedItems.Sum(x => x.Weight);

            _itemLookup = new List<KeyValuePair<int, T>>();

            var cumulativeWeight = 0;

            foreach (var item in weightedItems)
            {
                _itemLookup.Add(new KeyValuePair<int, T>(cumulativeWeight, item.Value));
                cumulativeWeight += item.Weight;
            }

            _itemLookup.Add(new KeyValuePair<int, T>(cumulativeWeight, default(T)));
        }

        private readonly List<KeyValuePair<int, T>> _itemLookup;

        public readonly int TotalWeight;

        public T this[int index]
        {
            get
            {
                if (index < 0 || TotalWeight <= index)
                    throw new ArgumentOutOfRangeException(nameof(index));

                for (var i = 0; i < _itemLookup.Count; i++)
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
    }
}
