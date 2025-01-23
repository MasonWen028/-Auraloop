using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using NeteaseCloudMusicSDK.Models.Response;
using NeteaseCloudMusicSDK.Utils;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.ApiClient
{
    public class ApiResponseProcessor
    {
        private static readonly HashSet<int> SpecialStatusCodes = new HashSet<int> { 201, 302, 400, 502, 800, 801, 802, 803 };


        /// <summary>
        /// Maps the API response code to a standardized status code.
        /// </summary>
        private static int MapStatusCode(int code)
        {
            return SpecialStatusCodes.Contains(code) ? 200 : code;
        }

        /// <summary>
        /// Extract the cookie of response out.
        /// </summary>
        /// <param name="httpRes"></param>
        /// <returns></returns>
        private static string ExtractCookie(HttpResponseMessage httpRes)
        {
            string cookie = string.Empty;

            httpRes.Headers.TryGetValues("Set-Cookie", out var cookieHeaders);

            if (cookieHeaders != null)
            {
                foreach (var cookieHeader in cookieHeaders)
                {
                    cookie += cookieHeader;
                }
            }

            return cookie;
        }

        /// <summary>
        /// Parses the API response body based on encryption status.
        /// </summary>
        private static object ParseResponseBody(string body, bool isEncrypted = false)
        {
            if (isEncrypted)
            {
                return CryptoUtils.EapiResDecrypt(body);
            }

            try
            {
                var parsedObject = body.DeepDeserialize() as Dictionary<string, object>; 
                return parsedObject;
            }
            catch (JsonException)
            {
                throw new InvalidOperationException("Failed to parse response body.");
            }
        }

        /// <summary>
        /// Processes the API response and maps it to an ApiResponse object.
        /// </summary>
        public static async Task<ApiResponse> ProcessApiResponse(HttpResponseMessage httpResponse)
        {
            var response = new ApiResponse { };
            string body = await httpResponse.Content.ReadAsStringAsync();

            try
            {     
                //TODO Decrypt the encrypted response.
                response.Data = ParseResponseBody(body);

                var code = response.Data is JObject jsonObject && jsonObject.TryGetValue("code", out var value)
                    ? value.ToObject<int>()
                    : (int)httpResponse.StatusCode;

                response.StatusCode = MapStatusCode(code);

                response.IsSuccess = true;

                response.Cookie = ExtractCookie(httpResponse);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error processing API response: " + ex.Message);
                response.Data = body;
                response.StatusCode = (int)httpResponse.StatusCode;
                response.ErrorMessage = "Failed to process API response.";
            }

            return response;
        }
    }
}
