using FluentAssertions;

namespace Sheepy.Common.Extensions.Tests;

public class DateTimeExtensionsTests
{
    [Fact]
    public void IsBetween_Inclusive_ShouldReturnTrue_WhenDateTimeIsWithinRange()
    {
        // Arrange
        var date = new DateTime(2023, 10, 15);
        var start = new DateTime(2023, 10, 1);
        var end = new DateTime(2023, 10, 31);

        // Act
        var result = date.IsBetween(start, end);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsBetween_Inclusive_ShouldReturnFalse_WhenDateTimeIsOutsideRange()
    {
        // Arrange
        var date = new DateTime(2023, 11, 1);
        var start = new DateTime(2023, 10, 1);
        var end = new DateTime(2023, 10, 31);

        // Act
        var result = date.IsBetween(start, end);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsBetween_Exclusive_ShouldReturnTrue_WhenDateTimeIsWithinRange()
    {
        // Arrange
        var date = new DateTime(2023, 10, 15);
        var start = new DateTime(2023, 10, 1);
        var end = new DateTime(2023, 10, 31);

        // Act
        var result = date.IsBetween(start, end, inclusive: false);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsBetween_Exclusive_ShouldReturnFalse_WhenDateTimeIsEqualToStartOrEnd()
    {
        // Arrange
        var date = new DateTime(2023, 10, 1);
        var start = new DateTime(2023, 10, 1);
        var end = new DateTime(2023, 10, 31);

        // Act
        var result = date.IsBetween(start, end, inclusive: false);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Clamp_ShouldReturnMin_WhenDateTimeIsLessThanMin()
    {
        // Arrange
        var date = new DateTime(2023, 9, 30);
        var min = new DateTime(2023, 10, 1);
        var max = new DateTime(2023, 10, 31);

        // Act
        var result = date.Clamp(min, max);

        // Assert
        result.Should().Be(min);
    }

    [Fact]
    public void Clamp_ShouldReturnMax_WhenDateTimeIsGreaterThanMax()
    {
        // Arrange
        var date = new DateTime(2023, 11, 1);
        var min = new DateTime(2023, 10, 1);
        var max = new DateTime(2023, 10, 31);

        // Act
        var result = date.Clamp(min, max);

        // Assert
        result.Should().Be(max);
    }

    [Fact]
    public void Clamp_ShouldReturnDateTime_WhenDateTimeIsWithinRange()
    {
        // Arrange
        var date = new DateTime(2023, 10, 15);
        var min = new DateTime(2023, 10, 1);
        var max = new DateTime(2023, 10, 31);

        // Act
        var result = date.Clamp(min, max);

        // Assert
        result.Should().Be(date);
    }

    [Fact]
    public void SetTime_ShouldReturnDateTimeWithSpecifiedTime()
    {
        // Arrange
        var date = new DateTime(2023, 10, 15, 12, 30, 45, 0, DateTimeKind.Local);
        var expected = new DateTime(2023, 10, 15, 13, 45, 20, 50, DateTimeKind.Local);

        // Act
        var result = date.SetTime(13, 45, 20, 50);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void SetDate_ShouldReturnDateTimeWithSpecifiedDate()
    {
        // Arrannge
        var date = new DateTime(2023, 10, 15, 12, 30, 45, 0, DateTimeKind.Local);
        var expected = new DateTime(2024, 01, 02, 12, 30, 45, 0, DateTimeKind.Local);

        // Act
        var result = date.SetDate(2024, 01, 02);

        // Assert
        result.Should().Be(expected);
    }
}