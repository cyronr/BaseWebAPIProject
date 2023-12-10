using Domain.Models.BaseModels;
using System.Linq.Expressions;

namespace Application.Persistence.Repositories;

public interface IRepository { }

public interface IRepository<TEntity> : IRepository where TEntity : Entity
{
    /// <summary> Returns Entity by given UUID and additional conditions </summary>
    /// <remarks> Accepts additional conditions </remarks>
    /// <param name="uuid"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<TEntity?> GetByUUIDAsync(Guid uuid, Expression<Func<TEntity, bool>>? filter = null);

    /// <summary> Returns all Entities of given type. </summary>
    /// <remarks> Accepts additional conditions </remarks>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);

    /// <summary>
    /// Creates Entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task CreateAsync(TEntity entity);
}
