using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods to interact with album-related functionalities in the Netease Cloud Music API.
    /// </summary>
    public interface IAlbumService
    {
        /// <summary>
        /// Retrieves album information by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the album.</param>
        /// <returns>An <see cref="ApiResponse"/> containing album details.</returns>
        Task<ApiResponse> Album(string id);

        /// <summary>
        /// Retrieves detailed information about an album by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the album.</param>
        /// <returns>An <see cref="ApiResponse"/> containing detailed album information.</returns>
        Task<ApiResponse> AlbumDetail(string id);

        /// <summary>
        /// Retrieves dynamic details about an album by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the album.</param>
        /// <returns>An <see cref="ApiResponse"/> with dynamic details about the album.</returns>
        Task<ApiResponse> AlbumDetailDynamic(string id);

        /// <summary>
        /// Retrieves a list of albums with filtering and pagination options.
        /// </summary>
        /// <param name="limit">The maximum number of albums to retrieve.</param>
        /// <param name="offset">The offset for pagination.</param>
        /// <param name="total">Indicates whether to include total count.</param>
        /// <param name="area">The area or region of the albums.</param>
        /// <param name="type">The type or genre of the albums.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the album list.</returns>
        Task<ApiResponse> AlbumList(int limit, int offset, bool total, string area, int type);

        /// <summary>
        /// Retrieves a list of albums by style with pagination options.
        /// </summary>
        /// <param name="limit">The maximum number of albums to retrieve.</param>
        /// <param name="offset">The offset for pagination.</param>
        /// <param name="total">Indicates whether to include total count.</param>
        /// <param name="area">The area or region of the albums.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the album list by style.</returns>
        Task<ApiResponse> AlbumListStyle(int limit, int offset, bool total, string area);

        /// <summary>
        /// Retrieves newly released albums with pagination options.
        /// </summary>
        /// <param name="limit">The maximum number of albums to retrieve.</param>
        /// <param name="offset">The offset for pagination.</param>
        /// <param name="total">Indicates whether to include total count.</param>
        /// <param name="area">The area or region of the albums.</param>
        /// <returns>An <see cref="ApiResponse"/> containing newly released albums.</returns>
        Task<ApiResponse> AlbumNew(int limit, int offset, bool total, string area);

        /// <summary>
        /// Retrieves the newest albums without pagination.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the newest albums.</returns>
        Task<ApiResponse> AlbumNewest();

        /// <summary>
        /// Retrieves privilege information for a specific album by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the album.</param>
        /// <returns>An <see cref="ApiResponse"/> containing privilege details of the album.</returns>
        Task<ApiResponse> AlbumPrivilege(string id);

        /// <summary>
        /// Retrieves sales information for album songs based on album type, sales type, and year.
        /// </summary>
        /// <param name="albumType">The type of the album (e.g., digital, physical).</param>
        /// <param name="type">The sales type or category.</param>
        /// <param name="year">The year for which sales data is required.</param>
        /// <returns>An <see cref="ApiResponse"/> containing sales information for album songs.</returns>
        Task<ApiResponse> AlbumSongsaleboard(int albumType, string type, string year);

        /// <summary>
        /// Subscribes or unsubscribes to an album.
        /// </summary>
        /// <param name="t">Action type (1 for subscribe, 0 for unsubscribe).</param>
        /// <param name="id">The unique identifier of the album.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the action.</returns>
        Task<ApiResponse> AlbumSub(int t, string id);

        /// <summary>
        /// Retrieves a list of subscribed albums with pagination options.
        /// </summary>
        /// <param name="limit">The maximum number of albums to retrieve.</param>
        /// <param name="offset">The offset for pagination.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of subscribed albums.</returns>
        Task<ApiResponse> AlbumSublist(int limit, int offset);
    }
}
