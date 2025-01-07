using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods to interact with artist-related functionalities in the Netease Cloud Music API.
    /// </summary>
    public interface IArtistService
    {
        /// <summary>
        /// Retrieves a list of albums by an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <param name="limit">The maximum number of albums to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's albums.</returns>
        Task<ApiResponse> GetAlbumsByArtist(long artistId, int limit = 50, int offset = 0);

        /// <summary>
        /// Retrieves basic information about an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing artist information.</returns>
        Task<ApiResponse> GetArtistInfo(long artistId);

        /// <summary>
        /// Retrieves the description of an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's description.</returns>
        Task<ApiResponse> GetArtistDescription(long artistId);

        /// <summary>
        /// Retrieves detailed information about an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing detailed artist information.</returns>
        Task<ApiResponse> GetArtistDetails(long artistId);

        /// <summary>
        /// Retrieves dynamic details about an artist, such as follower counts and updates.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing dynamic artist details.</returns>
        Task<ApiResponse> GetDynamicArtistDetails(long artistId);

        /// <summary>
        /// Retrieves the fan count for an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the fan count for the artist.</returns>
        Task<ApiResponse> GetArtistFanCount(long artistId);

        /// <summary>
        /// Retrieves the follow count for an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the follow count for the artist.</returns>
        Task<ApiResponse> GetArtistFollowCount(long artistId);

        /// <summary>
        /// Retrieves a list of artists based on specified filters.
        /// </summary>
        /// <param name="requestModel">The model containing filters for the artist list.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of artists.</returns>
        Task<ApiResponse> GetFilteredArtists(ArtistListRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of music videos (MVs) by an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <param name="limit">The maximum number of MVs to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's MVs.</returns>
        Task<ApiResponse> GetArtistMVs(long artistId, int limit = 50, int offset = 0);

        /// <summary>
        /// Retrieves a list of new MVs by artists.
        /// </summary>
        /// <param name="limit">The maximum number of MVs to retrieve. Default is 50.</param>
        /// <param name="beforeTimestamp">A timestamp to retrieve MVs released before this time.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the new MVs.</returns>
        Task<ApiResponse> GetNewMVs(int limit = 50, long beforeTimestamp = 0);

        /// <summary>
        /// Retrieves a list of new songs by an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's new songs.</returns>
        Task<ApiResponse> GetNewSongsByArtist(long artistId);

        /// <summary>
        /// Retrieves a list of songs by an artist with sorting and pagination options.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <param name="limit">The maximum number of songs to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <param name="order">The sorting order for the songs (e.g., "hot"). Default is "hot".</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's songs.</returns>
        Task<ApiResponse> GetSongsByArtist(long artistId, int limit = 50, int offset = 0, string order = "hot");

        /// <summary>
        /// Retrieves the top songs of an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's top songs.</returns>
        Task<ApiResponse> GetTopSongsByArtist(long artistId);

        /// <summary>
        /// Retrieves videos associated with an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's videos.</returns>
        Task<ApiResponse> GetArtistVideos(long artistId);

        /// <summary>
        /// Retrieves information about multiple artists by their IDs.
        /// </summary>
        /// <param name="artistIds">A comma-separated list of artist IDs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing information about the specified artists.</returns>
        Task<ApiResponse> GetArtistsByIds(string artistIds);
    }
}
