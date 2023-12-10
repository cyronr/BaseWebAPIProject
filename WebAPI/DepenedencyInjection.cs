using WebAPI.Common;

namespace WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        services.RegisterMapsterConfiguration();

        return services;
    }
}