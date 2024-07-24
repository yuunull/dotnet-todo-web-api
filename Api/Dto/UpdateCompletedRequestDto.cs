namespace TodoApi.Models;

public class UpdateCompletedRequestDto
{
    public int Id { get; set; }
    public bool Completed { get; set; }
}