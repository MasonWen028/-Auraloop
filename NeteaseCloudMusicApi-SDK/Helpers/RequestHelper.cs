using Microsoft.Extensions.Options;
using NeteaseCloudMusicApi_SDK.Helpers.RequestClient;
using NeteaseCloudMusicApi_SDK.Models.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Options = NeteaseCloudMusicApi_SDK.Helpers.RequestClient.Options;

public static class RequestHelper
{
    public static async Task<ApiResponse> HandleRequestAsync<TRequestModel>(
        IHttpContextAccessor httpContextAccessor,
        RequestProvider requestProvider,
        TRequestModel requestModel,
        string apiEndpoint,
        string optionType)
    {
        // Get cookies as string
        var ck = httpContextAccessor.GetCookiesAsString();

        // Build query dictionary
        var queryDic = new Dictionary<string, string>
        {
            ["cookie"] = ck
        };

        // Prepare options
        Options options = new Options(queryDic, optionType);

        // Send request
        var response = await requestProvider.SendRequestAsync(apiEndpoint, requestModel, options);

        // Extract status code
        var status = (int)response.StatusCode;

        // Extract body
        var content = await response.Content.ReadAsStringAsync();

        // Extract cookies
        response.Headers.TryGetValues("Set-Cookie", out var cookies);
        var cookieArray = cookies?.ToArray() ?? new string[0];

        return new ApiResponse
        {
            status = status,
            data = content,
            cookie = cookieArray
        };
    }
}

//try
//{
//    LoginQrKeyApiModel loginApiModule = new LoginQrKeyApiModel()
//    {
//        Data = new LoginQrKeyRequestModel()
//        {
//            Type = 3
//        }
//    };
//    var result = await _genericService.HandleRequestAsync(
//        loginApiModule.Data,
//        loginApiModule.ApiEndpoint,
//        loginApiModule.OptionType
//    );

//    return Ok(result.data);
//}
//catch (Exception ex)
//{
//    return StatusCode(500, new { Message = ex.Message });
//}
