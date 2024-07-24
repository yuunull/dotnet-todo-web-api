using TodoApi.Infrastructure.Database;
using TodoApi.Models;

namespace TodoApi.Repositories.Todo;

public interface ITodoRepository
{
    Task<IEnumerable<TodoEntity>> GetTodoListAsync();
    Task<TodoEntity?> GetTodoAsync(int id);
    Task<TodoEntity?> CreateTodoAsync(CreateRequestDto todo);
    Task<TodoEntity?> UpdateTodoAsync(UpdateRequestDto todo);
    // Task DeleteTodoItemAsync(int id);
}