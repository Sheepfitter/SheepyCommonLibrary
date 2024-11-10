namespace System.Collections.Generic
{
    /// <summary>
    /// Provides a reference enumerator for a collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class RefEnumerator<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public RefEnumerator(IEnumerable<T> enumerable)
        {
            _enumerator = enumerable.GetEnumerator();
        }

        /// <inheritdoc cref="IEnumerator{T}.Current"/>
        public T Current => _enumerator.Current;

        /// <inheritdoc cref="IEnumerator.Current"/>
        object? IEnumerator.Current => Current;

        /// <inheritdoc cref="IEnumerator.MoveNext"/>
        public bool MoveNext() => _enumerator.MoveNext();

        /// <inheritdoc cref="IEnumerator.Reset"/>
        public void Reset() => _enumerator.Reset();

        /// <inheritdoc cref="IEnumerator{T}.Dispose"/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="RefEnumerator{T}"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _enumerator.Dispose();
        }

        /// <summary>
        /// Attempts to advance the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the enumerator was successfully advanced to the next element; <c>false</c> if the enumerator
        /// has passed the end of the collection.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
        public bool TryMoveNext(out T value)
        {
            if (_enumerator.MoveNext())
            {
                value = _enumerator.Current;
                return true;
            }

            value = default!;
            return false;
        }
    }
}