using DateTimeProviders.Dimensions.Models;
using DateTimeProviders.Providers.DataTypes;
using DateTimeProviders.Providers.Extensions;

namespace DateTimeProviders.UnitTests.Dimensions.Extensions;

[ExcludeFromCodeCoverage]
public class DimensionExtensionsTests
{
    private readonly IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

    public static IEnumerable<object[]> GetDateDimensionData =>
        new List<object[]>
        {
            new object[]
            {
                new DateTime(2019, 05, 04, 00, 00, 00),
                new DateTime(2019, 03, 01, 00, 00, 00),
                new DateDimension
                {
                    DateKey = new DateDimKey(20190504L),
                    DateVal = new DateTime(2019, 05, 04, 00, 00, 00),
                    ShortDateVal = "04 May 2019",
                    YrNo = 2019,
                    MthNo = 05,
                    DayNo = 04,
                    WeekNo = 18,
                    WeekLabel = "Week 18",
                    DayOfWeekNo = 6,
                    DayOfWeek = "Saturday",
                    FirstDayOfWeek = 20190429L,
                    LastDayOfWeek = 20190505L,
                    MthShortDesc = "May",
                    MthLongDesc = "May",
                    QuarterNo = 2,
                    YrMthNo = 201905L,
                    FinYrNo = 2019,
                    FinMthNo = 3,
                    FinYrMthNo = 201903,
                    FinQuarterNo = 1
                }
            },
            new object[]
            {
                new DateTime(2019, 05, 04, 00, 00, 00),
                new DateTime(2019, 09, 01, 00, 00, 00),
                new DateDimension
                {
                    DateKey = new DateDimKey(20190504L),
                    DateVal = new DateTime(2019, 05, 04, 00, 00, 00),
                    ShortDateVal = "04 May 2019",
                    YrNo = 2019,
                    MthNo = 05,
                    DayNo = 04,
                    WeekNo = 18,
                    WeekLabel = "Week 18",
                    DayOfWeekNo = 6,
                    DayOfWeek = "Saturday",
                    FirstDayOfWeek = 20190429L,
                    LastDayOfWeek = 20190505L,
                    MthShortDesc = "May",
                    MthLongDesc = "May",
                    QuarterNo = 2,
                    YrMthNo = 201905L,
                    FinYrNo = 2018,
                    FinMthNo = 9,
                    FinYrMthNo = 201809,
                    FinQuarterNo = 3
                }
            },
            new object[]
            {
                new DateTime(2019, 03, 04, 00, 00, 00),
                new DateTime(2019, 03, 01, 00, 00, 00),
                new DateDimension
                {
                    DateKey = new DateDimKey(20190304L),
                    DateVal = new DateTime(2019, 03, 04, 00, 00, 00),
                    ShortDateVal = "04 Mar 2019",
                    YrNo = 2019,
                    MthNo = 03,
                    DayNo = 04,
                    WeekNo = 10,
                    WeekLabel = "Week 10",
                    DayOfWeekNo = 2,
                    DayOfWeek = "Monday",
                    FirstDayOfWeek = 20190304L,
                    LastDayOfWeek = 20190310L,
                    MthShortDesc = "Mar",
                    MthLongDesc = "March",
                    QuarterNo = 1,
                    YrMthNo = 201903L,
                    FinYrNo = 2019,
                    FinMthNo = 1,
                    FinYrMthNo = 201901,
                    FinQuarterNo = 1
                }
            },
            new object[]
            {
                new DateTime(2019, 01, 04, 00, 00, 00),
                new DateTime(2019, 03, 01, 00, 00, 00),
                new DateDimension
                {
                    DateKey = new DateDimKey(20190104L),
                    DateVal = new DateTime(2019, 01, 04, 00, 00, 00),
                    ShortDateVal = "04 Jan 2019",
                    YrNo = 2019,
                    MthNo = 01,
                    DayNo = 04,
                    WeekNo = 1,
                    WeekLabel = "Week 1",
                    DayOfWeekNo = 2,
                    DayOfWeek = "Friday",
                    FirstDayOfWeek = 20181231L,
                    LastDayOfWeek = 20190106L,
                    MthShortDesc = "Jan",
                    MthLongDesc = "January",
                    QuarterNo = 1,
                    YrMthNo = 201901L,
                    FinYrNo = 2018,
                    FinMthNo = 11,
                    FinYrMthNo = 201811,
                    FinQuarterNo = 4
                }
            }
        };

