using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for accessing historical recommendations and related details in the Netease Cloud Music API.
    /// </summary>
    public interface IHistoryService
    {
        /// <summary>
        /// Retrieves a list of historically recommended songs for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of recommended songs.</returns>
        Task<ApiResponse> GetRecommendedSongs();

        /// <summary>
        /// Retrieves detailed information about historically recommended songs for a specific date.
        /// </summary>
        /// <param name="requestModel">The model containing the date for fetching detailed song recommendations.</param>
        /// <returns>An <see cref="ApiResponse"/> containing detailed information about the recommended songs.</returns>
        Task<ApiResponse> GetRecommendedSongsDetail(HistoryRecommendSongsDetailRequestModel requestModel);
    }
}
