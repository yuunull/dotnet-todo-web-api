using System.Data;
using Npgsql;
using TodoApi.Repositories.Todo;

namespace TodoApi.Infrastructure.Configure;

public static class DatabaseConfigure
{
    public static void Init(IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
        
        services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(connectionString));

        services.AddScoped<ITodoRepository, TodoRepository>();
    }
}
