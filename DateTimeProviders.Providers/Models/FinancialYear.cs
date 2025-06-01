namespace DateTimeProviders.Dimensions.Models;

public class FinancialYear
{
    public FinancialYear(int finStartMonth)
    {
        FinStartMonth = finStartMonth;
    }

    public int FinStartMonth { get; }

    public int StartYear => Months.Any() ? Months.OrderBy(x => x.FinMthNo).First().YrNo : 0;
    
    public int EndYear => Months.Any() ? Months.OrderBy(x => x.FinMthNo).Last().YrNo : 0;
    
    public List<MonthDimension> Months { get; init; } = new();

    public override string ToString()
    {
        return $"{StartYear}/ {EndYear}";
    }
}