namespace TodoApi.Infrastructure.Database;

public class TodoEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool Completed { get; set; }
}