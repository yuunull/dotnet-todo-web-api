using TodoApi.Services.Todo;

namespace TodoApi.Infrastructure.Configure;

public static class ServiceConfigure
{
    public static void Init(IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
    }
}
