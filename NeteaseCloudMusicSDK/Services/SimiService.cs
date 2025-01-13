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
    public class SimiService : ISimiService
    {
        private readonly NetEaseApiClient _client;

        public SimiService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch similar artists
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Artist(long artistId)
        {
            try
            {
                var option = new RequestOptions("/api/discovery/simiArtist", new { artistId }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch similar artists by ID: {artistId}", ex);
            }
        }

        /// <summary>
        /// Fetch similar MVs
        /// </summary>
        /// <param name="mvId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Mv(long mvId)
        {
            try
            {
                var option = new RequestOptions("/api/discovery/simiMV", new { mvid = mvId }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch similar MV by ID: {mvId}", ex);
            }
        }

        /// <summary>
        /// Fetch similar playlists
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Playlist(SimiPlaylistRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/discovery/simiPlaylist", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch similar playlist by ID: {requestModel.SongId}", ex);
            }
        }

        /// <summary>
        /// Fetch similar songs
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Song(SimiSongRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/v1/discovery/simiSong", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch similar song by ID: {requestModel.SongId}", ex);
            }
        }

        /// <summary>
        /// Fetch similar users
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> User(SimiUserRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/discovery/simiUser", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch similar users by ID: {requestModel.SongId}", ex);
            }
        }
    }
}
