using System.Globalization;
using DateTimeProviders.Providers.DataTypes;

namespace DateTimeProviders.Providers.Extensions;

public static class DimensionKeyExtensions
{
    /// <summary>
    ///     Converts Date Dimension key to Datetime
    /// </summary>
    /// <param name="value">the Key</param>
    /// <returns>a DateTime</returns>
    public static DateTime FromDateDimKey(this DateDimKey value)
    {
        if (DateTime.TryParseExact($"{value.Value}", "yyyyMMdd", CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeLocal,
                out var result))
        {
            return result;
        }

        throw new ArgumentException("Invalid Date Dim Key", nameof(value));
    }

    /// <summary>
    ///     Converts Month Dimension key to Datetime
    /// </summary>
    /// <param name="value">the Key</param>
    /// <returns>a DateTime</returns>
    public static DateTime FromMonthDimKey(this MonthDimKey value)
    {
        if (DateTime.TryParseExact($"{value.Value}", "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal,
                out var result))
        {
            return result;
        }

        throw new ArgumentException("Invalid Month Dim Key", nameof(value));
    }
    
    /// <summary>
    ///     Calculates the next Date Dimension key
    /// </summary>
    /// <param name="value">the Key</param>
    /// <returns>a DateDimKey</returns>
    public static DateDimKey NextDateDimKey(this DateDimKey value)
    {
        var dateValue = value.FromDateDimKey();
        dateValue = dateValue.AddDays(1);
        return dateValue.ToDateDimKey();
    }
    
    /// <summary>
    ///     Calculates the next Month Dimension key
    /// </summary>
    /// <param name="value">the Key</param>
    /// <returns>a MonthDimKey</returns>
    public static MonthDimKey NextMonthDimKey(this MonthDimKey value)
    {
        var dateValue = value.FromMonthDimKey();
        dateValue = dateValue.AddMonths(1);
        return dateValue.ToMonthDimKey();
    }
    
    /// <summary>
    ///     Calculates the previous Date Dimension key
    /// </summary>
    /// <param name="value">the Key</param>
    /// <returns>a DateDimKey</returns>
    public static DateDimKey PrevDateDimKey(this DateDimKey value)
    {
        var dateValue = value.FromDateDimKey();
        dateValue = dateValue.AddDays(-1);
        return dateValue.ToDateDimKey();
    }
    
    /// <summary>
    ///     Calculates the previous Month Dimension key
    /// </summary>
    /// <param name="value">the Key</param>
    /// <returns>a MonthDimKey</returns>
    public static MonthDimKey PrevMonthDimKey(this MonthDimKey value)
    {
        var dateValue = value.FromMonthDimKey();
        dateValue = dateValue.AddMonths(-1);
        return dateValue.ToMonthDimKey();
    }

    /// <summary>
    ///     Converts Datetime to Date Dimension key
    /// </summary>
    /// <param name="value">the date time</param>
    /// <returns>a DateDimKey</returns>
    public static DateDimKey ToDateDimKey(this DateTime value)
    {
        var dimValue = value.ToMonthDimKey() * 100 + value.Day;
        return new DateDimKey(dimValue);
    }

    /// <summary>
    ///     Converts Datetime to Month Dimension key
    /// </summary>
    /// <param name="value">the date time</param>
    /// <returns>a MonthDimKey</returns>
    public static MonthDimKey ToMonthDimKey(this DateTime value)
    {
        var dimValue = value.Year * 100 + value.Month;
        return new MonthDimKey(dimValue);
    }
}