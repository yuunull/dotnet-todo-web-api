using TodoApi.Models;
using TodoApi.Repositories.Todo;

namespace TodoApi.Services.Todo;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<TodoModel>> GetTodoListAsync()
    {
        var todoList = await _todoRepository.GetTodoListAsync();
        return todoList.Select(todo => new TodoModel
        {
            Id = todo.Id,
            Title = todo.Title,
            Completed = todo.Completed
        });
    }
}
