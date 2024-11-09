using System.Globalization;

namespace DateTimeProviders.Providers.Extensions;

/// <summary>
///     DateTime Extensions class.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    ///     Calculates Easter Sunday
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
    ///     Calculates Easter Sunday
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
        var h = (19 * a + b - d - g + 15) % 30;
        var i = c / 4;
        var k = c % 4;
        var l = (32 + 2 * e + 2 * i - h - k) % 7;
        var m = (a + 11 * h + 22 * l) / 451;
        var easterMonth = (h + l - 7 * m + 114) / 31;
        var p = (h + l - 7 * m + 114) % 31;
        var easterDay = p + 1;

        return new DateTime(year, easterMonth, easterDay);
    }

    /// <summary>
    ///     Calculates the end of the weekday for the given date.
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
    ///     Calculates the end of the month for the given date.
    /// </summary>
    /// <param name="date">the DateTime as DateTimeOffset.</param>
    /// <returns>a DateTime</returns>
    public static DateTime EndOfTheMonth(this DateTimeOffset date)
    {
        return date.Date.EndOfTheMonth();
    }

    /// <summary>
    ///     Calculates the end of the month for the given date.
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime EndOfTheMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1)
            .AddMonths(1)
            .AddDays(-1);
    }

    /// <summary>
    ///     Calculates the first weekday for the year month.
    /// </summary>
    /// <param name="date">the target year month as datetime.</param>
    /// <param name="weekday">the weekday of the week.</param>
    /// <returns>the datetime for the weekday.</returns>
    public static DateTime GetFirstWeekday(this DateTime date, DayOfWeek weekday)
    {
        var dayCount = DateTime.DaysInMonth(date.Year, date.Month);
        var result = Enumerable
            .Range(1, dayCount)
            .Select(day => new DateTime(date.Year, date.Month, day))
            .First(d => d.DayOfWeek == weekday);
        return result;
    }

    /// <summary>
    ///     Calculates the last weekday for the year month.
    /// </summary>
    /// <param name="date">the target year month as datetime.</param>
    /// <param name="weekday">the weekday of the week.</param>
    /// <returns>the datetime for the weekday.</returns>
    public static DateTime GetLastWeekday(this DateTime date, DayOfWeek weekday)
    {
        var dayCount = DateTime.DaysInMonth(date.Year, date.Month);
        var result = Enumerable
            .Range(1, dayCount)
            .Select(day => new DateTime(date.Year, date.Month, day))
            .Last(d => d.DayOfWeek == weekday);
        return result;
    }

    /// <summary>
    ///     Calculates the Nth weekday for the year month.
    /// </summary>
    /// <param name="date">the target year month as datetime.</param>
    /// <param name="nth">the nth</param>
    /// <param name="weekday">the weekday of the week.</param>
    /// <returns>the datetime for the weekday.</returns>
    public static DateTime GetNthWeekday(this DateTime date, int nth, DayOfWeek weekday)
    {
        var dayCount = DateTime.DaysInMonth(date.Year, date.Month);
        var weekdayCount = date.GetWeekdayCount(weekday);
        if (weekdayCount < nth)
        {
            throw new ArgumentOutOfRangeException($"Only {weekdayCount} {weekday:G}'s in {date:Y}", nameof(nth));
        }

        var result = Enumerable.Range(1, dayCount)
            .Select(day => new DateTime(date.Year, date.Month, day))
            .Where(d => d.DayOfWeek == weekday)
            .Skip(nth - 1)
            .Take(1)
            .Single();

        return result;
    }

    /// <summary>
    ///     Calculates the number of a weekday for the year month.
    /// </summary>
    /// <param name="date">the target year month as datetime.</param>
    /// <param name="weekday">the weekday of the week.</param>
    /// <returns>the no of weekday in the month.</returns>
    public static int GetWeekdayCount(this DateTime date, DayOfWeek weekday)
    {
        var dayCount = DateTime.DaysInMonth(date.Year, date.Month);
        var result = Enumerable.Range(1, dayCount)
            .Select(day => new DateTime(date.Year, date.Month, day))
            .Where(d => d.DayOfWeek == weekday);
        return result.Count();
    }

    /// <summary>
    ///     Checks if the date is in a leap year
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a Boolean</returns>
    public static bool IsLeapDay(this DateTime date)
    {
        return date.Month == 2 && date.Day == 29;
    }

    /// <summary>
    ///     Checks if the date is a WorkDay
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <param name="workdayDefault"></param>
    /// <param name="workdays">the Working days of the week</param>
    /// <param name="holidays">the Holidays</param>
    /// <returns>a Boolean</returns>
    public static bool IsWorkDay(this DateTime date, bool workdayDefault = true,
        Dictionary<DayOfWeek, bool>? workdays = null, IEnumerable<DateTime>? holidays = null)
    {
        var result = false;

        if (!workdays?.TryGetValue(date.DayOfWeek, out result) ?? true)
        {
            result = workdayDefault;
        }

        if (result && holidays != null)
        {
            result = holidays.All(h => h != date);
        }

        return result;
    }

    /// <summary>
    ///     Calculates the next weekday of the week for the given date.
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <param name="weekday">the Next Weekday</param>
    /// <returns>a DateTime</returns>
    public static DateTime NextDayOfWeek(this DateTime date, DayOfWeek weekday)
    {
        var d = new GregorianCalendar().AddDays(date, -(int)date.DayOfWeek + (int)weekday).StartOfDay();
        return d.Day <= date.Day ? d.AddDays(7) : d;
    }

    /// <summary>
    ///     Calculates the previous weekday of the week for the given date.
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <param name="weekday">the Previous Weekday</param>
    /// <returns>a DateTime</returns>
    public static DateTime PreviousDayOfWeek(this DateTime date, DayOfWeek weekday)
    {
        var d = new GregorianCalendar().AddDays(date, -(int)date.DayOfWeek + (int)weekday).StartOfDay();
        return d.Day >= date.Day ? d.AddDays(-7) : d;
    }

    /// <summary>
    ///     Calculates the start of the date for the given date.
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime StartOfDay(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 000);
    }

    /// <summary>
    ///     Calculates the start of the next month for the given date.
    /// </summary>
    /// <param name="date">the DateTime as DateTimeOffset.</param>
    /// <returns>a DateTime</returns>
    public static DateTime StartOfNextMonth(this DateTimeOffset date)
    {
        return date.Date.StartOfNextMonth();
    }

    /// <summary>
    ///     Calculates the start of the next month for the given date.
    /// </summary>
    /// <param name="date">the DateTime</param>
    /// <returns>a DateTime</returns>
    public static DateTime StartOfNextMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1).AddMonths(1);
    }

    /// <summary>
    ///     Calculates the start of the month for the given date.
    /// </summary>
    /// <param name="date">the DateTime as DateTimeOffset.</param>
    /// <returns>a DateTime</returns>
    public static DateTime StartOfTheMonth(this DateTimeOffset date)
    {
        return date.Date.StartOfTheMonth();
    }

    /// <summary>
    ///     Calculates the start of the month for the given date.
    /// </summary>
    /// <param name="date">the DateTime.</param>
    /// <returns>a DateTime</returns>
    public static DateTime StartOfTheMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }
}