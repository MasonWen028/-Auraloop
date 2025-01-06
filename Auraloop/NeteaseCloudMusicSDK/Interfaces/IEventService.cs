using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing user events and interactions in the Netease Cloud Music API.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Retrieves a list of events or activities.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of events and related details.</returns>
        Task<ApiResponse> Event();

        /// <summary>
        /// Deletes a specific event created by the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the deletion operation.</returns>
        Task<ApiResponse> EventDel();

        /// <summary>
        /// Forwards or shares a specific event to other users.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the forward operation.</returns>
        Task<ApiResponse> EventForward();
    }
}
