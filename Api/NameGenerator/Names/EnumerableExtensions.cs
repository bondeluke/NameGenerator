using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Select<T>(this Natural natural, Func<int, T> selector)
        {
            for (int i = 0; i < natural.Value; i++)
            {
                yield return selector(i);
            }
        }

        public static Natural ToNatural(this int value)
        {
            return new Natural(value);
        }

        public static void AddIfNotPresent<T>(this ICollection<T> items, T item)
        {
            if (!items.Contains(item))
                items.Add(item);
        }

        public static IEnumerable<T> ToSingleton<T>(this T item)
        {
            return new[] { item };
        }

        public static IEnumerable<T> WhereInstantiated<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Where(item => item.IsInstantiated());
        }
    }
}
