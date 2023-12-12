namespace Domain.Models.BaseModels;


/// <summary>
/// Base EntityEvent model. Every Entity Event should inherit from it.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class EventEntity<TType>
{
    /// <summary> Internal Id </summary>
    public int Id { get; private set; }

    /// <summary> Event type (eg. created, deleted) </summary>
    public TType Type { get; private set; }

    /// <summary> Additional information about event </summary>
    public string? AddInfo { get; private set; }

    /// <summary> Date and time of event </summary>
    public DateTime Timestamp { get; private set; }

    protected EventEntity() { }

    protected EventEntity(TType? eventType, string? addInfo = default)
    {
        Type = eventType;
        AddInfo = addInfo;
        Timestamp = DateTime.UtcNow;
    }
}
