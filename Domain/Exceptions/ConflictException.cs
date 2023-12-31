using System.Net;

namespace Domain.Exceptions;

/// <summary>
/// Application ConflictException. Sets HttpStatusCode to Conflict (409)
/// </summary>
public class ConflictException : BaseException
{
    public ConflictException() => SetProperties();
    public ConflictException(string message) : base(message) => SetProperties();
    public ConflictException(string message, Exception inner) : base(message, inner) => SetProperties();
    public ConflictException(string message, string debugMessage) : base(message, debugMessage) => SetProperties();

    private void SetProperties()
    {
        Title = "Could not commit data.";
        StatusCode = HttpStatusCode.Conflict;
    }
}