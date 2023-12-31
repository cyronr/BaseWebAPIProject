using System.Net;

namespace Domain.Exceptions;

/// <summary>
/// Application AlreadyExistsException. Sets HttpStatusCode to Conflict (409)
/// </summary>
public class AlreadyExistsException : BaseException
{
    public AlreadyExistsException() => SetProperties();
    public AlreadyExistsException(string message) : base(message) => SetProperties();
    public AlreadyExistsException(string message, Exception inner) : base(message, inner) => SetProperties();
    public AlreadyExistsException(string message, string debugMessage) : base(message, debugMessage) => SetProperties();

    private void SetProperties()
    {
        Title = "Record already exists.";
        StatusCode = HttpStatusCode.Conflict;
    }
}