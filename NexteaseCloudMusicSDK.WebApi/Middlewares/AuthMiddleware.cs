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

            if (context.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                // Convert the header value to a string
                string authorizationValue = authorizationHeader.ToString();

                // Log or process the Authorization header
                Console.WriteLine($"Authorization Header: {authorizationValue}");

                _context.Cookie = authorizationValue;
            }
            else
            {
                Console.WriteLine("Authorization header is missing.");
            }

            await _next(context);
        }
    }
}
