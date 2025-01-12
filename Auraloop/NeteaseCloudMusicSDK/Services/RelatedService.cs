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
    public class RelatedService : IRelatedService
    {
        private readonly NetEaseApiClient _client;

        public RelatedService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Fetch all videos related to the one with ID: {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> AllVideo(string id)
        {
            try
            {
                var option = new RequestOptions("/api/cloudvideo/v1/allvideo/rcmd", new { id, type = 0 }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch videos related to current one with ID: {id}", ex);
            }
        }

        /// <summary>
        /// Fetch playlist related to curren one with Id: {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Playlist(string id)
        {
            try
            {
                string url = $"https://music.163.com/playlist?id={id}";

                return await _client.GetAsync(url);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the ralated playlist with ID: {id}", ex);
            }
        }
    }
}
