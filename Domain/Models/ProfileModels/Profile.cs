using Domain.Models.BaseModels;

namespace Domain.Models.ProfileModels;

public class Profile : BaseModel<ProfileStatus, ProfileEvent>
{
    public ProfileType Type { get; set; }
    public string Email { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}