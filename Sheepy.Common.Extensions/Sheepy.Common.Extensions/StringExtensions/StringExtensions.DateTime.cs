namespace System
{
    public static class StringToDateTimeExtensions
    {
        /// <summary>
        /// Converts the specified string representation of a date and time to its DateTime equivalent.
        /// </summary>
        /// <param name="source">A string containing a date and time to convert.</param>
        /// <returns>A DateTime equivalent to the date and time contained in source.</returns>
        /// <exception cref="FormatException">Thrown when the source is not a valid date and time.</exception>
        public static DateTime ToDateTime(this string source) => DateTime.Parse(source);

        /// <summary>
        /// Converts the specified string representation of a date and time to its DateTime equivalent using the specified format or the default format.
        /// </summary>
        /// <param name="source">A string containing a date and time to convert.</param>
        /// <param name="format">The format of the date and time string.</param>
        /// <returns>A DateTime equivalent to the date and time contained in source as specified by format.</returns>
        /// <exception cref="FormatException">Thrown when the source or format is not a valid date and time.</exception>
        public static DateTime ToDateTime(this string source, string format)
        {
            return DateTime.TryParseExact(source, format, null, Globalization.DateTimeStyles.None, out var result)
                ? result
                : DateTime.Parse(source);
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its DateTime equivalent using the specified formats or the default format.
        /// </summary>
        /// <param name="source">A string containing a date and time to convert.</param>
        /// <param name="formats">An array of allowable formats of the date and time string.</param>
        /// <returns>A DateTime equivalent to the date and time contained in source as specified by one of the formats.</returns>
        /// <exception cref="FormatException">Thrown when the source or formats are not valid date and time.</exception>
        public static DateTime ToDateTime(this string source, params string[] formats)
        {
            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(source, format, null, Globalization.DateTimeStyles.None, out var result))
                    return result;
            }
            return DateTime.Parse(source);
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its DateTime equivalent using the specified format strictly.
        /// </summary>
        /// <param name="source">A string containing a date and time to convert.</param>
        /// <param name="format">The format of the date and time string.</param>
        /// <returns>A DateTime equivalent to the date and time contained in source as specified by format.</returns>
        /// <exception cref="FormatException">Thrown when the source or format is not a valid date and time.</exception>
        public static DateTime ToDateTimeStrict(this string source, string format) => DateTime.ParseExact(source, format, null);

        /// <summary>
        /// Converts the specified string representation of a date and time to its DateTime equivalent using the specified formats strictly.
        /// </summary>
        /// <param name="source">A string containing a date and time to convert.</param>
        /// <param name="formats">An array of allowable formats of the date and time string.</param>
        /// <returns>A DateTime equivalent to the date and time contained in source as specified by one of the formats.</returns>
        /// <exception cref="FormatException">Thrown when the source or formats are not valid date and time.</exception>
        public static DateTime ToDateTimeStrict(this string source, params string[] formats)
        {
            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(source, format, null, Globalization.DateTimeStyles.None, out var result))
                    return result;
            }
            throw new FormatException("Source or formats are not valid date and time.");
        }
    }
}