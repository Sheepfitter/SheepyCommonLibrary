using FluentAssertions;

namespace Sheepy.Common.Extensions.Tests.StringExtensions;

public class StringPathExtensionsTests
{
    [Theory]
    [InlineData("C:\\temp\\file.txt")]
    [InlineData("/temp/file.txt")]
    [InlineData("temp/file.txt")]
    [InlineData("C:/temp/file.txt")]
    [InlineData("\\temp\\file.txt")]
    [InlineData("temp\\file.txt")]
    [InlineData("C://temp//file.txt")]
    [InlineData("temp/test")]
    [InlineData("temp/test/")]
    [InlineData("/temp/test")]
    [InlineData("/temp/test/")]
    public void GetFirstDirectory_WhenPathIsValid_ReturnsFirstDirectory(string path)
    {
        // Act
        var result = path.GetFirstDirectory();

        // Assert
        result.Should().Be("temp");
    }

    [Theory]
    [InlineData("C:\temp\file.txt")]
    [InlineData("\temp\file.txt")]
    [InlineData("temp\file.txt")]
    [InlineData("temp")]
    public void GetFirstDirectory_WhenPathIsNotValid_ThrowsArgumentException(string path)
    {
        // Act
        Action act = () => path.GetFirstDirectory();

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}