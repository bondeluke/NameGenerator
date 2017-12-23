using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public class KeyValuePairList <T,T2>: List<KeyValuePair<T, T2>>
    {
        public void Add(T key, T2 value)
        {
            Add(new KeyValuePair<T, T2>(key, value));
        }
    }
}
