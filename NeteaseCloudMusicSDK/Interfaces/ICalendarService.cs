using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods to interact with calendar-related functionalities in the Netease Cloud Music API.
    /// </summary>
    public interface ICalendarService
    {
        /// <summary>
        /// Retrieves calendar events or schedules related to music releases, events, or user activities.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching calendar details.</param>
        /// <returns>An <see cref="ApiResponse"/> containing calendar details, such as events or schedules.</returns>
        Task<ApiResponse> GetCalendarDetails(CalendarRequestModel requestModel);
    }
}
