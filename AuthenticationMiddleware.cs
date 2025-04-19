using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // 检查Session中是否存在Email
        if (string.IsNullOrEmpty(context.Session.GetString("Email")) && !context.Request.Path.StartsWithSegments("/Login"))
        {
            // 未登录，且不是访问登录页面，重定向到登录页面
            context.Response.Redirect("/Login");
            return;
        }

        // 已登录或正在访问登录页面，继续执行下一个中间件
        await _next(context);
    }
}
