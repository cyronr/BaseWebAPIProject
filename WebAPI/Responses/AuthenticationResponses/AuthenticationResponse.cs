using Application.Features.AuthenticationFeatures.Common;

namespace API.Requests.AuthenticationResponses
{
    public record AuthenticationResponse
    {
        public ProfileDto Profile { get; set; }
        public string Token { get; set; }
    }
}
