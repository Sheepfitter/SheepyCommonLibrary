using FluentAssertions;

namespace Sheepy.Common.Extensions.Tests;

public class LinqExtensionsTests
{
    [Fact]
    public void IsEmpty_WhenEmpty_ReturnsTrue()
    {
        // Arrange
        var source = new List<int>();

        // Act
        var result = source.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsEmpty_WhenNotEmpty_ReturnsFalse()
    {
        // Arrange
        var source = new List<int> { 1, 2, 3 };

        // Act
        var result = source.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsNotEmpty_WhenEmpty_ReturnsFalse()
    {
        // Arrange
        var source = new List<int>();

        // Act
        var result = source.IsNotEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsNotEmpty_WhenNotEmpty_ReturnsTrue()
    {
        // Arrange
        var source = new List<int> { 1, 2, 3 };

        // Act
        var result = source.IsNotEmpty();

        // Assert
        result.Should().BeTrue();
    }
}