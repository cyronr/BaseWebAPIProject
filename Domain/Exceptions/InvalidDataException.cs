using System.Net;

namespace Domain.Exceptions;

/// <summary>
/// Application InvalidDataException. Sets HttpStatusCode to BadRequest (400)
/// </summary>
public class InvalidDataException : BaseException
{
    public InvalidDataException() => SetProperties();
    public InvalidDataException(string message) : base(message) => SetProperties();
    public InvalidDataException(string message, Exception inner) : base(message, inner) => SetProperties();
    public InvalidDataException(string message, string debugMessage) : base(message, debugMessage) => SetProperties();

    private void SetProperties()
    {
        Title = "Invalid data.";
        StatusCode = HttpStatusCode.BadRequest;
    }
}