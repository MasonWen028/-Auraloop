using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods to handle batch processing requests in the Netease Cloud Music API.
    /// </summary>
    public interface IBatchService
    {
        /// <summary>
        /// Processes multiple API requests in a single batch operation.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the results of all the batched operations.</returns>
        Task<ApiResponse> Batch();
    }
}
