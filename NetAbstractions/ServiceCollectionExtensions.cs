namespace ToolBX.NetAbstractions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNetAbstractions(this IServiceCollection services, AutoInjectOptions? options = null)
    {
        return services.AddAutoInjectServices(Assembly.GetExecutingAssembly(), options);
    }
}