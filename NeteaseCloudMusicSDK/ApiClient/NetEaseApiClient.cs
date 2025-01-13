using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using NeteaseCloudMusicSDK.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;


namespace NeteaseCloudMusicSDK.ApiClient
{
    public class NetEaseApiClient
    {
        private readonly HttpClient _client;

        private readonly RequestContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetEaseApiClient"/> class with customized settings.
        /// </summary>
        public NetEaseApiClient(HttpClient client, RequestContext context)
        {
            _client = client;
            _context = context;
        }

        /// <summary>
        /// Handles the preparation and execution of an API request, and processes the response.
        /// </summary>
        /// <typeparam name="RequestOptions">The type of the request model containing the data for the API request.</typeparam>
        /// <returns>
        /// An <see cref="ApiResponse"/> object containing the status, response data, and error details if applicable.
        /// </returns>
        /// <remarks>
        /// This method performs the following steps:
        /// 1. Initializes a <see cref="RequestBuilder"/> instance to prepare the request settings.
        /// 2. Configures an <see cref="HttpRequestMessage"/> based on the prepared settings.
        /// 3. Adds headers, body content, and other request-specific configurations.
        /// 4. Sends the request using the injected <see cref="HttpClient"/>.
        /// 5. Processes the response and returns an <see cref="ApiResponse"/> containing the status code, success flag, data, and error message.
        ///
        /// **Notes**:
        /// - The method ensures headers are added or updated without duplication.
        /// - Body data is serialized as "application/x-www-form-urlencoded" if present.
        /// - Throws an exception if the response status is not successful (`response.EnsureSuccessStatusCode()`).
        ///
        /// **Example Usage**:
        /// <code>
        /// var response = await apiClient.HandleRequestAsync(
        ///     new { 
        ///         requestModel: new { Key = "value" },
        ///         uri: "/api/test",
        ///         crypto: "weapi",
        ///         cookie: "session_id=abc123",
        ///         realIp: "192.168.1.1",
        ///         ua: "CustomUserAgent/1.0"
        ///     }
        /// );
        ///
        /// if (response.IsSuccess)
        /// {
        ///     Console.WriteLine($"Response Data: {response.Data}");
        /// }
        /// else
        /// {
        ///     Console.WriteLine($"Error: {response.ErrorMessage}");
        /// }
        /// </code>
        /// </remarks>
        public async Task<ApiResponse> HandleRequestAsync(RequestOptions option)
        {
            if (!string.IsNullOrEmpty(_context.Cookie))
            {
                option.Cookie = _context.Cookie;
            }
            ApiResponse apiResponse = new ApiResponse();
            RequestBuilder requestBuilder = new RequestBuilder(option);

            var settings = requestBuilder.Setting;

            var request = new HttpRequestMessage
            {
                Method = new HttpMethod(settings.Method),
                RequestUri = new Uri(settings.Url)
            };

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

            if (!string.IsNullOrEmpty(settings.Data))
            {
                request.Content = new StringContent(settings.Data, Encoding.UTF8, "application/x-www-form-urlencoded");
            }

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await ApiResponseProcessor.ProcessApiResponse(response);
        }


        /// <summary>
        /// Post data to remote server
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsync(string url, ByteArrayContent data)
        {
            return await _client.PostAsync(url, data);
        }

        /// <summary>
        /// Fetch data by get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await ApiResponseProcessor.ProcessApiResponse(response);
        }
        //TODO handle response

        /// <summary>
        /// TODO handle response proccess
        /// </summary>
        /// <param name="httpRes"></param>
        /// <returns></returns>
        private string HandleErrorMsg(HttpResponseMessage httpRes)
        {
            return "";
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

}