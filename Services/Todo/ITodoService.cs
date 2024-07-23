using TodoApi.Models;

namespace TodoApi.Services.Todo;

public interface ITodoService
{
    Task<IEnumerable<TodoModel>> GetTodoListAsync();
    Task<TodoModel?> GetTodoAsync(int id);
    Task<TodoModel?> CreateTodoAsync(TodoModel todo);
    Task<TodoModel?> UpdateTodoAsync(TodoModel todo);
    // Task DeleteTodoItemAsync(int id);
}