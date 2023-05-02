using DateTimeProviders.Providers.Extensions;

namespace DateTimeProviders.UnitTests.Providers.Extensions;

[ExcludeFromCodeCoverage]
public class DateTimeExtensionsTests
{
    private readonly IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

    [Fact]
    public void Test_StartOfTheMonth()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 19, 16, 34, 12, TimeSpan.Zero));
        dateTimeProvider.StartOfTheMonth.Returns(new DateTimeOffset(2019, 03, 01, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.StartOfTheMonth();

        // Assert
        result.Should().Be(dateTimeProvider.StartOfTheMonth.Date);
    }

    [Fact]
    public void Test_StartOfTheMonth_Offset()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 19, 16, 34, 12, TimeSpan.Zero));
        dateTimeProvider.StartOfTheMonth.Returns(new DateTimeOffset(2019, 03, 01, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now;

        // Act
        var result = sut.StartOfTheMonth();

        // Assert
        result.Should().Be(dateTimeProvider.StartOfTheMonth.Date);
    }

    [Fact]
    public void Test_EndOfTheMonth()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 19, 16, 34, 12, TimeSpan.Zero));
        dateTimeProvider.EndOfTheMonth.Returns(new DateTimeOffset(2019, 03, 31, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.EndOfTheMonth();

        // Assert
        result.Should().Be(dateTimeProvider.EndOfTheMonth.Date);
    }

    [Fact]
    public void Test_EndOfTheMonth_Offset()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 19, 16, 34, 12, TimeSpan.Zero));
        dateTimeProvider.EndOfTheMonth.Returns(new DateTimeOffset(2019, 03, 31, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now;

        // Act
        var result = sut.EndOfTheMonth();

        // Assert
        result.Should().Be(dateTimeProvider.EndOfTheMonth.Date);
    }

    [Fact]
    public void Test_StartOfNextMonth()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 12, 19, 16, 34, 12, TimeSpan.Zero));
        dateTimeProvider.StartOfNextMonth.Returns(new DateTimeOffset(2020, 01, 01, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.StartOfNextMonth();

        // Assert
        result.Should().Be(dateTimeProvider.StartOfNextMonth.Date);
    }

    [Fact]
    public void Test_StartOfNextMonth_Offset()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 12, 19, 16, 34, 12, TimeSpan.Zero));
        dateTimeProvider.StartOfNextMonth.Returns(new DateTimeOffset(2020, 01, 01, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now;

        // Act
        var result = sut.StartOfNextMonth();

        // Assert
        result.Should().Be(dateTimeProvider.StartOfNextMonth.Date);
    }

    [Fact]
    public void Test_StartOfDay()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 19, 16, 34, 12, TimeSpan.Zero));
        var expected = new DateTime(2019, 03, 19, 00, 00, 00);

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.StartOfDay();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Test_EndOfDay()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 19, 16, 34, 12, TimeSpan.Zero));
        var expected = new DateTime(2019, 03, 19, 23, 59, 59);

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.EndOfDay();

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(PreviousDayOfWeekData))]
    public void Test_PreviousDayOfWeek(DayOfWeek weekDay, DateTime expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 20, 16, 34, 12, TimeSpan.Zero));

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.PreviousDayOfWeek(weekDay);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(NextDayOfWeekData))]
    public void Test_NextDayOfWeek(DayOfWeek weekDay, DateTime expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 20, 16, 34, 12, TimeSpan.Zero));

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.NextDayOfWeek(weekDay);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(GetFirstWeekdayData))]
    public void Test_GetFirstWeekday(DayOfWeek weekday, DateTime expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 04, 01, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.GetFirstWeekday(weekday);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(GetLastWeekdayData))]
    public void Test_GetLastWeekday(DayOfWeek weekday, DateTime expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 04, 01, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.GetLastWeekday(weekday);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(GetNthWeekdayData))]
    public void Test_GetNthWeekday(int nth, DayOfWeek weekday, DateTime expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 04, 01, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.GetNthWeekday(nth, weekday);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Test_GetNthWeekday_ArgumentOutOfRangeException()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 05, 01, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>("Only 4 Thursday's in May 2023", () => sut.GetNthWeekday(5, DayOfWeek.Thursday));

    }

    [Theory]
    [MemberData(nameof(GetWeekdayCountData))]
    public void Test_GetWeekdayCount(DayOfWeek weekday, int expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 05, 04, 00, 00, 00, TimeSpan.Zero));
        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.GetWeekdayCount(weekday);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(IsLeapDayData))]
    public void Test_IsLeapDay(DateTimeOffset now, bool expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(now);

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.IsLeapDay();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Test_IsWorkDay_True()
    {
        // Arrange
        dateTimeProvider.Now.Returns(new DateTimeOffset(2019, 03, 20, 16, 34, 12, TimeSpan.Zero));

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.IsWorkDay();

        // Assert
        result.Should().Be(true);
    }

    [Theory]
    [MemberData(nameof(IsWorkDayData))]
    public void Test_IsWorkDay(DateTimeOffset now, Dictionary<DayOfWeek, bool> workDays, bool expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(now);

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.IsWorkDay(workdays: workDays);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(IsWorkDayDataWithHolidays))]
    public void Test_IsWorkDay_WithHolidays(DateTimeOffset now, Dictionary<DayOfWeek, bool> workDays, IEnumerable<DateTime> holidays, bool expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(now);

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.IsWorkDay(workdays: workDays, holidays:holidays);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(EasterSundayData))]
    public void Test_EasterSunday_Date(DateTimeOffset now, DateTime expected)
    {
        // Arrange
        dateTimeProvider.Now.Returns(now);

        var sut = dateTimeProvider.Now.Date;

        // Act
        var result = sut.EasterSunday();

        // Assert
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> PreviousDayOfWeekData =>
        new List<object[]>
        {
            new object[] { DayOfWeek.Sunday, new DateTime(2019, 03, 17, 00, 00, 00) },
            new object[] { DayOfWeek.Monday, new DateTime(2019, 03, 18, 00, 00, 00) },
            new object[] { DayOfWeek.Tuesday, new DateTime(2019, 03, 19, 00, 00, 00) },
            new object[] { DayOfWeek.Wednesday, new DateTime(2019, 03, 13, 00, 00, 00) },
            new object[] { DayOfWeek.Thursday, new DateTime(2019, 03, 14, 00, 00, 00) },
            new object[] { DayOfWeek.Friday, new DateTime(2019, 03, 15, 00, 00, 00) },
            new object[] { DayOfWeek.Saturday, new DateTime(2019, 03, 16, 00, 00, 00) },
        };

    public static IEnumerable<object[]> NextDayOfWeekData =>
        new List<object[]>
        {
            new object[] { DayOfWeek.Sunday, new DateTime(2019, 03, 24, 00, 00, 00) },
            new object[] { DayOfWeek.Monday, new DateTime(2019, 03, 25, 00, 00, 00) },
            new object[] { DayOfWeek.Tuesday, new DateTime(2019, 03, 26, 00, 00, 00) },
            new object[] { DayOfWeek.Wednesday, new DateTime(2019, 03, 27, 00, 00, 00) },
            new object[] { DayOfWeek.Thursday, new DateTime(2019, 03, 21, 00, 00, 00) },
            new object[] { DayOfWeek.Friday, new DateTime(2019, 03, 22, 00, 00, 00) },
            new object[] { DayOfWeek.Saturday, new DateTime(2019, 03, 23, 00, 00, 00) },
        };

    public static IEnumerable<object[]> GetFirstWeekdayData =>
        new List<object[]>
        {
            new object[] { DayOfWeek.Sunday, new DateTime(2023, 04, 02, 00, 00, 00) },
            new object[] { DayOfWeek.Monday, new DateTime(2023, 04, 03, 00, 00, 00) },
            new object[] { DayOfWeek.Tuesday, new DateTime(2023, 04, 04, 00, 00, 00) },
            new object[] { DayOfWeek.Wednesday, new DateTime(2023, 04, 05, 00, 00, 00) },
            new object[] { DayOfWeek.Thursday, new DateTime(2023, 04, 06, 00, 00, 00) },
            new object[] { DayOfWeek.Friday, new DateTime(2023, 04, 07, 00, 00, 00) },
            new object[] { DayOfWeek.Saturday, new DateTime(2023, 04, 01, 00, 00, 00) },
        };

    public static IEnumerable<object[]> GetLastWeekdayData =>
        new List<object[]>
        {
            new object[] { DayOfWeek.Sunday, new DateTime(2023, 04, 30, 00, 00, 00) },
            new object[] { DayOfWeek.Monday, new DateTime(2023, 04, 24, 00, 00, 00) },
            new object[] { DayOfWeek.Tuesday, new DateTime(2023, 04, 25, 00, 00, 00) },
            new object[] { DayOfWeek.Wednesday, new DateTime(2023, 04, 26, 00, 00, 00) },
            new object[] { DayOfWeek.Thursday, new DateTime(2023, 04, 27, 00, 00, 00) },
            new object[] { DayOfWeek.Friday, new DateTime(2023, 04, 28, 00, 00, 00) },
            new object[] { DayOfWeek.Saturday, new DateTime(2023, 04, 29, 00, 00, 00) },
        };

    public static IEnumerable<object[]> GetNthWeekdayData =>
        new List<object[]>
        {
            new object[] { 3, DayOfWeek.Sunday, new DateTime(2023, 04, 16, 00, 00, 00) },
            new object[] { 1, DayOfWeek.Monday, new DateTime(2023, 04, 03, 00, 00, 00) },
            new object[] { 1, DayOfWeek.Tuesday, new DateTime(2023, 04, 04, 00, 00, 00) },
            new object[] { 4, DayOfWeek.Wednesday, new DateTime(2023, 04, 26, 00, 00, 00) },
            new object[] { 3, DayOfWeek.Thursday, new DateTime(2023, 04, 20, 00, 00, 00) },
            new object[] { 2, DayOfWeek.Friday, new DateTime(2023, 04, 14, 00, 00, 00) },
            new object[] { 2, DayOfWeek.Saturday, new DateTime(2023, 04, 08, 00, 00, 00) },
        };

    public static IEnumerable<object[]> GetWeekdayCountData =>
        new List<object[]>
        {
            new object[] { DayOfWeek.Sunday, 4 },
            new object[] { DayOfWeek.Monday, 5 },
            new object[] { DayOfWeek.Tuesday, 5 },
            new object[] { DayOfWeek.Wednesday, 5 },
            new object[] { DayOfWeek.Thursday, 4 },
            new object[] { DayOfWeek.Friday, 4 },
            new object[] { DayOfWeek.Saturday, 4 },
        };

    public static IEnumerable<object[]> IsLeapDayData =>
new List<object[]>
{
            new object[] { new DateTimeOffset(2019, 03, 20, 16, 34, 12, TimeSpan.Zero), false },
            new object[] { new DateTimeOffset(2019, 02, 20, 16, 34, 12, TimeSpan.Zero), false },
            new object[] { new DateTimeOffset(2020, 02, 28, 16, 34, 12, TimeSpan.Zero), false },
            new object[] { new DateTimeOffset(2020, 03, 01, 16, 34, 12, TimeSpan.Zero), false },
            new object[] { new DateTimeOffset(2016, 02, 29, 16, 34, 12, TimeSpan.Zero), true },
            new object[] { new DateTimeOffset(2020, 02, 29, 16, 34, 12, TimeSpan.Zero), true }
};

    public static IEnumerable<object[]> IsWorkDayData =>
        new List<object[]>
        {
            new object[]
            {
                new DateTimeOffset(2019, 03, 20, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, false },
                    { DayOfWeek.Monday, false },
                    { DayOfWeek.Tuesday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                    { DayOfWeek.Saturday, true }
                },
                true
            },
            new object[]
            {
                new DateTimeOffset(2019, 03, 19, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, false },
                    { DayOfWeek.Monday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                    { DayOfWeek.Saturday, true }
                },
                true
            },
            new object[]
            {
                new DateTimeOffset(2019, 03, 17, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, false },
                    { DayOfWeek.Monday, false },
                    { DayOfWeek.Tuesday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                    { DayOfWeek.Saturday, true }
                },
                false
            },
            new object[]
            {
                new DateTimeOffset(2019, 03, 18, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, false },
                    { DayOfWeek.Monday, false },
                    { DayOfWeek.Tuesday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                    { DayOfWeek.Saturday, true }
                },
                false
            },
            new object[]
            {
                new DateTimeOffset(2019, 03, 17, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Monday, false },
                    { DayOfWeek.Tuesday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                    { DayOfWeek.Saturday, true }
                },
                true
            },
            new object[]
            {
                new DateTimeOffset(2019, 03, 16, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, false },
                    { DayOfWeek.Monday, false },
                    { DayOfWeek.Tuesday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                },
                true
            },
        };

    public static IEnumerable<object[]> IsWorkDayDataWithHolidays =>
        new List<object[]>
        {
            new object[]
            {
                new DateTimeOffset(2019, 05, 01, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, false },
                    { DayOfWeek.Monday, true },
                    { DayOfWeek.Tuesday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                    { DayOfWeek.Saturday, false }
                },
                new List<DateTime>
                {
                    { new DateTime(2019, 04, 27) },
                    { new DateTime(2019, 05, 01) },
                    { new DateTime(2019, 06, 16) },
                },
                false
            },
            new object[]
            {
                new DateTimeOffset(2019, 03, 19, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, false },
                    { DayOfWeek.Monday, true },
                    { DayOfWeek.Tuesday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                    { DayOfWeek.Saturday, false }
                },
                new List<DateTime>
                {
                    { new DateTime(2019, 04, 27) },
                    { new DateTime(2019, 05, 01) },
                    { new DateTime(2019, 06, 16) },
                },
                true
            },
            new object[]
            {
                new DateTimeOffset(2019, 06, 16, 16, 34, 12, TimeSpan.Zero),
                new Dictionary<DayOfWeek, bool>
                {
                    { DayOfWeek.Sunday, false },
                    { DayOfWeek.Monday, true },
                    { DayOfWeek.Tuesday, true },
                    { DayOfWeek.Wednesday, true },
                    { DayOfWeek.Thursday, true },
                    { DayOfWeek.Friday, true },
                    { DayOfWeek.Saturday, false }
                },
                new List<DateTime>
                {
                    { new DateTime(2019, 04, 27) },
                    { new DateTime(2019, 05, 01) },
                    { new DateTime(2019, 06, 16) },
                },
                false
            }
        };

    public static IEnumerable<object[]> EasterSundayData =>
        new List<object[]>
        {
            new object[]
            {
                new DateTimeOffset(2019, 03, 20, 16, 34, 12, TimeSpan.Zero),
                new DateTime(2019, 04, 21, 00, 00, 00)
            },
            new object[]
            {
                new DateTimeOffset(2019, 05, 04, 16, 34, 12, TimeSpan.Zero),
                new DateTime(2020, 04, 12, 00, 00, 00)
            },
        };
}