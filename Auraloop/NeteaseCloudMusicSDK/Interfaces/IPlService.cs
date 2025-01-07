using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing private messages and notifications in the Netease Cloud Music API.
    /// </summary>
    public interface IPlService
    {
        /// <summary>
        /// Retrieves the count of private messages and notifications for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the count of private messages and notifications.</returns>
        Task<ApiResponse> Count();
    }
}
