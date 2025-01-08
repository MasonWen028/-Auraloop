using NeteaseCloudMusicSDK.ApiClient;

namespace NexteaseCloudMusicSDK.WebApi.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly RequestContext _context;

        public AuthMiddleware(RequestDelegate next, RequestContext context)
        {
            _next = next;
            _context = context;
        }

        //Process the cookie
        public async Task Invoke(HttpContext context)
        {
            //GET the cookie string from front end or other place

            _context.Cookie = "";
            await _next(context);
        }
    }
}
