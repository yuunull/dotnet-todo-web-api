using TodoApi.Models;

namespace TodoApi.Services.Todo;

public interface ITodoService
{
    Task<IEnumerable<GetListResponseDto>> GetTodoListAsync();
    Task<GetResponseDto?> GetTodoAsync(int id);
    Task<CreateResponseDto?> CreateTodoAsync(CreateRequestDto request);
    Task<UpdateResponseDto?> UpdateTodoAsync(UpdateRequestDto request);
    // Task DeleteTodoItemAsync(int id);
}