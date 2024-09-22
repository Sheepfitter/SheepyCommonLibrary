using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
    {
        /// <summary>
        ///     Checks if the source is empty.
        /// </summary>
        /// <returns><b>True</b> - if the source is empty, otherwise <b>false</b>.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();

        /// <summary>
        ///     Checks if the source is not empty.
        /// </summary>
        /// <returns><b>True</b> - if the source is not empty, otherwise <b>false</b>.</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source) => !source.IsEmpty();
    }
}