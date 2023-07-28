using System;

namespace Talabat.APIs1.Errors
{
    public class ApiErrorResponse
    {

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public ApiErrorResponse( int StatusCode , string message = null)
        {
            this.Message = message  ?? GetDefaultMessageForStatusCode(StatusCode);

            this.StatusCode = StatusCode ;

        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request , you have made ",
                401 => "Authorized, you are not ",
                404 => "Resorce Not found",
                500 => "Error are path in the dark side "  
            };


        }
    }
}
