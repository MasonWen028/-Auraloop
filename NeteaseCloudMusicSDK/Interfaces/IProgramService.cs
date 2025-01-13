using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IProgramService
    {
        /// <summary>
        /// Retrieves a list of recommended programs, such as DJ or radio shows, with filtering and pagination options.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching recommended programs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing recommended programs tailored to the user's preferences.</returns>
        Task<ApiResponse> Recommend(ProgramRecommendRequestModel requestModel);
    }
}