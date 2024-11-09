using DateTimeProviders.Providers.DataTypes;

namespace DateTimeProviders.Dimensions.Models;

/// <summary>
///     Date dimension class
/// </summary>
public class DateDimension
{
    /// <summary>
    ///     Gets or sets the date key
    /// </summary>
    public DateDimKey DateKey { get; set; }

    /// <summary>
    ///     Gets or sets the date value
    /// </summary>
    public DateTime DateVal { get; set; }

    /// <summary>
    ///     Gets or sets the Day value
    /// </summary>
    public int DayNo { get; set; }

    /// <summary>
    ///     Gets or sets the Day of the week description
    /// </summary>
    public string DayOfWeek { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the Day of the week value
    /// </summary>
    public int DayOfWeekNo { get; set; }

    /// <summary>
    ///     Gets or sets the Financial Month value
    /// </summary>
    public int FinMthNo { get; set; }

    /// <summary>
    ///     Gets or sets the Financial Quarter value
    /// </summary>
    public int FinQuarterNo { get; set; }

    /// <summary>
    ///     Gets or sets the Financial Year Month value
    /// </summary>
    public long FinYrMthNo { get; set; }

    /// <summary>
    ///     Gets or sets the Financial Year value
    /// </summary>
    public int FinYrNo { get; set; }

    /// <summary>
    ///     Gets or sets the First Day of the Week value
    /// </summary>
    public long FirstDayOfWeek { get; set; }

    /// <summary>
    ///     Gets or sets the Last Day of the Week value
    /// </summary>
    public long LastDayOfWeek { get; set; }

    /// <summary>
    ///     Gets or sets the Long Description for the Month
    /// </summary>
    public string MthLongDesc { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the Month value
    /// </summary>
    public int MthNo { get; set; }

    /// <summary>
    ///     Gets or sets the Month Short Description
    /// </summary>
    public string MthShortDesc { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the Quarter value
    /// </summary>
    public int QuarterNo { get; set; }

    /// <summary>
    ///     Gets or sets the short date value
    /// </summary>
    public string ShortDateVal { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the Week Description
    /// </summary>
    public string WeekLabel { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the Week value
    /// </summary>
    public int WeekNo { get; set; }

    /// <summary>
    ///     Gets or sets the Year Month value
    /// </summary>
    public long YrMthNo { get; set; }

    /// <summary>
    ///     Gets or sets the Year value
    /// </summary>
    public int YrNo { get; set; }
}