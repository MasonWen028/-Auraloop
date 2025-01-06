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
        /// <param name="id">The unique identifier of the artist.</param>
        /// <param name="limit">The maximum number of albums to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's albums.</returns>
        Task<ApiResponse> ArtistAlbum(int id, int limit = 50, int offset = 0);

        /// <summary>
        /// Retrieves basic information about an artist.
        /// </summary>
        /// <param name="id">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing artist information.</returns>
        Task<ApiResponse> Artist(string id);

        /// <summary>
        /// Retrieves the description of an artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's description.</returns>
        Task<ApiResponse> ArtistDesc();

        /// <summary>
        /// Retrieves detailed information about an artist.
        /// </summary>
        /// <param name="id">The unique identifier of the artist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing detailed artist information.</returns>
        Task<ApiResponse> ArtistDetail(string id);

        /// <summary>
        /// Retrieves dynamic details about an artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> with dynamic details about the artist.</returns>
        Task<ApiResponse> ArtistDetailDynamic();

        /// <summary>
        /// Retrieves the fan count of an artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the fan count of the artist.</returns>
        Task<ApiResponse> ArtistFans();

        /// <summary>
        /// Retrieves the follow count of an artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the follow count of the artist.</returns>
        Task<ApiResponse> ArtistFollowCount();

        /// <summary>
        /// Retrieves a list of artists based on the specified request model.
        /// </summary>
        /// <param name="requestModel">The model containing request parameters for the artist list.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of artists.</returns>
        Task<ApiResponse> ArtistList(ArtistListRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of music videos (MVs) by an artist.
        /// </summary>
        /// <param name="id">The unique identifier of the artist.</param>
        /// <param name="limit">The maximum number of MVs to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's MVs.</returns>
        Task<ApiResponse> ArtistMv(long id, int limit = 50, int offset = 0);

        /// <summary>
        /// Retrieves a list of new MVs by artists.
        /// </summary>
        /// <param name="limit">The maximum number of MVs to retrieve. Default is 50.</param>
        /// <param name="before">A timestamp to retrieve MVs released before this time.</param>
        /// <returns>An <see cref="ApiResponse"/> containing new MVs.</returns>
        Task<ApiResponse> ArtistNewMv(int limit = 50, long before = 0);

        /// <summary>
        /// Retrieves a list of new songs by an artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's new songs.</returns>
        Task<ApiResponse> ArtistNewSong();

        /// <summary>
        /// Retrieves a list of songs by an artist with sorting and pagination options.
        /// </summary>
        /// <param name="id">The unique identifier of the artist.</param>
        /// <param name="limit">The maximum number of songs to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <param name="order">The sorting order for the songs (e.g., "hot"). Default is "hot".</param>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's songs.</returns>
        Task<ApiResponse> ArtistSongs(string id, int limit = 50, int offset = 0, string order = "hot");

        /// <summary>
        /// Subscribes or unsubscribes to an artist.
        /// </summary>
        /// <param name="id">The unique identifier of the artist.</param>
        /// <param name="like">Indicates whether to subscribe (true) or unsubscribe (false).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the action.</returns>
        Task<ApiResponse> ArtistSub(long id, bool like);

        /// <summary>
        /// Retrieves a list of subscribed artists with pagination options.
        /// </summary>
        /// <param name="limit">The maximum number of artists to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of subscribed artists.</returns>
        Task<ApiResponse> ArtistSublist(int limit = 50, int offset = 0);

        /// <summary>
        /// Subscribes or unsubscribes to an artist using a specific action type.
        /// </summary>
        /// <param name="id">The unique identifier of the artist.</param>
        /// <param name="t">Action type (1 for subscribe, 0 for unsubscribe).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the action.</returns>
        Task<ApiResponse> ArtistSub(string id, int t);

        /// <summary>
        /// Retrieves the top songs of an artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's top songs.</returns>
        Task<ApiResponse> ArtistTopSong();

        /// <summary>
        /// Retrieves videos associated with an artist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the artist's videos.</returns>
        Task<ApiResponse> ArtistVideo();

        /// <summary>
        /// Retrieves information about multiple artists by their IDs.
        /// </summary>
        /// <param name="id">A comma-separated list of artist IDs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing information about the specified artists.</returns>
        Task<ApiResponse> Artists(string id);
    }
}