    public static IEnumerable<object[]> GetMonthDimensionData =>
        new List<object[]>
        {
            new object[]
            {
                new DateTime(2019, 05, 04, 00, 00, 00),
                new DateTime(2019, 09, 01, 00, 00, 00),
                new MonthDimension
                {
                    YrMthNo = new MonthDimKey(201905),
                    YrNo = 2019,
                    MthNo = 5,
                    QuarterNo = 2,
                    MthShortDesc = "May",
                    MthLongDesc = "May",
                    MthYearShortDesc = "May 2019",
                    MthYearLongDesc = "May 2019",
                    FinYrNo = 2018,
                    FinMthNo = 9,
                    FinYrMthNo = 201809,
                    FinQuarterNo = 3
                }
            },
            new object[]
            {
                new DateTime(2019, 05, 04, 00, 00, 00),
                new DateTime(2019, 03, 01, 00, 00, 00),
                new MonthDimension
                {
                    YrMthNo = new MonthDimKey(201905),
                    YrNo = 2019,
                    MthNo = 5,
                    QuarterNo = 2,
                    MthShortDesc = "May",
                    MthLongDesc = "May",
                    MthYearShortDesc = "May 2019",
                    MthYearLongDesc = "May 2019",
                    FinYrNo = 2019,
                    FinMthNo = 3,
                    FinYrMthNo = 201903,
                    FinQuarterNo = 1
                }
            },
            new object[]
            {
                new DateTime(2019, 03, 04, 00, 00, 00),
                new DateTime(2019, 03, 01, 00, 00, 00),
                new MonthDimension
                {
                    YrMthNo = new MonthDimKey(201903),
                    YrNo = 2019,
                    MthNo = 3,
                    QuarterNo = 1,
                    MthShortDesc = "Mar",
                    MthLongDesc = "March",
                    MthYearShortDesc = "Mar 2019",
                    MthYearLongDesc = "March 2019",
                    FinYrNo = 2019,
                    FinMthNo = 1,
                    FinYrMthNo = 201901,
                    FinQuarterNo = 1
                }
            },
            new object[]
            {
                new DateTime(2019, 05, 04, 00, 00, 00),
                new DateTime(2019, 09, 01, 00, 00, 00),
                new MonthDimension
                {
                    YrMthNo = new MonthDimKey(201905),
                    YrNo = 2019,
                    MthNo = 5,
                    QuarterNo = 2,
                    MthShortDesc = "May",
                    MthLongDesc = "May",
                    MthYearShortDesc = "May 2019",
                    MthYearLongDesc = "May 2019",
                    FinYrNo = 2018,
                    FinMthNo = 9,
                    FinYrMthNo = 201809,
                    FinQuarterNo = 3
                }
            },
            new object[]
            {
                new DateTime(2019, 11, 04, 00, 00, 00),
                new DateTime(2019, 09, 01, 00, 00, 00),
                new MonthDimension
                {
                    YrMthNo = new MonthDimKey(201911),
                    YrNo = 2019,
                    MthNo = 11,
                    QuarterNo = 4,
                    MthShortDesc = "Nov",
                    MthLongDesc = "November",
                    MthYearShortDesc = "Nov 2019",
                    MthYearLongDesc = "November 2019",
                    FinYrNo = 2019,
                    FinMthNo = 3,
                    FinYrMthNo = 201903,
                    FinQuarterNo = 1
                }
            }
        };

    [Fact]
    public void Test_DateDimKey_Fail()
    {
        Assert.Throws<ArgumentException>(() => new DateDimKey(20190004L));
    }

    [Fact]
    public void Test_FirstDayOfWeek()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 11, 19, 16, 34, 12, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.FirstDayOfWeek();

