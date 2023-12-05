using Domain.Models.BaseModels;

namespace Domain.Models.ProfileModels;

public class ProfileEvent : EventEntity<ProfileEventType>
{
    private ProfileEvent() : base() { } //For EF Core
    private ProfileEvent(ProfileEventType eventType, string? addInfo = default) : base(eventType, addInfo) { }

    public static ProfileEvent Create(ProfileEventType eventType, string? addInfo = default)
    {
        return new ProfileEvent(eventType, addInfo);
    }
}