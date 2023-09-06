﻿using Application.Common.Authentication;
using Application.Common.Http;
using Application.Common.MessageSenders;
using Application.DataAccess.Common;
using Application.DataAccess.Repositories;
using Infrastructure.Common;
using Infrastructure.Common.Authentication;
using Infrastructure.Common.Http;
using Infrastructure.Common.MessageSenders;
using Infrastructure.Data;
using Infrastructure.DataAccess.Common;
using Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAppSettings(configuration);

            services.ConfigureRepositoriesDependencyInjection();
            services.ConfigureCommonDependencyInjection();

            services.AddDbContext<DataContext>();

            return services;
        }

        private static IServiceCollection AddAppSettings(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.Configure<ConnectionStrings>(configuration.GetSection(ConnectionStrings.SectionName));
            services.Configure<SmtpConfig>(configuration.GetSection(SmtpConfig.SectionName));

            return services;
        }

        private static IServiceCollection ConfigureRepositoriesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDbOperation, DbOperation>();
            services.AddScoped<IInternalDbTransaction, InternalDbTransaction>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            return services;
        }

        private static IServiceCollection ConfigureCommonDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IHttpRequester, HttpRequester>();
            services.AddSingleton<IEmailSender, EmailSender>();

            return services;
        }
    }
}
