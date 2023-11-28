using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Common.AppProfile;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Net.NetworkInformation;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICurrentLoggedProfile, CurrentLoggedProfile>();

            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<Application>();

            services.AddAutoMapper(typeof(Application).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application).Assembly));

            return services;
        }
    }
}
