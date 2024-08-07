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

    public async Task<IEnumerable<GetListResponseDto>> GetTodoListAsync()
    {
        var todoList = await _todoRepository.GetTodoListAsync();
        return todoList.Select(todo => new GetListResponseDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Completed = todo.Completed
        });
    }

    public async Task<GetResponseDto?> GetTodoAsync(int id)
    {
        var todo = await _todoRepository.GetTodoAsync(id);
        return todo != null ? new GetResponseDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Completed = todo.Completed
        } : null;
    }

    public async Task<CreateResponseDto?> CreateTodoAsync(CreateRequestDto request)
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(request.Title))
        {
            errors.Add("Title is required");
        }

        if (request.Completed)
        {
            errors.Add("Invalid completed");
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        var newTodo = await _todoRepository.CreateTodoAsync(request);
        return newTodo != null ? new CreateResponseDto
        {
            Id = newTodo.Id,
            Title = newTodo.Title,
            Completed = newTodo.Completed
        } : null;
    }

    public async Task<UpdateResponseDto?> UpdateTodoAsync(UpdateRequestDto request)
    {
        var errors = new List<string>();

        if (request.Id == 0)
        {
            errors.Add("Id is required");
        }

        if (string.IsNullOrEmpty(request.Title))
        {
            errors.Add("Title is required");
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        var updatedTodo = await _todoRepository.UpdateTodoAsync(request);
        return updatedTodo != null ? new UpdateResponseDto
        {
            Id = updatedTodo.Id,
            Title = updatedTodo.Title,
            Completed = updatedTodo.Completed
        } : null;
    }

    public async Task UpdateCompletedAsync(UpdateCompletedRequestDto request)
    {
        var errors = new List<string>();

        if (request.Id == 0)
        {
            errors.Add("Id is required");
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        await _todoRepository.UpdateCompletedAsync(request);
    }
}

