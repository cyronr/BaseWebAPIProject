using Domain.Models.BaseModels;

namespace Domain.Models.ProfileModels;

public class ProfileEvent : EventEntity<ProfileEventType>
{
    public Profile Profile { get; private set; }

    private ProfileEvent() : base() { } //For EF Core
    private ProfileEvent(ProfileEventType eventType, string? addInfo = default) : base(eventType, addInfo) { }

    /// <summary>
    /// Creates Profile event of given event type and with optional additional informations
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="addInfo"></param>
    /// <returns></returns>
    public static ProfileEvent Create(Profile profile, ProfileEventType eventType, string? addInfo = default)
    {
        ProfileEvent profileEvent = new ProfileEvent(eventType, addInfo);
        profileEvent.Profile = profile;

        return profileEvent;
    }
}