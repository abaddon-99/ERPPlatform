using System.Net;
using ERP.WebAPI.Models;
using Newtonsoft.Json;
using Serilog;

namespace ERP.WebAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "An unhandled exception occurred.");

                // Handle the exception and send a meaningful response to the client
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Customize the error response based on the exception
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred.",
                    Details = ex.Message
                };

                var jsonError = JsonConvert.SerializeObject(errorResponse);
                await context.Response.WriteAsync(jsonError);
            }
        }
    }
}

