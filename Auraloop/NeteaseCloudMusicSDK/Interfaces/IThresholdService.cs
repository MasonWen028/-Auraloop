using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving influencer threshold information in the Netease Cloud Music API.
    /// </summary>
    public interface IThresholdService
    {
        /// <summary>
        /// Retrieves the threshold details required for influencers to meet certain criteria.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the influencer threshold details.</returns>
        Task<ApiResponse> ThresholdDetailGet();
    }
}
