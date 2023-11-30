using Application.Persistence;
using Application.Persistence.Repositories;
using Domain.Models.BaseModels;
using Infrastructure.Data;

namespace Infrastructure.Persistence;

internal partial class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(IServiceProvider serviceProvider, AppDbContext appDbContext)
    {
        _serviceProvider = serviceProvider;
        _appDbContext = appDbContext;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
    {
        return (IRepository<TEntity>)_serviceProvider.GetService(typeof(IRepository<TEntity>)) ?? throw new Exception($"Could not get repository for {typeof(TEntity)}");
    }

    public async Task CommitAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public Task RollbackAsync()
    {
        //DO NOTHING
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}
