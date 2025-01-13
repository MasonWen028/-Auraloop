using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing User-Generated Content (UGC) in the Netease Cloud Music API.
    /// </summary>
    public interface IUgcService
    {
        /// <summary>
        /// Retrieves brief encyclopedia information about a specific album.
        /// </summary>
        /// <param name="albumId">The unique identifier of the album.</param>
        /// <returns>An <see cref="ApiResponse"/> containing album information.</returns>
        Task<ApiResponse> AlbumGet(long albumId);

        /// <summary>
        /// Retrieves brief encyclopedia information about a specific artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing artist information.</returns>
        Task<ApiResponse> ArtistGet(long artistId);

        /// <summary>
        /// Searches for artists by keyword.
        /// </summary>
        /// <param name="requestModel">The model containing the search keyword and pagination details.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the search results.</returns>
        Task<ApiResponse> ArtistSearch(UgcArtistSearchRequestModel requestModel);

        /// <summary>
        /// Retrieves user-contributed content details with filtering and sorting options.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for filtering and sorting contributions.</param>
        /// <returns>An <see cref="ApiResponse"/> containing user-contributed content details.</returns>
        Task<ApiResponse> Detail(UgcDetailRequestModel requestModel);

        /// <summary>
        /// Retrieves brief encyclopedia information about a specific MV.
        /// </summary>
        /// <param name="mvId">The unique identifier of the MV.</param>
        /// <returns>An <see cref="ApiResponse"/> containing MV information.</returns>
        Task<ApiResponse> MvGet(long mvId);

        /// <summary>
        /// Retrieves brief encyclopedia information about a specific song.
        /// </summary>
        /// <param name="songId">The unique identifier of the song.</param>
        /// <returns>An <see cref="ApiResponse"/> containing song information.</returns>
        Task<ApiResponse> SongGet(long songId);

        /// <summary>
        /// Retrieves the user's contribution details, including items, points, and cloud coin count.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing user contribution details.</returns>
        Task<ApiResponse> UserDevote();
    }
}
