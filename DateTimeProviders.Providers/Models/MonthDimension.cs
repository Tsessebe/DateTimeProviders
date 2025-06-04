using System.Diagnostics;
using DateTimeProviders.Providers.DataTypes;

namespace DateTimeProviders.Dimensions.Models;

/// <summary>
///     Month Dimension Class
/// </summary>
[DebuggerDisplay("{MthShortDesc}")]
public class MonthDimension
{
    /// <summary>
    ///     Gets or sets the Financial Month value
    /// </summary>
    public int FinMthNo { get; set; }

    /// <summary>
    ///     Gets or sets the Financial Quarter value
    /// </summary>
    public int FinQuarterNo { get; set; }

    /// <summary>
    ///     Gets or sets the Financial Year Month Key
    /// </summary>
    public long FinYrMthNo { get; set; }

    /// <summary>
    ///     Gets or sets the Financial Year value
    /// </summary>
    public int FinYrNo { get; set; }

    /// <summary>
    ///     Gets or sets the Month Long Description
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
    ///     Gets or sets the Month Year Long Description
    /// </summary>
    public string MthYearLongDesc { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the Month Year Short Description
    /// </summary>
    public string MthYearShortDesc { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the Quarter value
    /// </summary>
    public int QuarterNo { get; set; }

    /// <summary>
    ///     Gets or sets the Year Month Key
    /// </summary>
    public MonthDimKey YrMthNo { get; set; }

    /// <summary>
    ///     Gets or sets the Year value
    /// </summary>
    public int YrNo { get; set; }
}