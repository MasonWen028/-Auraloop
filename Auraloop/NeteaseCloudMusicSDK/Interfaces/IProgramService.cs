using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IProgramService
    {
        /// <summary>
        /// Retrieves a list of recommended programs, such as DJ or radio shows.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recommended programs tailored to the user's preferences.</returns>
        Task<ApiResponse> ProgramRecommend();
    }
}