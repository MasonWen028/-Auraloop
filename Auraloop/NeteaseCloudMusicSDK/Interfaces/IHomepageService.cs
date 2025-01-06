using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving homepage-related content in the Netease Cloud Music API.
    /// </summary>
    public interface IHomepageService
    {
        /// <summary>
        /// Retrieves the main content blocks displayed on the homepage.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the content blocks for the homepage.</returns>
        Task<ApiResponse> HomepageBlockPage();

        /// <summary>
        /// Retrieves the "Dragon Ball" feature content from the homepage.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the "Dragon Ball" feature information.</returns>
        Task<ApiResponse> HomepageDragonBall();
    }
}
