using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string enumString)
        {
            EnumHelper.ThrowExceptionIfNotEnum<T>();

            return (T)Enum.Parse(typeof(T), enumString);
        }

        public static LetterGroupType GetOpposite(this LetterGroupType value)
        {
            return (LetterGroupType)((((int)value) + 1) % 2);
        }
    }

    public static class EnumHelper
    {
        public static IEnumerable<T> Enumerate<T>()
        {
            EnumHelper.ThrowExceptionIfNotEnum<T>();

            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static bool IsEnum<T>()
        {
            return true;
        }

        public static void ThrowExceptionIfNotEnum<T>()
        {
            if (!EnumHelper.IsEnum<T>())
                throw new ArgumentException("T is not of type enum");
        }
    }
}
