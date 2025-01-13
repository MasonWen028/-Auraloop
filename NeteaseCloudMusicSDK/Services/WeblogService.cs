using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class WeblogService : IWeblogService
    {
        private readonly NetEaseApiClient _client;

        public WeblogService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch the web log
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Weblog(object data)
        {
            try
            {
                var option = new RequestOptions("/api/feedback/weblog", null, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch web log", ex);
            }
        }
    }
}
