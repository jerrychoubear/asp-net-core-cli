using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class MyMiddleware
{
    private RequestDelegate _next;

    public MyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync($"{nameof(MyMiddleware)} in. \r\n");

        await _next(context);

        await context.Response.WriteAsync($"{nameof(MyMiddleware)} out. \r\n");
    }
}