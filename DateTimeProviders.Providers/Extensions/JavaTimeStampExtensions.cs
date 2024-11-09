namespace DateTimeProviders.Providers.Extensions;

public static class JavaTimeStampExtensions
{
    /// <summary>
    ///     Convert Java Timestamp to datetime.
    /// </summary>
    /// <param name="javaTimeStamp">the Java TimeStamp.</param>
    /// <returns>a DateTime</returns>
    public static DateTime JavaTimeStampToDateTime(this double javaTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddMilliseconds(javaTimeStamp * 1000).ToLocalTime();
        return dtDateTime;
    }

    /// <summary>
    ///     Convert DateTime to Java Timestamp
    /// </summary>
    /// <param name="dateTime">the DateTime</param>
    /// <returns>a Java Timestamp</returns>
    public static double ToJavaTimestamp(this DateTime dateTime)
    {
        return (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds /
               1000;
    }
}