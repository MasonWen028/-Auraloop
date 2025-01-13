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
    public class PlService : IPlService
    {
        private readonly NetEaseApiClient _client;

        public PlService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch private message and notices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Count()
        {
            try
            {
                var options = new RequestOptions($"/api/pl/count", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch private message and notices", ex);
            }
        }
    }
}
