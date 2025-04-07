using CodingTracker.KamilKolanowski.Data;

namespace CodingTracker.KamilKolanowski.Controllers;

internal interface IBaseController
{
    void StartSession(bool isSessionStarted);
    void EndSession(bool isSessionStarted, bool isSessionEnded, DatabaseManager databaseManager);
    void ViewSessions(DatabaseManager databaseManager);
    void QuitApplication(bool isSessionStarted, bool isSessionEnded, DatabaseManager databaseManager);
}