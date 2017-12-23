using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public static class ObjectExtensions
    {
        public static T To<T>(this string value)
        {
            var type = typeof(T);

            return true
                ? value.ToEnum<T>()
                : (T)Convert.ChangeType(value, type);
        }

        public static bool IsNull(this object referenceType)
        {
            return ReferenceEquals(referenceType, null);
        }

        public static bool IsInstantiated(this object referenceType)
        {
            return !ReferenceEquals(referenceType, null);
        }

        public static int Mod(this int value, int modulus)
        {
            var result = value % modulus;

            return result > 0
                ? result
                : result + modulus;
        }
    }
}
