namespace TodoApi.Models;

public class UpdateRequestDto
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool Completed { get; set; }
}