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

    public async Task<TodoModel?> GetTodoAsync(int id)
    {
        var todo = await _todoRepository.GetTodoAsync(id);
        return todo != null ? new TodoModel
        {
            Id = todo.Id,
            Title = todo.Title,
            Completed = todo.Completed
        } : null;
    }

    public async Task<TodoModel?> CreateTodoAsync(TodoModel todo)
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(todo.Title))
        {
            errors.Add("Title is required");
        }

        if (todo.Completed)
        {
            errors.Add("Invalid completed");
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        var newTodo = await _todoRepository.CreateTodoAsync(todo);
        return newTodo != null ? new TodoModel
        {
            Id = newTodo.Id,
            Title = newTodo.Title,
            Completed = newTodo.Completed
        } : null;
    }

    public async Task<TodoModel?> UpdateTodoAsync(TodoModel todo)
    {
        var errors = new List<string>();

        if (todo.Id == 0)
        {
            errors.Add("Id is required");
        }

        if (string.IsNullOrEmpty(todo.Title))
        {
            errors.Add("Title is required");
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        var updatedTodo = await _todoRepository.UpdateTodoAsync(todo);
        return updatedTodo != null ? new TodoModel
        {
            Id = updatedTodo.Id,
            Title = updatedTodo.Title,
            Completed = updatedTodo.Completed
        } : null;
    }
}

