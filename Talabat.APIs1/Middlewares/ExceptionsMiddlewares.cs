using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Hosting;
using Talabat.APIs1.Errors;
using System.Net;

namespace Talabat.APIs1.Middlewares
{
    public class ExceptionsMiddlewares
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsMiddlewares> _logger;
        private readonly IHostingEnvironment _env;
        public ExceptionsMiddlewares(ILogger<ExceptionsMiddlewares> logger, RequestDelegate next, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var excptionErrorResponse = _env.IsDevelopment() ?
                    new ApiExceptionsResponse(500, ex.StackTrace.ToString())
                       :
                       new ApiExceptionsResponse(500);

                var json = JsonConvert.SerializeObject(excptionErrorResponse);
                await context.Response.WriteAsync(json);
            }

        }

    }

}

