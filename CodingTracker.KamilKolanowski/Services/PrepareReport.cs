using System.Globalization;
using CodingTracker.KamilKolanowski.Data;
using CodingTracker.KamilKolanowski.Enums;

namespace CodingTracker.KamilKolanowski.Services;

internal class PrepareReport
{
    private readonly DatabaseManager _databaseManager = new();

    internal void PreparePeriodicReport(Options.ReportingOptions reportingOptions)
    {
        var rawTable  = _databaseManager.ReadTable();

        var groupedTable = rawTable
            .GroupBy()
    }
}