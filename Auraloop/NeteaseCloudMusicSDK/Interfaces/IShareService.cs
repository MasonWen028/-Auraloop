using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for sharing resources, such as songs, playlists, or videos, to the user's activity feed in the Netease Cloud Music API.
    /// </summary>
    public interface IShareService
    {
        /// <summary>
        /// Shares a resource, such as a song, playlist, or video, to the user's dynamic feed.
        /// </summary>
        /// <param name="requestModel">The model containing the resource details and optional message.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the sharing operation.</returns>
        Task<ApiResponse> ShareResource(ShareResourceRequestModel requestModel);
    }
}
