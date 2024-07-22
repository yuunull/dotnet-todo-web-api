using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services.Todo;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IEnumerable<TodoModel>> GetList()
    {
        return await _todoService.GetTodoListAsync();
    }
}
