using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing Mlog-related features in the Netease Cloud Music API.
    /// </summary>
    public interface IMlogService
    {
        /// <summary>
        /// Recommends music for Mlog posts.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing a list of recommended music tracks for Mlog.</returns>
        Task<ApiResponse> MlogMusicRcmd();

        /// <summary>
        /// Converts an Mlog post to a video format.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the conversion process.</returns>
        Task<ApiResponse> MlogToVideo();

        /// <summary>
        /// Retrieves the URL of an Mlog post.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the URL of the Mlog post.</returns>
        Task<ApiResponse> MlogUrl();
    }
}
