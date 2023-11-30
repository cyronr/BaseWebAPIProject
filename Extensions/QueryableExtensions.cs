using System.Linq.Expressions;

namespace Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> ApplyFilter<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>>? filter)
    {
        if (filter is not null)
            query = query.Where(filter);

        return query;
    }
}
