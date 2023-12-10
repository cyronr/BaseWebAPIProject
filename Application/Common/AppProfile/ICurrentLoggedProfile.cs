using Domain.Models.ProfileModels;

namespace Application.Common.AppProfile;

public interface ICurrentLoggedProfile
{
    Guid UUID { get; }
    string Email { get; }
    ProfileType Type { get; }
}
