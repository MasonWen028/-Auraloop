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
        Task<ApiResponse> GetAgeDistribution();

        /// <summary>
        /// Retrieves the gender distribution of fans.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the gender distribution of fans.</returns>
        Task<ApiResponse> GetGenderDistribution();

        /// <summary>
        /// Retrieves the provincial distribution of fans.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the provincial distribution of fans.</returns>
        Task<ApiResponse> GetProvinceDistribution();

        /// <summary>
        /// Retrieves an overview of fan center statistics, such as total fans and engagement.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the fan center overview statistics.</returns>
        Task<ApiResponse> GetOverview();

        /// <summary>
        /// Retrieves a list of trends related to fan activity.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching fan trends.</param>
        /// <returns>An <see cref="ApiResponse"/> containing fan activity trends.</returns>
        Task<ApiResponse> GetTrendList(FansCenterTrendRequestModel requestModel);
    }
}
