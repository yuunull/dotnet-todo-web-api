namespace TodoApi.Models;

public class UpdateCompletedResponseDto
{
    public int Id { get; set; }
    public bool Completed { get; set; }
}