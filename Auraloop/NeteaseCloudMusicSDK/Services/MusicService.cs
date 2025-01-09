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
    public class MusicService : IMusicService
    {
        private readonly NetEaseApiClient _client;

        public MusicService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch the process of song listened last time
        /// </summary>
        /// <param name="SongId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> StartMusicListening(long  songId)
        {
            try
            {
                var options = new RequestOptions($"/api/content/activity/music/first/listen/info", new { songId = songId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get process of song with ID: {songId}.", ex);
            }
        }
    }
}
