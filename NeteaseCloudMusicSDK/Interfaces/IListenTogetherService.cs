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
        /// <param name="requestModel">The model containing the invitation details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> AcceptInvitation(ListenTogetherAcceptRequestModel requestModel);

        /// <summary>
        /// Ends a "Listen Together" session.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room to end.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> EndSession(long roomId);

        /// <summary>
        /// Sends a heartbeat signal to maintain an active "Listen Together" session.
        /// </summary>
        /// <param name="requestModel">The model containing heartbeat details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> SendHeartbeat(ListenTogetherHeartbeatRequestModel requestModel);

        /// <summary>
        /// Sends a play command in a "Listen Together" session.
        /// </summary>
        /// <param name="requestModel">The model containing play command details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> SendPlayCommand(ListenTogetherPlayCommandRequestModel requestModel);

        /// <summary>
        /// Checks the status of a "Listen Together" room.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room to check.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the room's status information.</returns>
        Task<ApiResponse> CheckRoomStatus(long roomId);

        /// <summary>
        /// Creates a new "Listen Together" room.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the room creation.</returns>
        Task<ApiResponse> CreateRoom();

        /// <summary>
        /// Retrieves the status of the current "Listen Together" session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the session's status information.</returns>
        Task<ApiResponse> GetSessionStatus();

        /// <summary>
        /// Synchronizes the list of commands in a "Listen Together" session.
        /// </summary>
        /// <param name="requestModel">The model containing synchronization details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the synchronization.</returns>
        Task<ApiResponse> SyncCommandList(ListenTogetherSyncCommandRequestModel requestModel);

        /// <summary>
        /// Retrieves the synchronized playlist in a "Listen Together" session.
        /// </summary>
        /// <param name="roomId">The unique identifier of the room.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the synchronized playlist.</returns>
        Task<ApiResponse> GetSyncPlaylist(long roomId);
    }
}
