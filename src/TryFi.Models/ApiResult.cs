namespace TryFi.Models
{
    public record ApiResult<T> : ApiResult 
    {
        public ApiResult(bool success, T response) : base(success)
        {
            Response = response;
        }
       
        public T Response { get; set; }
    }

    public record ApiResult
    {

        public ApiResult(bool success)
        {
            Success = success;
            Errors ??= new();
        }

        public bool Success { get; set; }
        public List<ApiError> Errors { get; set; }

        public void RegisterError(string title, string description, string type)
        {
            
            Errors.Add(new ApiError(title, description, type));
        }
    }
}
