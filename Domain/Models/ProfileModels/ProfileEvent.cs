using Domain.Models.BaseModels;

namespace Domain.Models.ProfileModels;

public class ProfileEvent : BaseEvent<ProfileEventType>
{
    public Profile Profile { get; set; }
}