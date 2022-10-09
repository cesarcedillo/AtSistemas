using AutoMapper.Internal;
using System.Net;

namespace AtSistemas.API.Errors
{
    public class CodeErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public CodeErrorResponse(HttpStatusCode statusCode, string? errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(HttpStatusCode statusCode)
        {
            return statusCode switch
            {
                HttpStatusCode.BadRequest => "The request sending has errors",
                HttpStatusCode.Unauthorized => "Unauthorize for this resource",
                HttpStatusCode.NotFound => "Resource not found",
                HttpStatusCode.InternalServerError => "System Error",
                _ => string.Empty
            };
        }
    }
}
