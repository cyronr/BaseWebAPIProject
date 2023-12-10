using Application.Common.Http;
using Application.Common.MessageSenders;
using Application.Persistence;
using Application.Persistence.Repositories;
using Application.Services;
using Domain.Models.ProfileModels;
using Infrastructure.Common.Classes;
using Infrastructure.Common.Http;
using Infrastructure.Common.MessageSenders;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAppSettings(configuration);

        services.ConfigureServices();
        services.ConfigurePersistance();
        services.ConfigureCommonDependencyInjection();

        services.AddDbContext<AppDbContext>();

        return services;
    }

    private static IServiceCollection AddAppSettings(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
        services.Configure<SmtpConfig>(configuration.GetSection(nameof(SmtpConfig)));

        return services;
    }

    private static IServiceCollection ConfigurePersistance(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();

        services.AddScoped<IRepository<Profile>, ProfileRepository>();

        return services;
    }

    private static IServiceCollection ConfigureCommonDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<IHttpRequester, HttpRequester>();
        services.AddSingleton<IEmailSender, EmailSender>();

        return services;
    }

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        services.AddSingleton<IPasswordService, PasswordService>();

        return services;
    }
}
