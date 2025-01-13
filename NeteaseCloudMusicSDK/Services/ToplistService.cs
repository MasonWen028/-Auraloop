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
    public class ToplistService : IToplistService
    {
        private readonly NetEaseApiClient _client;

        public ToplistService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch all toplists
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Toplist()
        {
            try
            {
                var option = new RequestOptions("/api/toplist");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch all toplists", ex);
            }
        }

        /// <summary>
        /// Fetch artists on the toplist
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ToplistArtist(ToplistArtistRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/toplist/artist", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch artists on the toplist", ex);
            }
        }

        /// <summary>
        /// Fetch the brief details of toplist
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ToplistDetail()
        {
            try
            {
                var option = new RequestOptions("/api/toplist/detail", null, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fecth the brief details of toplist", ex);
            }
        }
    }
}
