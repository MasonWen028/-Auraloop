using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing music playback and related features in the Netease Cloud Music API.
    /// </summary>
    public interface IMusicService
    {
        /// <summary>
        /// Retrieves information required to initialize or start the music listening experience for the first time.
        /// </summary>
        /// <param name="SongId">The model containing parameters for starting music playback.</param>
        /// <returns>An <see cref="ApiResponse"/> containing details necessary for starting music playback.</returns>
        Task<ApiResponse> StartMusicListening(long SongId);
    }
}
