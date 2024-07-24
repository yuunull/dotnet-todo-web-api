namespace TodoApi.Models;

public class UpdateResponseDto
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool Completed { get; set; }
}