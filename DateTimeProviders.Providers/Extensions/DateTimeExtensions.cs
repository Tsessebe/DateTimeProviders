using System.Globalization;

namespace DateTimeProviders.Providers.Extensions;

/// <summary>
/// DateTime Extensions class
/// </summary>
public static class DateTimeExtensions
{
    public static DateTime StartOfTheMonth(this DateTimeOffset date)
    {
        return date.Date.StartOfTheMonth();
    }
    
    /// <summary>
    /// Calculates the start of the month for the given date
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime StartOfTheMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }
    
    public static DateTime EndOfTheMonth(this DateTimeOffset date)
    {
        return date.Date.EndOfTheMonth();
    }
    
    /// <summary>
    /// Calculates the end of the month for the given date
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime EndOfTheMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1)
            .AddMonths(1)
            .AddDays(-1);
    }

    public static DateTime StartOfNextMonth(this DateTimeOffset date)
    {
        return date.Date.StartOfNextMonth();
    }
    
    /// <summary>
    /// Calculates the start of the next month for the given date
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime StartOfNextMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1).AddMonths(1);
    }

    /// <summary>
    /// Calculates the start of the date for the given date
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime StartOfDay(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 000);
    }

    /// <summary>
    /// Calculates the end of the day for the given date
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime EndOfDay(this DateTime date)
    {
        return date.StartOfDay()
            .AddHours(23)
            .AddMinutes(59)
            .AddSeconds(59);
    }

    /// <summary>
    /// Calculates the next day of the week for the given date
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <param name="day">the Next Weekday</param>
    /// <returns>a DateTime</returns>
    public static DateTime NextDayOfWeek(this DateTime date, DayOfWeek day)
    {
        var d = new GregorianCalendar().AddDays(date, -(int)date.DayOfWeek + (int)day).StartOfDay();
        return (d.Day < date.Day) ? d.AddDays(7) : d;
    }

    /// <summary>
    /// Checks if the date is in a leap year
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a Boolean</returns>
    public static bool IsLeapDay(this DateTime date)
    {
        return date.Month == 2 && date.Day == 29;
    }
    
    /// <summary>
    /// Checks if the date is a WorkDay
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <param name="workdays">the Working days of the week</param>
    /// <returns>a Boolean</returns>
    public static bool IsWorkDay(this DateTime date, Dictionary<DayOfWeek, bool>? workdays = null)
    {
        if (workdays == null)
        {
            return date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday;
        }

        if (workdays.TryGetValue(date.DayOfWeek, out var result))
        {
            return result;
        }

        return date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday;
    }

    /// <summary>
    /// Calculates Easter Sunday
    /// </summary>
    /// <param name="value">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime EasterSunday(this DateTime value)
    {
        var easter = value.Year.EasterSunday();
        if (easter < value)
        {
            easter = value.AddYears(1).Year.EasterSunday();
        }

        return easter;
    }

    /// <summary>
    /// Calculates Easter Sunday
    /// </summary>
    /// <param name="year">the Year</param>
    /// <returns>a DateTime</returns>
    public static DateTime EasterSunday(this int year)
    {
        var a = year % 19;
        var b = year / 100;
        var c = year % 100;
        var d = b / 4;
        var e = b % 4;
        var f = (b + 8) / 25;
        var g = (b - f + 1) / 3;
        var h = ((19 * a) + b - d - g + 15) % 30;
        var i = c / 4;
        var k = c % 4;
        var l = (32 + (2 * e) + (2 * i) - h - k) % 7;
        var m = (a + (11 * h) + (22 * l)) / 451;
        var easterMonth = (h + l - (7 * m) + 114) / 31;
        var p = (h + l - (7 * m) + 114) % 31;
        var easterDay = p + 1;

        return new DateTime(year, easterMonth, easterDay);
    }
}