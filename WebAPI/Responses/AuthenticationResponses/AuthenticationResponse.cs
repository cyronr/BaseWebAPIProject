using WebAPI.Responses.AuthenticationResponses;

namespace API.Requests.AuthenticationResponses;

public record AuthenticationResponse
{
    public AuthenticationResponseProfile Profile { get; set; }
    public string Token { get; set; }
}
