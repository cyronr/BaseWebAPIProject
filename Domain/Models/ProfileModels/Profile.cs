using Domain.Models.BaseModels;
using Domain.ModelsUpdateParams;
using Mapster;
using System.Net.Mail;

namespace Domain.Models.ProfileModels;

public class Profile : Entity<Profile, ProfileStatus, ProfileEvent>
{
    public ProfileType Type { get; private set; }
    public string Email { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;
    public byte[] PasswordHash { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }

    private Profile() : base() { }

    #region public methods
    public static Profile Create(string email, ProfileType type)
    {
        Profile profile = new Profile();

        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            throw new Exceptions.InvalidDataException("Email is not valid.");

        profile.Email = email;
        profile.Type = type;
        profile.UpdateStatus(ProfileStatus.Prepared);
        profile.AddEvent(ProfileEventType.Created, profile.ToString());

        return profile;
    }

    public void Update(ProfileUpdateParams updateParams)
    {
        TypeAdapter.Adapt(updateParams, this, ProfileUpdateParams.MappingConfig);
    }

    public void AddEvent(ProfileEventType eventType, string? addInfo = default) => AddEvent(ProfileEvent.Create(eventType, addInfo));
    #endregion

    #region private methods
    private static bool IsValidEmail(string email)
    {
        try
        {
            new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion
}