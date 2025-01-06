using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing sign-in progress and related features in the Netease Cloud Music API.
    /// </summary>
    public interface ISigninService
    {
        /// <summary>
        /// Retrieves the progress of the user's sign-in activities for a specific module.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for the sign-in progress query.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the sign-in progress details.</returns>
        Task<ApiResponse> SigninProgress(SigninProgressRequestModel requestModel);

        /// <summary>
        /// Retrieves information about the "happy sign-in" feature.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the happy sign-in information.</returns>
        Task<ApiResponse> SignHappyInfo();
    }
}
