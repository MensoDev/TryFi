namespace TryFi.Kernel.Domain.DomainObjects
{
    public record PagingResult<T>
    {
        public PagingResult(int currentPage, int totalItems, int itemsPerPage, IEnumerable<T> value)
        {
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalPages = GetTotalPages(itemsPerPage, totalItems);
            Value = value;
        }

        public int CurrentPage { get; init; }
        public int TotalPages { get; init; }
        public int TotalItems { get; init; }
        public bool HasValue => Value != null && Value.Any();
        public IEnumerable<T> Value { get; init; }

        private static int GetTotalPages(int itemsPerPage, int totalItems)
        {
            return (int)Math.Ceiling((double)totalItems / itemsPerPage);
        }
    }
}
