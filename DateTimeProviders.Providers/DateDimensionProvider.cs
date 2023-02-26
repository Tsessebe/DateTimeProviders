using DateTimeProviders.Dimensions.Extensions;
using DateTimeProviders.Dimensions.Models;
using DateTimeProviders.Providers.Contracts;

namespace DateTimeProviders.Providers;

public class DateDimensionProvider : IDateDimensionProvider
{
    /// <summary>
    /// Gets a Date Dimensions Service with Jan as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartJan => new DateDimensionProvider(1);

    /// <summary>
    /// Gets a Date Dimensions Service with Feb as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartFeb => new DateDimensionProvider(2);

    /// <summary>
    /// Gets a Date Dimensions Service with Mar as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartMar => new DateDimensionProvider(3);

    /// <summary>
    /// Gets a Date Dimensions Service with Apr as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartApr => new DateDimensionProvider(4);

    /// <summary>
    /// Gets a Date Dimensions Service with May as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartMay => new DateDimensionProvider(5);

    /// <summary>
    /// Gets a Date Dimensions Service with Jun as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartJun => new DateDimensionProvider(6);

    /// <summary>
    /// Gets a Date Dimensions Service with Jun as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartJul => new DateDimensionProvider(7);

    /// <summary>
    /// Gets a Date Dimensions Service with Aug as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartAug => new DateDimensionProvider(8);

    /// <summary>
    /// Gets a Date Dimensions Service with Sep as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartSep => new DateDimensionProvider(9);

    /// <summary>
    /// Gets a Date Dimensions Service with Oct as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartOct => new DateDimensionProvider(10);

    /// <summary>
    /// Gets a Date Dimensions Service with Nov as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartNov => new DateDimensionProvider(11);

    /// <summary>
    /// Gets a Date Dimensions Service with Dec as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartDec => new DateDimensionProvider(12);

    /// <summary>
    /// Initializes a new instance of the <see cref="DateDimensionProvider"/> class.
    /// </summary>
    /// <param name="finStartDate">The date the financial year starts</param>
    public DateDimensionProvider(DateTime finStartDate)
        : this(finStartDate.Month)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateDimensionProvider"/> class.
    /// </summary>
    /// <param name="finStartMonth">The month the financial year starts</param>
    public DateDimensionProvider(int finStartMonth)
    {
        this.FinStartMonth = finStartMonth;
    }
    
    public int FinStartMonth { get; }

    /// <inheritdoc/>
    public IEnumerable<MonthDimension> GetMonthDimensions(DateTime startDate)
    {
        var nextValue = startDate.AddMonths(-1);
        var stopValue = DateTime.MaxValue.AddMonths(-1);

        while (true)
        {
            if (nextValue.AddMonths(1) >= stopValue)
            {
                yield break;
            }

            nextValue = nextValue.AddMonths(1);

            yield return nextValue.GetMonthDimension(this.FinStartMonth);
        }
    }
    
    /// <inheritdoc/>
    public IEnumerable<DateDimension> GetDateDimensions(DateTime startDate)
    {
        var nextValue = startDate.AddDays(-1);
        var stopValue = DateTime.MaxValue.AddMonths(-1);

        while (true)
        {
            if (nextValue.AddMonths(1) >= stopValue)
            {
                yield break;
            }

            nextValue = nextValue.AddDays(1);

            yield return nextValue.GetDateDimension(this.FinStartMonth);
        }
    }

    /// <inheritdoc/>
    public IEnumerable<MonthDimension> GetMonthDimensionFinYear(DateTime startDate)
    {
        var dateDim = startDate.GetMonthDimension(this.FinStartMonth);
        var adjustMonths = (dateDim.FinMthNo * -1) + 1;
        var finStartDate = startDate.AddMonths(adjustMonths);

        var nextValue = finStartDate.AddMonths(-1);
        for (int i = 0; i < 12; i++)
        {
            nextValue = nextValue.AddMonths(1);

            yield return nextValue.GetMonthDimension(this.FinStartMonth);
        }
    }
}