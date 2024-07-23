using TodoApi.Models;

namespace TodoApi.Services.Todo;

public interface ITodoService
{
    Task<IEnumerable<TodoModel>> GetTodoListAsync();
    Task<TodoModel?> GetTodoAsync(int id);
    Task<TodoModel?> CreateTodoAsync(TodoModel todo);
    // Task<TodoModel> UpdateTodoItemAsync(int id, TodoItem todoItem);
    // Task DeleteTodoItemAsync(int id);
}