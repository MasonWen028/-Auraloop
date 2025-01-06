using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for performing checks or validations in the Netease Cloud Music API.
    /// </summary>
    public interface ICheckService
    {
        /// <summary>
        /// Checks the availability or validity of a specific music track in the system.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the results of the music check, such as availability or status.</returns>
        Task<ApiResponse> CheckMusic();
    }
}
