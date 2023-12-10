using Domain.Models.ProfileModels;

namespace Application.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(Profile profile);
    }
}
