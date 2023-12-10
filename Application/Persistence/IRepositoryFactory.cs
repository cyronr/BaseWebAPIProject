using Application.Persistence.Repositories;
using Domain.Models.BaseModels;

namespace Application.Persistence;

public interface IRepositoryFactory
{
    /// <summary>
    /// Returns implementation of IRepository for specified entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
}
