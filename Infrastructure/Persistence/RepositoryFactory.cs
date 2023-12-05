using Application.Persistence;
using Application.Persistence.Repositories;
using Domain.Models.BaseModels;

namespace Infrastructure.Persistence;

internal class RepositoryFactory : IRepositoryFactory
{
    private readonly IServiceProvider _serviceProvider;
    public RepositoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity => 
        (IRepository<TEntity>)_serviceProvider.GetService(typeof(IRepository<TEntity>)) ?? throw new Exception($"Could not get repository for {typeof(TEntity)}");
}