        // Assert
        result.Should().Be(new DateTime(2019, 11, 18, 0, 0, 0));
    }

    [Fact]
    public void Test_FromDateDimKey()
    {
        var testDate = new DateTime(2019, 05, 04, 00, 00, 00);

        var dimKey = new DateDimKey(20190504L);

        var result = dimKey.FromDateDimKey();

        result.Should().Be(testDate);
    }

    [Fact]
    public void Test_FromDateDimKey_Long()
    {
        var testDate = new DateTime(2019, 05, 04, 00, 00, 00);

        var result = 20190504L.FromDateDimKey();

        result.Should().Be(testDate);
    }

    [Fact]
    public void Test_FromMonthDimKey()
    {
        // Arrange
        var expected = new DateTime(2019, 05, 01, 00, 00, 00);
        var dimKey = new MonthDimKey(201905L);
        // Act
        var result = dimKey.FromMonthDimKey();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Test_FromMonthDimKey_Long()
    {
        // Arrange
        var expected = new DateTime(2019, 05, 01, 00, 00, 00);

        // Act
        var result = 201905L.FromMonthDimKey();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(GetDateDimensionData))]
    public void Test_GetDateDimension(DateTime testDate, DateTime finStartDate, DateDimension expected)
    {
        // Arrange

        // Act
        var result = testDate.GetDateDimension(finStartDate);

        // Assert
        result.Should().NotBeNull();

        result.DateKey.Should().Be(expected.DateKey);
        result.DateVal.Should().Be(expected.DateVal);
        result.ShortDateVal.Should().Be(expected.ShortDateVal);

        result.YrNo.Should().Be(expected.YrNo);
        result.MthNo.Should().Be(expected.MthNo);
        result.DayNo.Should().Be(expected.DayNo);

        result.WeekNo.Should().Be(expected.WeekNo);
        result.WeekLabel.Should().Be(expected.WeekLabel);
        result.DayOfWeek.Should().Be(expected.DayOfWeek);
        result.FirstDayOfWeek.Should().Be(expected.FirstDayOfWeek);
        result.LastDayOfWeek.Should().Be(expected.LastDayOfWeek);

        result.MthShortDesc.Should().Be(expected.MthShortDesc);
        result.MthLongDesc.Should().Be(expected.MthLongDesc);

        result.QuarterNo.Should().Be(expected.QuarterNo);
        result.YrMthNo.Should().Be(expected.YrMthNo);

        result.FinYrNo.Should().Be(expected.FinYrNo);
        result.FinMthNo.Should().Be(expected.FinMthNo);
        result.FinYrMthNo.Should().Be(expected.FinYrMthNo);
        result.FinQuarterNo.Should().Be(expected.FinQuarterNo);
    }

    [Theory]
    [MemberData(nameof(GetMonthDimensionData))]
    public void Test_GetMonthDimension(DateTime testDate, DateTime finStartDate, MonthDimension expected)
    {
        // Arrange

        // Act
        var result = testDate.GetMonthDimension(finStartDate);

        // Assert
        result.Should().NotBeNull();

        result.YrMthNo.Should().Be(expected.YrMthNo);
        result.YrNo.Should().Be(expected.YrNo);
        result.MthNo.Should().Be(expected.MthNo);
        result.QuarterNo.Should().Be(expected.QuarterNo);
        result.MthShortDesc.Should().Be(expected.MthShortDesc);
        result.MthLongDesc.Should().Be(expected.MthLongDesc);
        result.MthYearShortDesc.Should().Be(expected.MthYearShortDesc);
        result.MthYearLongDesc.Should().Be(expected.MthYearLongDesc);
        result.FinYrNo.Should().Be(expected.FinYrNo);
        result.FinMthNo.Should().Be(expected.FinMthNo);
        result.FinYrMthNo.Should().Be(expected.FinYrMthNo);
        result.FinQuarterNo.Should().Be(expected.FinQuarterNo);
    }

    [Fact]
    public void Test_GetQuarter_Offset()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 11, 19, 16, 34, 12, TimeSpan.Zero));
        var sut = dateTimeProvider.Now;

        // Act
        var result = sut.GetQuarter();

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public void Test_LastDayOfWeek()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 11, 19, 16, 34, 12, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.LastDayOfWeek();

        // Assert
        result.Should().Be(new DateTime(2019, 11, 24, 0, 0, 0));
    }

    [Fact]
    public void Test_MonthDimKey_Fail()
    {
        Assert.Throws<ArgumentException>(() => new MonthDimKey(201900L));
    }

    [Fact]
    public void Test_NextDateDimKey()
    {
        var expected = 20190505L;
        var dimKey = new DateDimKey(20190504L);
        var result = dimKey.NextDateDimKey();

        result.Value.Should().Be(expected);
    }

    [Fact]
    public void Test_NextMonthDimKey()
    {
        // Arrange
        var expected = 201906L;
        var dimKey = new MonthDimKey(201905L);

        // Act
        var result = dimKey.NextMonthDimKey();

        // Assert
        result.Value.Should().Be(expected);
    }

    [Fact]
    public void Test_NextMonthDimKey_Dec()
    {
        // Arrange
        var expected = 202001L;
        var dimKey = new MonthDimKey(201912L);
        // Act
        var result = dimKey.NextMonthDimKey();

        // Assert
        result.Value.Should().Be(expected);
    }

    [Fact]
    public void Test_PrevDateDimKey()
    {
        var expected = 20190430L;
        var dimKey = new DateDimKey(20190501L);
        var result = dimKey.PrevDateDimKey();

        result.Value.Should().Be(expected);
    }

    [Fact]
    public void Test_PrevMonthDimKey()
    {
        // Arrange
        var expected = 201904L;
        var dimKey = new MonthDimKey(201905L);
        // Act
        var result = dimKey.PrevMonthDimKey();

        // Assert
        result.Value.Should().Be(expected);
    }

    [Fact]
    public void Test_PrevMonthDimKey_Jan()
    {
        // Arrange
        var expected = 201812L;
        var dimKey = new MonthDimKey(201901L);
        // Act
        var result = dimKey.PrevMonthDimKey();

        // Assert
        result.Value.Should().Be(expected);
    }

    [Fact]
    public void Test_ToDateDimKey()
    {
        var testDate = new DateTime(2019, 05, 04, 00, 00, 00);

        var result = testDate.ToDateDimKey();

        result.Value.Should().Be(20190504);
    }

    [Fact]
    public void Test_ToMonthDimKey()
    {
        // Arrange
        var testDate = new DateTime(2019, 05, 04, 00, 00, 00);
        // Act
        var result = testDate.ToMonthDimKey();
        // Assert
        result.Value.Should().Be(201905);
    }

    [Fact]
    public void Test_ToMonthDimKey_FromDateDimKey()
    {
        // Arrange
        var testDate = new DateTime(2019, 05, 04, 00, 00, 00);
        var dateDimKey = testDate.ToDateDimKey();
        // Act
        var result = dateDimKey.ToMonthDimKey();
        // Assert
        result.Value.Should().Be(201905);
    }
}