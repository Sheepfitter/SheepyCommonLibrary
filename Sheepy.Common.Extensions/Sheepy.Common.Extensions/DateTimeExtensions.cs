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

        /// <summary>
        /// Sets the time of the specified DateTime to the given hour, minute, second, and millisecond values.
        /// </summary>
        /// <param name="source">The DateTime to modify.</param>
        /// <param name="hour">The hour value.</param>
        /// <param name="minute">The minute value.</param>
        /// <param name="second">The second value. Default is 0.</param>
        /// <param name="millisecond">The millisecond value. Default is 0.</param>
        /// <returns>The modified DateTime with the new time values.</returns>
        public static DateTime SetTime(this DateTime source, int hour, int minute, int second = 0, int millisecond = 0)
        {
            return new DateTime(source.Year, source.Month, source.Day, hour, minute, second, millisecond, source.Kind);
        }

        /// <summary>
        /// Sets the date of the specified DateTime to the given year, month, and day values.
        /// </summary>
        /// <param name="source">The DateTime to modify.</param>
        /// <param name="year">The year value.</param>
        /// <param name="month">The month value.</param>
        /// <param name="day">The day value.</param>
        /// <returns>The modified DateTime with the new date values.</returns>
        public static DateTime SetDate(this DateTime source, int year, int month, int day)
        {
            return new DateTime(year, month, day, source.Hour, source.Minute, source.Second, source.Millisecond, source.Kind);
        }
    }
}