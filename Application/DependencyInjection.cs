using Application.Common.AppProfile;
using Application.Common.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICurrentLoggedProfile, CurrentLoggedProfile>();

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<Application>();
        services.RegisterMapsterConfiguration();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application).Assembly));

        return services;
    }
}
