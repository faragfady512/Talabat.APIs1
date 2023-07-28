namespace Talabat.APIs1.Errors
{
    public class ApiExceptionsResponse : ApiErrorResponse
    {
        public string Details { get; set; }
        public ApiExceptionsResponse(int StatusCode, string message = null, string details = null) : base(StatusCode, message)
        {
            Details = details;
        }
    }
}
