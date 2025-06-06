﻿using DateTimeProviders.Dimensions.Models;
using DateTimeProviders.Providers.Contracts;
using DateTimeProviders.Providers.DataTypes;
using DateTimeProviders.Providers.Enums;
using DateTimeProviders.Providers.Extensions;

namespace DateTimeProviders.Providers;

public class DateDimensionProvider : IDateDimensionProvider
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DateDimensionProvider" /> class.
    /// </summary>
    /// <param name="finStartDate">The date the financial year starts</param>
    public DateDimensionProvider(DateTime finStartDate)
        : this(finStartDate.Month)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DateDimensionProvider" /> class.
    /// </summary>
    /// <param name="finStartMonth">The month the financial year starts</param>
    public DateDimensionProvider(int finStartMonth)
    {
        FinStartMonth = finStartMonth;
    }

    /// <summary>
    ///     Gets a Date Dimensions Service with Apr as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartApr => new DateDimensionProvider(4);

    /// <summary>
    ///     Gets a Date Dimensions Service with Aug as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartAug => new DateDimensionProvider(8);

    /// <summary>
    ///     Gets a Date Dimensions Service with Dec as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartDec => new DateDimensionProvider(12);

    /// <summary>
    ///     Gets a Date Dimensions Service with Feb as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartFeb => new DateDimensionProvider(2);

    /// <summary>
    ///     Gets a Date Dimensions Service with Jan as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartJan => new DateDimensionProvider(1);

    /// <summary>
    ///     Gets a Date Dimensions Service with Jun as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartJul => new DateDimensionProvider(7);

    /// <summary>
    ///     Gets a Date Dimensions Service with Jun as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartJun => new DateDimensionProvider(6);

    /// <summary>
    ///     Gets a Date Dimensions Service with Mar as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartMar => new DateDimensionProvider(3);

    /// <summary>
    ///     Gets a Date Dimensions Service with May as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartMay => new DateDimensionProvider(5);

    /// <summary>
    ///     Gets a Date Dimensions Service with Nov as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartNov => new DateDimensionProvider(11);

    /// <summary>
    ///     Gets a Date Dimensions Service with Oct as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartOct => new DateDimensionProvider(10);

    /// <summary>
    ///     Gets a Date Dimensions Service with Sep as Financial Start Month
    /// </summary>
    public static IDateDimensionProvider FinStartSep => new DateDimensionProvider(9);

    public int FinStartMonth { get; }

    /// <inheritdoc />
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

            yield return nextValue.GetDateDimension(FinStartMonth);
        }
    }

    /// <inheritdoc />
    public IEnumerable<MonthDimension> GetMonthDimensionFinYear(DateTime startDate)
    {
        var dateDim = startDate.GetMonthDimension(FinStartMonth);
        var adjustMonths = dateDim.FinMthNo * -1 + 1;
        var finStartDate = startDate.AddMonths(adjustMonths);

        var nextValue = finStartDate.AddMonths(-1);
        for (var i = 0; i < 12; i++)
        {
            nextValue = nextValue.AddMonths(1);

            yield return nextValue.GetMonthDimension(FinStartMonth);
        }
    }

    /// <inheritdoc />
    public IEnumerable<MonthDimension> GetMonthDimensionFinYear(int startYear)
    {
        var monthDimKey = new MonthDimKey(startYear * 100 + FinStartMonth);
        var startDate = monthDimKey.FromMonthDimKey();
        
        var dateDim = startDate.GetMonthDimension(FinStartMonth);
        var adjustMonths = dateDim.FinMthNo * -1 + 1;
        var finStartDate = startDate.AddMonths(adjustMonths);

        var nextValue = finStartDate.AddMonths(-1);
        for (var i = 0; i < 12; i++)
        {
            nextValue = nextValue.AddMonths(1);

            yield return nextValue.GetMonthDimension(FinStartMonth);
        }
    }
    
    /// <inheritdoc />
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

            yield return nextValue.GetMonthDimension(FinStartMonth);
        }
    }

    /// <inheritdoc />
    public FinancialYear GetFinancialYear(DateTime startDate)
    {
        var months = GetMonthDimensionFinYear(startDate).ToList();
        var result = new FinancialYear(FinStartMonth)
        {
            Months = months,
        };
        return result;
    }

    /// <inheritdoc />
    public FinancialYear GetFinancialYear(int startYear)
    {
        var months = GetMonthDimensionFinYear(startYear).ToList();
        var result = new FinancialYear(FinStartMonth)
        {
            Months = months,
        };
        return result;
    }

    /// <inheritdoc />
    public IEnumerable<FinancialYear> GetFinancialYears(int yearNo, int count, GetTypes getType = GetTypes.Previous)
    {
        var result = new List<FinancialYear>();
        
        var startYear = getType == GetTypes.Previous ? yearNo - count : yearNo;
        var endYear = getType == GetTypes.Previous ? yearNo : yearNo + count;

        for (var i = startYear; i < endYear; i++)
        {
            var financialYear = GetFinancialYear(i);
            result.Add(financialYear);
        }
        
        return result;
    }
}