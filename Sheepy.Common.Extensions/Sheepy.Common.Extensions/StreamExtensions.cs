namespace System.IO
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="Stream"/> to a byte array.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to convert.</param>
        /// <returns>A byte array containing the contents of the stream.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream is null.</exception>
        public static byte[] ToByteArray(this Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (stream is MemoryStream memoryStream)
                return memoryStream.ToArray();

            using var ms = stream.CanSeek ? new MemoryStream((int)stream.Length) : new MemoryStream();
            stream.CopyTo(ms, 81920); // Use a larger buffer size for better performance
            return ms.ToArray();
        }
    }
}