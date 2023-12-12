using Newtonsoft.Json;

namespace Domain.Models.BaseModels;

/// <summary>
/// Base entity model. Every entity should inherit from it.
/// T - Status
/// U - Events 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="U"></typeparam>
public abstract class Entity<T, TStatus, TEvent> : Entity
{
    /// <summary> Entity state (eg. deleted, active) </summary>
    public TStatus Status { get; private set; }

    /// <summary> List of events related to entity (eg. created, deleted, modified) </summary>
    public List<TEvent> Events {  get; private set; }

    protected Entity() : base()
    {
        Events = new List<TEvent>();
    }


    /// <summary>
    /// Updates entity status
    /// </summary>
    /// <param name="status"></param>
    public void UpdateStatus(TStatus status)
    {
        Status = status;
    }

    /// <summary>
    /// Adds event to list of entity events
    /// </summary>
    /// <param name="entityEvent"></param>
    public void AddEvent(TEvent entityEvent) => Events.Add(entityEvent);
}

/// <summary>
/// Base entity model.
/// </summary>
public abstract class Entity
{
    /// <summary> Internal entity Id </summary>
    public int Id { get; private set; }

    /// <summary> Entity UUID <br/> Used for external purposes </summary>
    public Guid UUID { get; private set; }

    public Entity()
    {
        UUID = Guid.NewGuid();
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}