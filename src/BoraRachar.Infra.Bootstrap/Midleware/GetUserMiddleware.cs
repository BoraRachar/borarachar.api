using Microsoft.AspNetCore.Http;

namespace BoraRachar.Infra.Bootstrap.Midleware;

public class GetUserMiddleware
{
    private readonly RequestDelegate _next;

    public GetUserMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Authorization header missing.");
            return;
        }
        
        var req = context.Request.Headers["Authorization"].ToString();

        var hasToken = req.StartsWith("Bearer ");
        
        Console.WriteLine("Requisiao com token: ", hasToken);
        
        await _next(context);
    }
}