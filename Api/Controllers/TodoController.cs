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
    public async Task<ActionResult<IEnumerable<GetListResponseDto>>> GetList()
    {
        var todoList = await _todoService.GetTodoListAsync();
        return Ok(todoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetResponseDto>> Get(int id)
    {
        var todo = await _todoService.GetTodoAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        return todo;
    }

    [HttpPost]
    public async Task<ActionResult<CreateResponseDto>> Create([FromBody] CreateRequestDto request)
    {
        var newTodo = await _todoService.CreateTodoAsync(request);
        if (newTodo == null)
        {
            return BadRequest();
        }

        return newTodo;
    }

    [HttpPut]
    public async Task<ActionResult<UpdateResponseDto>> Update([FromBody] UpdateRequestDto request)
    {
        var updatedTodo = await _todoService.UpdateTodoAsync(request);
        if (updatedTodo == null)
        {
            return BadRequest();
        }

        return updatedTodo;
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateCompleted([FromBody] UpdateCompletedRequestDto request)
    {
        await _todoService.UpdateCompletedAsync(request);
        return Ok();
    }
}
