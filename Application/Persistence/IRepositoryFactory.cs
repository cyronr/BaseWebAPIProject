using Application.Persistence.Repositories;
using Domain.Models.BaseModels;

namespace Application.Persistence;

public interface IRepositoryFactory
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
}
