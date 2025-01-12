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
    public class RecordService : IRecordService
    {
        private readonly NetEaseApiClient _client;

        public RecordService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch the play record of albums
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> RecentAlbum(int limit)
        {
            try
            {
                var option = new RequestOptions("/api/play-record/album/list", new { limit }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the play record of albums", ex);
            }
        }

        public Task<ApiResponse> RecentListenList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch the play record of playlist
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> RecentPlaylist(int limit)
        {
            try
            {
                var option = new RequestOptions("/api/play-record/playlist/list", new { limit }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the play record of playlist", ex);
            }
        }

        /// <summary>
        /// Fetch the play record of radios
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> RecentRadio(int limit)
        {
            try
            {
                var option = new RequestOptions("/api/play-record/djradio/list", new { limit }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the play record of radios", ex);
            }
        }

        /// <summary>
        /// Fetch the play record of songs
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> RecentSong(int limit)
        {
            try
            {
                var option = new RequestOptions("/api/play-record/song/list", new { limit }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the play record of songs", ex);
            }
        }

        /// <summary>
        /// Fetch the play record of videos
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> RecentVideo(int limit)
        {
            try
            {
                var option = new RequestOptions("/api/play-record/video/list", new { limit }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the play record of videos", ex);
            }
        }


        /// <summary>
        /// Fetch the play record of voices
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> RecentVoice(int limit)
        {
            try
            {
                var option = new RequestOptions("/api/play-record/voice/list", new { limit }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the play record of voices", ex);
            }
        }
    }
}
