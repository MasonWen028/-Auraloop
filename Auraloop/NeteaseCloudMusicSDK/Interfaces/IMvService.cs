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
        /// <param name="requestModel">The model containing filtering and pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of MVs.</returns>
        Task<ApiResponse> GetAll(MvAllRequestModel requestModel);

        /// <summary>
        /// Retrieves detailed information about a specific MV.
        /// </summary>
        /// <param name="mvid">The unique identifier of the MV.</param>
        /// <returns>An <see cref="ApiResponse"/> containing detailed information about the MV.</returns>
        Task<ApiResponse> Detail(long mvid);

        /// <summary>
        /// Retrieves additional information, such as likes and shares, for a specific MV.
        /// </summary>
        /// <param name="mvid">The unique identifier of the MV.</param>
        /// <returns>An <see cref="ApiResponse"/> containing additional MV details.</returns>
        Task<ApiResponse> DetailInfo(long mvid);

        /// <summary>
        /// Retrieves exclusive and recommended MVs.
        /// </summary>
        /// <param name="limit">The maximum number of results to retrieve. Default is 30.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing exclusive and recommended MVs.</returns>
        Task<ApiResponse> ExclusiveRcmd(int limit = 30, int offset = 0);

        /// <summary>
        /// Retrieves the latest MVs.
        /// </summary>
        /// <param name="requestModel">The model containing filtering and pagination parameters for the latest MVs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the latest MVs.</returns>
        Task<ApiResponse> First(MvFirstRequestModel requestModel);

        /// <summary>
        /// Subscribes or unsubscribes to a specific MV.
        /// </summary>
        /// <param name="requestModel">The model containing the MV ID and subscription operation.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> Subscribe(MvSubscribeRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of subscribed MVs with pagination options.
        /// </summary>
        /// <param name="limit">The maximum number of results to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of subscribed MVs.</returns>
        Task<ApiResponse> Sublist(int limit = 50, int offset = 0);

        /// <summary>
        /// Retrieves the playback URL for a specific MV.
        /// </summary>
        /// <param name="requestModel">The model containing the MV ID and desired resolution.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the MV playback URL.</returns>
        Task<ApiResponse> Url(MvUrlRequestModel requestModel);
    }
}
