using System.Net;

namespace Domain.Exceptions;

/// <summary>
/// Application AuthenticationException. Sets HttpStatusCode to Unauthorized (401)
/// </summary>
public class AuthenticationException : BaseException
{
    public AuthenticationException() => SetProperties();
    public AuthenticationException(string message) : base(message) => SetProperties();
    public AuthenticationException(string message, Exception inner) : base(message, inner) => SetProperties();
    public AuthenticationException(string message, string debugMessage) : base(message, debugMessage) => SetProperties();

    private void SetProperties()
    {
        Title = "Authentication error.";
        StatusCode = HttpStatusCode.Unauthorized;
    }
}