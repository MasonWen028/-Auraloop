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
    public class PlaymodeService : IPlaymodeService
    {
        private readonly NetEaseApiClient _client;

        public PlaymodeService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Set intelligence play mode
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> IntelligenceList(PlaymodeIntelligenceListRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/playmode/intelligence/list", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to set intelligence play mode.", ex);
            }
        }

        /// <summary>
        /// Set random play mode
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SongVector(PlaymodeSongVectorRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/playmode/song/vector/get", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to set random play mode.", ex);
            }
        }
    }
}
