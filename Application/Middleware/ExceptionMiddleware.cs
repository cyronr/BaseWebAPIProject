using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Services.Middleware;

public partial class ExceptionMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (BaseException baseEx)
        {
            _logger.LogError($"{baseEx.Title}: {baseEx.Message}");
            _logger.LogDebug($"{baseEx.Title}: {baseEx.Message} ({baseEx.DebugMessage})");

            ErrorDetails errorDetails = new ErrorDetails()
            {
                Type = baseEx.GetType().Name.ToString(),
                Title = baseEx.Title,
                Status = (int)baseEx.StatusCode
            };
            errorDetails.Errors.Add(baseEx.Message);

            await HandleExceptionAsync(httpContext, errorDetails);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Internal Server Error: {ex}");

            ErrorDetails errorDetails = new ErrorDetails()
            {
                Type = "Exception",
                Title = "Internal Server Error.",
                Status = (int)HttpStatusCode.InternalServerError
            };
            errorDetails.Errors.Add("Unknown error occured.");

            await HandleExceptionAsync(httpContext, errorDetails);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, ErrorDetails errorDetails)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorDetails.Status;

        await context.Response.WriteAsync(errorDetails.ToString());
    }
}