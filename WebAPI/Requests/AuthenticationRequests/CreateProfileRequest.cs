namespace WebAPI.Requests.AuthenticationRequests;

public abstract record CreateProfileRequest : BaseRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}
