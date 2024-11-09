namespace DateTimeProviders.Providers.Contracts;

/// <summary>
///     IDateTimeProvider interface.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    ///     Gets a date value for the End of the current month.
    /// </summary>
    DateTimeOffset EndOfTheMonth { get; }

    /// <summary>
    ///     Gets a date & time value for "now".
    /// </summary>
    DateTimeOffset Now { get; }

    /// <summary>
    ///     Gets a date value for the Start of the next month.
    /// </summary>
    DateTimeOffset StartOfNextMonth { get; }

    /// <summary>
    ///     Gets a date value for the Start of the current month.
    /// </summary>
    DateTimeOffset StartOfTheMonth { get; }

    /// <summary>
    ///     Gets a date value for "Start of Day Today".
    /// </summary>
    DateTimeOffset Today { get; }

    /// <summary>
    ///     Gets the value for the "zero"/ date.
    /// </summary>
    DateTimeOffset Zero { get; }
}