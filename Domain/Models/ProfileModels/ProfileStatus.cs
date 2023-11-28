namespace Domain.Models.ProfileModels;

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
