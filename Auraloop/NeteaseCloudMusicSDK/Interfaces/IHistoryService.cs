using System;
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
        Task<ApiResponse> HistoryRecommendSongs();

        /// <summary>
        /// Retrieves detailed information about historically recommended songs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing detailed information about the recommended songs.</returns>
        Task<ApiResponse> HistoryRecommendSongsDetail();
    }
}
