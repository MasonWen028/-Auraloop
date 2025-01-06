using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for accessing and managing fan center data in the Netease Cloud Music API.
    /// </summary>
    public interface IFansCenterService
    {
        /// <summary>
        /// Retrieves the age distribution of fans.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the age distribution of fans.</returns>
        Task<ApiResponse> FansCenterBasicinfoAgeGet();

        /// <summary>
        /// Retrieves the gender distribution of fans.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the gender distribution of fans.</returns>
        Task<ApiResponse> FansCenterBasicinfoGenderGet();

        /// <summary>
        /// Retrieves the provincial distribution of fans.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the provincial distribution of fans.</returns>
        Task<ApiResponse> FansCenterBasicinfoProvinceGet();

        /// <summary>
        /// Retrieves an overview of fan center statistics, such as total fans and engagement.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the fan center overview statistics.</returns>
        Task<ApiResponse> FansCenterOverviewGet();

        /// <summary>
        /// Retrieves a list of trends related to fan activity.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing fan activity trends.</returns>
        Task<ApiResponse> FansCenterTrendList();
    }
}
