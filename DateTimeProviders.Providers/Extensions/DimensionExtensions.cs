using System.Globalization;
using DateTimeProviders.Dimensions.Models;

namespace DateTimeProviders.Providers.Extensions;

public static class DimensionExtensions
{
    public static DateTime FirstDayOfWeek(this DateTime value)
    {
        var d = new GregorianCalendar().AddDays(value, -(int)value.DayOfWeek + (int)DayOfWeek.Monday);

        return d;
    }


    /// <summary>
    ///     Calculates a Date Dimension based on the value
    /// </summary>
    /// <param name="value">the Date Value</param>
    /// <param name="finYearStart">the start of the Financial year</param>
    /// <returns>a DateDimension</returns>
    public static DateDimension GetDateDimension(this DateTime value, DateTime finYearStart)
    {
        return value.GetDateDimension(finYearStart.Month);
    }

    /// <summary>
    ///     Calculates a Date Dimension based on the value
    /// </summary>
    /// <param name="value">the Date Value</param>
    /// <param name="finYearStartMonth">the start of the Financial year</param>
    /// <returns>a DateDimension</returns>
    public static DateDimension GetDateDimension(this DateTime value, int finYearStartMonth)
    {
        var finYearStart = new DateTime(value.Year, finYearStartMonth, 1);

        if (finYearStart > value)
        {
            finYearStart = finYearStart.AddYears(-1);
        }

        var finYearFactor = 12 - finYearStartMonth + 1;

        var dateKey = value.ToDateDimKey();
        var yearMonth = value.ToMonthDimKey();

        var finYear = finYearStart.Year;
        var finMonth = value.Month >= finYearStartMonth
            ? value.Month - finYearStartMonth + 1
            : value.Month + finYearFactor;

        var finYearMonth = finYear * 100 + finMonth;
        var finYrMthDate = new DateTime(finYear, finMonth, 1);
        var weekNo = value.GetIso8601WeekOfYear();
        return new DateDimension
        {
            DateKey = dateKey,
            DateVal = value,
            ShortDateVal = value.ToString("dd MMM yyyy"),

            YrNo = value.Year,
            MthNo = value.Month,
            DayNo = value.Day,

            WeekNo = weekNo,
            WeekLabel = $"Week {weekNo}",

            DayOfWeekNo = (int)value.DayOfWeek,
            DayOfWeek = value.DayOfWeek.ToString("G"),
            FirstDayOfWeek = value.FirstDayOfWeek().ToDateDimKey(),
            LastDayOfWeek = value.LastDayOfWeek().ToDateDimKey(),

            MthShortDesc = value.ToString("MMM", CultureInfo.InvariantCulture),
            MthLongDesc = value.ToString("MMMM", CultureInfo.InvariantCulture),

            QuarterNo = value.GetQuarter(),

            YrMthNo = yearMonth,

            FinYrNo = finYear,
            FinMthNo = finMonth,
            FinYrMthNo = finYearMonth,
            FinQuarterNo = finYrMthDate.GetQuarter()
        };
    }

    // This presumes that weeks start with Monday.
    // Week 1 is the 1st week of the year with a Thursday in it.
    public static int GetIso8601WeekOfYear(this DateTime value)
    {
        // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
        // be the same week# as whatever Thursday, Friday or Saturday are,
        // and we always get those right
        var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(value);
        if (day is >= DayOfWeek.Monday and <= DayOfWeek.Wednesday)
        {
            value = value.AddDays(3);
        }

        // Return the week of our adjusted day
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek,
            DayOfWeek.Monday);
    }

    /// <summary>
    ///     Calculates a Month Dimension based on the value
    /// </summary>
    /// <param name="value">the Date Value</param>
    /// <param name="finYearStart">the start of the Financial year</param>
    /// <returns>a MonthDimension</returns>
    public static MonthDimension GetMonthDimension(this DateTime value, DateTime finYearStart)
    {
        return value.GetMonthDimension(finYearStart.Month);
    }

    /// <summary>
    ///     Calculates a Month Dimension based on the value
    /// </summary>
    /// <param name="value">the Date Value</param>
    /// <param name="finYearStartMonth">the start of the Financial year</param>
    /// <returns>a MonthDimension</returns>
    public static MonthDimension GetMonthDimension(this DateTime value, int finYearStartMonth)
    {
        var finYearStart = new DateTime(value.Year, finYearStartMonth, 1);

        if (finYearStart > value)
        {
            finYearStart = finYearStart.AddYears(-1);
        }

        var finYearFactor = 12 - finYearStartMonth + 1;

        var yearMonth = value.ToMonthDimKey();

        var finYear = finYearStart.Year;
        var finMonth = value.Month >= finYearStartMonth
            ? value.Month - finYearStartMonth + 1
            : value.Month + finYearFactor;

        var finYearMonth = finYear * 100 + finMonth;
        var finYrMthDate = new DateTime(finYear, finMonth, 1);

        return new MonthDimension
        {
            YrMthNo = yearMonth,
            YrNo = value.Year,
            MthNo = value.Month,
            QuarterNo = value.GetQuarter(),
            MthShortDesc = value.ToString("MMM", CultureInfo.InvariantCulture),
            MthLongDesc = value.ToString("MMMM", CultureInfo.InvariantCulture),
            MthYearShortDesc = value.ToString("MMM yyyy", CultureInfo.InvariantCulture),
            MthYearLongDesc = value.ToString("MMMM yyyy", CultureInfo.InvariantCulture),
            FinYrNo = finYear,
            FinMthNo = finMonth,
            FinYrMthNo = finYearMonth,
            FinQuarterNo = finYrMthDate.GetQuarter()
        };
    }

    /// <summary>
    ///     Calculates the Quarter in the Year
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a Integer</returns>
    public static int GetQuarter(this DateTimeOffset date)
    {
        return GetQuarter(date.Date);
    }

    /// <summary>
    ///     Calculates the Quarter in the Year
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a Integer</returns>
    public static int GetQuarter(this DateTime date)
    {
        return date.Month switch
        {
            >= 1 and <= 3 => 1,
            >= 4 and <= 6 => 2,
            >= 7 and <= 9 => 3,
            _ => 4
        };
    }

    public static DateTime LastDayOfWeek(this DateTime value)
    {
        var d = new GregorianCalendar().AddDays(value, -(int)value.DayOfWeek + (int)DayOfWeek.Sunday);

        return d < value ? d.AddDays(7) : d;
    }
}