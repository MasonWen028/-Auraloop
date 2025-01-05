using NeteaseCloudMusicSDK.Models.Response;
using NeteaseCloudMusicSDK.RequestClient.Models;
using NeteaseCloudMusicSDK.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class NetEaseApiClient
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="NetEaseApiClient"/> class with customized settings.
    /// </summary>
    public NetEaseApiClient()
    {
        var handler = new HttpClientHandler
        {
            AllowAutoRedirect = true,
            MaxConnectionsPerServer = 10
        };

        _client = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(100)
        };
    }

    public static async Task<ApiResponse> HandleRequestAsync<TRequestModel>(TRequestModel requestModel, string apiEndpoint, string optionType)
    {
        
    }

    /// <summary>
    /// Sends an HTTP request to the NetEase API based on the provided settings and cookies.
    /// </summary>
    /// <param name="settings">The request settings including method, URL, headers, and body.</param>
    /// <param name="cookieDic">A dictionary of cookies to include in the request.</param>
    /// <returns>The HTTP response received from the server.</returns>
    private async Task<HttpResponseMessage> SendRequestAsync(RequestSetting settings, Dictionary<string, string> cookieDic)
    {
        // Create and configure the request
        var request = new HttpRequestMessage
        {
            Method = new HttpMethod(settings.Method),
            RequestUri = new Uri(settings.Url)
        };

        // Add headers
        if (settings.Headers != null)
        {
            foreach (var header in settings.Headers)
            {
                if (request.Headers.Contains(header.Key))
                {
                    request.Headers.Remove(header.Key);
                }
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        // Add cookies as a header
        if (cookieDic?.Any() == true)
        {
            request.Headers.TryAddWithoutValidation("Cookie", DicStrUtil.DictionaryToString(cookieDic));
        }

        // Add body data if present
        if (!string.IsNullOrEmpty(settings.Data))
        {
            request.Content = new StringContent(settings.Data, Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        // Send the request and ensure success
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return response;
    }
}
