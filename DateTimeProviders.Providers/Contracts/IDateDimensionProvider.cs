using DateTimeProviders.Dimensions.Models;

namespace DateTimeProviders.Providers.Contracts;

/// <summary>
///     IDateDimensionProvider interface.
/// </summary>
public interface IDateDimensionProvider
{
    /// <summary>
    ///     Get the value for the Financial Start Month.
    /// </summary>
    int FinStartMonth { get; }

    /// <summary>
    ///     Generates Date Dimensions.
    /// </summary>
    /// <param name="startDate">the start date</param>
    /// <returns>DateDimension</returns>
    IEnumerable<DateDimension> GetDateDimensions(DateTime startDate);

    /// <summary>
    ///     Generates Month Dimensions for the Financial Year.
    /// </summary>
    /// <param name="startDate">the start date</param>
    /// <returns>MonthDimensions</returns>
    IEnumerable<MonthDimension> GetMonthDimensionFinYear(DateTime startDate);

    /// <summary>
    ///     Generates Month Dimensions.
    /// </summary>
    /// <param name="startDate">the start date</param>
    /// <returns>MonthDimensions</returns>
    IEnumerable<MonthDimension> GetMonthDimensions(DateTime startDate);
}