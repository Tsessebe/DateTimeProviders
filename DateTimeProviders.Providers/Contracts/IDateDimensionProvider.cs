using DateTimeProviders.Dimensions.Models;
using DateTimeProviders.Providers.Enums;

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
    ///     Generates Month Dimensions for the Financial Year.
    /// </summary>
    /// <param name="startYear">the start year</param>
    /// <returns>MonthDimensions</returns>
    IEnumerable<MonthDimension> GetMonthDimensionFinYear(int startYear);

    /// <summary>
    ///     Generates Month Dimensions.
    /// </summary>
    /// <param name="startDate">the start date</param>
    /// <returns>MonthDimensions</returns>
    IEnumerable<MonthDimension> GetMonthDimensions(DateTime startDate);

    /// <summary>
    ///     Generates a Financial Year.
    /// </summary>
    /// <param name="startDate">the Start Date.</param>
    /// <returns>FinancialYear</returns>
    FinancialYear GetFinancialYear(DateTime startDate);

    /// <summary>
    ///     Generates a Financial Year.
    /// </summary>
    /// <param name="startYear">the Start Year No.</param>
    /// <returns>FinancialYear</returns>
    FinancialYear GetFinancialYear(int startYear);

    /// <summary>
    ///     Generates a list of Financial Years.
    /// </summary>
    /// <param name="yearNo">the Year No.</param>
    /// <param name="count">the Count of financial years.</param>
    /// <param name="getType">Previous or Next {count} of years.</param>
    /// <returns>Financial Years</returns>
    IEnumerable<FinancialYear> GetFinancialYears(int yearNo, int count, GetTypes getType = GetTypes.Previous);
}