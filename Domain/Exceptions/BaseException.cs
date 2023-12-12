using System.Net;

namespace Domain.Exceptions;

/// <summary>
/// Base application Exception. Every custom application Exception should inherit from it.
/// </summary>
public abstract class BaseException : Exception
{
    public string Title { get; set; } = string.Empty;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    public string DebugMessage { get; set; } = string.Empty;

    public BaseException() { }
    public BaseException(string message) : base(message) { }
    public BaseException(string message, Exception inner) : base(message, inner) { }
    public BaseException(string message, string debugMessage) : base(message)
    {
        DebugMessage = debugMessage;
    }
}