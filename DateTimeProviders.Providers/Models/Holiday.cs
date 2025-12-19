
namespace DateTimeProviders.Providers.Models;

/// <summary>
/// Public Holiday class
/// </summary>
public class Holiday
{
    /// <summary>
    /// Gets or sets the date of the holiday
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// Gets or sets the name of the holiday
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Gets the day of the week for the holiday
    /// </summary>
    public DayOfWeek DayOfWeek => Date.DayOfWeek;
}