namespace Domain.Models.ProfileModels;

/// <summary>
/// Model used only to represent Profile type type in database
/// </summary>
public class ProfileTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum ProfileType
{
    Admin = 1
}