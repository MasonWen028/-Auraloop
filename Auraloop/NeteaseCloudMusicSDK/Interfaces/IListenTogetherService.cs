using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing the "Listen Together" feature in the Netease Cloud Music API.
    /// </summary>
    public interface IListenTogetherService
    {
        /// <summary>
        /// Accepts an invitation to join a "Listen Together" session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> ListenTogetherAccept();

        /// <summary>
        /// Ends a "Listen Together" session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> ListenTogetherEnd();

        /// <summary>
        /// Sends a heartbeat signal to maintain an active "Listen Together" session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> ListenTogetherHeartbeat();

        /// <summary>
        /// Sends a play command in a "Listen Together" session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> ListenTogetherPlayCommand();

        /// <summary>
        /// Checks the status of a "Listen Together" room.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the room's status information.</returns>
        Task<ApiResponse> ListenTogetherRoomCheck();

        /// <summary>
        /// Creates a new "Listen Together" room.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the room creation.</returns>
        Task<ApiResponse> ListenTogetherRoomCreate();

        /// <summary>
        /// Retrieves the status of the current "Listen Together" session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the session's status information.</returns>
        Task<ApiResponse> ListenTogetherStatus();

        /// <summary>
        /// Synchronizes the list of commands in a "Listen Together" session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the synchronization.</returns>
        Task<ApiResponse> ListenTogetherSyncListCommand();

        /// <summary>
        /// Retrieves the synchronized playlist in a "Listen Together" session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the synchronized playlist.</returns>
        Task<ApiResponse> ListenTogetherSyncPlaylistGet();
    }
}
