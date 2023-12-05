namespace Domain.Models.BaseModels;


/// <summary>
/// Klasa bazowa dla Eventu modelu
/// T - EventType
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class EventEntity<TType>
{
    public int Id { get; private set; }
    public TType Type { get; private set; }
    public string? AddInfo { get; private set; } 
    public DateTime Timestamp { get; private set; }

    protected EventEntity() { }

    protected EventEntity(TType? eventType, string? addInfo = default)
    {
        Type = eventType;
        AddInfo = addInfo;
        Timestamp = DateTime.UtcNow;
    }
}
