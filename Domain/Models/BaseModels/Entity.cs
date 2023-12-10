using Domain.Models.ProfileModels;
using Newtonsoft.Json;
using System.Data;

namespace Domain.Models.BaseModels;

/// <summary>
/// Bazowy model, z którego powinny dziedziczyć wszystkie inne modele.
/// T - Status
/// U - Events 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="U"></typeparam>
public abstract class Entity<T, TStatus, TEvent> : Entity
{
    public TStatus Status { get; private set; }
    public List<TEvent> Events {  get; private set; }

    protected Entity() : base()
    {
        Events = new List<TEvent>();
    }

    public void UpdateStatus(TStatus status)
    {
        Status = status;
    }

    public void AddEvent(TEvent entityEvent) => Events.Add(entityEvent);
}

public abstract class Entity
{
    public int Id { get; private set; }
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