using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing social dynamics (events or activities) in the Netease Cloud Music API.
    /// </summary>
    public interface ISocialDynamicsService
    {
        /// <summary>
        /// Retrieves a list of social dynamics or activities.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of social dynamics and related details.</returns>
        Task<ApiResponse> GetDynamics();

        /// <summary>
        /// Deletes a specific social dynamic created by the user.
        /// </summary>
        /// <param name="requestModel">The model containing the details of the dynamic to delete.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the deletion operation.</returns>
        Task<ApiResponse> DeleteDynamic(DeleteDynamicRequestModel requestModel);

        /// <summary>
        /// Forwards or shares a specific social dynamic to other users.
        /// </summary>
        /// <param name="requestModel">The model containing the details of the dynamic to forward.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the forward operation.</returns>
        Task<ApiResponse> ForwardDynamic(ForwardDynamicRequestModel requestModel);
    }
}
