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
    IEnumerable<DateDimension> GetDateDimensions(DateTime startDate);
    int FinStartMonth { get; }
```

## Setup guide
Install the package https://www.nuget.org/packages/Tsessebe.DateTimeProviders/ using nuget


## Gotcha's

* None

## Versions

* 18 Nov 2022 - v1.0.0-preview Initial Release

