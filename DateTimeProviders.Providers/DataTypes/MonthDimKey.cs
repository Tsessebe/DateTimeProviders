using System.Globalization;

namespace DateTimeProviders.Providers.DataTypes;

/// <summary>
///     Strongly typed Month Dimension Key
/// </summary>
/// <param name="Value">the long value</param>
public readonly record struct MonthDimKey(long Value)
{
    public long Value { get; init; } =
        DateTime.TryParseExact($"{Value}", "yyyyMM", CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeLocal, out var _)
            ? Value
            : throw new ArgumentException("Invalid Month Dim Key", nameof(Value));

    public static implicit operator long(MonthDimKey value)
    {
        return value.Value;
    }
}