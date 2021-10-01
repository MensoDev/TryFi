namespace TryFi.Models
{
    public record ApiError
    {
        public ApiError(string title, string message, string type)
        {
            Title = title;
            Message = message;
            Type = type;
        }

        public ApiError()
        {

        }

        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"Title: {Title} | Error: {Message} | Type: {Type}";
        }
    }
}
