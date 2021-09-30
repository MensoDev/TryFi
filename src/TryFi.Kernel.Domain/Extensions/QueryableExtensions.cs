using System.Linq.Expressions;

namespace TryFi.Kernel.Domain.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Pagination<T, TKey>(this IQueryable<T> queryable, int page, int pageSize, Expression<Func<T, TKey>> orderBy)
        {
            return queryable
                .OrderBy(orderBy)
               .Skip((page - 1) * pageSize)
               .Take(pageSize);
        }

        public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, int page, int pageSize)
        {
            return queryable
               .Skip((page - 1) * pageSize)
               .Take(pageSize);
        }
    }
}
