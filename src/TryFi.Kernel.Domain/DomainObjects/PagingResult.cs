namespace TryFi.Kernel.Domain.DomainObjects
{
    public class PagingResult<T>
    {
        public PagingResult(int page, int totalPages, int totalItems, bool success, string message, IEnumerable<T> value)
        {
            Page = page;
            TotalPages = totalPages;
            TotalItems = totalItems;
            Success = success;
            Message = message;
            Value = value;
        }

        public int Page { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalItems { get; private set; }

        public bool Success { get; private set; }
        public string Message { get; set; }

        public IEnumerable<T> Value { get; private set; }
    }
}
