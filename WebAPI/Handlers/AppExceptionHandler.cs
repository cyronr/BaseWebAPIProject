using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace WebAPI.Handlers;

internal partial class AppExceptionHandler(ILogger<AppExceptionHandler> _logger) : IExceptionHandler
{
    private readonly ILogger<AppExceptionHandler> _logger = _logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ErrorDetails errorDetails = new ErrorDetails();

        if (exception is BaseException)
        {
            BaseException baseEx = (BaseException)exception;

            _logger.LogError($"{baseEx.Title}: {baseEx.Message}");
            _logger.LogDebug($"{baseEx.Title}: {baseEx.Message} ({baseEx.DebugMessage})");

            errorDetails.Type = baseEx.GetType().Name.ToString();
            errorDetails.Title = baseEx.Title;
            errorDetails.Status = (int)baseEx.StatusCode;
            errorDetails.Errors.Add(baseEx.Message);
        }
        else
        {
            _logger.LogCritical($"Internal Server Error: {exception}");

            errorDetails.Type = "Exception";
            errorDetails.Title = "Internal Server Error.";
            errorDetails.Status = (int)HttpStatusCode.InternalServerError;
            errorDetails.Errors.Add("Unknown error occured.");
        }

        httpContext.Response.StatusCode = errorDetails.Status;
        await httpContext.Response.WriteAsJsonAsync(errorDetails);
        return true;
    }
}
