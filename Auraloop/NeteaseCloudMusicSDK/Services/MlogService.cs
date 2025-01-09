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
    public class MlogService : IMlogService
    {
        private readonly NetEaseApiClient _client;

        public MlogService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch videos relate to current song.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> MusicRcmd(MlogMusicRcmdRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/mlog/rcmd/feed/list", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get videos related to current song.", ex);
            }
        }

        /// <summary>
        /// Convert mlog id to video id
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> ToVideo(MlogToVideoRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/mlog/video/convert/id", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to convert mlog id to video id.", ex);
            }
        }

        /// <summary>
        /// Fetch mlog url
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Url(MlogUrlRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/mlog/detail/v1", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch mlog url.", ex);
            }
        }
    }
}
