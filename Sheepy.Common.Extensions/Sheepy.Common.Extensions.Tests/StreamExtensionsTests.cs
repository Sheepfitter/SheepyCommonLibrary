using FluentAssertions;

namespace Sheepy.Common.Extensions.Tests;

public class StreamExtensionsTests
{
    [Fact]
    public void ToByteArray_MemoryStream_ReturnsByteArray()
    {
        // Arrange
        var expectedBytes = new byte[] { 1, 2, 3, 4, 5 };
        using var memoryStream = new MemoryStream(expectedBytes);

        // Act
        var result = memoryStream.ToByteArray();

        // Assert
        result.Should().BeEquivalentTo(expectedBytes);
    }

    [Fact]
    public void ToByteArray_NonSeekableStream_ReturnsByteArray()
    {
        // Arrange
        var expectedBytes = new byte[] { 1, 2, 3, 4, 5 };
        using var nonSeekableStream = new NonSeekableStream(new MemoryStream(expectedBytes));

        // Act
        var result = nonSeekableStream.ToByteArray();

        // Assert
        result.Should().BeEquivalentTo(expectedBytes);
    }

    [Fact]
    public void ToByteArray_EmptyStream_ReturnsByteArray()
    {
        // Arrange
        using var emptyStream = new MemoryStream();

        // Act
        var result = emptyStream.ToByteArray();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void ToByteArray_NullStream_ThrowsArgumentNullException()
    {
        // Arrange
        Stream nullStream = null;

        // Act
        var act = () => nullStream.ToByteArray();

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    private class NonSeekableStream(Stream innerStream) : Stream
    {
        private readonly Stream _innerStream = innerStream;

        public override bool CanRead => _innerStream.CanRead;
        public override bool CanSeek => false;
        public override bool CanWrite => _innerStream.CanWrite;
        public override long Length => _innerStream.Length;

        public override long Position
        {
            get => _innerStream.Position;
            set => _innerStream.Position = value;
        }

        public override void Flush() => _innerStream.Flush();

        public override int Read(byte[] buffer, int offset, int count) => _innerStream.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override void SetLength(long value) => _innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _innerStream.Write(buffer, offset, count);
    }
}