using System.Net;

namespace Domain.Exceptions;

/// <summary>
/// Application DictionaryValueNotExistsException. Sets HttpStatusCode to BadRequest (400)
/// </summary>
public class DictionaryValueNotExistsException : BaseException
{
    public DictionaryValueNotExistsException() => SetProperties();
    public DictionaryValueNotExistsException(string message) : base(message) => SetProperties();
    public DictionaryValueNotExistsException(string message, Exception inner) : base(message, inner) => SetProperties();
    public DictionaryValueNotExistsException(string message, string debugMessage) : base(message, debugMessage) => SetProperties();

    private void SetProperties()
    {
        Title = "Wrong dictionary value.";
        StatusCode = HttpStatusCode.BadRequest;
    }
}