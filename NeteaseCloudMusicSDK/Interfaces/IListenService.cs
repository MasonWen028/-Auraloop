using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for tracking and reporting listening footprints in the Netease Cloud Music API.
    /// </summary>
    public interface IListenService
    {
        /// <summary>
        /// Reports real-time listening data.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for the real-time report.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the real-time report submission.</returns>
        Task<ApiResponse> RealtimeReport(ListenDataRealtimeReportRequestModel requestModel);

        /// <summary>
        /// Submits listening data for a specific period or event.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the data submission.</returns>
        Task<ApiResponse> Report(ListenDataReportRequestModel requestModel);

        /// <summary>
        /// Retrieves the songs listened to by the user today.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of songs listened to today.</returns>
        Task<ApiResponse> TodaySongs();

        /// <summary>
        /// Retrieves the total listening data for the user, including song count and duration.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the total listening data.</returns>
        Task<ApiResponse> Total();

        /// <summary>
        /// Retrieves an annual report summarizing the user's listening habits over the year.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the annual listening report.</returns>
        Task<ApiResponse> YearReport();
    }
}
