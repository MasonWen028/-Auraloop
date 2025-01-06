using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing music videos (MVs) in the Netease Cloud Music API.
    /// </summary>
    public interface IMvService
    {
        /// <summary>
        /// Retrieves a list of all MVs with filtering and pagination options.
        /// </summary>
        /// <param name="area">The region or area for filtering MVs. Default is "all".</param>
        /// <param name="type">The type or genre of MVs. Default is "all".</param>
        /// <param name="order">The order in which to sort MVs. Default is "latest".</param>
        /// <param name="limit">The maximum number of results to retrieve. Default is 30.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of MVs.</returns>
        Task<ApiResponse> MvAll(string area = "all", string type = "all", string order = "latest", int limit = 30, int offset = 0);

        /// <summary>
        /// Retrieves detailed information about a specific MV.
        /// </summary>
        /// <param name="mvid">The unique identifier of the MV.</param>
        /// <returns>An <see cref="ApiResponse"/> containing detailed information about the MV.</returns>
        Task<ApiResponse> MvDetail(long mvid);

        /// <summary>
        /// Retrieves additional information, such as likes and shares, for a specific MV.
        /// </summary>
        /// <param name="mvid">The unique identifier of the MV.</param>
        /// <returns>An <see cref="ApiResponse"/> containing additional MV details.</returns>
        Task<ApiResponse> MvDetailInfo(long mvid);

        /// <summary>
        /// Retrieves exclusive and recommended MVs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing exclusive and recommended MVs.</returns>
        Task<ApiResponse> MvExclusiveRcmd();

        /// <summary>
        /// Retrieves the latest MVs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the latest MVs.</returns>
        Task<ApiResponse> MvFirst();

        /// <summary>
        /// Subscribes or unsubscribes to a specific MV.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> MvSub();

        /// <summary>
        /// Retrieves a list of subscribed MVs with pagination options.
        /// </summary>
        /// <param name="limit">The maximum number of results to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of subscribed MVs.</returns>
        Task<ApiResponse> MvSublist(int limit = 50, int offset = 0);

        /// <summary>
        /// Retrieves the playback URL for a specific MV.
        /// </summary>
        /// <param name="id">The unique identifier of the MV.</param>
        /// <param name="r">The desired resolution of the MV (e.g., 1080 for 1080p). Default is 1080.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the MV playback URL.</returns>
        Task<ApiResponse> MvUrl(long id, int r = 1080);
    }
}
