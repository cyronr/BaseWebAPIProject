using Application.Persistence.Repositories;
using Domain.Models.BaseModels;

namespace Application.Persistence;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Commits trasaction and saves changes to database
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();

    /// <summary>
    /// Returns generic repository for entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    //IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;

    /// <summary>
    /// Returns specific repository for Entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    /// <returns></returns>
    TRepository GetRepository<TEntity, TRepository>() where TEntity : Entity where TRepository : IRepository<TEntity>;
}
