using Domain.Models.BaseModels;
using System.Linq.Expressions;

namespace Application.Persistence.Repositories;

public interface IRepository { }

public interface IRepository<TEntity> : IRepository where TEntity : Entity
{
    Task<TEntity?> GetByUUIDAsync(Guid uuid, Expression<Func<TEntity, bool>>? filter = null);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);

    Task CreateAsync(TEntity entity);
}
