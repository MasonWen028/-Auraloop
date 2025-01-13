using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods to interact with banner-related functionalities in the Netease Cloud Music API.
    /// </summary>
    public interface IBannerService
    {
        /// <summary>
        /// Retrieves the current promotional banners displayed on the platform for a specific client type.
        /// </summary>
        /// <param name="clientType">
        /// /// <summary>
        /// PC client.
        /// </summary>
        //PC,
        /// <summary>
        /// Android client.
        /// </summary>
        //Android,
        /// <summary>
        /// iPhone client.
        /// </summary>
        //iPhone,
        /// <summary>
        /// iPad client.
        /// </summary>
        // iPad
        /// </param>
        /// <returns>An <see cref="ApiResponse"/> containing the banner details, including images and associated links.</returns>
        Task<ApiResponse> GetBanners(string clientType = "PC");
    }
}
