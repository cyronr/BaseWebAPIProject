using Application;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using Swashbuckle.AspNetCore.Filters;
using WebAPI.ApplicationConfiguration;

namespace WebAPI.ApplicationConfiguration;

internal static class BuilderExtensions
{

    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        builder.AddLogger();
        builder.AddSwagger();
        builder.AddAuthentication();
        builder.AddCors();
        builder.AddDependencyProjects();

        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();

        return builder;
    }


    private static WebApplicationBuilder AddDependencyProjects(this WebApplicationBuilder builder)
    {
        builder.Services.AddDomain();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddAPI();

        return builder;
    }

    private static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
    {
        Logger logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        return builder;
    }

    private static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.OperationFilter<SecurityRequirementsOperationFilter>();
            c.EnableAnnotations();
        });

        return builder;
    }

    private static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                        .GetBytes(builder.Configuration.GetSection("JwtSettings:Key").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .WithExposedHeaders("X-Pagination")
                           .AllowAnyMethod();
                });
        });

        return builder;
    }
}
