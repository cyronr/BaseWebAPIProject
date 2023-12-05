using Application.Persistence;
using Application.Persistence.Repositories;
using Domain.Models.BaseModels;
using Infrastructure.Data;

namespace Infrastructure.Persistence;

internal partial class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    private readonly IRepositoryFactory _repositoryFactory;

    private readonly Dictionary<Type, IRepository> _repositories = new Dictionary<Type, IRepository>();

    public UnitOfWork(AppDbContext appDbContext, IRepositoryFactory repositoryFactory)
    {
        _appDbContext = appDbContext;
        _repositoryFactory = repositoryFactory;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
    {
        Type type = typeof(TEntity);
        if (_repositories.TryGetValue(type, out IRepository? repository))
            return repository as IRepository<TEntity> ?? throw new Exception($"Could not cast repository to IRepository<{type}>");

        repository = _repositoryFactory.GetRepository<TEntity>();
        _repositories.Add(type, repository);
        return repository as IRepository<TEntity> ?? throw new Exception($"Could not cast repository to IRepository<{type}>");
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}
