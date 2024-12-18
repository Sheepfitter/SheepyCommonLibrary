using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace System
{
    public static class StringPathExtensions
    {
        /// <summary>
        /// Gets the first directory in the specified path.
        /// </summary>
        /// <param name="source">The path to get the first directory from.</param>
        /// <returns>The name of the first directory in the specified path.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified path does not contain any directories or is not a well-formed path string.</exception>
        public static string GetFirstDirectory(this string source)
        {
            var directoryPath = Path.GetDirectoryName(source);
            if (string.IsNullOrEmpty(directoryPath) || Path.IsPathRooted(directoryPath) && Path.GetPathRoot(directoryPath) == source)
                throw new ArgumentException("The specified path does not contain any directories.", nameof(source));

            if (!Path.IsPathRooted(source))
                source = Path.DirectorySeparatorChar + source;

            if (!Uri.TryCreate(source, UriKind.RelativeOrAbsolute, out _))
                throw new ArgumentException("The specified path is not a well-formed path string.", nameof(source));

            var directory = new DirectoryInfo(source);
            while (directory.Parent != null && directory.Parent.Name != directory.Root.Name)
                directory = directory.Parent;

            return directory.Name;
        }

        /// <summary>
        /// Tries to get the first directory in the specified path.
        /// </summary>
        /// <param name="source">The path to get the first directory from.</param>
        /// <param name="firstDirectory">When this method returns, contains the name of the first directory in the specified path, if the path is valid; otherwise, null.</param>
        /// <returns>true if the first directory was successfully retrieved; otherwise, false.</returns>
        public static bool TryGetFirstDirectory(this string source, [NotNullWhen(true)] out string? firstDirectory)
        {
            try
            {
                firstDirectory = source.GetFirstDirectory();
                return true;
            }
            catch
            {
                firstDirectory = null;
                return false;
            }
        }
    }
}