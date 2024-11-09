# DateTimeProviders

The package contains providers for testable dates. As well as additional extensions.

Inspired by this video from [Nick Chapsas](https://youtu.be/5DrGdyxnO5A)

Target platform: .NET Core 6

## Interface

* IDateTimeProvider

```csharp
    DateTimeOffset Now { get; }
    DateTimeOffset Today { get; }
    DateTimeOffset Zero { get; }
    DateTimeOffset StartOfTheMonth { get; }
    DateTimeOffset EndOfTheMonth { get; }
    DateTimeOffset StartOfNextMonth { get; }
```

* IDateDimensionProvider

```csharp
    IEnumerable<MonthDimension> GetMonthDimensions(DateTime startDate);
    IEnumerable<MonthDimension> GetMonthDimensionFinYear(DateTime startDate);
    IEnumerable<DateDimension> GetDateDimensions(DateTime startDate);
    int FinStartMonth { get; }
```

## Extensions

* DateTimeExtensions

```csharp
    DateTime StartOfTheMonth(this DateTimeOffset date)
    DateTime StartOfTheMonth(this DateTime date)
    
    DateTime EndOfTheMonth(this DateTimeOffset date)
    DateTime EndOfTheMonth(this DateTime date)
    
    DateTime StartOfNextMonth(this DateTimeOffset date)
    DateTime StartOfNextMonth(this DateTime date)

    DateTime StartOfDay(this DateTime date)
    DateTime EndOfDay(this DateTime date)

    DateTime PreviousDayOfWeek(this DateTime date, DayOfWeek weekday)
    DateTime NextDayOfWeek(this DateTime date, DayOfWeek weekday)
    DateTime GetFirstWeekday(this DateTime date, DayOfWeek weekday)
    DateTime GetLastWeekday(this DateTime date, DayOfWeek weekday)
    DateTime GetNthWeekday(this DateTime date, int nth, DayOfWeek weekday)
    int GetWeekdayCount(this DateTime date, DayOfWeek weekday)

    bool IsLeapDay(this DateTime date)

    bool IsWorkDay(this DateTime date, bool workdayDefault = true, Dictionary<DayOfWeek, bool>? workdays = null, IEnumerable<DateTime>? holidays = null)

    DateTime EasterSunday(this DateTime value)
    DateTime EasterSunday(this int year)
```

*

## Setup guide

Install the package https://www.nuget.org/packages/Tsessebe.DateTimeProviders/ using nuget

## Gotcha's

* None

## Versions

* 26 Feb 2023 - v1.0.0
    * Added Method to Calculate Financial Year based on date.
    * First Release
* 18 Nov 2022 - v1.0.0-preview Initial Release

