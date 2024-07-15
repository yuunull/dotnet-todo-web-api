namespace TodoApi.Infrastructure.Database;

using Npgsql;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService()
    {
        _connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
    }

    public NpgsqlConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
