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
    public class ThresholdService : IThresholdService
    {
        private readonly NetEaseApiClient _client;

        public ThresholdService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch threshold details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ThresholdDetailGet()
        {
            try
            {
                var option = new RequestOptions("/api/influencer/web/apply/threshold/detail/get");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch threshold details", ex);
            }
        }
    }
}
