using Domain.Models.BaseModels;
using Domain.ModelsUpdateParams;
using Mapster;
using System.Net.Mail;

namespace Domain.Models.ProfileModels;

public class Profile : Entity<Profile, ProfileStatus, ProfileEvent>
{
    /// <summary> Profile type (eg. Admin) </summary>
    public ProfileType Type { get; private set; }
    public string Email { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;
    public byte[] PasswordHash { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }
    /// <summary> Unsuccesfull login attempts count since last succesful login </summary>
    public int UnsuccessfulLoginAttemptsCount { get; private set; }

    private Profile() : base() { }

    #region public methods
    /// <summary>
    /// Creates Profile of given type with given email
    /// </summary>
    /// <param name="email"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="Exceptions.InvalidDataException"></exception>
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

    /// <summary>
    /// Updates Profile properties
    /// </summary>
    /// <param name="updateParams"></param>
    public void Update(ProfileUpdateParams updateParams)
    {
        TypeAdapter.Adapt(updateParams, this, ProfileUpdateParams.MappingConfig);
    }

    /// <summary>
    /// Increments Unsuccesfull login attempts count
    /// </summary>
    public void IncrementUnsuccessfulLoginAttemptsCount()
    {
        UnsuccessfulLoginAttemptsCount++;
    }

    /// <summary>
    /// Resets Unsuccesfull login attempts count
    /// </summary>
    public void ResetUnsuccessfulLoginAttemptsCount()
    {
        UnsuccessfulLoginAttemptsCount = 0;
    }

    /// <summary>
    /// Adds event to Profile events
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="addInfo"></param>
    public void AddEvent(ProfileEventType eventType, string? addInfo = default) => AddEvent(ProfileEvent.Create(this, eventType, addInfo));
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