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
    public class SendService : ISendService
    {
        private readonly NetEaseApiClient _client;

        public SendService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Send Album to another one
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Album(SendAlbumRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/msg/private/send", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send album with id: {requestModel.AlbumId} to user with Id: {requestModel.UserIds}", ex);
            }
        }

        /// <summary>
        /// Send playlist to another user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Playlist(SendPlaylistRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/msg/private/send", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send plalist with id: {requestModel.PlaylistId} to user with Id: {requestModel.UserIds}", ex);
            }
        }

        /// <summary>
        /// Send song to another user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Song(SendSongRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/msg/private/send", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send song with id: {requestModel.SongId} to user with Id: {requestModel.UserIds}", ex);
            }
        }

        /// <summary>
        /// Send text message to another user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Text(SendTextRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/msg/private/send", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send text {requestModel.Message} to user with Id: {requestModel.UserIds}", ex);
            }
        }
    }
}
