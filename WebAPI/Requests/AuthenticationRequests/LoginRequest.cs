using WebAPI.Requests;

namespace API.Requests.AuthenticationRequests;

public record LoginRequest : BaseRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
