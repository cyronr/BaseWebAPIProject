using Domain.Models.BaseModels;
using Mapster;

namespace Domain.ModelsUpdateParams;

/// <summary>
/// Base class for UpdateParams used to update entity properties
/// </summary>
/// <typeparam name="TParams"></typeparam>
/// <typeparam name="TEntity"></typeparam>
public abstract record UpdateParams<TParams, TEntity> where TParams : class where TEntity : Entity
{
    /// <summary>
    /// Mapster TypeAdapterConfig needed for mapping Params to Entity
    /// </summary>
    public static TypeAdapterConfig MappingConfig
    { 
        get
        {
            TypeAdapterConfig config = new TypeAdapterConfig();
            config.NewConfig<TParams, TEntity>().NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            return config;
        } 
    }
}
