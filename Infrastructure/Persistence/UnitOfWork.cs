using Application.Persistence;
using Application.Persistence.Repositories;
using Domain.Models.BaseModels;

namespace Infrastructure.Persistence;

internal partial class UnitOfWork(AppDbContext _appDbContext, 
    IRepositoryFactory _repositoryFactory) : IUnitOfWork
{
    #region DI
    private readonly AppDbContext _appDbContext = _appDbContext;
    private readonly IRepositoryFactory _repositoryFactory = _repositoryFactory;
    #endregion
    private Dictionary<Type, IRepository> _repositories = new Dictionary<Type, IRepository>();

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
    {
        Type type = typeof(TEntity);
        if (_repositories.TryGetValue(type, out IRepository? repository))
            return (IRepository<TEntity>)repository ?? throw new Exception($"Could not cast repository to IRepository<{type}>");

        repository = _repositoryFactory.GetRepository<TEntity>();
        _repositories.Add(type, repository);

        return (IRepository<TEntity>)repository;
    }

    public TRepository GetRepository<TEntity, TRepository>() where TEntity : Entity where TRepository : IRepository<TEntity>
    {
        return (TRepository)GetRepository<TEntity>() ?? throw new Exception($"Could not cast repository to {typeof(TRepository)}");
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
