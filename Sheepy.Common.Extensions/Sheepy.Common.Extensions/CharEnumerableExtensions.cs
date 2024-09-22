using System.Linq;

namespace System.Collections.Generic
{
    public static class CharEnumerableExtensions
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> of characters to a string.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of characters to convert.</param>
        /// <returns>A string that consists of the characters in the source.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the source is null.</exception>
        public static string AsString(this IEnumerable<char> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return new string(source.ToArray());
        }
    }
}