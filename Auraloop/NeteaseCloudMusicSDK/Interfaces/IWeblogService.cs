using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{

    /// <summary>
    /// Defines methods for fetching web log and related data in the Netease Cloud Music API.
    /// </summary>
    public interface IWeblogService
    {
        /// <summary>
        /// Logs user actions or feedback to the platform.
        /// </summary>
        /// <param name="data">The data associated with the user action or feedback.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the logging operation.</returns>
        Task<ApiResponse> Weblog(object data);
    }
}