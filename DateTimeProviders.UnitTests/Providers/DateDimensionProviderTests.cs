using DateTimeProviders.Providers;
using DateTimeProviders.Providers.Enums;

namespace DateTimeProviders.UnitTests.Providers;

[ExcludeFromCodeCoverage]
public class DateDimensionProviderTests
{
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
            new object[] { DateDimensionProvider.FinStartDec, 12 }
        };

    [Fact]
    public void Test_Constructor()
    {
        var sut = new DateDimensionProvider(new DateTime(2019, 01, 01));

        var result = sut.FinStartMonth;

        result.Should().Be(1);
    }

    [Theory]
    [MemberData(nameof(FinStartData))]
    public void Test_FinStart(IDateDimensionProvider sut, int expected)
    {
        var result = sut.FinStartMonth;

        result.Should().Be(expected);
    }

    [Fact]
    public void Test_GetDateDimensions()
    {
        var sut = DateDimensionProvider.FinStartMay;

        var list = sut.GetDateDimensions(new DateTime(2019, 01, 01))
            .Take(365 * 2)
            .ToList();

        list.Should().NotBeNull();
        list.Should().NotBeEmpty();
    }

    [Fact]
    public void Test_GetMonthDimensionFinYear()
    {
        var sut = DateDimensionProvider.FinStartJun;
        var list = sut.GetMonthDimensionFinYear(new DateTime(2023, 02, 28)).ToList();
        list.Should().NotBeNull();
        list.Should().NotBeEmpty();
        list[0].YrMthNo.Value.Should().Be(202206);
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
    public void Test_GetMonthDimensionFinYear_From_Year()
    {
        var sut = DateDimensionProvider.FinStartMar;

        var list = sut.GetMonthDimensionFinYear(2024)
            .ToList();

        list.Should().NotBeNull();
        list.Should().NotBeEmpty();
    }

    [Fact]
    public void Test_GetFinancialYear()
    {
        var sut = DateDimensionProvider.FinStartMar;
        
        var result = sut.GetFinancialYear(new DateTime(2025, 02, 01));

        result.Should().NotBeNull();
        result.FinStartMonth.Should().Be(3);
        result.StartYear.Should().Be(2024);
        result.EndYear.Should().Be(2025);
    }

    [Fact]
    public void Test_GetFinancialYear_From_Year()
    {
        var sut = DateDimensionProvider.FinStartMar;
        
        var result = sut.GetFinancialYear(2024);

        result.Should().NotBeNull();
        result.FinStartMonth.Should().Be(3);
        result.StartYear.Should().Be(2024);
        result.EndYear.Should().Be(2025);
    }

    [Fact]
    public void Test_GetFinancialYears_Previous()
    {
        var sut = DateDimensionProvider.FinStartMar;
        
        var result = sut.GetFinancialYears(2024, 5).ToList();
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
        result.Should().HaveCount(5);
        var firstYear = result.First();
        firstYear.StartYear.Should().Be(2019);
        var lastYear = result.Last();
        lastYear.EndYear.Should().Be(2024);
    }
    
    [Fact]
    public void Test_GetFinancialYears_Next()
    {
        var sut = DateDimensionProvider.FinStartMar;
        
        var result = sut.GetFinancialYears(2024, 5, GetTypes.Next).ToList();
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
        result.Should().HaveCount(5);
        var firstYear = result.First();
        firstYear.StartYear.Should().Be(2024);
        var lastYear = result.Last();
        lastYear.EndYear.Should().Be(2029);
    }
}