namespace DateTimeProviders.Providers.Extensions;

/// <summary>
///     Unix Timestamp Extensions class
/// </summary>
public static class UnixTimestampExtensions
{
    /// <summary>
    ///     Convert DateTime to Unix Timestamp
    /// </summary>
    /// <param name="dateTime">the DateTime</param>
    /// <returns>a Unix Timestamp</returns>
    public static long ToUnixTimestamp(this DateTime dateTime)
    {
        return (long)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    /// <summary>
    ///     Convert Unix Timestamp to datetime
    /// </summary>
    /// <param name="unixTimeStamp">the Unix TimeStamp</param>
    /// <returns>a DateTime</returns>
    public static DateTime UnixTimeStampToDateTime(this long unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }
}