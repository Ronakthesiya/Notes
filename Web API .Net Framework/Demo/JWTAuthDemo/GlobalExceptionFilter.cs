
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace JWTAuthDemo
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // Log the exception
            var errorMessage = context.Exception.Message;

            // Customize the response
            context.Response = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new { Message = "Error Catch By GlobalExceptionFilter.", Details = errorMessage }
            );
        }
    }

}