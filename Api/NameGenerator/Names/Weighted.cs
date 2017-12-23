using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomNameGenerator
{
    public class Weighted<T>
    {
        public Weighted(T item, int weight)
        {
            Value = item;
            Weight = weight;
        }

        public T Value { get; private set; }

        public int Weight { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Value, Weight);
        }
    }
}
