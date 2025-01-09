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
    public class HomepageService : IHomepageService
    {
        private readonly NetEaseApiClient _client;

        public HomepageService(NetEaseApiClient client)
        {
            _client = client;            
        }

        /// <inberitdoc/>
        public async Task<ApiResponse> GetBlockPage(HomepageBlockPageRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/homepage/block/page", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get blocked pages.", ex);
            }
        }

        /// <inberitdoc/>
        public async Task<ApiResponse> GetDragonBall()
        {
            try
            {
                var options = new RequestOptions($"/api/homepage/dragon/ball/static");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get blocked pages.", ex);
            }
        }
    }
}
