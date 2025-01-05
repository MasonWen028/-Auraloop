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

        var ck = _httpContextAccessor.HttpContext.Request.Headers.Authorization;
        if (!string.IsNullOrEmpty(ck))
        {
            cookies = ck;
        }
        //cookies += "MUSIC_U=005F14D98085815617A46F437C40963858A89F21C6298AF32C5C2A19A880D6C6AF932D7E4D81158F2A9622830AE0EFAF0BB2C0D9265C0CD6EB6EA8474DC4C824C0E6EB5D338F4C5AB00478AA679972652185CAE8BEF0F75AB68A658854AEB8A1FAFCB1DDE95D9D19DC815524F401E3530B699E55538131CB4AEF07F5EA2F045BB0AA4DB7133558C97E5EE374FEDF8BBFCF1B84AE0A075C6CCB5D1BF3F89F713C14ED01CD2F95172AF95D40437B8DBB871B76C0A6973D307D503D16E7C8348D9A023F705599BD1817E766EE19E1F8B79085E3E1C82D4C8FE5FF8EA2E11497FCE57A79EBD058827A1118EB2A2F0F742070D6A69217CD3A4B7A9A56E9AF0CBEFA4E1E57DD45F5AA7D43E349FA333ACBC91B81FF224AC6D322F28BD1CDBAB65C3D17770E488BA70E970E35F82F066DFA79635490EA3F89AEC9502342644FD4AA317371E4F679270826D82F631CB71A25E1D57DA33EE897395C6F1724F13514D9928A3E;";
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
        //if (cookieArray.Any())
        //{
        //    _httpContextAccessor.HttpContext.Items["CustomCookies"] = cookieArray;
        //}

        return new ApiResponse
        {
            status = status,
            body = content,
            cookie = cookieArray
        };
    }
}
