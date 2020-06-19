using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using API.Errors;
using System.Text.Json;

namespace API.Middleware
{
    // we are creating a middleware to handle all the exception and showing an standard output to the user.
    
    public class ExceptionMiddleWare
    {
        private RequestDelegate _next { set; get; }
        private ILogger<ExceptionMiddleWare> _logger { set; get; }
        private IHostEnvironment _hostEnvironment { set; get; }

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try {
                await _next(context); // if everything is looking fine means no exception then continue the flow of request as it is.
            }
            catch (Exception e)
            {
                // in case of any exception we can set the message here 

                _logger.LogError(e, e.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _hostEnvironment.IsDevelopment() ? new ApiException(500, e.Message, e.StackTrace) : new ApiException(500, e.Message);
                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }; // to show the output as camel case.

                var json = JsonSerializer.Serialize(response,option);
                await context.Response.WriteAsync(json);
            }
        }

    }
}
