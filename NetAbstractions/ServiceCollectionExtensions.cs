namespace ToolBX.NetAbstractions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNetAbstractions(this IServiceCollection services)
    {
        return services.AddAutoInjectServices(Assembly.GetExecutingAssembly());
    }
}