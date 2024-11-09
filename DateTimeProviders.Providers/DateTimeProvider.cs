using System.Diagnostics.CodeAnalysis;
using DateTimeProviders.Providers.Contracts;
using DateTimeProviders.Providers.Extensions;

namespace DateTimeProviders.Providers;

/// <summary>
///     DateTimeProvider class.
/// </summary>
/// <remarks>
///     Time Zone is UTC.
/// </remarks>
[ExcludeFromCodeCoverage]
public class DateTimeProvider : IDateTimeProvider
{
    /// <summary>
    ///     Gets the value for the "Min" date.
    /// </summary>
    /// <remarks>
    ///     UTC Unix epoch
    /// </remarks>
    public static DateTime MinDate => new(1970, 01, 01, 00, 00, 00, DateTimeKind.Utc);

    /// <summary>
    ///     Gets the value for the "zero"/ date.
    /// </summary>
    /// <remarks>
    ///     UTC Unix epoch
    /// </remarks>
    public static DateTimeOffset ZeroDateOffSet => new(1970, 01, 01, 00, 00, 00, TimeSpan.Zero);

    /// <inheritdoc cref="IDateTimeProvider" />
    public DateTimeOffset EndOfTheMonth => Today.EndOfTheMonth();

    /// <inheritdoc cref="IDateTimeProvider" />
    /// <remarks>
    ///     UTC Now
    /// </remarks>
    public DateTimeOffset Now => DateTimeOffset.UtcNow;

    /// <inheritdoc cref="IDateTimeProvider" />
    public DateTimeOffset StartOfNextMonth => Today.StartOfNextMonth();

    /// <inheritdoc cref="IDateTimeProvider" />
    public DateTimeOffset StartOfTheMonth => Today.StartOfTheMonth();

    /// <inheritdoc cref="IDateTimeProvider" />
    /// <remarks>
    ///     UTC Now Date (Start of Day)
    /// </remarks>
    public DateTimeOffset Today => Now.Date;

    /// <inheritdoc cref="IDateTimeProvider" />
    public DateTimeOffset Zero => new(1970, 01, 01, 00, 00, 00, TimeSpan.Zero);
}