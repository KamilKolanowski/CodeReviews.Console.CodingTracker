namespace CodingTracker.KamilKolanowski.Services;

internal class SessionsService
{
    internal static DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }

    internal static decimal GetDuration(DateTime startTime, DateTime endTime)
    {
        TimeSpan duration = endTime - startTime;
        return (decimal)duration.TotalSeconds;
    }
}