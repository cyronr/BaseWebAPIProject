using Domain.Models.ProfileModels;

namespace WebAPI.Responses.AuthenticationResponses
{
    public record AuthenticationResponseProfile
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AuthenticationResponseProfileType ProfileType { get; set; }
    }

    public record AuthenticationResponseProfileType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
