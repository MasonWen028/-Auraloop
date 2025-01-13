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
    public class SocialDynamicsService: ISocialDynamicsService
    {
        private readonly NetEaseApiClient _client;

        public SocialDynamicsService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> DeleteDynamic(DeleteDynamicRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/event/delete", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get dynamic events for current user.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> ForwardDynamic(ForwardDynamicRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/event/forward", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get dynamic events for current user.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetDynamics(int limit = 20, long lastTime = -1)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/event/get", new { pagesize = limit, lasttime = lastTime }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get dynamic events for current user.", ex);
            }
        }
    }
}
