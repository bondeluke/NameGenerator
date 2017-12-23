using System;

namespace RNG.Names
{
    public class Weighted<T>
    {
        public Weighted(T item, int weight)
        {
            Value = item;

            if (weight < 0)
                throw new ArgumentException("Weight must be non-negative.");

            Weight = weight;
        }

        public T Value { get; }

        public int Weight { get; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Value, Weight);
        }
    }
}
