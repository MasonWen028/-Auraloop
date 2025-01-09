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
    public class LyricService : ILyricService
    {
        private readonly NetEaseApiClient _client;

        public LyricService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch lyric for song v1
        /// </summary>
        /// <param name="songId">song id</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> GetAdvancedLyrics(long songId)
        {
            try
            {
                LyricNewRequestModel requestModel = new LyricNewRequestModel { SongId = songId };
                var options = new RequestOptions($"/api/song/lyric/v1", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get lyric for {songId}.", ex);
            }
        }

        /// <summary>
        /// Fetch lyric for song
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> GetLyrics(long songId)
        {
            try
            {
                LyricRequestModel requestModel = new LyricRequestModel { SongId = songId };
                var options = new RequestOptions($"/api/song/lyric", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get lyric for {songId}.", ex);
            }
        }
    }
}
