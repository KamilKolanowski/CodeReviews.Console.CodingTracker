using Spectre.Console;
using System.Globalization;
using CodingTracker.KamilKolanowski.Data;
using CodingTracker.KamilKolanowski.Enums;

namespace CodingTracker.KamilKolanowski.Services;

internal class PrepareReport
{
    private readonly DatabaseManager _databaseManager = new();

    internal void PreparePeriodicReport(Options.ReportingOptions reportingOptions)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumn("[lime]Period[/]");
        table.AddColumn("[lime]Time Spent (s)[/]");

        var rawTable = _databaseManager.ReadTable();

        var groupedTable = reportingOptions switch
        {
            Options.ReportingOptions.GetWeeklyReport => rawTable
                .GroupBy(x =>
                {
                    var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                        x.StartDateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                    return $"Week {week} - {x.StartDateTime.Year}";
                })
                .Select(g => new { Period = g.Key, Duration = g.Sum(x => x.Duration) }),

            Options.ReportingOptions.GetMonthlyReport => rawTable
                .GroupBy(x => new { x.StartDateTime.Year, x.StartDateTime.Month })
                .Select(g => new
                {
                    Period = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month)} - {g.Key.Year}",
                    Duration = g.Sum(x => x.Duration)
                }),

            Options.ReportingOptions.GetYearlyReport => rawTable
                .GroupBy(x => x.StartDateTime.Year)
                .Select(g => new { Period = g.Key.ToString(), Duration = g.Sum(x => x.Duration) }),

            _ => throw new ArgumentOutOfRangeException()
        };

        foreach (var row in groupedTable.OrderBy(x => x.Period))
            table.AddRow($"[dodgerblue1]{row.Period}[/]", $"[dodgerblue1]{row.Duration.ToString()}[/]");

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to go back to the main menu.");
        Console.ReadKey();
    }


}