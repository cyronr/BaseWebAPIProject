namespace Domain.Models.ProfileModels;

public class ProfileTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum ProfileType
{
    Admin = 1
}