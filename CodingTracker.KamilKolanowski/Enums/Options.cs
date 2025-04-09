namespace CodingTracker.KamilKolanowski.Enums;

internal class Options
{
    internal enum MenuOptions
    {
        AddSessionManually,
        StartSession,
        EndSession,
        ViewSessions,
        GetReport,
        Quit
    };
    
    internal static readonly Dictionary<MenuOptions, string> OptionDisplayNames = new()
    {
        { MenuOptions.AddSessionManually, "Add Session" },
        { MenuOptions.StartSession, "Start Session" },
        { MenuOptions.EndSession, "End Session" },
        { MenuOptions.ViewSessions, "View Sessions" },
        { MenuOptions.GetReport, "View Reports" },
        { MenuOptions.Quit, "Quit App" }
    };

    internal enum ReportingOptions
    {
        GetWeeklyReport,
        GetMonthlyReport,
        GetYearlyReport,
        GroupingPeriod
    };

    internal static readonly Dictionary<ReportingOptions, string> ReportingOptionDisplayNames = new()
    {
        { ReportingOptions.GetWeeklyReport, "Get Weekly Report" },
        { ReportingOptions.GetMonthlyReport, "Get Monthly Report" },
        { ReportingOptions.GetYearlyReport, "Get Yearly Report" }
    };


}