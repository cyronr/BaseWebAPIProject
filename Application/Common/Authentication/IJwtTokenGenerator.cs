using Domain.Models.ProfileModels;

namespace Application.Common.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Profile profile);
    }
}
