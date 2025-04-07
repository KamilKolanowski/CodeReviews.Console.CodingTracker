namespace CodingTracker.KamilKolanowski.Enums;

internal class Options
{
    internal enum MenuOptions
    {
        StartSession,
        EndSession,
        ViewSessions,
        Quit 
    }
    
    internal static readonly Dictionary<MenuOptions, string> OptionDisplayNames = new()
    {
        { MenuOptions.StartSession, "Start Session" },
        { MenuOptions.EndSession, "End Session" },
        { MenuOptions.ViewSessions, "View Sessions" },
        { MenuOptions.Quit, "Quit App" }
    };
}