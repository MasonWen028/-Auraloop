using System;
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
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the real-time report submission.</returns>
        Task<ApiResponse> ListenDataRealtimeReport();

        /// <summary>
        /// Submits listening data for a specific period or event.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the data submission.</returns>
        Task<ApiResponse> ListenDataReport();

        /// <summary>
        /// Retrieves the songs listened to by the user today.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of songs listened to today.</returns>
        Task<ApiResponse> ListenDataTodaySong();

        /// <summary>
        /// Retrieves the total listening data for the user, including song count and duration.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the total listening data.</returns>
        Task<ApiResponse> ListenDataTotal();

        /// <summary>
        /// Retrieves an annual report summarizing the user's listening habits over the year.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the annual listening report.</returns>
        Task<ApiResponse> ListenDataYearReport();
    }
}
