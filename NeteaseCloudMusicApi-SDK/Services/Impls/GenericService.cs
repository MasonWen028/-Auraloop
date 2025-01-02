using NeteaseCloudMusicApi_SDK.Helpers.RequestClient;
using NeteaseCloudMusicApi_SDK.Models.Dtos;

public class GenericService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly RequestProvider _requestProvider;

    public GenericService(IHttpContextAccessor httpContextAccessor, RequestProvider requestProvider)
    {
        _httpContextAccessor = httpContextAccessor;
        _requestProvider = requestProvider;
    }

    public async Task<ApiResponse> HandleRequestAsync(ApiModel apiModel)
    {
        if (apiModel == null)
        {
            throw new ArgumentNullException(nameof(apiModel), "The ApiModel cannot be null.");
        }

        // Get cookies as string
        var cookies = _httpContextAccessor.GetCookiesAsString();

        // Build query dictionary
        var queryDic = new Dictionary<string, string>
        {
            ["cookie"] = cookies
        };

        // Prepare options
        var options = new Options(queryDic, apiModel.OptionType);

        // Send request
        HttpResponseMessage response = await _requestProvider.SendRequestAsync(apiModel.ApiEndpoint, apiModel.Data, options);

        // Extract status code
        var status = (int)response.StatusCode;

        // Extract body
        var content = await response.Content.ReadAsStringAsync();

        // Extract cookies
        response.Headers.TryGetValues("Set-Cookie", out var setCookies);
        var cookieArray = setCookies?.ToArray() ?? Array.Empty<string>();

        // Store cookies in HttpContext.Items
        if (cookieArray.Any())
        {
            _httpContextAccessor.HttpContext.Items["CustomCookies"] = cookieArray;
        }

        return new ApiResponse
        {
            status = status,
            data = content,
            cookie = cookieArray
        };
    }
}
