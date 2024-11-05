namespace System
{
    /// <summary>
    /// Provides extension methods for the DateTime structure.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Determines whether the specified DateTime is between the given start and end DateTime values.
        /// </summary>
        /// <param name="source">The DateTime to check.</param>
        /// <param name="start">The start DateTime value.</param>
        /// <param name="end">The end DateTime value.</param>
        /// <param name="inclusive">If true, the range is inclusive; otherwise, it is exclusive.</param>
        /// <returns>True if the source DateTime is between the start and end values; otherwise, false.</returns>
        public static bool IsBetween(this DateTime source, DateTime start, DateTime end, bool inclusive = true)
        {
            return inclusive
                ? source >= start && source <= end
                : source > start && source < end;
        }

        /// <summary>
        /// Clamps the specified DateTime to be within the given minimum and maximum DateTime values.
        /// </summary>
        /// <param name="source">The DateTime to clamp.</param>
        /// <param name="min">The minimum DateTime value.</param>
        /// <param name="max">The maximum DateTime value.</param>
        /// <returns>The clamped DateTime value.</returns>
        public static DateTime Clamp(this DateTime source, DateTime min, DateTime max)
        {
            if (source < min) return min;
            if (source > max) return max;
            return source;
        }
    }
}