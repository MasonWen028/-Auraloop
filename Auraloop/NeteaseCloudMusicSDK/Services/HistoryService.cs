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
    public class HistoryService: IHistoryService
    {
        private readonly NetEaseApiClient _client;

        public HistoryService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetRecommendedSongs()
        {
            try
            {
                var options = new RequestOptions($"/api/discovery/recommend/songs/history/recent", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetRecommendedSongsDetail(HistoryRecommendSongsDetailRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/discovery/recommend/songs/history/detail", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }
    }
}
