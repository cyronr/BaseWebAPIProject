namespace Domain.Models.ProfileModels;

/// <summary>
/// Model used only to represent Profile status in database
/// </summary>
public class ProfileStatusModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum ProfileStatus
{
    Prepared = 1,
    Active = 2,
    Locked = 3,
    Deleted = 4
}
