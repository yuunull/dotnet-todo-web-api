using TodoApi.Models;

namespace TodoApi.Services.Todo;

public interface ITodoService
{
    Task<IEnumerable<TodoModel>> GetTodoList();
    // Task<TodoModel> GetTodoItemAsync(int id);
    // Task<TodoModel> CreateTodoItemAsync(TodoItem todoItem);
    // Task<TodoModel> UpdateTodoItemAsync(int id, TodoItem todoItem);
    // Task DeleteTodoItemAsync(int id);
}