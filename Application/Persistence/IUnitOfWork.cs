﻿using Application.Persistence.Repositories;
using Domain.Models.BaseModels;

namespace Application.Persistence;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
}
