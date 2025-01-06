using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing messages and notifications in the Netease Cloud Music API.
    /// </summary>
    public interface IMsgService
    {
        /// <summary>
        /// Retrieves comments sent to the user in messages.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing a list of comments received in messages.</returns>
        Task<ApiResponse> MsgComments();

        /// <summary>
        /// Retrieves forwarded content sent to the user in messages.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing a list of forwarded messages.</returns>
        Task<ApiResponse> MsgForwards();

        /// <summary>
        /// Retrieves general notices and notifications for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing notices or announcements.</returns>
        Task<ApiResponse> MsgNotices();

        /// <summary>
        /// Retrieves private messages exchanged with other users.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing private messages.</returns>
        Task<ApiResponse> MsgPrivate();

        /// <summary>
        /// Retrieves the chat history for a specific private conversation.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the private message history.</returns>
        Task<ApiResponse> MsgPrivateHistory();

        /// <summary>
        /// Retrieves the list of recent contacts the user has interacted with.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recent contact information.</returns>
        Task<ApiResponse> MsgRecentcontact();
    }
}
