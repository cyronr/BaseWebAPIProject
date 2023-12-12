namespace Domain.Models.ProfileModels;

/// <summary>
/// Model used only to represent Profile event type in database
/// </summary>
public class ProfileEventTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum ProfileEventType
{
    Created = 1,
    Updated = 2,
    Deleted = 3
}