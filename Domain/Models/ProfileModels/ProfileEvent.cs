using Domain.Models.BaseModels;

namespace Domain.Models.ProfileModels;

public class ProfileEvent : EventEntity<ProfileEventType>
{
    private ProfileEvent() { } //For EF Core
    private ProfileEvent(ProfileEventType eventType) 
    {
        Type = eventType;
    }

    public static ProfileEvent Create(ProfileEventType eventType)
    {
        return new ProfileEvent(eventType);
    }
}