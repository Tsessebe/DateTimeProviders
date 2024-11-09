using DateTimeProviders.Providers.Extensions;

namespace DateTimeProviders.UnitTests.Providers.Extensions;

[ExcludeFromCodeCoverage]
public class JavaTimestampExtensionsTests
{
    private readonly IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

    [Fact]
    public void Test_JavaTimeStampToDateTime()
    {
        dateTimeProvider.Now.Returns(new DateTimeOffset(1977, 5, 4, 0, 0, 0, TimeSpan.Zero));
        // Arrange
        const double sut = 231544800;

        // Act
        var result = sut.JavaTimeStampToDateTime();

        // Assert
        result.Should().Be(dateTimeProvider.Now.DateTime);
    }

    [Fact]
    public void Test_JavaTimeStampToDateTime_164515()
    {
        dateTimeProvider.Now.Returns(new DateTimeOffset(1977, 5, 4, 16, 45, 15, TimeSpan.Zero));
        // Arrange
        const double sut = 231605115;

        // Act
        var result = sut.JavaTimeStampToDateTime();

        // Assert
        result.Should().Be(dateTimeProvider.Now.DateTime);
    }

    [Fact]
    public void Test_ToJavaTimestamp()
    {
        dateTimeProvider.Now.Returns(new DateTimeOffset(1977, 5, 4, 0, 0, 0, TimeSpan.Zero));
        // Arrange
        var sut = dateTimeProvider.Now;

        // Act
        var result = sut.DateTime.ToJavaTimestamp();

        // Assert
        result.Should().Be(231544800);
    }

    [Fact]
    public void Test_ToJavaTimestamp_164515()
    {
        dateTimeProvider.Now.Returns(new DateTimeOffset(1977, 5, 4, 16, 45, 15, TimeSpan.Zero));
        // Arrange
        var sut = dateTimeProvider.Now;

        // Act
        var result = sut.DateTime.ToJavaTimestamp();

        // Assert
        result.Should().Be(231605115);
    }
}