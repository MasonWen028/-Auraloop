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
    public class ProgramService : IProgramService
    {
        private readonly NetEaseApiClient _client;

        public ProgramService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch recommended programs
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<ApiResponse> Recommend(ProgramRecommendRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/program/recommend/v1", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch recommended programs by cate ID: {requestModel.CategoryId}", ex);
            }
        }
    }
}
