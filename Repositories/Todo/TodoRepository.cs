
using System.Data;
using Dapper;
using TodoApi.Infrastructure.Database;

namespace TodoApi.Repositories.Todo;

public class TodoRepository : ITodoRepository
{
    private readonly IDbConnection _dbConnection;

    public TodoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<TodoEntity>> GetTodoListAsync()
    {
        var sql = "select * from \"Todo\"";
        var todos = await _dbConnection.QueryAsync<TodoEntity>(sql);
        return todos;
    }
}