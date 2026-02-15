using System.Net;
using System.Text.Json;
using API.Error;

namespace API.Middleware;

public class ApiMiddleWare(RequestDelegate next, ILogger<ApiMiddleWare> logger, IHostEnvironment env)
{

   public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";


            var response = env.IsDevelopment() ? new APIError(context.Response.StatusCode, ex.Message, ex.StackTrace)
            : new APIError(context.Response.StatusCode, ex.Message, null);


            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }
}

