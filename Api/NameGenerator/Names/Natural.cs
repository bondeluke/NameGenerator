using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public class Natural
    {
        public Natural(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value");

            Value = value;
        }

        public int Value { get; private set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
