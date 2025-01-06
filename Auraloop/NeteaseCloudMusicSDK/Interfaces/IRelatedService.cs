using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving related content, such as videos and playlists, in the Netease Cloud Music API.
    /// </summary>
    public interface IRelatedService
    {
        /// <summary>
        /// Retrieves a list of videos related to a specific context, such as a song or artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing related videos.</returns>
        Task<ApiResponse> RelatedAllVideo();

        /// <summary>
        /// Retrieves playlists related to a specific context, such as a song or artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing related playlists.</returns>
        Task<ApiResponse> RelatedPlaylist();
    }
}
