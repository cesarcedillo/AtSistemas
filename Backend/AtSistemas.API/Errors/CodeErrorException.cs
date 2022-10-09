using System.Net;

namespace AtSistemas.API.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }

        public CodeErrorException(HttpStatusCode statusCode, 
                                    string? errorMessage = null,
                                    string? details = null) : base(statusCode, errorMessage)
        {
            Details = details;
        }
    }
}
