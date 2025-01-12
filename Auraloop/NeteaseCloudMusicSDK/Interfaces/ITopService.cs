using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving top-ranked content in the Netease Cloud Music API.
    /// </summary>
    public interface ITopService
    {
        /// <summary>
        /// Retrieves a list of newly released albums.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching new albums.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of albums.</returns>
        Task<ApiResponse> Album(TopAlbumRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of top artists.
        /// </summary>
        /// <param name="limit">The maximum number of artists to retrieve. Default is 100.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of top artists.</returns>
        Task<ApiResponse> Artists(int limit = 100, int offset = 0);

        /// <summary>
        /// Retrieves a specific top list by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the top list.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the top list details.</returns>
        Task<ApiResponse> List(long id);

        /// <summary>
        /// Retrieves a list of top MVs.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching top MVs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of MVs.</returns>
        Task<ApiResponse> Mv(TopMvRequestModel requestModel);

        /// <summary>
        /// Retrieves playlists by category and sorting order.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching playlists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the playlists.</returns>
        Task<ApiResponse> Playlist(TopPlaylistRequestModel requestModel);

        /// <summary>
        /// Retrieves high-quality playlists.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching high-quality playlists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the high-quality playlists.</returns>
        Task<ApiResponse> PlaylistHighquality(TopPlaylistHighqualityRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of newly released songs by region.
        /// </summary>
        /// <param name="areaId">The region ID (e.g., 0 for all, 7 for Chinese, 96 for Western).</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of new songs.</returns>
        Task<ApiResponse> Song(int areaId = 0);

        /// <summary>
        /// Retrieves the artist rankings.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the artist rankings.</returns>
        Task<ApiResponse> ArtistRankings();

        /// <summary>
        /// Retrieves a detailed summary of all top lists.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the summary of all top lists.</returns>
        Task<ApiResponse> Detail();
    }
}
