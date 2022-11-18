using DateTimeProviders.Dimensions.Models;

namespace DateTimeProviders.Providers.Contracts;

/// <summary>
/// IDateDimensionProvider interface.
/// </summary>
public interface IDateDimensionProvider
{
    /// <summary>
    /// Generates Month Dimensions.
    /// </summary>
    /// <param name="startDate">the start date</param>
    /// <returns>MonthDimensions</returns>
    IEnumerable<MonthDimension> GetMonthDimensions(DateTime startDate);

    /// <summary>
    /// Generates Date Dimensions.
    /// </summary>
    /// <param name="startDate">the start date</param>
    /// <returns>DateDimension</returns>
    IEnumerable<DateDimension> GetDateDimensions(DateTime startDate);
    
    /// <summary>
    /// Get the value for the Financial Start Month.
    /// </summary>
    int FinStartMonth { get; }
}