using Domain.Models.ProfileModels;

namespace Application.Common.AppProfile
{
    public interface ICurrentLoggedProfile
    {
        Profile? GetCurrentLoggedProfile();
    }
}
