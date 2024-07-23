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

    [HttpPost]
    public async Task<ActionResult<TodoModel>> Create([FromBody] TodoModel todo)
    {
        var newTodo = await _todoService.CreateTodoAsync(todo);
        if (newTodo == null)
        {
            return BadRequest();
        }

        return newTodo;
    }

    [HttpPatch]
    public async Task<ActionResult<TodoModel>> Update([FromBody] TodoModel todo)
    {
        var updatedTodo = await _todoService.UpdateTodoAsync(todo);
        if (updatedTodo == null)
        {
            return BadRequest();
        }

        return updatedTodo;
    }
}
