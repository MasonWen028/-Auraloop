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
        /// <returns>An <see cref="ApiResponse"/> containing the lyrics for the song.</returns>
        Task<ApiResponse> GetLyrics(long songId);

        /// <summary>
        /// Retrieves the lyrics for a specific song by its unique identifier, including advanced lyric versions.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the lyrics for the specified song.</returns>
        Task<ApiResponse> GetAdvancedLyrics(long songId);
    }
}
