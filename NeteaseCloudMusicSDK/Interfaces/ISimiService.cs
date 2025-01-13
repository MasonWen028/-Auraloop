using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving similar entities, such as artists, MVs, playlists, songs, and users, in the Netease Cloud Music API.
    /// </summary>
    public interface ISimiService
    {
        /// <summary>
        /// Retrieves similar artists to the specified artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing a list of similar artists.</returns>
        Task<ApiResponse> Artist(long artistId);

        /// <summary>
        /// Retrieves similar MVs to the specified MV.
        /// </summary>
        /// <param name="mvId">The unique identifier of the MV.</param>
        /// <returns>An <see cref="ApiResponse"/> containing a list of similar MVs.</returns>
        Task<ApiResponse> Mv(long mvId);

        /// <summary>
        /// Retrieves playlists similar to the playlist containing the specified song.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching similar playlists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing a list of similar playlists.</returns>
        Task<ApiResponse> Playlist(SimiPlaylistRequestModel requestModel);

        /// <summary>
        /// Retrieves songs similar to the specified song.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching similar songs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing a list of similar songs.</returns>
        Task<ApiResponse> Song(SimiSongRequestModel requestModel);

        /// <summary>
        /// Retrieves users with similar music tastes to the specified song.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching similar users.</param>
        /// <returns>An <see cref="ApiResponse"/> containing a list of similar users.</returns>
        Task<ApiResponse> User(SimiUserRequestModel requestModel);
    }
}
