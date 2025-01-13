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
        /// <param name="requestModel">The model containing parameters for fetching comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing a list of comments received in messages.</returns>
        Task<ApiResponse> Comments(MsgCommentsRequestModel requestModel);

        /// <summary>
        /// Retrieves forwarded content sent to the user in messages.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching forwarded messages.</param>
        /// <returns>An <see cref="ApiResponse"/> containing a list of forwarded messages.</returns>
        Task<ApiResponse> Forwards(MsgForwardsRequestModel requestModel);

        /// <summary>
        /// Retrieves general notices and notifications for the user.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching notices.</param>
        /// <returns>An <see cref="ApiResponse"/> containing notices or announcements.</returns>
        Task<ApiResponse> Notices(MsgNoticesRequestModel requestModel);

        /// <summary>
        /// Retrieves private messages exchanged with other users.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching private messages.</param>
        /// <returns>An <see cref="ApiResponse"/> containing private messages.</returns>
        Task<ApiResponse> PrivateMessages(MsgPrivateRequestModel requestModel);

        /// <summary>
        /// Retrieves the chat history for a specific private conversation.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching private message history.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the private message history.</returns>
        Task<ApiResponse> PrivateHistory(MsgPrivateHistoryRequestModel requestModel);

        /// <summary>
        /// Retrieves the list of recent contacts the user has interacted with.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recent contact information.</returns>
        Task<ApiResponse> RecentContacts();
    }
}
