using FluentAssertions;

namespace Sheepy.Common.Extensions.Tests;

public class StringExtensionsTests
{
    [Fact]
    public void ToDateTime_ValidDateString_ReturnsDateTime()
    {
        // Arrange
        const string dateString = "2024-01-02";

        // Act
        var result = dateString.ToDateTime();

        // Assert
        result.Should().Be(new(2024, 1, 2));
    }

    [Fact]
    public void ToDateTime_InvalidDateString_ThrowsFormatException()
    {
        // Arrange
        const string dateString = "invalid-date";

        // Act
        var act = () => dateString.ToDateTime();

        // Assert
        act.Should().Throw<FormatException>();
    }

    [Fact]
    public void ToDateTime_InvalidDateStringWithValidFormat_ReturnsDateTime()
    {
        // Arrange
        const string dateString = "2024-01@02";
        const string format = "yyyy-dd@MM";

        // Act
        var result = dateString.ToDateTime(format);

        // Assert
        result.Should().Be(new(2024, 2, 1));
    }

    [Fact]
    public void ToDateTime_InvalidDateStringWithInvalidFormat_ThrowsFormatException()
    {
        // Arrange
        const string dateString = "2024-01@02";
        const string format = "yyyy-MM-dd";

        // Act
        var act = () => dateString.ToDateTime(format);

        // Assert
        act.Should().Throw<FormatException>();
    }

    [Fact]
    public void ToDateTime_ValidDateStringWithInvalidFormat_ReturnsDateTime()
    {
        // Arrange
        const string dateString = "2024-01-02";
        const string format = "dd-MM-yyyy";

        // Act
        var result = dateString.ToDateTime(format);

        // Assert
        result.Should().Be(new(2024, 1, 2));
    }

    [Fact]
    public void ToDateTime_ValidDateStringWithMultipleInvalidFormats_ReturnsDateTime()
    {
        // Arrange
        const string dateString = "2024-01-02";
        string[] formats = ["yyyy-MM@dd", "dd-MM-yyyy"];

        // Act
        var result = dateString.ToDateTime(formats);

        // Assert
        result.Should().Be(new(2024, 1, 2));
    }

    [Fact]
    public void ToDateTime_InvalidDateStringWithMultipleInvalidFormats_ThrowsFormatException()
    {
        // Arrange
        const string dateString = "2024-01@02";
        string[] formats = ["yyyy-MM-dd", "dd-MM-yyyy"];

        // Act
        var act = () => dateString.ToDateTime(formats);

        // Assert
        act.Should().Throw<FormatException>();
    }

    [Fact]
    public void ToDateTime_InvalidDateStringWithMultipleValidFormats_ReturnsDateTime()
    {
        // Arrange
        const string dateString = "2024-01@02";
        string[] formats = ["yyyy-MM@dd", "dd-MM-yyyy"];

        // Act
        var result = dateString.ToDateTime(formats);

        // Assert
        result.Should().Be(new(2024, 1, 2));
    }

    [Fact]
    public void ToDateTimeStrict_InvalidDateStringWithValidFormat_ReturnsDateTime()
    {
        // Arrange
        const string dateString = "01@02-2024";
        const string format = "MM@dd-yyyy";

        // Act
        var result = dateString.ToDateTimeStrict(format);

        // Assert
        result.Should().Be(new(2024, 1, 2));
    }

    [Fact]
    public void ToDateTimeString_ValidDateStringWithInvalidFormat_ThrowsFormatException()
    {
        // Arrange
        const string dateString = "01-02-2024";
        const string format = "yyyy-MM-dd";

        // Act
        var act = () => dateString.ToDateTimeStrict(format);

        // Assert
        act.Should().Throw<FormatException>();
    }

    [Fact]
    public void ToDateTimeStrict_InvalidDateStringWithMultipleValidFormats_ReturnsDateTime()
    {
        // Arrange
        const string dateString = "2024-01@02";
        string[] formats = ["yyyy-MM@dd", "dd-MM-yyyy"];

        // Act
        var result = dateString.ToDateTimeStrict(formats);

        // Assert
        result.Should().Be(new(2024, 1, 2));
    }

    [Fact]
    public void ToDateTimeStrict_ValidDateStringWithMultipleInvalidFormats_ThrowsFormatException()
    {
        // Arrange
        const string dateString = "2024-01-02";
        string[] formats = ["yyyy-MM@dd", "dd-MM-yyyy"];

        // Act
        var act = () => dateString.ToDateTimeStrict(formats);

        // Assert
        act.Should().Throw<FormatException>();
    }
}