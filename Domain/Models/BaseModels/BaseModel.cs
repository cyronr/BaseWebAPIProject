using Newtonsoft.Json;

namespace Domain.Models.BaseModels;

/// <summary>
/// Bazowy model, z którego powinny dziedziczyć wszystkie inne modele.
/// T - Status
/// U - Events 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="U"></typeparam>
public abstract class BaseModel<T, U>
{
    public int Id { get; set; }
    public Guid UUID { get; set; }
    public T Status { get; set; }
    public List<U> Events {  get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
