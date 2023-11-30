using Domain.Models.BaseModels;
using System.Data;

namespace Domain.Models.ProfileModels;

public class Profile : Entity<Profile, ProfileStatus, ProfileEvent>
{
    public ProfileType Type { get; private set; }
    public string Email { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;
    public byte[] PasswordHash { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }

    private Profile() : base() 
    {
    }

    public static Profile Create()
    {
        Profile profile = new Profile();

        profile.UpdateStatus(ProfileStatus.Prepared);
        profile.Events.Add(ProfileEvent.Create(ProfileEventType.Created));

        return profile;
    }
}