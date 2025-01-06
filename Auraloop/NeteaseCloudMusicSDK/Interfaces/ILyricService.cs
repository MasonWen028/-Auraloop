using System;
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
        Task<ApiResponse> Lyric();

        /// <summary>
        /// Retrieves the lyrics for a specific song by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the song.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the lyrics for the specified song.</returns>
        Task<ApiResponse> LyricNew(long id);
    }
}
