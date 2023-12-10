using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

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