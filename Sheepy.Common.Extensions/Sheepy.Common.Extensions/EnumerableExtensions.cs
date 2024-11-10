namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns a reference enumerator for the specified enumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to get a reference enumerator for.</param>
        /// <returns>A reference enumerator for the specified enumerable.</returns>
        public static RefEnumerator<T> GetRefEnumerator<T>(this IEnumerable<T> enumerable) => new RefEnumerator<T>(enumerable);
    }
}