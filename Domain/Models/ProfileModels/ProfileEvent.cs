using Domain.Models.BaseModels;

namespace Domain.Models.ProfileModels;

public class ProfileEvent : EventEntity<ProfileEventType>
{
    private ProfileEvent() : base() { } //For EF Core
    private ProfileEvent(ProfileEventType eventType, string? addInfo = default) : base(eventType, addInfo) { }

    /// <summary>
    /// Creates Profile event of given event type and with optional additional informations
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="addInfo"></param>
    /// <returns></returns>
    public static ProfileEvent Create(ProfileEventType eventType, string? addInfo = default)
    {
        return new ProfileEvent(eventType, addInfo);
    }
}