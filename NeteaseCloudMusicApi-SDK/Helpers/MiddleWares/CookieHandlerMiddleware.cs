using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

public class CookieHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CookieHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Proceed to the next middleware in the pipeline
        await _next(context);

        // Check if response has cookies
        if (context.Items.TryGetValue("CustomCookies", out var cookies) && cookies is string[] cookieArray)
        {
            foreach (var cookie in cookieArray)
            {
                // Split cookie into key-value
                var cookieParts = cookie.Split('=', 2);
                if (cookieParts.Length == 2)
                {
                    var key = cookieParts[0];
                    var value = cookieParts[1];

                    context.Response.Cookies.Append(key, value, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });
                }
            }
        }
    }
}
