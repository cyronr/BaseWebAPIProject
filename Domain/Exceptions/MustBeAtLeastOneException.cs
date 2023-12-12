using System.Net;

namespace Domain.Exceptions;

/// <summary>
/// Application MustBeAtLeastOneException. Sets HttpStatusCode to BadRequest (400)
/// </summary>
public class MustBeAtLeastOneException : BaseException
{
    public MustBeAtLeastOneException() => SetProperties();
    public MustBeAtLeastOneException(string message) : base(message) => SetProperties();
    public MustBeAtLeastOneException(string message, Exception inner) : base(message, inner) => SetProperties();
    public MustBeAtLeastOneException(string message, string debugMessage) : base(message, debugMessage) => SetProperties();

    private void SetProperties()
    {
        Title = "Must be specified at least one.";
        StatusCode = HttpStatusCode.BadRequest;
    }
}