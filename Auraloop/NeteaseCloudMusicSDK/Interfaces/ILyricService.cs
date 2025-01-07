using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving lyrics in the Netease Cloud Music API.
    /// </summary>
    public interface ILyricService
    {
        /// <summary>
        /// Retrieves the lyrics for a currently playing or default song.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching lyrics.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the lyrics for the song.</returns>
        Task<ApiResponse> GetLyrics(LyricRequestModel requestModel);

        /// <summary>
        /// Retrieves the lyrics for a specific song by its unique identifier, including advanced lyric versions.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching advanced lyrics.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the lyrics for the specified song.</returns>
        Task<ApiResponse> GetAdvancedLyrics(LyricNewRequestModel requestModel);
    }
}
