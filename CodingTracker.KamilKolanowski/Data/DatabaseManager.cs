using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;


namespace CodingTracker.KamilKolanowski.Data;

internal class DatabaseManager
{
    private readonly string _connectionString;
    internal DatabaseManager()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        
        _connectionString = config.GetConnectionString("DatabaseConnection");
    }
    internal class CodingSession
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal Duration { get; set; }
    }
    
    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
    
    internal List<CodingSession> ReadTable()
    {
        var connection = CreateConnection();
        connection.Open();
        
        string query = $"SELECT * FROM CodingTracker.TCSA.CodingSessions";
        var sessions = connection.Query<CodingSession>(query).ToList();

        return sessions;
    }

    internal void WriteTable(DateTime startDateTime, DateTime endDateTime, decimal duration)
    {
        var connection = CreateConnection();
        connection.Open();
        
        string query = @$"INSERT INTO CodingTracker.TCSA.CodingSessions (StartDateTime, EndDateTime, Duration) 
                       VALUES (@StartDateTime, @EndDateTime, @Duration)";
        
        connection.Execute(query, new { StartDateTime = startDateTime, EndDateTime = endDateTime, Duration = duration });
    }
}