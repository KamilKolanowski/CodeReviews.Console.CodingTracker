using CodingTracker.KamilKolanowski.Services;
using CodingTracker.KamilKolanowski.Data;
using Spectre.Console;

namespace CodingTracker.KamilKolanowski.Controllers;

internal class SessionsController : IBaseController
{
    private DateTime _startTime;
    private DateTime _endTime;
    private decimal _duration;
    public void StartSession(bool isSessionStarted)
    {
        if (isSessionStarted)
        {
            Console.WriteLine("The session is already started.");
            Console.WriteLine("Press any key to go back to menu.");

            Console.ReadKey();
        }
        else
        {
            _startTime = SessionsService.GetCurrentTime();
            Console.WriteLine($"Starting session at {_startTime}");
            Console.WriteLine("Session started. Press any key to go back to menu.");
            
            Console.ReadKey();
        }
    }

    public void EndSession(bool isSessionStarted, bool isSessionEnded, DatabaseManager databaseManager)
    {
        if (isSessionEnded && isSessionStarted)
        {
            _endTime = SessionsService.GetCurrentTime();
            _duration = SessionsService.GetDuration(_startTime, _endTime);
            
            databaseManager.WriteTable(_startTime, _endTime, _duration);
            Console.WriteLine($"Ending session at {_endTime} - Your session lasted {_duration} seconds.");
            Console.WriteLine("Session saved. Press any key to go back to menu.");
            
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("There's no active session.");
            Console.WriteLine("Press any key to go back to menu.");

            Console.ReadKey();
        }
    }

    public void ViewSessions(DatabaseManager databaseManager)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        
        table.AddColumn("[lime]Session Id[/]");
        table.AddColumn("[lime]Start Date Time[/]");
        table.AddColumn("[lime]End Date Time[/]");
        table.AddColumn("[lime]Duration (s)[/]");

        var sessions = databaseManager.ReadTable();
        int idx = 1;
        
        foreach (var session in sessions)
        {
            table.AddRow(
                $"[turquoise2]{idx.ToString()}[/]",
                $"[dodgerblue1]{session.StartDateTime}[/]",
                $"[dodgerblue1]{session.EndDateTime}[/]",
                $"[dodgerblue1]{session.Duration}[/]"
            );
            
            idx++;
        }

        table.Columns[0].Centered();
        table.Columns[1].Centered();
        table.Columns[2].Centered();
        table.Columns[3].Centered();
        
        AnsiConsole.Write(table);
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void QuitApplication(bool isSessionStarted, bool isSessionEnded, DatabaseManager databaseManager)
    {
        if (!isSessionEnded && isSessionStarted)
        {
            _endTime = SessionsService.GetCurrentTime();
            _duration = SessionsService.GetDuration(_startTime, _endTime);
            
            databaseManager.WriteTable(_startTime, _endTime, _duration);
            Console.WriteLine($"Ending session at {_endTime} - Your session lasted {_duration} seconds.");
            Console.WriteLine("Session saved. Thank you for using Coding Tracker\nGoodbye!");
            
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Thank you for using Coding Tracker\nGoodbye!");
            Environment.Exit(0);
        }
    }
}