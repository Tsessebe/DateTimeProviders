using System.Globalization;

namespace DateTimeProviders.Providers.DataTypes;

/// <summary>
///     Strongly typed Date Dimension Key
/// </summary>
/// <param name="Value">the long value</param>
public readonly record struct DateDimKey(long Value)
{
    public long Value { get; init; } =
        DateTime.TryParseExact($"{Value}", "yyyyMMdd", CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeLocal, out var _)
            ? Value
            : throw new ArgumentException("Invalid Date Dim Key", nameof(Value));

    public static implicit operator long(DateDimKey value)
    {
        return value.Value;
    }
}