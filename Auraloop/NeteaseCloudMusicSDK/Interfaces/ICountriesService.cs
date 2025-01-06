using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving country and region codes in the Netease Cloud Music API.
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Retrieves a list of country and region codes supported by the platform.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of country and region codes.</returns>
        Task<ApiResponse> CountriesCodeList();
    }
}
