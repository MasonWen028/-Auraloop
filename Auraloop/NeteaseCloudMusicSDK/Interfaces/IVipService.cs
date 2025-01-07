using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing VIP features and related information in the Netease Cloud Music API.
    /// </summary>
    public interface IVipService
    {
        /// <summary>
        /// Retrieves the basic VIP growth point information for the current user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the user's VIP growth point details.</returns>
        Task<ApiResponse> GrowthPoint();

        /// <summary>
        /// Retrieves the details of VIP growth point rewards with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for pagination.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the growth point reward details.</returns>
        Task<ApiResponse> GrowthPointDetails(VipGrowthPointDetailsRequestModel requestModel);

        /// <summary>
        /// Retrieves VIP growth points by completing specified tasks.
        /// </summary>
        /// <param name="taskIds">The list of task IDs for which to claim rewards.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the claim operation.</returns>
        Task<ApiResponse> GrowthPointGet(long[] taskIds);

        /// <summary>
        /// Retrieves the user's VIP information.
        /// </summary>
        /// <param name="userId">The unique identifier of the user. Optional.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's VIP information.</returns>
        Task<ApiResponse> Info(long? userId = null);

        /// <summary>
        /// Retrieves additional VIP information for the user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user. Optional.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the additional VIP information.</returns>
        Task<ApiResponse> InfoV2(long? userId = null);

        /// <summary>
        /// Retrieves the list of VIP tasks available for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of VIP tasks.</returns>
        Task<ApiResponse> Tasks();

        /// <summary>
        /// Retrieves the VIP time machine data for the user within a specified time range.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for the time range.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the VIP time machine data.</returns>
        Task<ApiResponse> TimeMachine(VipTimeMachineRequestModel requestModel);
    }
}
