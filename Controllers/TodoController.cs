using Dapper;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Infrastructure.Database;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;
    private readonly DatabaseService _databaseService;

    public TodoController(ILogger<TodoController> logger, DatabaseService databaseService)
    {
        _logger = logger;
        _databaseService = databaseService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoModel>>> GetList()
    {
        using (var connection = _databaseService.CreateConnection())
        {
            var sql = "select * from \"Todo\"";
            var todos = await connection.QueryAsync<TodoModel>(sql);
            return Ok(todos);
        }
    }
}
