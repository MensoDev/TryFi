using System.Linq.Expressions;

namespace TryFi.Kernel.Domain.DomainObjects
{
    public class Paging<T>
    {
        public Paging(int page, int itemsPerPage)
        {
            Page = page;
            if (Page < 1) Page = 1;

            ItemsPerPage = itemsPerPage;
            if (ItemsPerPage < 5) ItemsPerPage = 5;

            Type = PagingType.Page;
        }

        public Paging(int page, int itemsPerPage, Expression<Func<T, bool>> query)
            : this(page, itemsPerPage)
        {
            Query = query;
            Type = PagingType.PageQuery;
        }

        public PagingType Type { get; private set; }

        public int Page { get; private set; }
        public int ItemsPerPage { get; private set; }

        public Expression<Func<T, bool>> Query { get; private set; }

        public enum PagingType
        {
            Page = 0,
            PageQuery
        }

    }
}
