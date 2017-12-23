using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public static class StringExtensions
    {
        public static string StringJoin(this IEnumerable<string> enumerable, string separator = "")
        {
            return string.Join(separator, enumerable);
        }

        public static string StringJoin<T>(this IEnumerable<T> enumerable, string separator = "")
        {
            return string.Join<T>(separator, enumerable);
        }

        public static string ToTitleCase(this string value)
        {
            if (value.IsNullOrWhiteSpace())
                return value;

            if (value.Length == 1)
                return value.ToUpper();

            return char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }

        public static bool HasContent(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool ContainsAnElementOf(this string value, IEnumerable<string> elements)
        {
            return elements.Any(e => value.Contains(e));
        }
    }
}
