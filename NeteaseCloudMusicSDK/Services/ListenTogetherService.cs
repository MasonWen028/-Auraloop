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
    public class ListenTogetherService : IListenTogetherService
    {
        private readonly NetEaseApiClient _client;

        public ListenTogetherService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AcceptInvitation(ListenTogetherAcceptRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/listen/together/play/invitation/accept", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to accept listen together invitation.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> CheckRoomStatus(long roomId)
        {
            try
            {
                var options = new RequestOptions($"/api/listen/together/room/check", new { roomId = roomId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to check listen together room status.", ex);
            }
        }

        /// <summary>
        /// create listen together room
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> CreateRoom()
        {
            try
            {
                var options = new RequestOptions($"/api/listen/together/room/create", new { refer = "songplay_more" });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create a listen together room.", ex);
            }
        }


        /// <summary>
        /// End listen together room
        /// </summary>
        /// <param name="roomId">the room Id</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> EndSession(long roomId)
        {
            try
            {
                var options = new RequestOptions($"/api/listen/together/end/v2", new { roomId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to end listen together room with ID: {roomId}.", ex);
            }
        }

        /// <summary>
        /// Fetch listen together status of current user.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> GetSessionStatus()
        {
            try
            {
                var options = new RequestOptions($"/api/listen/together/status/get", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to listen together status for current user.", ex);
            }
        }

        /// <summary>
        /// Fetch playlist of current listen together room
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> GetSyncPlaylist(long roomId)
        {
            try
            {
                var options = new RequestOptions($"/api/listen/together/sync/playlist/get", new { roomId }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch current room playlist.", ex);
            }
        }

        /// <summary>
        /// Sent heart beat to current listen together room
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> SendHeartbeat(ListenTogetherHeartbeatRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/listen/together/heartbeat", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch current room playlist.", ex);
            }
        }

        /// <summary>
        /// Send play command to listen together room
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> SendPlayCommand(ListenTogetherPlayCommandRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/listen/together/play/command/report", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send play command to listen together room.", ex);
            }
        }

        //TODO updating playlist
        public Task<ApiResponse> SyncCommandList(ListenTogetherSyncCommandRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
