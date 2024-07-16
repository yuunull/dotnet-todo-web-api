using TodoApi.Infrastructure.Database;

namespace TodoApi.Repositories.Todo;

public interface ITodoRepository
{
    Task<IEnumerable<TodoEntity>> GetTodoList();
    // Task<TodoModel> GetTodoItemAsync(int id);
    // Task<TodoModel> CreateTodoItemAsync(TodoItem todoItem);
    // Task<TodoModel> UpdateTodoItemAsync(int id, TodoItem todoItem);
    // Task DeleteTodoItemAsync(int id);
}