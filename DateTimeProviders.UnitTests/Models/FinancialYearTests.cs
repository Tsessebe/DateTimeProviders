using DateTimeProviders.Dimensions.Models;
using DateTimeProviders.Providers;

namespace DateTimeProviders.UnitTests.Models;

[ExcludeFromCodeCoverage]
public class FinancialYearTests
{
    [Fact]
    public void Test_Constructor()
    {
        var provider = DateDimensionProvider.FinStartMar;
        var sut = new FinancialYear(provider.FinStartMonth);
        sut.FinStartMonth.Should().Be(3);
    }
    
    [Fact]
    public void Test_Months()
    {
        var provider = DateDimensionProvider.FinStartMar;
        var months = provider.GetMonthDimensionFinYear(new DateTime(2025, 02, 01));
        var sut = new FinancialYear(provider.FinStartMonth)
        {
            Months = months.ToList()
        };
        sut.FinStartMonth.Should().Be(3);
        sut.StartYear.Should().Be(2024);
        sut.EndYear.Should().Be(2025);
    }
}