using DateTimeProviders.Providers.Extensions;

namespace DateTimeProviders.UnitTests.Providers.Extensions;

[ExcludeFromCodeCoverage]
public class UnixTimestampExtensionsTests
{
    private readonly IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

    public UnixTimestampExtensionsTests()
    {
        dateTimeProvider.Now.Returns(new DateTimeOffset(1977, 5, 4, 0, 0, 0, TimeSpan.Zero));
    }
    
    [Fact]
    public void Test_ToUnixTimestamp()
    {
        // Arrange
        var sut = dateTimeProvider.Now;
        
        // Act
        var result = sut.DateTime.ToUnixTimestamp();

        // Assert
        result.Should().Be(231544800);
    }
    
    [Fact]
    public void Test_UnixTimeStampToDateTime()
    {
        // Arrange
        const long sut = 231544800;
        
        // Act
        var result = sut.UnixTimeStampToDateTime();

        // Assert
        result.Should().Be(dateTimeProvider.Now.DateTime);
    }
    
}
