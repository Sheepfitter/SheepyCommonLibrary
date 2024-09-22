using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Determines whether the specified collection is empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to check for emptiness.</param>
        /// <returns><c>true</c> if the collection is empty; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the source collection is null.</exception>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return !source.Any();
        }

        /// <summary>
        /// Determines whether the specified collection is not empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to check for non-emptiness.</param>
        /// <returns><c>true</c> if the collection is not empty; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the source collection is null.</exception>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return !source.IsEmpty();
        }
    }
}