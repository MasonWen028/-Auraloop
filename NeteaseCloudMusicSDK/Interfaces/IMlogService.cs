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
        /// <param name="requestModel">The model containing parameters for music recommendations.</param>
        /// <returns>An <see cref="ApiResponse"/> containing a list of recommended music tracks for Mlog.</returns>
        Task<ApiResponse> MusicRcmd(MlogMusicRcmdRequestModel requestModel);

        /// <summary>
        /// Converts an Mlog post to a video format.
        /// </summary>
        /// <param name="requestModel">The model containing the Mlog ID to convert.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the conversion process.</returns>
        Task<ApiResponse> ToVideo(MlogToVideoRequestModel requestModel);

        /// <summary>
        /// Retrieves the URL of an Mlog post.
        /// </summary>
        /// <param name="requestModel">The model containing parameters to fetch the Mlog URL.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the URL of the Mlog post.</returns>
        Task<ApiResponse> Url(MlogUrlRequestModel requestModel);
    }
}
