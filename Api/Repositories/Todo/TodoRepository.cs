
using System.Data;

using Dapper;

using TodoApi.Infrastructure.Database;
using TodoApi.Models;

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

    public async Task<TodoEntity?> GetTodoAsync(int id)
    {
        var sql = "select * from \"Todo\" where \"id\" = @id";
        var todo = await _dbConnection.QueryFirstOrDefaultAsync<TodoEntity>(sql, new { id = id });
        return todo;
    }

    public async Task<TodoEntity?> CreateTodoAsync(CreateRequestDto todo)
    {
        var sql = "insert into \"Todo\" (\"title\", \"completed\") values (@title, @completed) returning *";
        var createdTodo = await _dbConnection.QueryFirstOrDefaultAsync<TodoEntity>(sql, new { title = todo.Title, completed = todo.Completed });
        return createdTodo;
    }

    public async Task<TodoEntity?> UpdateTodoAsync(UpdateRequestDto todo)
    {
        var sql = "update \"Todo\" set \"title\" = @title, \"completed\" = @completed where \"id\" = @id returning *";
        var updatedTodo = await _dbConnection.QueryFirstOrDefaultAsync<TodoEntity>(sql, new { id = todo.Id, title = todo.Title, completed = todo.Completed });
        return updatedTodo;
    }

    public async Task UpdateCompletedAsync(UpdateCompletedRequestDto todo)
    {
        var sql = "update \"Todo\" set \"completed\" = @completed where \"id\" = @id";
        await _dbConnection.ExecuteAsync(sql, new { id = todo.Id, completed = todo.Completed });
    }
}