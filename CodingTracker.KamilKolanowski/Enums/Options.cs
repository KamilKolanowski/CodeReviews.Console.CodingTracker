namespace CodingTracker.KamilKolanowski.Enums;

internal class Options
{
    internal enum MenuOptions
    {
        AddSessionManually,
        StartSession,
        EndSession,
        ViewSessions,
        Quit 
    }

    internal enum AddDateOptions
    {
        UserAddDate,
        AppAddDate
    }

    internal static readonly Dictionary<MenuOptions, string> OptionDisplayNames = new()
    {
        { MenuOptions.AddSessionManually, "Add Session" },
        { MenuOptions.StartSession, "Start Session" },
        { MenuOptions.EndSession, "End Session" },
        { MenuOptions.ViewSessions, "View Sessions" },
        { MenuOptions.Quit, "Quit App" }
    };
    
}