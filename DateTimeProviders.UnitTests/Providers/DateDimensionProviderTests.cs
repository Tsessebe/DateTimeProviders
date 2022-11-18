using DateTimeProviders.Providers;

namespace DateTimeProviders.UnitTests.Providers;

[ExcludeFromCodeCoverage]
public class DateDimensionProviderTests
{
    [Theory]
    [MemberData(nameof(FinStartData))]
    public void Test_FinStart(IDateDimensionProvider sut, int expected)
    {
        var result = sut.FinStartMonth;

        result.Should().Be(expected);
    }

    [Fact]
    public void Test_Constructor()
    {
        var sut = new DateDimensionProvider(new DateTime(2019, 01, 01));
        
        var result = sut.FinStartMonth;
        
        result.Should().Be(1);
    }

    [Fact]
    public void Test_GetMonthDimensions()
    {
        var sut = DateDimensionProvider.FinStartMay;

        var list = sut.GetMonthDimensions(new DateTime(2019, 01, 01))
            .Take(24)
            .ToList();

        list.Should().NotBeNull();
        list.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Test_GetDateDimensions()
    {
        var sut = DateDimensionProvider.FinStartMay;

        var list = sut.GetDateDimensions(new DateTime(2019, 01, 01))
            .Take(365*2)
            .ToList();

        list.Should().NotBeNull();
        list.Should().NotBeEmpty();
    }

    public static IEnumerable<object[]> FinStartData =>
        new List<object[]>
        {
            new object[] { DateDimensionProvider.FinStartJan, 1 },
            new object[] { DateDimensionProvider.FinStartFeb, 2 },
            new object[] { DateDimensionProvider.FinStartMar, 3 },
            new object[] { DateDimensionProvider.FinStartApr, 4 },
            new object[] { DateDimensionProvider.FinStartMay, 5 },
            new object[] { DateDimensionProvider.FinStartJun, 6 },
            new object[] { DateDimensionProvider.FinStartJul, 7 },
            new object[] { DateDimensionProvider.FinStartAug, 8 },
            new object[] { DateDimensionProvider.FinStartSep, 9 },
            new object[] { DateDimensionProvider.FinStartOct, 10 },
            new object[] { DateDimensionProvider.FinStartNov, 11 },
            new object[] { DateDimensionProvider.FinStartDec, 12 },
        };
    
}