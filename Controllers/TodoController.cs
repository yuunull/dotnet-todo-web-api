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
    public async Task<ActionResult<IEnumerable<TodoModel>>> GetList()
    {
        var todoList = await _todoService.GetTodoListAsync();
        return Ok(todoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoModel>> Get(int id)
    {
        var todo = await _todoService.GetTodoAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        return todo;
    }
}
