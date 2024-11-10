using FluentAssertions;

namespace Sheepy.Common.Extensions.Tests;

public class RefEnumeratorTests
{
    [Fact]
    public void GetRefEnumerator_ShouldReturnEnumerator_WhenCalledOnList()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };

        // Act
        var enumerator = list.GetRefEnumerator();

        // Assert
        enumerator.Should().NotBeNull();
    }

    [Fact]
    public void TryMoveNext_ShouldReturnTrueAndSetValue_WhenEnumeratorHasNextElement()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };
        using var enumerator = list.GetRefEnumerator();

        // Act
        var result = enumerator.TryMoveNext(out var value);

        // Assert
        result.Should().BeTrue();
        value.Should().Be(1);
    }

    [Fact]
    public void TryMoveNext_ShouldReturnFalseAndSetDefaultValue_WhenEnumeratorHasNoNextElement()
    {
        // Arrange
        var list = new List<int> { 1 };
        using var enumerator = list.GetRefEnumerator();
        enumerator.MoveNext(); // Move to the first element

        // Act
        var result = enumerator.TryMoveNext(out var value);

        // Assert
        result.Should().BeFalse();
        value.Should().Be(default);
    }

    [Fact]
    public void TryMoveNext_ShouldReturnTrueAndSetValue_WhenCalledMultipleTimes()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };
        using var enumerator = list.GetRefEnumerator();

        // Act & Assert
        enumerator.TryMoveNext(out var value1).Should().BeTrue();
        value1.Should().Be(1);

        enumerator.TryMoveNext(out var value2).Should().BeTrue();
        value2.Should().Be(2);

        enumerator.TryMoveNext(out var value3).Should().BeTrue();
        value3.Should().Be(3);

        enumerator.TryMoveNext(out var value4).Should().BeFalse();
        value4.Should().Be(default);
    }
}