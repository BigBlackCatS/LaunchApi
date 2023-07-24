using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LaunchApi.Extensions
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpRequestException httpResponseException)
            {
                switch (httpResponseException?.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        context.Result = new NotFoundObjectResult(context.Exception.Message);
                        break;
                    default:
                        context.Result = new ObjectResult("Internal Server Error.")
                        {
                            StatusCode = 500
                        };
                        break;
                }
            }

            // Prevent other exception filters from being executed.
            context.ExceptionHandled = true;
        }
    }
}
