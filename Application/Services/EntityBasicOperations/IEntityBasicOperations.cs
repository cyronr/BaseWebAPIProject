using Domain.Models.BaseModels;

namespace Application.Services.EntityBasicOperations;

internal interface IEntityBasicOperations<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Throws AlreadyExistsException if entity already exists in database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    ///Task CheckIfAlreadyExists(TEntity entity);
}
