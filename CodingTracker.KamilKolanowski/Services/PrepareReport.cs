using Spectre.Console;
using System.Globalization;
using CodingTracker.KamilKolanowski.Data;
using CodingTracker.KamilKolanowski.Enums;

namespace CodingTracker.KamilKolanowski.Services;

internal class PrepareReport
{
    private readonly DatabaseManager _databaseManager = new();

    internal void PreparePeriodicReport(Options.ReportingOptions reportingOptions, string orderingReport)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumn("[lime]Period[/]");
        table.AddColumn("[lime]Time Spent (s)[/]");

        var reportTable = new List<DatabaseManager.CodingReport>();
        
        switch(reportingOptions)
        {
            case Options.ReportingOptions.GetWeeklyReport:
                reportTable = _databaseManager.CreateReport(reportingOptions, orderingReport);
                break;
            case Options.ReportingOptions.GetMonthlyReport:
                reportTable =_databaseManager.CreateReport(reportingOptions, orderingReport);
                break;
            case Options.ReportingOptions.GetYearlyReport:
                reportTable = _databaseManager.CreateReport(reportingOptions, orderingReport);
                break;
        };

        foreach (var row in reportTable)
        {
            table.AddRow($"[dodgerblue1]{row.Period}[/]", $"[dodgerblue1]{row.TimeSpent.ToString()}[/]");
        }
            
        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadKey();
    }


}