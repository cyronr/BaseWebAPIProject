using Application.Middleware;

namespace WebAPI.ApplicationConfiguration;

internal static class ApplicationExtensions
{
    public static WebApplication Configure(this WebApplication application)
    {
        application.AddSwagger();
        application.AddMiddleware();

        application.UseHttpsRedirection();
        application.UseAuthentication();
        application.UseAuthorization();
        application.MapControllers();
        application.UseCors("AllowAll");

        return application;
    }


    private static WebApplication AddSwagger(this WebApplication application)
    {
        application.UseSwagger();
        application.UseSwaggerUI(c =>
        {
            string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
            c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Sample API");
        });

        return application;
    }

    private static WebApplication AddMiddleware(this WebApplication application)
    {
        application.UseMiddleware<ExceptionMiddleware>();

        return application;
    }
}
