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
    public class RecommendService : IRecommendService
    {
        private readonly NetEaseApiClient _client;

        public RecommendService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Fetch daily recommended list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Resource()
        {
            try
            {
                var option = new RequestOptions("/api/v1/discovery/recommend/resource", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the daily recommended list", ex);
            }
        }

        /// <summary>
        /// Fetch the daily recommened song list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Songs()
        {
            try
            {
                var option = new RequestOptions("/api/v3/discovery/recommend/songs", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the daily recommened song list", ex);
            }
        }

        /// <summary>
        /// Dislike the song in daily recommened list
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SongsDislike(RecommendSongsDislikeRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/v3/discovery/recommend/songs", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to dislike song with ID: {requestModel.ResId}", ex);
            }
        }
    }
}
