namespace Domain.Models.BaseModels;


/// <summary>
/// Klasa bazowa dla Eventu modelu
/// T - EventType
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseEvent<T>
{
    public int Id { get; set; }
    public T Type { get; set; }
    public string AddInfo { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.Now;
}
