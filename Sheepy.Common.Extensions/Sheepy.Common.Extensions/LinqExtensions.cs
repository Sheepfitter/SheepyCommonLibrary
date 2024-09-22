using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();
        public static bool IsNotEmpty<T>(this IEnumerable<T> source) => !source.IsEmpty();
    }
}