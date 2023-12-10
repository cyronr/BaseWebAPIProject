using Domain.Models.BaseModels;
using Mapster;

namespace Domain.ModelsUpdateParams;

public abstract record UpdateParams<TParams, TEntity> where TParams : class where TEntity : Entity
{
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
